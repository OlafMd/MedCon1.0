/* 
 * Generated on 10/13/15 17:35:56
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
    /// var result = cls_Save_Contract_Due_Dates.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Contract_Due_Dates
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_MD_SCDD_1729 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            foreach (var dueDate in Parameter.DueDates)
            {
                #region NEW PARAMETER
                if (dueDate.ID == Guid.Empty)
                {
                    if (dueDate.IsActive)
                    {
                        var newDueDateParameter = new ORM_CMN_CTR_Contract_Parameter();
                        newDueDateParameter.CMN_CTR_Contract_ParameterID = Guid.NewGuid();
                        newDueDateParameter.Contract_RefID = Parameter.ContractID;
                        newDueDateParameter.Creation_Timestamp = DateTime.Now;
                        newDueDateParameter.IfNumericValue_Value = dueDate.Value;
                        newDueDateParameter.IsNumericValue = true;
                        newDueDateParameter.Modification_Timestamp = DateTime.Now;
                        newDueDateParameter.ParameterName = dueDate.Name;
                        newDueDateParameter.Tenant_RefID = securityTicket.TenantID;

                        newDueDateParameter.Save(Connection, Transaction);
                    }
                }
                #endregion

                #region EDIT
                else
                {
                    var existingParameter = ORM_CMN_CTR_Contract_Parameter.Query.Search(Connection, Transaction, new ORM_CMN_CTR_Contract_Parameter.Query()
                    {
                        CMN_CTR_Contract_ParameterID = dueDate.ID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (existingParameter != null)
                    {
                        if (dueDate.IsActive)
                        {
                            existingParameter.IfNumericValue_Value = dueDate.Value;
                        }
                        else
                        {
                            existingParameter.IsDeleted = true;
                        }

                        existingParameter.Modification_Timestamp = DateTime.Now;

                        existingParameter.Save(Connection, Transaction);
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
        public static FR_Guid Invoke(string ConnectionString, P_MD_SCDD_1729 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_MD_SCDD_1729 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_SCDD_1729 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_SCDD_1729 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Contract_Due_Dates", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_SCDD_1729 for attribute P_MD_SCDD_1729
    [DataContract]
    public class P_MD_SCDD_1729
    {
        [DataMember]
        public P_MD_SCDD_1729_Array[] DueDates { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid ContractID { get; set; }

    }
    #endregion
    #region SClass P_MD_SCDD_1729_Array for attribute DueDates
    [DataContract]
    public class P_MD_SCDD_1729_Array
    {
        //Standard type parameters
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Double Value { get; set; }
        [DataMember]
        public Boolean IsActive { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Contract_Due_Dates(,P_MD_SCDD_1729 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Contract_Due_Dates.Invoke(connectionString,P_MD_SCDD_1729 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Manipulation.P_MD_SCDD_1729();
parameter.DueDates = ...;

parameter.ContractID = ...;

*/
