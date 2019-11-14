/* 
 * Generated on 2.2.2015 2:09:34
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
using CL3_Language.Complex.Retrieval;
using CL1_LOG_REG;

namespace CL3_SupplierSelectionArea.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_SupplierSelectionArea_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_SupplierSelectionArea_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L3SA_SSSAwCA_0202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();

            var defaultLanguageResult = cls_Get_Default_Language_For_Tenant.Invoke(Connection, Transaction, securityTicket);


            ORM_LOG_REG_SupplierSelectionArea supplierSelectionArea = ORM_LOG_REG_SupplierSelectionArea.Query.Search(Connection, Transaction, new ORM_LOG_REG_SupplierSelectionArea.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_SupplierSelectionAreaID = Parameter.SupplySelectionAreaID
            }).FirstOrDefault();


            if (supplierSelectionArea == null)
            {
                supplierSelectionArea = new ORM_LOG_REG_SupplierSelectionArea();
                supplierSelectionArea.LOG_REG_SupplierSelectionAreaID = Parameter.SupplySelectionAreaID;
                supplierSelectionArea.SupplierSelectionArea_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                supplierSelectionArea.SupplierSelectionArea_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                supplierSelectionArea.Tenant_RefID = securityTicket.TenantID;
            }

            if (defaultLanguageResult != null && defaultLanguageResult.Result != null && defaultLanguageResult.Result.DefaultLanguage != null)
            {
                supplierSelectionArea.SupplierSelectionArea_Name.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.SupplySelectionAreaName);
                supplierSelectionArea.SupplierSelectionArea_Description.UpdateEntry(defaultLanguageResult.Result.DefaultLanguage.CMN_LanguageID, Parameter.SupplySelectionAreaDescription);
            }

            supplierSelectionArea.Save(Connection, Transaction);

            #region Country assignments

            List<ORM_LOG_REG_SupplierSelectionArea_2_Country> supplierSelectionArea2Countries = ORM_LOG_REG_SupplierSelectionArea_2_Country.Query.Search(Connection, Transaction, new ORM_LOG_REG_SupplierSelectionArea_2_Country.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_SupplierSelectionArea_RefID = Parameter.SupplySelectionAreaID
            });


            // Find all assigments that have to be added

            foreach (var countryId in Parameter.AssignedCountryIds)
            {
                var supplierSelectionArea2Country = supplierSelectionArea2Countries.FirstOrDefault(ca => ca.CMN_Country_RefID == countryId);
                if (supplierSelectionArea2Country == null)
                {
                    //assignment does not exist, it should be added
                    supplierSelectionArea2Country = new ORM_LOG_REG_SupplierSelectionArea_2_Country();
                    supplierSelectionArea2Country.CMN_Country_RefID = countryId;
                    supplierSelectionArea2Country.LOG_REG_SupplierSelectionArea_RefID = Parameter.SupplySelectionAreaID;
                    supplierSelectionArea2Country.Tenant_RefID = securityTicket.TenantID;
                    supplierSelectionArea2Country.Save(Connection, Transaction);
                }
            }

            // find all assignments that have to be removed

            foreach (var supplierSelectionArea2Country in supplierSelectionArea2Countries)
            {
                bool exists = Parameter.AssignedCountryIds.Contains(supplierSelectionArea2Country.CMN_Country_RefID);
                if (!exists)
                {
                    supplierSelectionArea2Country.IsDeleted = true;
                    supplierSelectionArea2Country.Save(Connection, Transaction);
                }
            }

            #endregion


            returnValue.Result = supplierSelectionArea.LOG_REG_SupplierSelectionAreaID;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L3SA_SSSAwCA_0202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L3SA_SSSAwCA_0202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L3SA_SSSAwCA_0202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3SA_SSSAwCA_0202 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_SupplierSelectionArea_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3SA_SSSAwCA_0202 for attribute P_L3SA_SSSAwCA_0202
    [DataContract]
    public class P_L3SA_SSSAwCA_0202
    {
        //Standard type parameters
        [DataMember]
        public Guid SupplySelectionAreaID { get; set; }
        [DataMember]
        public string SupplySelectionAreaName { get; set; }
        [DataMember]
        public string SupplySelectionAreaDescription { get; set; }
        [DataMember]
        public Guid[] AssignedCountryIds { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_SupplierSelectionArea_with_Country_Assignments(,P_L3SA_SSSAwCA_0202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_SupplierSelectionArea_with_Country_Assignments.Invoke(connectionString,P_L3SA_SSSAwCA_0202 Parameter,securityTicket);
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
var parameter = new CL3_SupplierSelectionArea.Complex.Manipulation.P_L3SA_SSSAwCA_0202();
parameter.SupplySelectionAreaID = ...;
parameter.SupplySelectionAreaName = ...;
parameter.SupplySelectionAreaDescription = ...;
parameter.AssignedCountryIds = ...;

*/
