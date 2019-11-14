/* 
 * Generated on 08/26/16 10:45:03
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
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Case.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_All_Drugs_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_All_Drugs_for_PracticeID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_GADfPID_1620_Array Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_GADfPID_1620 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_GADfPID_1620_Array();
            var drugs_result = new List<CAS_GADfPID_1620>();

            var distinct_contracts = cls_Get_Assigned_ContractIDs_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GACIDsfPID_2057() { PracticeID = Parameter.PracticeID }, securityTicket).Result;
 
            var drugs = cls_Get_All_Drugs_for_ContractIDs.Invoke(Connection, Transaction, new P_CAS_GADfCIDs_2046() { ContractIDs = distinct_contracts.Select(t => t.ContractID).ToArray() }, securityTicket).Result;

            foreach (var drug in drugs)
            {
                if (!drugs_result.Any(drug_from_db => drug_from_db.drug_id == drug.drug_id))
                {
                    drugs_result.Add(new CAS_GADfPID_1620() { drug_id = drug.drug_id, drug_name = drug.drug_name });
                }
            }


            returnValue.Result = drugs_result.OrderBy(drug => drug.drug_name).ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_GADfPID_1620_Array Invoke(string ConnectionString, P_CAS_GADfPID_1620 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_GADfPID_1620_Array Invoke(DbConnection Connection, P_CAS_GADfPID_1620 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_GADfPID_1620_Array Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_GADfPID_1620 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_GADfPID_1620_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_GADfPID_1620 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_GADfPID_1620_Array functionReturn = new FR_CAS_GADfPID_1620_Array();
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

                throw new Exception("Exception occured in method cls_Get_All_Drugs_for_PracticeID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_GADfPID_1620_Array : FR_Base
    {
        public CAS_GADfPID_1620[] Result { get; set; }
        public FR_CAS_GADfPID_1620_Array() : base() { }

        public FR_CAS_GADfPID_1620_Array(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_GADfPID_1620 for attribute P_CAS_GADfPID_1620
    [DataContract]
    public class P_CAS_GADfPID_1620
    {
        //Standard type parameters
        [DataMember]
        public Guid PracticeID { get; set; }

    }
    #endregion
    #region SClass CAS_GADfPID_1620 for attribute CAS_GADfPID_1620
    [DataContract]
    public class CAS_GADfPID_1620
    {
        //Standard type parameters
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public String drug_name { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GADfPID_1620_Array cls_Get_All_Drugs_for_PracticeID(,P_CAS_GADfPID_1620 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GADfPID_1620_Array invocationResult = cls_Get_All_Drugs_for_PracticeID.Invoke(connectionString,P_CAS_GADfPID_1620 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Complex.Retrieval.P_CAS_GADfPID_1620();
parameter.PracticeID = ...;

*/
