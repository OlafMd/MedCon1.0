/* 
 * Generated on 29.1.2015 14:50:49
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
using CL1_CMN;
using CL3_Language.Complex.Retrieval;

namespace CL3_EconomicRegion.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_EconomicRegion_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_EconomicRegion_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L3ER_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            var defaultLanguageResult = cls_Get_Default_Language_For_Tenant.Invoke(Connection, Transaction, securityTicket);

            ORM_CMN_EconomicRegion economicRegion = ORM_CMN_EconomicRegion.Query.Search(Connection, Transaction, new ORM_CMN_EconomicRegion.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_EconomicRegionID = Parameter.EconomicRegionID
            }).FirstOrDefault();

            if (economicRegion == null)
            {
                economicRegion = new ORM_CMN_EconomicRegion()
                {
                    CMN_EconomicRegionID = Parameter.EconomicRegionID,
                    Creation_Timestamp = DateTime.Now,
                    EconomicRegion_Description = new Dict() { DictionaryID = Guid.NewGuid() },
                    EconomicRegion_Name = new Dict() { DictionaryID = Guid.NewGuid() },
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
            }
            economicRegion.ParentEconomicRegion_RefID = Parameter.EconomicRegionParentID;
            economicRegion.IsEconomicRegionCountry = Parameter.IsEconomicRegionCountry;

            if (defaultLanguageResult != null && defaultLanguageResult.Result != null && defaultLanguageResult.Result.DefaultLanguage != null)
            {
                economicRegion.EconomicRegion_Name.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.EconomicRegionName);
                economicRegion.EconomicRegion_Description.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.EconomicRegionDescription);
            }

            economicRegion.Save(Connection, Transaction);


            #region Country assignemnts

            ORM_CMN_Country_2_EconomicRegion[] country2EconomicRegions = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, new ORM_CMN_Country_2_EconomicRegion.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_EconomicRegion_RefID = Parameter.EconomicRegionID
            }).ToArray();


            // Find all assigments that have to be added

            foreach (var countryId in Parameter.AssignedCountryIds)
            {
                var country2EconomicRegion = country2EconomicRegions.FirstOrDefault(ca => ca.CMN_Country_RefID == countryId);
                if (country2EconomicRegion == null)
                {
                    //assignment does not exist, it should be added
                    country2EconomicRegion = new ORM_CMN_Country_2_EconomicRegion();
                    country2EconomicRegion.CMN_Country_RefID = countryId;
                    country2EconomicRegion.CMN_EconomicRegion_RefID = Parameter.EconomicRegionID;
                    country2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
                    country2EconomicRegion.Save(Connection, Transaction);
                }
            }

            // find all assignments that have to be removed

            foreach (var country2EconomicRegion in country2EconomicRegions)
            {
                bool exists = Parameter.AssignedCountryIds.Contains(country2EconomicRegion.CMN_Country_RefID);
                if (!exists)
                {
                    country2EconomicRegion.IsDeleted = true;
                    country2EconomicRegion.Save(Connection, Transaction);
                }
            }


            #endregion Country assignemnts

            returnValue.Result = economicRegion.CMN_EconomicRegionID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L3ER_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L3ER_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L3ER_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3ER_SERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_EconomicRegion_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3ER_SERwCA_1016 for attribute P_L3ER_SERwCA_1016
    [DataContract]
    public class P_L3ER_SERwCA_1016
    {
        //Standard type parameters
        [DataMember]
        public Guid EconomicRegionID { get; set; }
        [DataMember]
        public string EconomicRegionName { get; set; }
        [DataMember]
        public string EconomicRegionDescription { get; set; }
        [DataMember]
        public Guid EconomicRegionParentID { get; set; }
        [DataMember]
        public bool IsEconomicRegionCountry { get; set; }
        [DataMember]
        public Guid[] AssignedCountryIds { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_EconomicRegion_with_Country_Assignments(,P_L3ER_SERwCA_1016 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_EconomicRegion_with_Country_Assignments.Invoke(connectionString,P_L3ER_SERwCA_1016 Parameter,securityTicket);
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
var parameter = new CL3_EconomicRegion.Complex.Manipulation.P_L3ER_SERwCA_1016();
parameter.EconomicRegionID = ...;
parameter.EconomicRegionName = ...;
parameter.EconomicRegionDescription = ...;
parameter.EconomicRegionParentID = ...;
parameter.IsEconomicRegionCountry = ...;
parameter.AssignedCountryIds = ...;

*/
