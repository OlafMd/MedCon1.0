/* 
 * Generated on 11/29/16 17:54:19
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

namespace MMDocConnectDBMethods.MainData.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Contract_Parameter.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_Parameter
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCP_1754 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var contract_parameter = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
            {
                Contract_RefID = Parameter.ContractID,
                ParameterName = Parameter.Name,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (contract_parameter == null)
            {
                contract_parameter = new ORM_CMN_CTR_Contract_Parameter();
                contract_parameter.Tenant_RefID = securityTicket.TenantID;
                contract_parameter.ParameterName = Parameter.Name;
                contract_parameter.Contract_RefID = Parameter.ContractID;
            }

            if (Parameter.BooleanValue.HasValue)
            {
                contract_parameter.IsBooleanValue = true;
                contract_parameter.IfBooleanValue_Value = Parameter.BooleanValue.Value;
            }
            else if (Parameter.NumericValue.HasValue)
            {
                contract_parameter.IsNumericValue = true;
                contract_parameter.IfNumericValue_Value = Parameter.NumericValue.Value;
            }
            else
            {
                contract_parameter.IsStringValue = true;
                contract_parameter.IfStringValue_Value = Parameter.StringValue;
            }
            contract_parameter.Modification_Timestamp = DateTime.Now;

            contract_parameter.Save(Connection, Transaction);
            
            returnValue.Result = contract_parameter.CMN_CTR_Contract_ParameterID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCP_1754 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCP_1754 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCP_1754 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCP_1754 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_Parameter", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCP_1754 for attribute P_MD_SCP_1754
    [DataContract]
    public class P_MD_SCP_1754
    {
        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Double? NumericValue { get; set; }
        [DataMember]
        public String StringValue { get; set; }
        [DataMember]
        public Boolean? BooleanValue { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_Parameter(,P_MD_SCP_1754 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_Parameter.Invoke(connectionString,P_MD_SCP_1754 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCP_1754();
parameter.ContractID = ...;
parameter.ID = ...;
parameter.Name = ...;
parameter.NumericValue = ...;
parameter.StringValue = ...;
parameter.BooleanValue = ...;

*/
