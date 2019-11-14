/* 
 * Generated on 12/2/2013 12:46:21 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL2_Price.Atomic.Manipulation;
using CL1_CMN_SLS;
using CL1_CMN;

namespace CL5_APOAdmin_Pricelists.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Pricelist_Deep_Delete.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Pricelist_Deep_Delete
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PL_PDD_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            P_L2PL_SP_1407 delPricelistParam = new P_L2PL_SP_1407();
            delPricelistParam = Parameter.Save_CMN_SLS_Pricelist_Param;

            var pricelistReleasesQuery = new ORM_CMN_SLS_Pricelist_Release.Query();
            pricelistReleasesQuery.Pricelist_RefID = delPricelistParam.CMN_SLS_PricelistID;
            pricelistReleasesQuery.Tenant_RefID = securityTicket.TenantID;
            var foundReleases = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, pricelistReleasesQuery);

            //delete all found releases/versions for pricelistID
            foreach (var release in foundReleases)
            {
                release.IsDeleted = true;
                release.Save(Connection, Transaction);
            }

            //check if this is default pricelist
            var tenantQuery = new ORM_CMN_Tenant.Query();
            tenantQuery.CMN_TenantID = securityTicket.TenantID;
            tenantQuery.Tenant_RefID = securityTicket.TenantID;
            var foundTenant = ORM_CMN_Tenant.Query.Search(Connection, Transaction, tenantQuery).SingleOrDefault();

            //if yes, then set default pricelist id to empty guid
            if (foundTenant != null && foundTenant.Customers_DefaultPricelist_RefID == delPricelistParam.CMN_SLS_PricelistID)
            {
                foundTenant.Customers_DefaultPricelist_RefID = Guid.Empty;
            }

            //finaly, delete pricelist
            var deletedPricelist = cls_Save_CMN_SLS_Pricelist.Invoke(Connection, Transaction, delPricelistParam, securityTicket).Result;
            returnValue.Result = deletedPricelist;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PL_PDD_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PL_PDD_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PL_PDD_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PL_PDD_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Pricelist_Deep_Delete",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PL_PDD_1242 for attribute P_L5PL_PDD_1242
		[DataContract]
		public class P_L5PL_PDD_1242 
		{
			//Standard type parameters
			[DataMember]
			public P_L2PL_SP_1407 Save_CMN_SLS_Pricelist_Param { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Pricelist_Deep_Delete(,P_L5PL_PDD_1242 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Pricelist_Deep_Delete.Invoke(connectionString,P_L5PL_PDD_1242 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Pricelists.Complex.Manipulation.P_L5PL_PDD_1242();
parameter.Save_CMN_SLS_Pricelist_Param = ...;

*/
