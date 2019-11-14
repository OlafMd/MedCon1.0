/* 
 * Generated on 09/19/16 13:18:53
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
using CL1_CMN_CTR;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_TreatmentYearLength.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_TreatmentYearLength
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Int Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GTYL_1317 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Int();
            returnValue.Result = 365;

            var oct_gpos_ids = cls_Get_GposIDs_for_GposType.Invoke(Connection, Transaction, new P_MD_GGpoIDsfGposT_1145() { GposType = EGposType.Oct.Value() }, securityTicket).Result;

            var last_potential_consent = cls_Get_Patient_Consents_before_Date_and_GposIDs.Invoke(Connection, Transaction, new P_PA_GPCbDaGposIDs_1154()
            {
                Date = Parameter.Date,
                GposIDs = oct_gpos_ids.Select(t => t.GposID).ToArray(),
                PatientID = Parameter.PatientID
            }, securityTicket).Result.FirstOrDefault(t => t.consent_valid_from.Date <= Parameter.Date);

            if (last_potential_consent != null)
            {
                var all_contract_parameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                {
                    Contract_RefID = last_potential_consent.contract_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                var treatment_year_length_ctr_parameter = all_contract_parameters.SingleOrDefault(t => t.ParameterName == "Preexaminations - Days");
                if (treatment_year_length_ctr_parameter != null)
                {
                    returnValue.Result = Convert.ToInt32(treatment_year_length_ctr_parameter.IfNumericValue_Value);
                }
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Int Invoke(string ConnectionString, P_CAS_GTYL_1317 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Int Invoke(DbConnection Connection, P_CAS_GTYL_1317 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Int Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GTYL_1317 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Int Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GTYL_1317 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Int functionReturn = new FR_Int();
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

                throw new Exception("Exception occured in method cls_Get_TreatmentYearLength", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_GTYL_1317 for attribute P_CAS_GTYL_1317
    [DataContract]
    public class P_CAS_GTYL_1317
    {
        //Standard type parameters
        [DataMember]
        public Guid PatientID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Int cls_Get_TreatmentYearLength(,P_CAS_GTYL_1317 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Int invocationResult = cls_Get_TreatmentYearLength.Invoke(connectionString,P_CAS_GTYL_1317 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GTYL_1317();
parameter.PatientID = ...;
parameter.Date = ...;

*/
