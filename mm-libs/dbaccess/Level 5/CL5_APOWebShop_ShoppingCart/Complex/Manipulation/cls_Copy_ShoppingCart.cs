/* 
 * Generated on 11/12/2013 04:54:19
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
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using CL5_APOWebShop_ShoppingCart.Complex.Retrieval;

namespace CL5_APOWebShop_ShoppingCart.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Copy_ShoppingCart.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Copy_ShoppingCart
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_CSC_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            // Shopping Cart for Current Office
            #region Shopping Cart for Current Office
            // Create new or get existing shopping cart for this office
            var officeShoppingCart = CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_Office_ShoppingCart.Query
                {
                    ORD_PRC_ShoppingCart_RefID = Parameter.ORD_PRC_ShoppingCartID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            var getParamShoppingCartForCurrentOffice = new P_L5AWSSC_GoCSCfCO_1105();
            getParamShoppingCartForCurrentOffice.OfficeID = officeShoppingCart.CMN_STR_Office_RefID;

            var shoppingCartForCurrentOffice = cls_Get_or_Create_ShoppingCart_for_CurrentOffice.Invoke(Connection, Transaction, getParamShoppingCartForCurrentOffice, securityTicket).Result.Single();

            if (shoppingCartForCurrentOffice.ORD_PRC_Office_ShoppingCartID == Parameter.ORD_PRC_ShoppingCartID)
            {
                throw new Exception("Cannot copy shopping cart because is active shopping cart");
            }
            #endregion

            // Get shopping products for shopping cart id in param
            #region Get shopping products for shopping cart id in param
            var getParam = new P_L5AWSSC_GSPfSC_1650();
            getParam.ShoppingCartID = Parameter.ORD_PRC_ShoppingCartID;

            // Get shopping products for referent shopping cart
            var shoppingProducts = cls_Get_ShoppingProducts_for_ShoppingCartID.Invoke(Connection, Transaction, getParam, securityTicket).Result;
            #endregion

            // Check is product valid
            #region Check is product valid
            foreach (var shopProduct in shoppingProducts.Products)
            {
                // Get product by shopping product
                var product = CL1_CMN_PRO.ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                    new CL1_CMN_PRO.ORM_CMN_PRO_Product.Query
                    {
                        CMN_PRO_ProductID = shopProduct.CMN_PRO_Product_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                    }).SingleOrDefault();

                // Remove product
                if (product == null)
                {
                    shopProduct.CMN_PRO_Product_RefID = Guid.Empty;
                }
                // Check is product valid
                else if (!product.IsProductAvailableForOrdering || !product.IsProduct_Article)
                {
                    // Find a duplicate product
                    var duplicateProduct = CL1_CMN_PRO.ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                    new CL1_CMN_PRO.ORM_CMN_PRO_Product.Query
                    {
                        ProductITL = product.ProductITL,
                        Tenant_RefID = securityTicket.TenantID,
                        IsProduct_Article = true,
                        IsProductAvailableForOrdering = true,
                        IsDeleted = false
                    }).SingleOrDefault();

                    // Remove product
                    if (duplicateProduct == null)
                    {
                        shopProduct.CMN_PRO_Product_RefID = Guid.Empty;
                    }
                    // Change product with a valid product
                    else
                    {
                        shopProduct.CMN_PRO_Product_RefID = duplicateProduct.CMN_PRO_ProductID;
                        shopProduct.CMN_PRO_Product_Release_RefID = Guid.Empty;
                        shopProduct.CMN_PRO_Product_Variant_RefID = Guid.Empty;
                    }
                }
            }
            #endregion

            // Saving Products for current shopping cart
            #region Saving Products for current shopping cart
            var saveParam = new P_L5AWSAR_SSCP_1653();
            var shoppingCart = new List<P_L5AWSAR_SSCP_1653_ShoppingCart>();

            foreach (var item in shoppingProducts.Products)
            {
                // If product is removed
                if (item.CMN_PRO_Product_RefID == Guid.Empty)
                    continue;

                var shoppProductParam = new P_L5AWSAR_SSCP_1653_ShoppingCart();
                var existProduct = shoppingCartForCurrentOffice.Products.FirstOrDefault(x => x.CMN_PRO_Product_RefID == item.CMN_PRO_Product_RefID);

                if (existProduct != null)
                {
                    shoppProductParam.ORD_PRC_ShoppingCart_ProductID = existProduct.ORD_PRC_ShoppingCart_ProductID;
                    shoppProductParam.Quantity = existProduct.Quantity;
                }

                // Add products to a new shopping cart
                shoppProductParam.ORD_PRC_ShoppingCart_RefID = shoppingCartForCurrentOffice.ORD_PRC_ShoppingCartID;
                shoppProductParam.CMN_PRO_Product_RefID = item.CMN_PRO_Product_RefID;
                shoppProductParam.CMN_PRO_Product_Release_RefID = item.CMN_PRO_Product_Release_RefID;
                shoppProductParam.CMN_PRO_Product_Variant_RefID = item.CMN_PRO_Product_Variant_RefID;
                shoppProductParam.Quantity += item.Quantity;
                shoppingCart.Add(shoppProductParam);
            }

            saveParam.ShoppingCart = shoppingCart.ToArray();

            // Save this shopping products
            cls_Save_ShoppingCart_Product.Invoke(Connection, Transaction, saveParam, securityTicket);
            #endregion

            return new FR_Guid(shoppingCartForCurrentOffice.ORD_PRC_ShoppingCartID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AWSSC_CSC_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AWSSC_CSC_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_CSC_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_CSC_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Copy_ShoppingCart",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AWSSC_CSC_1653 for attribute P_L5AWSSC_CSC_1653
		[DataContract]
		public class P_L5AWSSC_CSC_1653 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ShoppingCartID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Copy_ShoppingCart(,P_L5AWSSC_CSC_1653 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Copy_ShoppingCart.Invoke(connectionString,P_L5AWSSC_CSC_1653 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSSC_CSC_1653();
parameter.ORD_PRC_ShoppingCartID = ...;

*/
