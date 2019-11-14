/* 
 * Generated on 10/29/2013 9:51:12 AM
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
using CL5_Plannico_TypesOfWork.Atomic.Retrieval;
using CL1_CMN_STR;
using CL1_CMN;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfWork.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_TypeOfWork_For_ProfessionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_TypeOfWork_For_ProfessionID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5TW_GTWFP_1326 Execute(DbConnection Connection, DbTransaction Transaction, P_L5TW_GTWFP_1326 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5TW_GTWFP_1326();
            ORM_CMN_STR_Profession.Query professionQuery = new ORM_CMN_STR_Profession.Query();
            professionQuery.CMN_STR_ProfessionID = Parameter.CMN_STR_ProfessionID;
            professionQuery.IsDeleted = false;
            professionQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_STR_Profession> professions = ORM_CMN_STR_Profession.Query.Search(Connection, Transaction, professionQuery);
            if (professions != null && professions.Count != 0)
            {
                L5TW_GTWFT_1327 professionItem = new L5TW_GTWFT_1327();

                ORM_CMN_STR_Profession profession = professions[0];
                professionItem.CMN_STR_ProfessionID = profession.CMN_STR_ProfessionID;
                professionItem.ProfessionName = profession.ProfessionName;
                professionItem.GlobalPropertyMatchingID = profession.GlobalPropertyMatchingID;

                ORM_CMN_STR_ProfessionKey.Query professionKeyQuery = new ORM_CMN_STR_ProfessionKey.Query();
                professionKeyQuery.CMN_STR_Profession_RefID = Parameter.CMN_STR_ProfessionID;
                professionKeyQuery.IsDeleted = false;
                professionKeyQuery.Tenant_RefID = securityTicket.TenantID;
                List<ORM_CMN_STR_ProfessionKey> professionKeys = ORM_CMN_STR_ProfessionKey.Query.Search(Connection, Transaction, professionKeyQuery);
                if(professionKeys.Count!=0){
                    ORM_CMN_STR_ProfessionKey professionKey=professionKeys[0];
                    professionItem.SocialSecurityProfessionKey = professionKey.SocialSecurityProfessionKey;
                    ORM_CMN_EconomicRegion.Query economicRegionQuery = new ORM_CMN_EconomicRegion.Query();
                    economicRegionQuery.CMN_EconomicRegionID = professionKey.CMN_EconomicRegion_RefID;
                    economicRegionQuery.IsDeleted = false;
                    economicRegionQuery.Tenant_RefID=securityTicket.TenantID;
                    List<ORM_CMN_EconomicRegion> economicRegions = ORM_CMN_EconomicRegion.Query.Search(Connection, Transaction, economicRegionQuery);
                    if(economicRegions.Count!=0){
                        ORM_CMN_EconomicRegion economicRegion = economicRegions[0];
                        ORM_CMN_Country_2_EconomicRegion.Query economicRegionToCountryQuery = new ORM_CMN_Country_2_EconomicRegion.Query();
                        economicRegionToCountryQuery.CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID;
                        economicRegionToCountryQuery.IsDeleted = false;
                        economicRegionToCountryQuery.Tenant_RefID = securityTicket.TenantID;
                        List<ORM_CMN_Country_2_EconomicRegion> economicRegionToCountries = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, economicRegionToCountryQuery);
                        if (economicRegionToCountries.Count != 0)
                        {
                            ORM_CMN_Country_2_EconomicRegion economicRegionToCountry = economicRegionToCountries[0];
                            ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
                            countryQuery.CMN_CountryID = economicRegionToCountry.CMN_Country_RefID;
                            countryQuery.IsDeleted = false;
                            countryQuery.Tenant_RefID = securityTicket.TenantID;
        
                            List<ORM_CMN_Country> countries = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery);
                            if (countries.Count != 0)
                            {
                                professionItem.Country_ISOCode_Alpha2 = countries[0].Country_ISOCode_Alpha2;
                            }
                        
                        }
                    }
                }
                
                returnValue.Result = new L5TW_GTWFP_1326();
                returnValue.Result.TypeOfWork = professionItem;
            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5TW_GTWFP_1326 Invoke(string ConnectionString, P_L5TW_GTWFP_1326 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5TW_GTWFP_1326 Invoke(DbConnection Connection, P_L5TW_GTWFP_1326 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5TW_GTWFP_1326 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5TW_GTWFP_1326 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5TW_GTWFP_1326 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5TW_GTWFP_1326 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5TW_GTWFP_1326 functionReturn = new FR_L5TW_GTWFP_1326();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
                throw new Exception("Exception occured in method cls_Get_TypeOfWork_For_ProfessionID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5TW_GTWFP_1326 : FR_Base
    {
        public L5TW_GTWFP_1326 Result { get; set; }

        public FR_L5TW_GTWFP_1326() : base() { }

        public FR_L5TW_GTWFP_1326(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes


    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TW_GTWFP_1326 cls_Get_TypeOfWork_For_ProfessionID(,P_L5TW_GTWFP_1326 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TW_GTWFP_1326 invocationResult = cls_Get_TypeOfWork_For_ProfessionID.Invoke(connectionString,P_L5TW_GTWFP_1326 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_TypesOfWork.Complex.Retrieval.P_L5TW_GTWFP_1326();
parameter.CMN_STR_ProfessionID = ...;

*/