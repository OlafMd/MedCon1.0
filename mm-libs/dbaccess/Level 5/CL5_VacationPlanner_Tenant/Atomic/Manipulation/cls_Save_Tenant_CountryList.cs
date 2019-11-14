/* 
 * Generated on 3/4/2014 1:29:54 PM
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
using CL2_Country.Atomic.Retrieval;
using CL1_CMN;
using CL2_Country.Complex.Retrieval;
using CL5_VacationPlanner_Office.Complex.Retrieval;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Tenant_CountryList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Tenant_CountryList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TN_STCL_1439 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_STCL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5TN_STCL_1439();
            returnValue.Result = new L5TN_STCL_1439();

            List<L5CM_GCWRfT_0938> countriesResult = new List<L5CM_GCWRfT_0938>();
            
			//Put your code here
            ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
            countryQuery.IsDeleted = false;
            countryQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_Country> countryList = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery);

            ORM_CMN_Country country;
            L5CM_GCWRfT_0938 countryResultItem;
            foreach (var countryWithoutTenant in Parameter.CountriesWithoutTenant)
            {
                bool isCountryWithoutTenantInNewList = Parameter.NewListOfCountries.Any(i => i.Country_ISOCode_Alpha2 == countryWithoutTenant.Country_ISOCode_Alpha2);

                country = countryList.FirstOrDefault(i => i.Country_ISOCode_Alpha2 == countryWithoutTenant.Country_ISOCode_Alpha2);

                if (country == null)
                {
                    if (isCountryWithoutTenantInNewList)
                    {
                        country = new ORM_CMN_Country();
                        country.Tenant_RefID = securityTicket.TenantID;
                        country.Country_ISOCode_Alpha2 = countryWithoutTenant.Country_ISOCode_Alpha2;
                        country.Country_ISOCode_Alpha3 = countryWithoutTenant.Country_ISOCode_Alpha3;
                        country.Country_ISOCode_Numeric = countryWithoutTenant.Country_ISOCode_Numeric;

                        Dict countryName = new Dict(countryWithoutTenant.Country_Name.SourceTable);
                        countryName.DictionaryID = Guid.NewGuid();

                        List<DictEntry> entryItems = new List<DictEntry>();
                        entryItems.AddRange(countryWithoutTenant.Country_Name.Contents.Select(entry => new DictEntry() { 
                            Content = entry.Content,
                            LanguageID = entry.LanguageID,
                            DictID = countryName.DictionaryID,
                            EntityID = Guid.NewGuid()
                        }));

                        countryName.Contents = entryItems;

                        country.Country_Name = countryName;
                        country.Default_Currency_RefID = countryWithoutTenant.Default_Currency_RefID;
                        country.Default_Language_RefID = countryWithoutTenant.Default_Language_RefID;
                        country.Save(Connection, Transaction);
                    }
                }
                else
                {
                    country.IsDeleted = !isCountryWithoutTenantInNewList;
                    country.Save(Connection, Transaction);
                }

                if (country != null && !country.IsDeleted)
                {
                    countryResultItem = new L5CM_GCWRfT_0938();
                    countryResultItem.CMN_CountryID = country.CMN_CountryID;
                    countryResultItem.Country_ISOCode_Alpha2 = country.Country_ISOCode_Alpha2;
                    countryResultItem.Country_ISOCode_Alpha3 = country.Country_ISOCode_Alpha3;
                    countryResultItem.Country_ISOCode_Numeric = country.Country_ISOCode_Numeric;
                    countryResultItem.Country_Name = country.Country_Name;
                    countryResultItem.Default_Currency_RefID = country.Default_Currency_RefID;
                    countryResultItem.Default_Language_RefID = country.Default_Language_RefID;
                    countriesResult.Add(countryResultItem);
                }
            }

            returnValue.Result.Countries = countriesResult.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TN_STCL_1439 Invoke(string ConnectionString,P_L5TN_STCL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TN_STCL_1439 Invoke(DbConnection Connection,P_L5TN_STCL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TN_STCL_1439 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_STCL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TN_STCL_1439 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_STCL_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TN_STCL_1439 functionReturn = new FR_L5TN_STCL_1439();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TN_STCL_1439 : FR_Base
	{
		public L5TN_STCL_1439 Result	{ get; set; }

		public FR_L5TN_STCL_1439() : base() {}

		public FR_L5TN_STCL_1439(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TN_STCL_1439 cls_Save_Tenant_CountryList(P_L5TN_STCL_1439 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5TN_STCL_1439 result = cls_Save_Tenant_CountryList.Invoke(connectionString,P_L5TN_STCL_1439 Parameter,securityTicket);
	 return result;
}
*/