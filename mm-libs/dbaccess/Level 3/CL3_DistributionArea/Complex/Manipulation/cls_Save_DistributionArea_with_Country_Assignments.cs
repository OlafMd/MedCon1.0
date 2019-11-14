/* 
 * Generated on 2.2.2015 2:04:57
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
using CL1_LOG_REG;
using CL3_Language.Complex.Retrieval;

namespace CL3_DistributionArea.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_DistributionArea_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_DistributionArea_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L3DA_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            var defaultLanguageResult = cls_Get_Default_Language_For_Tenant.Invoke(Connection, Transaction, securityTicket);

            ORM_LOG_REG_DistributionArea distributionArea = ORM_LOG_REG_DistributionArea.Query.Search(Connection, Transaction, new ORM_LOG_REG_DistributionArea.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_DistributionAreaID = Parameter.DistributionAreaID
            }).FirstOrDefault();

            if (distributionArea == null)
            {
                distributionArea = new ORM_LOG_REG_DistributionArea();
                distributionArea.LOG_REG_DistributionAreaID = Parameter.DistributionAreaID;
                distributionArea.DistributionArea_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                distributionArea.DistributionArea_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                distributionArea.Tenant_RefID = securityTicket.TenantID;
            }

            if (defaultLanguageResult != null && defaultLanguageResult.Result != null && defaultLanguageResult.Result.DefaultLanguage != null)
            {
                distributionArea.DistributionArea_Description.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.DistributionAreaDescription);
                distributionArea.DistributionArea_Name.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.DistributionAreaName);
            }

            distributionArea.Save(Connection, Transaction);

            #region Country assignments

            List<ORM_LOG_REG_DistributionArea_2_Country> distributionArea2Countries = ORM_LOG_REG_DistributionArea_2_Country.Query.Search(Connection, Transaction, new ORM_LOG_REG_DistributionArea_2_Country.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_DistributionArea_RefID = Parameter.DistributionAreaID
            });


            // Find all assigments that have to be added

            foreach (var countryId in Parameter.AssignedCountryIds)
            {
                var distributionArea2Country = distributionArea2Countries.FirstOrDefault(ca => ca.CMN_Country_RefID == countryId);
                if (distributionArea2Country == null)
                {
                    //assignment does not exist, it should be added
                    distributionArea2Country = new ORM_LOG_REG_DistributionArea_2_Country();
                    distributionArea2Country.CMN_Country_RefID = countryId;
                    distributionArea2Country.LOG_REG_DistributionArea_RefID = Parameter.DistributionAreaID;
                    distributionArea2Country.Tenant_RefID = securityTicket.TenantID;
                    distributionArea2Country.Save(Connection, Transaction);
                }
            }

            // find all assignments that have to be removed

            foreach (var distributionArea2Country in distributionArea2Countries)
            {
                bool exists = Parameter.AssignedCountryIds.Contains(distributionArea2Country.CMN_Country_RefID);
                if (!exists)
                {
                    distributionArea2Country.IsDeleted = true;
                    distributionArea2Country.Save(Connection, Transaction);
                }
            }

            #endregion

            returnValue.Result = distributionArea.LOG_REG_DistributionAreaID;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L3DA_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L3DA_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L3DA_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3DA_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_DistributionArea_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3DA_SERwCA_1016 for attribute P_L3DA_SERwCA_1016
    [DataContract]
    public class P_L3DA_SERwCA_1016
    {
        //Standard type parameters
        [DataMember]
        public Guid DistributionAreaID { get; set; }
        [DataMember]
        public string DistributionAreaName { get; set; }
        [DataMember]
        public string DistributionAreaDescription { get; set; }
        [DataMember]
        public Guid[] AssignedCountryIds { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DistributionArea_with_Country_Assignments(,P_L3DA_SERwCA_1016 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DistributionArea_with_Country_Assignments.Invoke(connectionString,P_L3DA_SERwCA_1016 Parameter,securityTicket);
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
var parameter = new CL3_DistributionArea.Complex.Manipulation.P_L3DA_SERwCA_1016();
parameter.DistributionAreaID = ...;
parameter.DistributionAreaName = ...;
parameter.DistributionAreaDescription = ...;
parameter.AssignedCountryIds = ...;

*/
