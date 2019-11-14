/* 
 * Generated on 11/02/16 15:52:00
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectUtils;
using MMDocConnectDocApp;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Previous_Case_Data_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Previous_Case_Data_for_PatientID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_GPCDfPID_1144 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GPCDfPID_1144 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_CAS_GPCDfPID_1144();
            //Put your code here
            var latest_case = cls_Get_Latest_NonError_CaseID_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GLNECIDfPID_1552() { PatientID = Parameter.PatientID }, securityTicket).Result;

            if (latest_case != null)
            {
                returnValue.Result = new CAS_GPCDfPID_1144();
                returnValue.Result.case_id = latest_case.case_id;

                #region Treatment
                var treatment_data = cls_Get_Case_Treatment_Data_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCTDfCID_1143() { CaseID = latest_case.case_id }, securityTicket).Result;
                
                returnValue.Result.is_diagnosis_confirmed = treatment_data.is_confirmed;
                returnValue.Result.localization = treatment_data.localization;
                returnValue.Result.diagnose_id = treatment_data.diagnose_id;
                returnValue.Result.treatment_doctor_id = treatment_data.op_doctor_id;
                #endregion

                #region Aftercare
                var aftercare_planned_action_data = cls_Get_Case_PlannedActionData_for_CaseID_and_ActionTypeGpmID.Invoke(Connection, Transaction, new P_CAS_GCPADfCIDaATGpmID_1235()
                {
                    CaseID = latest_case.case_id,
                    ActionTypeGpmID = EActionType.PlannedAftercare.Value()
                }, securityTicket).Result;

                if (aftercare_planned_action_data != null)
                {
                    var aftercare_doctor = cls_Get_Case_DoctorData_for_DoctorBptID.Invoke(Connection, Transaction, new P_CAS_GCDDfDBptID_1242() { DoctorBptID = aftercare_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;

                    if (aftercare_doctor != null)
                    {
                        returnValue.Result.aftercare_doctor_display_name = GenericUtils.GetDoctorName(aftercare_doctor);
                        returnValue.Result.aftercare_doctor_id = aftercare_doctor.id;
                        returnValue.Result.is_aftercare_doctor = true;
                    }
                    else
                    {
                        var aftercare_practice = cls_Get_Case_PracticeData_for_PracticeBptID.Invoke(Connection, Transaction, new P_CAS_GCPDfPBptID_1248() { PracticeBptID = aftercare_planned_action_data.to_be_performed_by_bpt_id }, securityTicket).Result;
                        if (aftercare_practice != null)
                        {
                            returnValue.Result.aftercare_practice_display_name = aftercare_practice.name;
                            returnValue.Result.aftercare_practice_id = aftercare_practice.id;
                            returnValue.Result.is_aftercare_doctor = false;
                        }
                    }
                }
                #endregion
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_GPCDfPID_1144 Invoke(string ConnectionString, P_CAS_GPCDfPID_1144 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection, P_CAS_GPCDfPID_1144 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GPCDfPID_1144 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_GPCDfPID_1144 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GPCDfPID_1144 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GPCDfPID_1144 functionReturn = new FR_CAS_GPCDfPID_1144();
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

                throw new Exception("Exception occured in method cls_Get_Previous_Case_Data_for_PatientID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_GPCDfPID_1144 : FR_Base
    {
        public CAS_GPCDfPID_1144 Result { get; set; }

        public FR_CAS_GPCDfPID_1144() : base() { }

        public FR_CAS_GPCDfPID_1144(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_GPCDfPID_1144 for attribute P_CAS_GPCDfPID_1144
    [DataContract]
    public class P_CAS_GPCDfPID_1144
    {
        //Standard type parameters
        [DataMember]
        public Guid PatientID { get; set; }

    }
    #endregion
    #region SClass CAS_GPCDfPID_1144 for attribute CAS_GPCDfPID_1144
    [DataContract]
    public class CAS_GPCDfPID_1144
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public Guid diagnose_id { get; set; }
        [DataMember]
        public String localization { get; set; }
        [DataMember]
        public Guid aftercare_doctor_id { get; set; }
        [DataMember]
        public Boolean is_aftercare_doctor { get; set; }
        [DataMember]
        public String aftercare_doctor_display_name { get; set; }
        [DataMember]
        public String aftercare_practice_display_name { get; set; }
        [DataMember]
        public Guid aftercare_practice_id { get; set; }
        [DataMember]
        public Boolean is_diagnosis_confirmed { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GPCDfPID_1144 cls_Get_Previous_Case_Data_for_PatientID(,P_CAS_GPCDfPID_1144 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GPCDfPID_1144 invocationResult = cls_Get_Previous_Case_Data_for_PatientID.Invoke(connectionString,P_CAS_GPCDfPID_1144 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GPCDfPID_1144();
parameter.PatientID = ...;

*/
