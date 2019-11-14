/* 
 * Generated on 12/1/2014 3:59:57 PM
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
using CL1_CMN_STR;

namespace CL3_CostCenter.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_All_CostCenters.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_All_CostCenters
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L3CC_GACC_1551 Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L3CC_GACC_1551();
            returnValue.Result = new L3CC_GACC_1551();


            List<ORM_CMN_STR_CostCenter> costCenters = ORM_CMN_STR_CostCenter.Query.Search(Connection, Transaction, new ORM_CMN_STR_CostCenter.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            if (costCenters != null)
            {
                returnValue.Result.CostCenters = costCenters.ToArray();
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3CC_GACC_1551 Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3CC_GACC_1551 Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3CC_GACC_1551 Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3CC_GACC_1551 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3CC_GACC_1551 functionReturn = new FR_L3CC_GACC_1551();
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

                functionReturn = Execute(Connection, Transaction, securityTicket);

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

                throw new Exception("Exception occured in method cls_Get_All_CostCenters", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3CC_GACC_1551 : FR_Base
    {
        public L3CC_GACC_1551 Result { get; set; }

        public FR_L3CC_GACC_1551() : base() { }

        public FR_L3CC_GACC_1551(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass L3CC_GACC_1551 for attribute L3CC_GACC_1551
    [DataContract]
    public class L3CC_GACC_1551
    {
        [DataMember]
        public ORM_CMN_STR_CostCenter[] CostCenters { get; set; }

        //Standard type parameters
    }
    #endregion


    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CC_GACC_1551 cls_Get_All_CostCenters(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CC_GACC_1551 invocationResult = cls_Get_All_CostCenters.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

