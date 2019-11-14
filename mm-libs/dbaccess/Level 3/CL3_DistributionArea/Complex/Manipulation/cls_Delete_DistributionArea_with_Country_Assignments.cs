/* 
 * Generated on 2.2.2015 2:04:53
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
using CL1_CMN_PRO;

namespace CL3_DistributionArea.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Delete_DistributionArea_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Delete_DistributionArea_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L3DA_DDAwCA_0141 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Base();

            ORM_LOG_REG_DistributionArea distributionArea = ORM_LOG_REG_DistributionArea.Query.Search(Connection, Transaction, new ORM_LOG_REG_DistributionArea.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_DistributionAreaID = Parameter.DistributionAreaID
            }).FirstOrDefault();

            if (distributionArea == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = String.Format("DistributionArea entry with ID = {0} does not exist in database", Parameter.DistributionAreaID);
                return returnValue;
            }

            distributionArea.IsDeleted = true;
            distributionArea.Save(Connection, Transaction);

            List<ORM_LOG_REG_DistributionArea_2_Country> distributionArea2Countries = ORM_LOG_REG_DistributionArea_2_Country.Query.Search(Connection, Transaction, new ORM_LOG_REG_DistributionArea_2_Country.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                LOG_REG_DistributionArea_RefID = Parameter.DistributionAreaID
            });

            foreach (var distributionArea2Country in distributionArea2Countries)
            {
                distributionArea2Country.IsDeleted = true;
                distributionArea2Country.Save(Connection, Transaction);
            }

            ORM_CMN_PRO_DistributionCenter.Query distributionCentersQuery = new ORM_CMN_PRO_DistributionCenter.Query();
            distributionCentersQuery.LOG_REG_DistributionArea_RefID = Parameter.DistributionAreaID;
            distributionCentersQuery.Tenant_RefID = securityTicket.TenantID;
            distributionCentersQuery.IsDeleted = false;
            List<ORM_CMN_PRO_DistributionCenter> distributionCentersList = ORM_CMN_PRO_DistributionCenter.Query.Search(Connection, Transaction, distributionCentersQuery);

            foreach (var distributionCenter in distributionCentersList)
            {
                distributionCenter.IsDeleted = true;
                distributionCenter.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L3DA_DDAwCA_0141 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3DA_DDAwCA_0141 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3DA_DDAwCA_0141 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3DA_DDAwCA_0141 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Delete_DistributionArea_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3DA_DDAwCA_0141 for attribute P_L3DA_DDAwCA_0141
    [DataContract]
    public class P_L3DA_DDAwCA_0141
    {
        //Standard type parameters
        [DataMember]
        public Guid DistributionAreaID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_DistributionArea_with_Country_Assignments(,P_L3DA_DDAwCA_0141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_DistributionArea_with_Country_Assignments.Invoke(connectionString,P_L3DA_DDAwCA_0141 Parameter,securityTicket);
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
var parameter = new CL3_DistributionArea.Complex.Manipulation.P_L3DA_DDAwCA_0141();
parameter.DistributionAreaID = ...;

*/
