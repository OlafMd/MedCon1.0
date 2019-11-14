/* 
 * Generated on 02-Dec-13 15:27:11
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

namespace CL3_EconomicRegion.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_EconomicRegion_As_Country.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_EconomicRegion_As_Country
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3ER_SERAC_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_CMN_EconomicRegion economicRegion = new ORM_CMN_EconomicRegion();

            if (Parameter.CMN_EconomicRegionID != Guid.Empty)
            {
                var result = economicRegion.Load(Connection, Transaction, Parameter.CMN_EconomicRegionID);
                if (result.Status != FR_Status.Success || economicRegion.CMN_EconomicRegionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
            countryQuery.Country_ISOCode_Alpha2 = Parameter.Country_ISO;
            countryQuery.Tenant_RefID = securityTicket.TenantID;
            countryQuery.IsDeleted = false;

            ORM_CMN_Country country = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery).FirstOrDefault();

            if (Parameter.CMN_EconomicRegionID != Guid.Empty)
            {
                ORM_CMN_Country_2_EconomicRegion.Query country2EconomicRegionQuery = new ORM_CMN_Country_2_EconomicRegion.Query();
                country2EconomicRegionQuery.CMN_EconomicRegion_RefID = Parameter.CMN_EconomicRegionID;
                country2EconomicRegionQuery.CMN_Country_RefID = country.CMN_CountryID;
                country2EconomicRegionQuery.IsDeleted = false;
                country2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;
                if (ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, country2EconomicRegionQuery).Count != 0)
                {
                    returnValue = new FR_Guid(Parameter.CMN_EconomicRegionID);
                    return returnValue;
                }
            }
            foreach (var content in country.Country_Name.Contents)
            {
                economicRegion.EconomicRegion_Description.UpdateEntry(content.LanguageID, content.Content);
                economicRegion.EconomicRegion_Name.UpdateEntry(content.LanguageID, content.Content);
            }
            economicRegion.IsEconomicRegionCountry = true;
            economicRegion.Tenant_RefID = securityTicket.TenantID;
            economicRegion.Save(Connection, Transaction);

            ORM_CMN_Country_2_EconomicRegion country2EconomicRegion = new ORM_CMN_Country_2_EconomicRegion();
            country2EconomicRegion.CMN_Country_RefID = country.CMN_CountryID;
            country2EconomicRegion.CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID;
            country2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
            country2EconomicRegion.Save(Connection, Transaction);

            returnValue = new FR_Guid(economicRegion.CMN_EconomicRegionID);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3ER_SERAC_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3ER_SERAC_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ER_SERAC_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ER_SERAC_1621 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3ER_SERAC_1621 for attribute P_L3ER_SERAC_1621
		[DataContract]
		public class P_L3ER_SERAC_1621 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_EconomicRegionID { get; set; } 
			[DataMember]
			public String Country_ISO { get; set; } 

		}
		#endregion

	#endregion
}
