/* 
 * Generated on 3/3/2014 2:31:45 PM
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
using CL1_CMN_PER;
using CL1_CMN;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_CompulsorySocialSecurityStatuses.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CompulsorySocialSecurityStatuses_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CompulsorySocialSecurityStatuses_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CS_GCSSFT_1319_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 

			var returnValue = new FR_L5CS_GCSSFT_1319_Array();

			//Put your code here
            List<L5CS_GCSSFT_1319> retValList = new List<L5CS_GCSSFT_1319>();

            ORM_CMN_PER_CompulsorySocialSecurityStatus.Query socialSecurityQuery = new ORM_CMN_PER_CompulsorySocialSecurityStatus.Query();
            socialSecurityQuery.Tenant_RefID = securityTicket.TenantID;
            socialSecurityQuery.IsDeleted = false;
            List<ORM_CMN_PER_CompulsorySocialSecurityStatus> socialSecurityList = ORM_CMN_PER_CompulsorySocialSecurityStatus.Query.Search(Connection, Transaction, socialSecurityQuery);

            ORM_CMN_EconomicRegion economicRegion;
            FR_Base economicRegionRes;
            ORM_CMN_Country_2_EconomicRegion countryEconomicRegion;
            ORM_CMN_Country country;
            FR_Base countryRes;
            L5CS_GCSSFT_1319 retValItem;
            foreach (var socialSecurity in socialSecurityList)
            {
                retValItem = new L5CS_GCSSFT_1319();
                retValItem.CMN_EconomicRegion_RefID = socialSecurity.CMN_EconomicRegion_RefID;
                retValItem.CMN_PER_CompulsorySocialSecurityStatusID = socialSecurity.CMN_PER_CompulsorySocialSecurityStatusID;
                retValItem.GlobalPropertyMatchingID = socialSecurity.GlobalPropertyMatchingID;
                retValItem.SocialSecurityStatus_Code = socialSecurity.SocialSecurityStatus_Code;
                retValItem.SocialSecurityStatus_Description = socialSecurity.SocialSecurityStatus_Description;
                retValItem.SocialSecurityStatus_Name = socialSecurity.SocialSecurityStatus_Name;

                economicRegion = new ORM_CMN_EconomicRegion();
                economicRegionRes = economicRegion.Load(Connection, Transaction, socialSecurity.CMN_EconomicRegion_RefID);

                if (economicRegionRes.Status != FR_Status.Success || economicRegion.CMN_EconomicRegionID == Guid.Empty)
                {
                    retValItem.Country_ISOCode_Alpha2 = "";
                    retValList.Add(retValItem);
                    continue;
                }

                countryEconomicRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction,
                    new ORM_CMN_Country_2_EconomicRegion.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID
                    }).FirstOrDefault();

                if (countryEconomicRegion == null)
                {
                    retValItem.Country_ISOCode_Alpha2 = "";
                    retValList.Add(retValItem);
                    continue;
                }

                country = new ORM_CMN_Country();
                countryRes = country.Load(Connection, Transaction, countryEconomicRegion.CMN_Country_RefID);

                if (countryRes.Status != FR_Status.Success || country.CMN_CountryID == Guid.Empty)
                {
                    retValItem.Country_ISOCode_Alpha2 = "";
                    retValList.Add(retValItem);
                    continue;
                }

                retValItem.Country_ISOCode_Alpha2 = country.Country_ISOCode_Alpha2;
                retValList.Add(retValItem);
            }

            returnValue.Result = retValList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CS_GCSSFT_1319_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CS_GCSSFT_1319_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CS_GCSSFT_1319_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CS_GCSSFT_1319_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CS_GCSSFT_1319_Array functionReturn = new FR_L5CS_GCSSFT_1319_Array();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CS_GCSSFT_1319_Array : FR_Base
	{
		public L5CS_GCSSFT_1319[] Result	{ get; set; } 
		public FR_L5CS_GCSSFT_1319_Array() : base() {}

		public FR_L5CS_GCSSFT_1319_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CS_GCSSFT_1319_Array cls_Get_CompulsorySocialSecurityStatuses_For_Tenant(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5CS_GCSSFT_1319_Array result = cls_Get_CompulsorySocialSecurityStatuses_For_Tenant.Invoke(connectionString,securityTicket);
	 return result;
}
*/