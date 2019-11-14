/* 
 * Generated on 14.8.2015 9:03:11
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
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using CL1_BIL;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
namespace MMDocConnectDBMethods.Case.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Settlement_Change_Case_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Settlement_Change_Case_Status
    {
        public static readonly int QueryTimeout = 6000000;

        #region Method Execution
        protected static FR_CAS_SCCS_1520 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SCCS_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_SCCS_1520();

            returnValue.Result = new CAS_SCCS_1520();

            //Put your code here
            var Ids_eligible = new List<Guid>();
            var StatusOld = DateTime.Now;
            var StatusNew = DateTime.Now;
            var settlements = new List<Settlement_Model>();
            var patientDetailList = new List<PatientDetailViewModel>();
            var itemsForChange = Parameter.ids_to_change.Count();

            //filter case eligibility 
            foreach (var id in Parameter.ids_to_change)
            {
                if (Parameter.status_to == 8)
                {
                    var settlementEdit = Get_Settlement.GetSettlementForID(id.ToString(), securityTicket);

                    if (settlementEdit != null)
                        if (settlementEdit.status == "FS4" || settlementEdit.status == "FS12")
                        {
                            Ids_eligible.Add(id);
                        }
                }
                else if (Parameter.status_to == 9)
                {
                    var settlementEdit = Get_Settlement.GetSettlementForID(id.ToString(), securityTicket);
                    if (settlementEdit != null)
                        if (settlementEdit.status == "FS7")
                        {
                            Ids_eligible.Add(id);
                        }
                }
            }

            var itemsChanged = Ids_eligible.Count;
            foreach (var ideligible in Ids_eligible)
            {

                #region update setttlement elastic

                var settlementEdit = Get_Settlement.GetSettlementForID(ideligible.ToString(), securityTicket);
                settlementEdit.status = Parameter.status_to == 8 ? "FS" + 7 : "FS" + 12;
                settlementEdit.status_date = DateTime.Now;
                settlements.Add(settlementEdit);

                PatientDetailViewModel patient_detail = Retrieve_Patients.Get_PatientDetaiForID(settlementEdit.id, securityTicket);
                if (patient_detail != null)
                {
                    patient_detail.status = settlementEdit.status;
                    patientDetailList.Add(patient_detail);
                }
                #endregion

                List<CAS_GCTCfCID_1427> casePositions = cls_Get_Case_TransmitionCode_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTCfCID_1427() { CaseID = Guid.Parse(settlementEdit.case_id) }, securityTicket).Result.ToList();
                var aftercareNum = casePositions.Count(fs => fs.fs_key == "aftercare");
                foreach (var item in casePositions)
                {
                    if (item.fs_key == "treatment")
                    {
                        var StatusForCase = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                        {
                            IsDeleted = false,
                            IsActive = true,
                            Tenant_RefID = securityTicket.TenantID,
                            BIL_BillPosition_TransmitionStatusID = item.status_id
                        }).SingleOrDefault();

                        if (StatusForCase != null)
                        {
                            StatusOld = StatusForCase.Modification_Timestamp;

                            StatusForCase.Modification_Timestamp = DateTime.Now;
                            StatusForCase.IsActive = false;
                            StatusForCase.Save(Connection, Transaction);
                            StatusNew = StatusForCase.Modification_Timestamp;

                            var NewStatusForCase = new ORM_BIL_BillPosition_TransmitionStatus();
                            NewStatusForCase.IsDeleted = false;
                            NewStatusForCase.Creation_Timestamp = DateTime.Now;
                            NewStatusForCase.Modification_Timestamp = DateTime.Now;
                            NewStatusForCase.Tenant_RefID = securityTicket.TenantID;
                            NewStatusForCase.IsActive = true;
                            NewStatusForCase.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                            NewStatusForCase.BillPosition_RefID = StatusForCase.BillPosition_RefID;
                            NewStatusForCase.TransmitionCode = Convert.ToInt32(Parameter.status_to) == 9 ? 12 : 7;
                            NewStatusForCase.TransmittedOnDate = DateTime.Now;
                            NewStatusForCase.TransmitionStatusKey = StatusForCase.TransmitionStatusKey;
                            NewStatusForCase.Save(Connection, Transaction);
                        }
                    }
                    else
                    {
                        if ((aftercareNum > 1 && (item.fs_status != 8)) || aftercareNum == 0)
                        {
                            var StatusForCase = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, new ORM_BIL_BillPosition_TransmitionStatus.Query()
                            {
                                IsDeleted = false,
                                IsActive = true,
                                Tenant_RefID = securityTicket.TenantID,
                                BIL_BillPosition_TransmitionStatusID = item.status_id
                            }).SingleOrDefault();

                            if (StatusForCase != null)
                            {
                                StatusOld = StatusForCase.Modification_Timestamp;

                                StatusForCase.Modification_Timestamp = DateTime.Now;
                                StatusForCase.IsActive = false;
                                StatusForCase.Save(Connection, Transaction);
                                StatusNew = StatusForCase.Modification_Timestamp;

                                var NewStatusForCase = new ORM_BIL_BillPosition_TransmitionStatus();
                                NewStatusForCase.IsDeleted = false;
                                NewStatusForCase.Creation_Timestamp = DateTime.Now;
                                NewStatusForCase.Modification_Timestamp = DateTime.Now;
                                NewStatusForCase.Tenant_RefID = securityTicket.TenantID;
                                NewStatusForCase.IsActive = true;
                                NewStatusForCase.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                NewStatusForCase.BillPosition_RefID = StatusForCase.BillPosition_RefID;
                                NewStatusForCase.TransmitionCode = Convert.ToInt32(Parameter.status_to) == 9 ? 12 : 7;
                                NewStatusForCase.TransmittedOnDate = DateTime.Now;
                                NewStatusForCase.TransmitionStatusKey = StatusForCase.TransmitionStatusKey;
                                NewStatusForCase.Save(Connection, Transaction);
                            }
                        }
                    }
                }

                if (settlements.Count != 0)
                    Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());

                if (patientDetailList.Count != 0)
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
            }

            returnValue.Result.number_of_ids_changed = itemsChanged;
            returnValue.Result.number_of_ids_to_change = itemsForChange;
            returnValue.Result.status_to = Parameter.status_to;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_SCCS_1520 Invoke(string ConnectionString, P_CAS_SCCS_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_SCCS_1520 Invoke(DbConnection Connection, P_CAS_SCCS_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_SCCS_1520 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SCCS_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_SCCS_1520 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SCCS_1520 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_SCCS_1520 functionReturn = new FR_CAS_SCCS_1520();
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

                throw new Exception("Exception occured in method cls_Settlement_Change_Case_Status", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_SCCS_1520 : FR_Base
    {
        public CAS_SCCS_1520 Result { get; set; }

        public FR_CAS_SCCS_1520() : base() { }

        public FR_CAS_SCCS_1520(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_SCCS_1520 for attribute P_CAS_SCCS_1520
    [DataContract]
    public class P_CAS_SCCS_1520
    {
        //Standard type parameters
        [DataMember]
        public Double status_to { get; set; }
        [DataMember]
        public Guid[] ids_to_change { get; set; }

    }
    #endregion
    #region SClass CAS_SCCS_1520 for attribute CAS_SCCS_1520
    [DataContract]
    public class CAS_SCCS_1520
    {
        //Standard type parameters
        [DataMember]
        public Double number_of_ids_to_change { get; set; }
        [DataMember]
        public Double number_of_ids_changed { get; set; }
        [DataMember]
        public Double status_to { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_SCCS_1520 cls_Settlement_Change_Case_Status(,P_CAS_SCCS_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_SCCS_1520 invocationResult = cls_Settlement_Change_Case_Status.Invoke(connectionString,P_CAS_SCCS_1520 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Manipulation.P_CAS_SCCS_1520();
parameter.status_to = ...;
parameter.ids_to_change = ...;

*/
