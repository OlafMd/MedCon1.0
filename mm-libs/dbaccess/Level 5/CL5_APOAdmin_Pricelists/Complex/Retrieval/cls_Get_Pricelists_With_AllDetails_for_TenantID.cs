/* 
 * Generated on 11/29/2013 10:39:26 AM
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
using System.Runtime.Serialization;
using CL2_Price.Atomic.Retrieval;
using CL1_CMN;
using CL1_CMN_SLS;

namespace CL5_APOAdmin_Pricelists.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Pricelists_With_AllDetails_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Pricelists_With_AllDetails_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PL_GPWADfT_1720_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PL_GPWADfT_1720_Array();
			//Put your code here

            List<L5PL_GPWADfT_1720> finalList = new List<L5PL_GPWADfT_1720>();

            P_L2PL_GAPfToP_1723 paramPricelists = new P_L2PL_GAPfToP_1723();
            var pricelists = cls_Get_AllPricelists_For_TenantID_or_PricelistID.Invoke(Connection, paramPricelists, securityTicket).Result;
            
            Guid defaultPricelist = Guid.Empty;
            var tenantQuery = new ORM_CMN_Tenant.Query();
            tenantQuery.Tenant_RefID = securityTicket.TenantID;
            tenantQuery.CMN_TenantID = securityTicket.TenantID;
            var foundTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery);
            if (foundTenant != null)
            {
                defaultPricelist = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).Single().Customers_DefaultPricelist_RefID;
            }

            foreach (var pricelist in pricelists)
            {
                L5PL_GPWADfT_1720 temp = new L5PL_GPWADfT_1720();
                temp.PricelistDetails = pricelist;

                var releasesQuery = new ORM_CMN_SLS_Pricelist_Release.Query();
                releasesQuery.Tenant_RefID = securityTicket.TenantID;
                releasesQuery.Pricelist_RefID = pricelist.CMN_SLS_PricelistID;
                var foundReleases = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, releasesQuery).ToList();

                P_L2PL_GARfToPID_1730 releasesParam = new P_L2PL_GARfToPID_1730();
                releasesParam.PricelistID = pricelist.CMN_SLS_PricelistID;
                L2PL_GARfToPID_1730[] releasesArray = cls_Get_AllReleases_for_TenantID_ID_or_PricelistID.Invoke(Connection, Transaction, releasesParam).Result;

                temp.Releases = new L2PL_GARfToPID_1730[releasesArray.Length]; 

                for (int i = 0; i < releasesArray.Length; i++)
                {
                    temp.Releases[i] = releasesArray[i];
                }

                temp.IsDefault = pricelist.CMN_SLS_PricelistID == defaultPricelist;

                finalList.Add(temp);
            }

            returnValue.Result = finalList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PL_GPWADfT_1720_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PL_GPWADfT_1720_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PL_GPWADfT_1720_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PL_GPWADfT_1720_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PL_GPWADfT_1720_Array functionReturn = new FR_L5PL_GPWADfT_1720_Array();
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

				throw new Exception("Exception occured in method cls_Get_Pricelists_With_AllDetails_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PL_GPWADfT_1720_Array : FR_Base
	{
		public L5PL_GPWADfT_1720[] Result	{ get; set; } 
		public FR_L5PL_GPWADfT_1720_Array() : base() {}

		public FR_L5PL_GPWADfT_1720_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PL_GPWADfT_1720 for attribute L5PL_GPWADfT_1720
		[DataContract]
		public class L5PL_GPWADfT_1720 
		{
			//Standard type parameters
			[DataMember]
			public L2PL_GARfToPID_1730[] Releases { get; set; } 
			[DataMember]
			public L2PL_GAPfToP_1723 PricelistDetails { get; set; } 
			[DataMember]
			public Boolean IsDefault { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PL_GPWADfT_1720_Array cls_Get_Pricelists_With_AllDetails_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PL_GPWADfT_1720_Array invocationResult = cls_Get_Pricelists_With_AllDetails_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

