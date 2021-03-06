/* 
 * Generated on 10/30/2013 1:25:54 PM
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
    /// var result = cls_Get_CompulsorySocialSecurityStatus_For_CompulsorySocialSecurityStatusID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CompulsorySocialSecurityStatus_For_CompulsorySocialSecurityStatusID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CS_GCSSFCS_1320 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CS_GCSSFCS_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5CS_GCSSFCS_1320();

            ORM_CMN_PER_CompulsorySocialSecurityStatus.Query securityStatusQuery = new ORM_CMN_PER_CompulsorySocialSecurityStatus.Query();
            securityStatusQuery.CMN_PER_CompulsorySocialSecurityStatusID = Parameter.CMN_PER_CompulsorySocialSecurityStatusID;
            securityStatusQuery.IsDeleted = false;
            securityStatusQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_PER_CompulsorySocialSecurityStatus> securityStatuses = ORM_CMN_PER_CompulsorySocialSecurityStatus.Query.Search(Connection, Transaction, securityStatusQuery);
            if (securityStatuses != null && securityStatuses.Count != 0)
            {
                L5CS_GCSSFT_1319 securityStatusItem = new L5CS_GCSSFT_1319();

                ORM_CMN_PER_CompulsorySocialSecurityStatus securityStatus = securityStatuses[0];
                securityStatusItem.CMN_PER_CompulsorySocialSecurityStatusID = securityStatus.CMN_PER_CompulsorySocialSecurityStatusID;
                securityStatusItem.SocialSecurityStatus_Name = securityStatus.SocialSecurityStatus_Name;
                securityStatusItem.GlobalPropertyMatchingID = securityStatus.GlobalPropertyMatchingID;
                securityStatusItem.SocialSecurityStatus_Description = securityStatus.SocialSecurityStatus_Description;
                securityStatusItem.SocialSecurityStatus_Code = securityStatus.SocialSecurityStatus_Code;
                securityStatusItem.Country_ISOCode_Alpha2 = Get_CountryISO_For_SocialSecurity(Connection, Transaction, securityTicket, securityStatus);
                returnValue.Result = new L5CS_GCSSFCS_1320();
                returnValue.Result.CompulsorySocialSecurityStatus = securityStatusItem;
            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

        #region Get_CountryISO_For_SocialSecurity
        private static string Get_CountryISO_For_SocialSecurity(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, ORM_CMN_PER_CompulsorySocialSecurityStatus socialSecurity)
        {
            string ISO = "";

            ORM_CMN_EconomicRegion economicRegion;
            FR_Base economicRegionRes;
            ORM_CMN_Country_2_EconomicRegion countryEconomicRegion;
            ORM_CMN_Country country;
            FR_Base countryRes;

            economicRegion = new ORM_CMN_EconomicRegion();
            economicRegionRes = economicRegion.Load(Connection, Transaction, socialSecurity.CMN_EconomicRegion_RefID);

            if (economicRegionRes.Status != FR_Status.Success || economicRegion.CMN_EconomicRegionID == Guid.Empty)
                return "";

            countryEconomicRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction,
                new ORM_CMN_Country_2_EconomicRegion.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID
                }).FirstOrDefault();

            if (countryEconomicRegion == null)
                return "";

            country = new ORM_CMN_Country();
            countryRes = country.Load(Connection, Transaction, countryEconomicRegion.CMN_Country_RefID);

            if (countryRes.Status != FR_Status.Success || country.CMN_CountryID == Guid.Empty)
                return "";

            ISO = country.Country_ISOCode_Alpha2;

            return ISO;
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CS_GCSSFCS_1320 Invoke(string ConnectionString,P_L5CS_GCSSFCS_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CS_GCSSFCS_1320 Invoke(DbConnection Connection,P_L5CS_GCSSFCS_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CS_GCSSFCS_1320 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CS_GCSSFCS_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CS_GCSSFCS_1320 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CS_GCSSFCS_1320 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CS_GCSSFCS_1320 functionReturn = new FR_L5CS_GCSSFCS_1320();
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
				throw new Exception("Exception occured in method cls_Get_CompulsorySocialSecurityStatus_For_CompulsorySocialSecurityStatusID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CS_GCSSFCS_1320 : FR_Base
	{
		public L5CS_GCSSFCS_1320 Result	{ get; set; }

		public FR_L5CS_GCSSFCS_1320() : base() {}

		public FR_L5CS_GCSSFCS_1320(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CS_GCSSFCS_1320 cls_Get_CompulsorySocialSecurityStatus_For_CompulsorySocialSecurityStatusID(,P_L5CS_GCSSFCS_1320 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CS_GCSSFCS_1320 invocationResult = cls_Get_CompulsorySocialSecurityStatus_For_CompulsorySocialSecurityStatusID.Invoke(connectionString,P_L5CS_GCSSFCS_1320 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_CompulsorySocialSecurityStatuses.Complex.Retrieval.P_L5CS_GCSSFCS_1320();
parameter.CMN_PER_CompulsorySocialSecurityStatusID = ...;

*/