/* 
 * Generated on 01/18/16 09:33:08
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
using CL1_HEC;
using CL1_ORD_PRC;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_USR;
using CL1_HEC_PRC;
using CL1_HEC_CAS;
using CL1_CMN;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDocApp;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Drug_Order.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Drug_Order
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CDO_1202 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CDO_1202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CDO_1202();
            returnValue.Result = new CAS_CDO_1202();
            //Put your code here
            var statusCodePrefix = "MO";
            var statusCode = 0;

            var drugOrderStatus = String.Format("{0}{1}", statusCodePrefix, statusCode);

            var hec_drugQ = new ORM_HEC_Product.Query();
            hec_drugQ.Tenant_RefID = securityTicket.TenantID;
            hec_drugQ.IsDeleted = false;
            hec_drugQ.HEC_ProductID = Parameter.drug_id;

            var hec_drug = ORM_HEC_Product.Query.Search(Connection, Transaction, hec_drugQ).SingleOrDefault();
            if (hec_drug != null)
            {
                var ord_drug_order_header = new ORM_ORD_PRC_ProcurementOrder_Header();
                ord_drug_order_header.CreatedBy_BusinessParticipant_RefID = Parameter.created_by_bpt;
                ord_drug_order_header.ProcurementOrder_Date = DateTime.Now;
                ord_drug_order_header.Tenant_RefID = securityTicket.TenantID;
                ord_drug_order_header.ProcurementOrder_Number = cls_Get_Next_Order_Number.Invoke(Connection, Transaction, securityTicket).Result.order_number;

                returnValue.Result.procurement_order_header_id = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;

                var drug_order_status = new ORM_ORD_PRC_ProcurementOrder_Status();
                drug_order_status.GlobalPropertyMatchingID = String.Format("mm.doc.connect.drug.order.status.{0}", drugOrderStatus.ToLower());
                drug_order_status.Status_Code = statusCode;
                drug_order_status.Tenant_RefID = securityTicket.TenantID;
                drug_order_status.Status_Name = new Dict(ORM_ORD_PRC_ProcurementOrder_Status.TableName);
                foreach (var lang in Parameter.all_languagesL)
                {
                    drug_order_status.Status_Name.AddEntry(lang.CMN_LanguageID, drugOrderStatus);
                }

                drug_order_status.Save(Connection, Transaction);

                ord_drug_order_header.Current_ProcurementOrderStatus_RefID = drug_order_status.ORD_PRC_ProcurementOrder_StatusID;
                ord_drug_order_header.Save(Connection, Transaction);

                var drug_order_status_history = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                drug_order_status_history.ProcurementOrder_Header_RefID = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;
                drug_order_status_history.ProcurementOrder_Status_RefID = drug_order_status.ORD_PRC_ProcurementOrder_StatusID;
                drug_order_status_history.Tenant_RefID = securityTicket.TenantID;
                drug_order_status_history.IsStatus_Created = true;
                drug_order_status_history.TriggeredAt_Date = DateTime.Now;
                drug_order_status_history.TriggeredBy_BusinessParticipant_RefID = Parameter.created_by_bpt;

                drug_order_status_history.Save(Connection, Transaction);

                var ord_drug_order_position = new ORM_ORD_PRC_ProcurementOrder_Position();
                ord_drug_order_position.CMN_PRO_Product_RefID = hec_drug.Ext_PRO_Product_RefID;
                ord_drug_order_position.Position_RequestedDateOfDelivery = Parameter.delivery_date;
                ord_drug_order_position.ProcurementOrder_Header_RefID = ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;
                ord_drug_order_position.Tenant_RefID = securityTicket.TenantID;
                ord_drug_order_position.RequestedDateOfDelivery_TimeFrame_From = Parameter.is_alternative_delivery_date ? Parameter.alternative_delivery_date_from : Parameter.treatment_date.AddHours(08).AddMinutes(00).AddSeconds(00);
                ord_drug_order_position.RequestedDateOfDelivery_TimeFrame_To = Parameter.is_alternative_delivery_date ? Parameter.alternative_delivery_date_to : Parameter.treatment_date.AddHours(17).AddMinutes(59).AddSeconds(59);
                ord_drug_order_position.IsProFormaOrderPosition = Parameter.is_label_only;
                ord_drug_order_position.Position_Comment = Parameter.order_comment;

                if (Parameter.is_send_invoice_to_practice)
                {
                    var id = Guid.Empty;
                    var practice_account = cls_Get_Practice_AccountID_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPAIDfPID_1351() { PracticeID = Parameter.practice_id }, securityTicket).Result;
                    if (practice_account != null)
                    {
                        id = practice_account.accountID;
                    }

                    var invoice_practice_accountQ = new ORM_USR_Account.Query();
                    invoice_practice_accountQ.USR_AccountID = id;
                    invoice_practice_accountQ.Tenant_RefID = securityTicket.TenantID;
                    invoice_practice_accountQ.IsDeleted = false;

                    var invoice_practice_account = ORM_USR_Account.Query.Search(Connection, Transaction, invoice_practice_accountQ).SingleOrDefault();
                    if (invoice_practice_account != null)
                    {
                        ord_drug_order_position.BillTo_BusinessParticipant_RefID = invoice_practice_account.BusinessParticipant_RefID;
                    }
                }

                ord_drug_order_position.Save(Connection, Transaction);

                var ord_drug_order_history = new ORM_ORD_PRC_ProcurementOrder_Position_History();
                ord_drug_order_history.Creation_Timestamp = DateTime.Now;
                ord_drug_order_history.IsCreated = true;
                ord_drug_order_history.Modification_Timestamp = DateTime.Now;
                ord_drug_order_history.Tenant_RefID = securityTicket.TenantID;
                ord_drug_order_history.TriggeredBy_BusinessParticipant_RefID = Parameter.created_by_bpt;
                ord_drug_order_history.ProcurementOrder_Position_RefID = ord_drug_order_position.ORD_PRC_ProcurementOrder_PositionID;

                ord_drug_order_history.Save(Connection, Transaction);

                var hec_drug_order_position = new ORM_HEC_PRC_ProcurementOrder_Position();
                hec_drug_order_position.Creation_Timestamp = DateTime.Now;
                hec_drug_order_position.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_drug_order_position.ORD_PRC_ProcurementOrder_PositionID;
                hec_drug_order_position.Modification_Timestamp = DateTime.Now;
                hec_drug_order_position.OrderedFor_Patient_RefID = Parameter.patient_id;
                hec_drug_order_position.Tenant_RefID = securityTicket.TenantID;
                hec_drug_order_position.IfProFormaOrderPosition_PrintLabelOnly = Parameter.is_label_only;
                hec_drug_order_position.IsOrderForPatient_PatientFeeWaived = Parameter.is_patient_fee_waived;

                if (Parameter.treatment_doctor_id != Guid.Empty)
                {
                    hec_drug_order_position.OrderedFor_Doctor_RefID = Parameter.treatment_doctor_id;
                    hec_drug_order_position.OrderedForDoctor_DisplayName = GenericUtils.GetDoctorName(Parameter.treatment_doctor_details);
                }
                else
                {
                    var doctor_id = cls_Get_DoctorID_for_AccountID.Invoke(Connection, Transaction, securityTicket).Result;
                    if (doctor_id != null)
                    {
                        var doctor = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = doctor_id.DoctorID }, securityTicket).Result.SingleOrDefault();
                        if (doctor != null)
                        {
                            hec_drug_order_position.OrderedFor_Doctor_RefID = doctor.id;
                            hec_drug_order_position.OrderedForDoctor_DisplayName = GenericUtils.GetDoctorName(doctor);
                        }
                    }

                }

                hec_drug_order_position.OrderedForPatient_DisplayName = Parameter.patient_details.patient_last_name + " " + Parameter.patient_details.patient_first_name;

                hec_drug_order_position.Save(Connection, Transaction);

                returnValue.Result.procurement_order_position_id = hec_drug_order_position.HEC_PRC_ProcurementOrder_PositionID;

                var practice_invoice_universal_property = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                {
                    GlobalPropertyMatchingID = "mm.doc.connect.case.practice.invoice",
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (practice_invoice_universal_property == null)
                {
                    practice_invoice_universal_property = new ORM_HEC_CAS_Case_UniversalProperty();
                    practice_invoice_universal_property.Tenant_RefID = securityTicket.TenantID;
                    practice_invoice_universal_property.PropertyName = "Send Invoice to Practice";
                    practice_invoice_universal_property.IsValue_Boolean = true;
                    practice_invoice_universal_property.GlobalPropertyMatchingID = "mm.doc.connect.case.practice.invoice";
                    practice_invoice_universal_property.Modification_Timestamp = DateTime.Now;

                    practice_invoice_universal_property.Save(Connection, Transaction);
                }

                var practice_invoice_universal_property_value = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                {
                    HEC_CAS_Case_RefID = Parameter.case_id,
                    HEC_CAS_Case_UniversalProperty_RefID = practice_invoice_universal_property.HEC_CAS_Case_UniversalPropertyID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (practice_invoice_universal_property_value == null)
                {
                    practice_invoice_universal_property_value = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                    practice_invoice_universal_property_value.Tenant_RefID = securityTicket.TenantID;
                    practice_invoice_universal_property_value.HEC_CAS_Case_RefID = Parameter.case_id;
                    practice_invoice_universal_property_value.HEC_CAS_Case_UniversalProperty_RefID = practice_invoice_universal_property.HEC_CAS_Case_UniversalPropertyID;
                }
                practice_invoice_universal_property_value.Modification_Timestamp = DateTime.Now;
                practice_invoice_universal_property_value.Value_Boolean = Parameter.is_send_invoice_to_practice;

                practice_invoice_universal_property_value.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CDO_1202 Invoke(string ConnectionString, P_CAS_CDO_1202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CDO_1202 Invoke(DbConnection Connection, P_CAS_CDO_1202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CDO_1202 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CDO_1202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CDO_1202 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CDO_1202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CDO_1202 functionReturn = new FR_CAS_CDO_1202();
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

                throw new Exception("Exception occured in method cls_Create_Drug_Order", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CDO_1202 : FR_Base
    {
        public CAS_CDO_1202 Result { get; set; }

        public FR_CAS_CDO_1202() : base() { }

        public FR_CAS_CDO_1202(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CDO_1202 for attribute P_CAS_CDO_1202
    [DataContract]
    public class P_CAS_CDO_1202
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid created_by_bpt { get; set; }
        [DataMember]
        public ORM_CMN_Language[] all_languagesL { get; set; }
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public DateTime delivery_date { get; set; }
        [DataMember]
        public Boolean is_alternative_delivery_date { get; set; }
        [DataMember]
        public DateTime alternative_delivery_date_from { get; set; }
        [DataMember]
        public DateTime alternative_delivery_date_to { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Boolean is_label_only { get; set; }
        [DataMember]
        public Boolean is_send_invoice_to_practice { get; set; }
        [DataMember]
        public Boolean is_patient_fee_waived { get; set; }
        [DataMember]
        public DO_GDDfDID_0823 treatment_doctor_details { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public P_PA_GPDfPID_1124 patient_details { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public String order_comment { get; set; }

    }
    #endregion
    #region SClass CAS_CDO_1202 for attribute CAS_CDO_1202
    [DataContract]
    public class CAS_CDO_1202
    {
        //Standard type parameters
        [DataMember]
        public Guid procurement_order_header_id { get; set; }
        [DataMember]
        public Guid procurement_order_position_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CDO_1202 cls_Create_Drug_Order(,P_CAS_CDO_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CDO_1202 invocationResult = cls_Create_Drug_Order.Invoke(connectionString,P_CAS_CDO_1202 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CDO_1202();
parameter.case_id = ...;
parameter.created_by_bpt = ...;
parameter.all_languagesL = ...;
parameter.drug_id = ...;
parameter.delivery_date = ...;
parameter.is_alternative_delivery_date = ...;
parameter.alternative_delivery_date_from = ...;
parameter.alternative_delivery_date_to = ...;
parameter.treatment_date = ...;
parameter.is_label_only = ...;
parameter.is_send_invoice_to_practice = ...;
parameter.is_patient_fee_waived = ...;
parameter.treatment_doctor_details = ...;
parameter.treatment_doctor_id = ...;
parameter.patient_details = ...;
parameter.practice_id = ...;
parameter.patient_id = ...;
parameter.order_comment = ...;

*/
