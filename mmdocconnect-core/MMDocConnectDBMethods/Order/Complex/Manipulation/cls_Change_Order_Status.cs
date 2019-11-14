/* 
 * Generated on 09/26/15 15:35:33
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using CL1_ORD_PRC;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;

namespace MMDocConnectDBMethods.Order.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Change_Order_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Change_Order_Status
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_OR_COS_0840 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            List<Case_Model> cases = new List<Case_Model>();
            List<PatientDetailViewModel> patientDetailList = new List<PatientDetailViewModel>();
            List<Order_Model> OrderModelL = new List<Order_Model>();
            //Put your code here
            foreach (var ParameterInstance in Parameter.ParameterArray)
            {
                var procurmentHeader = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    ORD_PRC_ProcurementOrder_HeaderID = ParameterInstance.Order_ID
                }).Single();


                var newOrderStatus = new ORM_ORD_PRC_ProcurementOrder_Status();
                newOrderStatus.Tenant_RefID = securityTicket.TenantID;
                newOrderStatus.Status_Code = ParameterInstance.Status_To;
                newOrderStatus.Modification_Timestamp = DateTime.Now;
                newOrderStatus.Save(Connection, Transaction);

                var newOrderStatusHistory = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                newOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
                newOrderStatusHistory.ProcurementOrder_Status_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                newOrderStatusHistory.IsStatus_RejectedBySupplier = true;
                newOrderStatusHistory.ProcurementOrder_Header_RefID = procurmentHeader.ORD_PRC_ProcurementOrder_HeaderID;
                newOrderStatusHistory.Save(Connection, Transaction);

                procurmentHeader.Current_ProcurementOrderStatus_RefID = newOrderStatus.ORD_PRC_ProcurementOrder_StatusID;
                procurmentHeader.Save(Connection, Transaction);

                #region Update Case Elastic
                var caseForUpdate = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = ParameterInstance.CaseID }, securityTicket).Result;
                var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = caseForUpdate.patient_id }, securityTicket).Result;
                var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = caseForUpdate.diagnose_id }, securityTicket).Result;
                var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = caseForUpdate.drug_id }, securityTicket).Result;
                var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = caseForUpdate.op_doctor_id }, securityTicket).Result.SingleOrDefault();
                var case_status = cls_Check_Case_Status.Invoke(Connection, Transaction, new P_CAS_CCS_1639() { CaseID = ParameterInstance.CaseID }, securityTicket).Result;
                if (case_status == null)
                {
                    var case_model_elastic = Get_Cases.GetCaseforCaseID(caseForUpdate.case_id.ToString(), securityTicket);
                    if (case_model_elastic != null)
                    {
                        case_model_elastic.status_drug_order = ParameterInstance.Status_To_Str;
                        case_model_elastic.order_modification_timestamp = caseForUpdate.order_modification_timestamp;
                        case_model_elastic.order_modification_timestamp_string = caseForUpdate.order_modification_timestamp.ToString("dd.MM.yyyy");

                        cases.Add(case_model_elastic);
                    }
                }
                #endregion

                var orderM = Get_Orders.GetOrderforOrderID(procurmentHeader.ORD_PRC_ProcurementOrder_HeaderID.ToString(), securityTicket);
                if (orderM != null)
                {
                    orderM.status_drug_order = ParameterInstance.Status_To_Str;
                    orderM.order_modification_timestamp = DateTime.Now;
                    orderM.order_modification_timestamp_string = DateTime.Now.ToString("dd.MM.yyyy");

                    OrderModelL.Add(orderM);

                    var patientDetalTreatmentWithOrder = Retrieve_Patients.Get_PatientDetaiForIDandOrderID(orderM.id, securityTicket).Where(i => i.detail_type == "op").SingleOrDefault();


                    if (patientDetalTreatmentWithOrder == null)
                    {
                        PatientDetailViewModel patient_detail = new PatientDetailViewModel();
                        patient_detail.case_id = orderM.case_id;
                        patient_detail.date = orderM.treatment_date;
                        patient_detail.date_string = patient_detail.date.ToString("dd.MM.");
                        patient_detail.detail_type = "order";
                        patient_detail.diagnose_or_medication = orderM.drug;
                        patient_detail.practice_id = orderM.practice_id;
                        patient_detail.id = orderM.id;
                        patient_detail.order_id = orderM.id;
                        patient_detail.case_id = orderM.case_id;
                        patient_detail.order_status = orderM.status_drug_order;
                        patient_detail.patient_id = patient_details.id.ToString();
                        patient_detail.drug_id = orderM.drug_id;

                        patientDetailList.Add(patient_detail);
                    }
                    else
                    {
                        patientDetalTreatmentWithOrder.date = orderM.treatment_date;
                        patientDetalTreatmentWithOrder.date_string = patientDetalTreatmentWithOrder.date.ToString("dd.MM.");
                        patientDetalTreatmentWithOrder.case_id = orderM.case_id;
                        patientDetalTreatmentWithOrder.order_id = orderM.id;
                        patientDetalTreatmentWithOrder.practice_id = orderM.practice_id;
                        patientDetalTreatmentWithOrder.drug = orderM.drug;
                        patientDetalTreatmentWithOrder.drug_id = orderM.drug_id;
                        patientDetalTreatmentWithOrder.order_status = orderM.status_drug_order;
                        patientDetalTreatmentWithOrder.patient_id = patient_details.id.ToString();

                        patientDetailList.Add(patientDetalTreatmentWithOrder);
                    }
                }
            }

            if (patientDetailList.Count != 0)
                Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());

            if (OrderModelL.Count != 0)
                Add_New_Order.Import_Order_Data_to_ElasticDB(OrderModelL, securityTicket.TenantID.ToString());

            if (cases.Count != 0)
                Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_OR_COS_0840 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_OR_COS_0840 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_OR_COS_0840 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_OR_COS_0840 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Change_Order_Status", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_OR_COS_0840 for attribute P_OR_COS_0840
    [DataContract]
    public class P_OR_COS_0840
    {
        [DataMember]
        public P_OR_COS_0840a[] ParameterArray { get; set; }

        //Standard type parameters
    }
    #endregion
    #region SClass P_OR_COS_0840a for attribute ParameterArray
    [DataContract]
    public class P_OR_COS_0840a
    {
        //Standard type parameters
        [DataMember]
        public Guid CaseID { get; set; }
        [DataMember]
        public Guid Order_ID { get; set; }
        [DataMember]
        public int Status_To { get; set; }
        [DataMember]
        public String Status_To_Str { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_Order_Status(,P_OR_COS_0840 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_Order_Status.Invoke(connectionString,P_OR_COS_0840 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Order.Complex.Manipulation.P_OR_COS_0840();
parameter.ParameterArray = ...;


*/
