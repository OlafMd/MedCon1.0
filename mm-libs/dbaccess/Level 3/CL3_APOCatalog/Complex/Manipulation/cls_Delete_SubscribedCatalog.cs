/* 
 * Generated on 3/12/2014 3:16:39 PM
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
using CL1_CMN_SLS;
using CL1_CMN_PRO;

namespace CL3_APOCatalog.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_SubscribedCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_SubscribedCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3CA_DIC_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            var subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
            subscribedCatalog.Load(Connection, Transaction, Parameter.SubscribedCatalogID);

            subscribedCatalog.IsDeleted = true;
            subscribedCatalog.Save(Connection, Transaction);

            /*
             * @all products from this catalog are not available anymore
             * */
            var productQuery = new ORM_CMN_PRO_Product.Query();
            productQuery.Tenant_RefID = securityTicket.TenantID;
            productQuery.IfImportedFromExternalCatalog_CatalogSubscription_RefID = subscribedCatalog.CMN_PRO_SubscribedCatalogID;
            productQuery.IsDeleted = false;

            var productList = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productQuery).ToList();

            foreach (var product in productList)
            {
                product.IsProductAvailableForOrdering = false;
                product.Save(Connection, Transaction);
            }

            /*
           * @delete priceList and all products prices
            * */

            var priceReleaseQuery = new ORM_CMN_SLS_Pricelist_Release.Query();
            priceReleaseQuery.Tenant_RefID = securityTicket.TenantID;
            priceReleaseQuery.CMN_SLS_Pricelist_ReleaseID = subscribedCatalog.SubscribedCatalog_PricelistRelease_RefID;
            priceReleaseQuery.IsDeleted = false;

            var priceRelease = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, priceReleaseQuery).First();
            priceRelease.IsDeleted = true;

            var priceListQuery = new ORM_CMN_SLS_Pricelist.Query();
            priceListQuery.Tenant_RefID = securityTicket.TenantID;
            priceListQuery.CMN_SLS_PricelistID = priceRelease.Pricelist_RefID;
            priceListQuery.IsDeleted = false;

            var priceList = ORM_CMN_SLS_Pricelist.Query.Search(Connection, Transaction, priceListQuery).First();
            priceList.IsDeleted = true;
            priceList.Save(Connection, Transaction);

            var priceQuery = new ORM_CMN_SLS_Price.Query();
            priceQuery.Tenant_RefID = securityTicket.TenantID;
            priceQuery.PricelistRelease_RefID = priceRelease.Pricelist_RefID;
            priceQuery.IsDeleted = false;

            var prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, priceQuery).ToList();

            foreach (var price in prices)
            {
                price.IsDeleted = true;
                price.Save(Connection, Transaction);
            }

            priceRelease.Save(Connection, Transaction);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3CA_DIC_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3CA_DIC_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CA_DIC_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CA_DIC_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_SubscribedCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CA_DIC_1511 for attribute P_L3CA_DIC_1511
		[DataContract]
		public class P_L3CA_DIC_1511 
		{
			//Standard type parameters
			[DataMember]
			public Guid SubscribedCatalogID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_SubscribedCatalog(,P_L3CA_DIC_1511 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_SubscribedCatalog.Invoke(connectionString,P_L3CA_DIC_1511 Parameter,securityTicket);
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
var parameter = new CL3_APOCatalog.Complex.Manipulation.P_L3CA_DIC_1511();
parameter.SubscribedCatalogID = ...;

*/
