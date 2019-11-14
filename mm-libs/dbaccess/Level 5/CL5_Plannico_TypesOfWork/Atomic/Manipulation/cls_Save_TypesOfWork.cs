/* 
 * Generated on 18-Feb-14 17:15:38
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
using CL1_CMN;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfWork.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TypesOfWork.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TypesOfWork
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TW_STW_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new ORM_CMN_STR_Profession();
            if (Parameter.CMN_STR_ProfessionID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_STR_ProfessionID);
                if (result.Status != FR_Status.Success || item.CMN_STR_ProfessionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            item.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
            item.ProfessionName = Parameter.ProfessionName;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Save(Connection, Transaction);

            ORM_CMN_STR_ProfessionKey.Query professionKeyQuery = new ORM_CMN_STR_ProfessionKey.Query();
            professionKeyQuery.CMN_STR_Profession_RefID = item.CMN_STR_ProfessionID;
            professionKeyQuery.IsDeleted = false;
            professionKeyQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_STR_ProfessionKey> professionKeys = ORM_CMN_STR_ProfessionKey.Query.Search(Connection, Transaction, professionKeyQuery);
            if (professionKeys.Count != 0)
            {
                ORM_CMN_STR_ProfessionKey professionKey = professionKeys[0];
                professionKey.SocialSecurityProfessionKey = Parameter.SocialSecurityProfessionKey;
                professionKey.Save(Connection, Transaction);
            }
            else
            {

                ORM_CMN_STR_ProfessionKey professionKey = new ORM_CMN_STR_ProfessionKey();
                professionKey.SocialSecurityProfessionKey = Parameter.SocialSecurityProfessionKey;
                professionKey.CMN_STR_Profession_RefID = item.CMN_STR_ProfessionID;
                professionKey.Tenant_RefID = securityTicket.TenantID;


                ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
                countryQuery.Country_ISOCode_Alpha2 = Parameter.Country_ISOCode_Alpha2;
                countryQuery.IsDeleted = false;
                countryQuery.Tenant_RefID = securityTicket.TenantID;

                List<ORM_CMN_Country> countries = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery);
                if(countries.Count!=0){
                    ORM_CMN_Country country=countries[0];
                    ORM_CMN_Country_2_EconomicRegion.Query economicRegionToCountryQuery = new ORM_CMN_Country_2_EconomicRegion.Query();
                    economicRegionToCountryQuery.CMN_Country_RefID = country.CMN_CountryID;
                    economicRegionToCountryQuery.IsDeleted = false;
                    economicRegionToCountryQuery.Tenant_RefID = securityTicket.TenantID;
                    List<ORM_CMN_Country_2_EconomicRegion> economicRegionToCountries = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, economicRegionToCountryQuery);
                    if (economicRegionToCountries.Count != 0)
                    {
                        ORM_CMN_EconomicRegion.Query economicRegionQuery = new ORM_CMN_EconomicRegion.Query();
                        economicRegionQuery.CMN_EconomicRegionID = economicRegionToCountries[0].CMN_EconomicRegion_RefID;
                        economicRegionQuery.IsDeleted = false;
                        economicRegionQuery.Tenant_RefID = securityTicket.TenantID;
                        List<ORM_CMN_EconomicRegion> economicRegions = ORM_CMN_EconomicRegion.Query.Search(Connection, Transaction, economicRegionQuery);
                        if (economicRegions.Count != 0)
                        {
                            professionKey.CMN_EconomicRegion_RefID = economicRegions[0].CMN_EconomicRegionID;
                        }
                    }
                    else
                    {
                        ORM_CMN_Country_2_EconomicRegion economicRegionToCountry = new ORM_CMN_Country_2_EconomicRegion();
                        economicRegionToCountry.CMN_Country_RefID = country.CMN_CountryID;
                        economicRegionToCountry.Tenant_RefID = securityTicket.TenantID;

                        ORM_CMN_EconomicRegion economicRegion = new ORM_CMN_EconomicRegion();
                        economicRegion.IsEconomicRegionCountry = true;
                        economicRegion.Tenant_RefID = securityTicket.TenantID;
                        economicRegionToCountry.CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID;

                        economicRegion.Save(Connection, Transaction);
                        economicRegionToCountry.Save(Connection, Transaction);
                        professionKey.CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID;

                    }
                }


                professionKey.Save(Connection, Transaction);
            }


            returnValue.Result = item.CMN_STR_ProfessionID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TW_STW_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TW_STW_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TW_STW_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TW_STW_1325 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);


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
					if (cleanupTransaction == true && Transaction!=null)
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
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}
