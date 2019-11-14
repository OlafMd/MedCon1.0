/* 
 * Generated on 26/06/2014 09:38:58
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
using CL1_CMN_LOC;
using PlannicoModel.Models;

namespace CL2_Country.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CountriesWithRegions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CountriesWithRegions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CM_GCWRfT_0938_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

            var returnValue = new FR_L5CM_GCWRfT_0938_Array();
			//Put your code here
            ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
            countryQuery.IsDeleted = false;
            countryQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_Country> countries = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery);
            List<L5CM_GCWRfT_0938> countryList = new List<L5CM_GCWRfT_0938>();
            foreach (var country in countries)
            {
                L5CM_GCWRfT_0938 item = new L5CM_GCWRfT_0938();
                item.CMN_CountryID = country.CMN_CountryID;
                item.Country_ISOCode_Alpha2 = country.Country_ISOCode_Alpha2;
                item.Country_ISOCode_Alpha3 = country.Country_ISOCode_Alpha3;
                item.Country_ISOCode_Numeric = country.Country_ISOCode_Numeric;
                item.Country_Name = country.Country_Name;
                item.Default_Currency_RefID = country.Default_Currency_RefID;
                item.Default_Language_RefID = country.Default_Language_RefID;
                countryQuery = new ORM_CMN_Country.Query();
                countryQuery.IsDeleted = false;
                countryQuery.Tenant_RefID = Guid.Empty;
                countryQuery.Country_ISOCode_Alpha2 = item.Country_ISOCode_Alpha2;
                countries = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery);

                ORM_CMN_LOC_Region.Query regionsQuery = new ORM_CMN_LOC_Region.Query();
                regionsQuery.IsDeleted = false;
                regionsQuery.Country_RefID = countries[0].CMN_CountryID;
                List<ORM_CMN_LOC_Region> regions = ORM_CMN_LOC_Region.Query.Search(Connection, Transaction, regionsQuery);
                List<L5CM_GCWRfT_0938_Region> regionList = new List<L5CM_GCWRfT_0938_Region>();
                foreach (var region in regions)
                {

                    L5CM_GCWRfT_0938_Region regionItem = new L5CM_GCWRfT_0938_Region();
                    regionItem.CMN_LOC_RegionID = region.CMN_LOC_RegionID;
                    regionItem.Parent_RefID = region.Parent_RefID;
                    regionItem.Region_Name = region.Region_Name;
                    regionItem.RegionExternalID = region.RegionExternalID;
                    regionList.Add(regionItem);
                }
                item.Regions = regionList.ToArray();

                countryList.Add(item);
            }

            returnValue.Result = countryList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CM_GCWRfT_0938_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CM_GCWRfT_0938_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CM_GCWRfT_0938_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CM_GCWRfT_0938_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CM_GCWRfT_0938_Array functionReturn = new FR_L5CM_GCWRfT_0938_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_CountriesWithRegions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5CM_GCWRfT_0938_raw 
	{
		public Guid CMN_CountryID; 
		public Guid Default_Language_RefID; 
		public Guid Default_Currency_RefID; 
		public Dict Country_Name; 
		public String Country_ISOCode_Alpha3; 
		public String Country_ISOCode_Alpha2; 
		public int Country_ISOCode_Numeric; 
		public Guid CMN_LOC_RegionID; 
		public Dict Region_Name; 
		public String RegionExternalID; 
		public Guid Parent_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5CM_GCWRfT_0938[] Convert(List<L5CM_GCWRfT_0938_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5CM_GCWRfT_0938 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_CountryID)).ToArray()
	group el_L5CM_GCWRfT_0938 by new 
	{ 
		el_L5CM_GCWRfT_0938.CMN_CountryID,

	}
	into gfunct_L5CM_GCWRfT_0938
	select new L5CM_GCWRfT_0938
	{     
		CMN_CountryID = gfunct_L5CM_GCWRfT_0938.Key.CMN_CountryID ,
		Default_Language_RefID = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Default_Language_RefID ,
		Default_Currency_RefID = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Default_Currency_RefID ,
		Country_Name = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Country_Name ,
		Country_ISOCode_Alpha3 = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Country_ISOCode_Alpha3 ,
		Country_ISOCode_Alpha2 = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Country_ISOCode_Alpha2 ,
		Country_ISOCode_Numeric = gfunct_L5CM_GCWRfT_0938.FirstOrDefault().Country_ISOCode_Numeric ,

		Regions = 
		(
			from el_Regions in gfunct_L5CM_GCWRfT_0938.Where(element => !EqualsDefaultValue(element.CMN_LOC_RegionID)).ToArray()
			group el_Regions by new 
			{ 
				el_Regions.CMN_LOC_RegionID,

			}
			into gfunct_Regions
			select new L5CM_GCWRfT_0938_Region
			{     
				CMN_LOC_RegionID = gfunct_Regions.Key.CMN_LOC_RegionID ,
				Region_Name = gfunct_Regions.FirstOrDefault().Region_Name ,
				RegionExternalID = gfunct_Regions.FirstOrDefault().RegionExternalID ,
				Parent_RefID = gfunct_Regions.FirstOrDefault().Parent_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5CM_GCWRfT_0938_Array : FR_Base
	{
		public L5CM_GCWRfT_0938[] Result	{ get; set; } 
		public FR_L5CM_GCWRfT_0938_Array() : base() {}

		public FR_L5CM_GCWRfT_0938_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CM_GCWRfT_0938_Array cls_Get_CountriesWithRegions_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CM_GCWRfT_0938_Array invocationResult = cls_Get_CountriesWithRegions_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

