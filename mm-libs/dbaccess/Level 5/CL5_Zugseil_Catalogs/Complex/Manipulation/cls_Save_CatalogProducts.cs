/* 
 * Generated on 17/11/2014 02:22:18
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
using CL3_Variant.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CL5_Zugseil_Catalogs.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CatalogProducts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CatalogProducts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CA_SCP_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            foreach (var productID in Parameter.Products)
            {
                ORM_CMN_PRO_Product_Variant.Query variantsQuery = new ORM_CMN_PRO_Product_Variant.Query() { 
                    CMN_PRO_Product_RefID = productID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false                 
                };

                var variants = ORM_CMN_PRO_Product_Variant.Query.Search(Connection, Transaction, variantsQuery).ToList();

                foreach (var variant in variants)
                {
                    ORM_CMN_PRO_Catalog_Product.Query catVersionQuery = new ORM_CMN_PRO_Catalog_Product.Query() { CMN_PRO_Catalog_Revision_RefID = Parameter.CatalogRevisionID, CMN_PRO_Product_RefID = productID, CMN_PRO_Product_Variant_RefID = variant.CMN_PRO_Product_VariantID };
                    var catVersionProduct = ORM_CMN_PRO_Catalog_Product.Query.Search(Connection, Transaction, catVersionQuery);

                    Guid catalogProdID = Guid.Empty;

                    if (catVersionProduct == null || catVersionProduct.Count == 0)
                    {
                        ORM_CMN_PRO_Catalog_Product catProduct = new ORM_CMN_PRO_Catalog_Product();
                        catProduct.CMN_PRO_Catalog_ProductID = Guid.NewGuid();
                        catProduct.CMN_PRO_Catalog_Revision_RefID = Parameter.CatalogRevisionID;
                        catProduct.CMN_PRO_Product_RefID = productID;
                        catProduct.CMN_PRO_Product_Variant_RefID = variant.CMN_PRO_Product_VariantID;
                        catProduct.Tenant_RefID = securityTicket.TenantID;                       
                        catProduct.Save(Connection, Transaction);

                        catalogProdID = catProduct.CMN_PRO_Catalog_ProductID;
                    }
                    else if (catVersionProduct.First().IsDeleted == true)
                    {
                        catVersionProduct.First().IsDeleted = false;
                        catVersionProduct.First().Save(Connection, Transaction);
                    }

                    ORM_CMN_PRO_Catalog_Product_2_ProductGroup cat2prod = new ORM_CMN_PRO_Catalog_Product_2_ProductGroup();
                    cat2prod.AssignmentID = Guid.NewGuid();
                    cat2prod.CMN_PRO_Catalog_Product_RefID = catalogProdID != Guid.Empty ? catalogProdID : catVersionProduct.First().CMN_PRO_Catalog_ProductID;
                    cat2prod.CMN_PRO_Catalog_ProductGroup_RefID = Parameter.CatalogGroupID;
                    cat2prod.Tenant_RefID = securityTicket.TenantID;
                    cat2prod.Save(Connection, Transaction);
                    
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
		public static FR_Guid Invoke(string ConnectionString,P_L5CA_SCP_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CA_SCP_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CA_SCP_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CA_SCP_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CatalogProducts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CA_SCP_1007 for attribute P_L5CA_SCP_1007
		[DataContract]
		public class P_L5CA_SCP_1007 
		{
			//Standard type parameters
			[DataMember]
			public Guid CatalogGroupID { get; set; } 
			[DataMember]
			public Guid CatalogRevisionID { get; set; } 
			[DataMember]
			public Guid[] Products { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CatalogProducts(,P_L5CA_SCP_1007 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CatalogProducts.Invoke(connectionString,P_L5CA_SCP_1007 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Catalogs.Complex.Manipulation.P_L5CA_SCP_1007();
parameter.CatalogGroupID = ...;
parameter.CatalogRevisionID = ...;
parameter.Products = ...;

*/
