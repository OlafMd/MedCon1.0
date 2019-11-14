/* 
 * Generated on 11/25/2014 09:27:01
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
using CL1_CMN_SLS;
using CL1_CMN_PRO;

namespace CL3_Product.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_ImportOrUpdate_Products_for_SubscribedCatalog.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ImportOrUpdate_Products_for_SubscribedCatalog
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_IoUPfSC_1326_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_IoUPfSC_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode
            var returnValue = new FR_L3PR_IoUPfSC_1326_Array();

            //Put your code here
            var importedProducts = new List<L3PR_IoUPfSC_1326>();

            #region ImportOrUpdate Product's BaseData
            P_L3PR_IoUPBD_1614 param = new P_L3PR_IoUPBD_1614();
            param.Products = Parameter.Products.Select(i => i.Product).ToArray();
            var importedProductsBaseData = cls_ImportOrUpdate_Products_BaseData.Invoke(Connection, Transaction, param, securityTicket).Result;
            #endregion

            //TODO: for each product saved, create or update product_2_productGroup
            foreach (var importedProductBaseData in importedProductsBaseData)
            {
                var currentParameter = Parameter.Products.SingleOrDefault(i => i.Product.ProductITL == importedProductBaseData.ProductITL);

                var product = new ORM_CMN_PRO_Product();
                product.Load(Connection, Transaction, importedProductBaseData.ProductID);

                if (!importedProductBaseData.IsAlreadyExisted)
                {
                    product.IfImportedFromExternalCatalog_CatalogSubscription_RefID = Parameter.SubscribedCatalogID;
                    product.IsImportedFromExternalCatalog = true;
                    product.Save(Connection, Transaction);

                    ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                    product_2_productGroup.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    product_2_productGroup.CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID;
                    product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                    product_2_productGroup.Creation_Timestamp = DateTime.Now;
                    product_2_productGroup.Save(Connection, Transaction);
                }
                else
                {
                    #region Update Product_2_ProductGroup
                    var isAlreadyInGroup = ORM_CMN_PRO_Product_2_ProductGroup.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_Product_2_ProductGroup.Query()
                    {
                        CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                        CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    if (!isAlreadyInGroup)
                    {
                        ORM_CMN_PRO_Product_2_ProductGroup product_2_productGroup = new ORM_CMN_PRO_Product_2_ProductGroup();
                        product_2_productGroup.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                        product_2_productGroup.CMN_PRO_ProductGroup_RefID = Parameter.ProductGroupID;
                        product_2_productGroup.Tenant_RefID = securityTicket.TenantID;
                        product_2_productGroup.Creation_Timestamp = DateTime.Now;
                        product_2_productGroup.Save(Connection, Transaction);
                    }
                    #endregion
                }

                #region Default Price

                var price = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Price.Query()
                {
                    PricelistRelease_RefID = Parameter.PriceListReleaseID,
                    CMN_PRO_Product_RefID = product.CMN_PRO_ProductID,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_Currency_RefID = Parameter.CatalogCurrencyID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (price == null)
                {
                    price = new ORM_CMN_SLS_Price();
                    price.CMN_SLS_PriceID = Guid.NewGuid();
                    price.PricelistRelease_RefID = Parameter.PriceListReleaseID;
                    price.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                    price.CMN_Currency_RefID = Parameter.CatalogCurrencyID;
                    price.Tenant_RefID = securityTicket.TenantID;
                    price.Creation_Timestamp = DateTime.Now;
                }

                price.PriceAmount = currentParameter.Price;
                price.Save(Connection, Transaction);

                #endregion

                importedProducts.Add(new L3PR_IoUPfSC_1326()
                {
                    ProductID = product.CMN_PRO_ProductID,
                    ProductITL = product.ProductITL
                });
            }

            returnValue.Result = importedProducts.ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_IoUPfSC_1326_Array Invoke(string ConnectionString,P_L3PR_IoUPfSC_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_IoUPfSC_1326_Array Invoke(DbConnection Connection,P_L3PR_IoUPfSC_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_IoUPfSC_1326_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_IoUPfSC_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_IoUPfSC_1326_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_IoUPfSC_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_IoUPfSC_1326_Array functionReturn = new FR_L3PR_IoUPfSC_1326_Array();
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

				throw new Exception("Exception occured in method cls_ImportOrUpdate_Products_for_SubscribedCatalog",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_IoUPfSC_1326_Array : FR_Base
	{
		public L3PR_IoUPfSC_1326[] Result	{ get; set; } 
		public FR_L3PR_IoUPfSC_1326_Array() : base() {}

		public FR_L3PR_IoUPfSC_1326_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_IoUPfSC_1326 for attribute P_L3PR_IoUPfSC_1326
		[DataContract]
		public class P_L3PR_IoUPfSC_1326 
		{
			[DataMember]
			public P_L3PR_IoUPfSC_1326_Products[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid SubscribedCatalogID { get; set; } 
			[DataMember]
			public Guid CatalogCurrencyID { get; set; } 
			[DataMember]
			public Guid CatalogLanguageID { get; set; } 
			[DataMember]
			public Guid ProductGroupID { get; set; } 
			[DataMember]
			public Guid PriceListReleaseID { get; set; } 

		}
		#endregion
		#region SClass P_L3PR_IoUPfSC_1326_Products for attribute Products
		[DataContract]
		public class P_L3PR_IoUPfSC_1326_Products 
		{
			[DataMember]
			public P_L3PR_IoUPBD_1614_Products Product { get; set; }

			//Standard type parameters
			[DataMember]
			public Decimal Price { get; set; } 

		}
		#endregion
		#region SClass L3PR_IoUPfSC_1326 for attribute L3PR_IoUPfSC_1326
		[DataContract]
		public class L3PR_IoUPfSC_1326 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_IoUPfSC_1326_Array cls_ImportOrUpdate_Products_for_SubscribedCatalog(,P_L3PR_IoUPfSC_1326 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_IoUPfSC_1326_Array invocationResult = cls_ImportOrUpdate_Products_for_SubscribedCatalog.Invoke(connectionString,P_L3PR_IoUPfSC_1326 Parameter,securityTicket);
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
var parameter = new CL3_Product.Complex.Manipulation.P_L3PR_IoUPfSC_1326();
parameter.Products = ...;

parameter.SubscribedCatalogID = ...;
parameter.CatalogCurrencyID = ...;
parameter.CatalogLanguageID = ...;
parameter.ProductGroupID = ...;
parameter.PriceListReleaseID = ...;

*/
