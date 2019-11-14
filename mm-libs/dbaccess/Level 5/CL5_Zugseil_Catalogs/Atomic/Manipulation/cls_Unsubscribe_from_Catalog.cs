/* 
 * Generated on 18/11/2014 01:54:52
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
using CL1_CMN_PRO;

namespace CL5_Zugseil_Catalogs.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Unsubscribe_from_Catalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Unsubscribe_from_Catalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_UfC_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_CMN_PRO_SubscribedCatalog catalog = new ORM_CMN_PRO_SubscribedCatalog();
            catalog.Load(Connection, Transaction, Parameter.SubscribedCatalogID);
            catalog.IsDeleted = true;
            catalog.Save(Connection, Transaction);

            ORM_CMN_PRO_Product.Query productsQuery = new ORM_CMN_PRO_Product.Query() { IsDeleted = false, IsImportedFromExternalCatalog = true, IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID, Tenant_RefID = securityTicket.TenantID };
            var products = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, productsQuery);

            if (products != null && products.Count > 0)
            {
                foreach (var product in products)
                {
                    product.IsProductAvailableForOrdering = false;
                    product.Save(Connection, Transaction);

                    ORM_CMN_PRO_Product_Variant.Query variantsQuery = new ORM_CMN_PRO_Product_Variant.Query() { CMN_PRO_Product_RefID = product.CMN_PRO_ProductID, Tenant_RefID = securityTicket.TenantID };
                    var variants = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, variantsQuery).ToList();

                    foreach (var variant in variants)
                    {
                        variant.IsProductAvailableForOrdering = false;
                        variant.Save(Connection, Transaction);
                    }
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_UfC_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_UfC_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_UfC_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_UfC_1352 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Unsubscribe_from_Catalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_UfC_1352 for attribute P_L5CA_UfC_1352
		[DataContract]
		public class P_L5CA_UfC_1352 
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
FR_Guid cls_Unsubscribe_from_Catalog(,P_L5CA_UfC_1352 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Unsubscribe_from_Catalog.Invoke(connectionString,P_L5CA_UfC_1352 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Atomic.Manipulation.P_L5CA_UfC_1352();
parameter.SubscribedCatalogID = ...;

*/
