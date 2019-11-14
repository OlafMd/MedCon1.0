/* 
 * Generated on 30.1.2015 10:17:39
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

namespace CL3_EconomicRegion.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Delete_EconomicRegion_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Delete_EconomicRegion_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L3ER_DERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Base();

            //Delete all children and after that economic region
            DeleteChildrenWithCountryAssignments(Connection, Transaction, Parameter.EconomicRegionID, securityTicket.TenantID);


            ORM_CMN_EconomicRegion economicRegion = ORM_CMN_EconomicRegion.Query.Search(Connection, Transaction, new ORM_CMN_EconomicRegion.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_EconomicRegionID = Parameter.EconomicRegionID
            }).FirstOrDefault();

            if (economicRegion == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("Economic region with id {0} does not exist.", Parameter.EconomicRegionID);
                return returnValue;
            }

            economicRegion.IsDeleted = true;
            economicRegion.Save(Connection, Transaction);


            #region Delete all assignments

            List<ORM_CMN_Country_2_EconomicRegion> contry2EconomicRegions = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, new ORM_CMN_Country_2_EconomicRegion.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                CMN_EconomicRegion_RefID = Parameter.EconomicRegionID
            });

            foreach (var contry2EconomicRegion in contry2EconomicRegions)
            {
                contry2EconomicRegion.IsDeleted = true;
                contry2EconomicRegion.Save(Connection, Transaction);
            }

            #endregion

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method extension

        private static void DeleteChildrenWithCountryAssignments(DbConnection connection, DbTransaction transaction, Guid economicRegionId, Guid tenantId)
        {

            List<ORM_CMN_EconomicRegion> economicRegions = ORM_CMN_EconomicRegion.Query.Search(connection, transaction, new ORM_CMN_EconomicRegion.Query()
            {
                IsDeleted = false,
                Tenant_RefID = tenantId,
                ParentEconomicRegion_RefID = economicRegionId
            });

            foreach (var economicRegion in economicRegions)
            {

                DeleteChildrenWithCountryAssignments(connection, transaction, economicRegion.CMN_EconomicRegionID, tenantId);

                economicRegion.IsDeleted = true;
                economicRegion.Save(connection, transaction);

                #region Delete all assignments

                List<ORM_CMN_Country_2_EconomicRegion> contry2EconomicRegions = ORM_CMN_Country_2_EconomicRegion.Query.Search(connection, transaction, new ORM_CMN_Country_2_EconomicRegion.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = tenantId,
                    CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID

                });

                foreach (var contry2EconomicRegion in contry2EconomicRegions)
                {
                    contry2EconomicRegion.IsDeleted = true;
                    contry2EconomicRegion.Save(connection, transaction);
                }

                #endregion

            }


        }

        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L3ER_DERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3ER_DERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3ER_DERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3ER_DERwCA_1016 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Base functionReturn = new FR_Base();
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

                throw new Exception("Exception occured in method cls_Delete_EconomicRegion_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3ER_DERwCA_1016 for attribute P_L3ER_DERwCA_1016
    [DataContract]
    public class P_L3ER_DERwCA_1016
    {
        //Standard type parameters
        [DataMember]
        public Guid EconomicRegionID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_EconomicRegion_with_Country_Assignments(,P_L3ER_DERwCA_1016 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_EconomicRegion_with_Country_Assignments.Invoke(connectionString,P_L3ER_DERwCA_1016 Parameter,securityTicket);
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
var parameter = new CL3_EconomicRegion.Complex.Manipulation.P_L3ER_DERwCA_1016();
parameter.EconomicRegionID = ...;

*/
