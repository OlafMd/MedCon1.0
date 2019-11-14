/* 
 * Generated on 5/6/2014 5:06:10 PM
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
using PlainElastic.Net.Queries;
using BOp.CatalogAPI.data;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_CMN_PRO;
using BOp.CatalogAPI;
using CL3_Price.Complex.Retrieval;
using CL3_ABDA.Utils;

namespace CL3_ABDA.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ABDA_Products_For_SearchConditions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ABDA_Products_For_SearchConditions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ABDA_GAPfSC_1435 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ABDA_GAPfSC_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3ABDA_GAPfSC_1435();
            returnValue.Result = new L3ABDA_GAPfSC_1435();
            returnValue.Result.Result = new ABDASearchResult();
            returnValue.Result.Result.Products = new List<ABDAProduct>();

            string catalogITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA);

            var sbsCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, new ORM_CMN_PRO_SubscribedCatalog.Query()
            {
                CatalogCodeITL = catalogITL,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();

            if (sbsCatalog == null)
                return returnValue;

            string query = new QueryBuilder<Product>()
            .From(Parameter.pageIndex * Parameter.pageSize)
            .Size(Parameter.pageSize)
            .Query(q => q
                .Bool(b => b
                     .Must(m => m
                        .QueryString(qs => qs.Fields(new string[] { SearchCondition.GetFiledName(ProductField.NAME), SearchCondition.GetFiledName(ProductField.CODE) })
                            .Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.NAME)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.CODE)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.CODE)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.UNIT)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.UNIT)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.DOSAGE_FORM)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.DOSAGE_FORM)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.SUBSTANCE)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.SUBSTANCE)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.DISTRIBUTION_STATUS)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.DISTRIBUTION_STATUS)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.PRODUCER)).Query(SearchCondition.GetQueryForField(Parameter.Conditions, ProductField.PRODUCER)))
                        .Prefix(p => p.Field(SearchCondition.GetFiledName(ProductField.NAME_TOKEN)).Prefix(SearchCondition.GetPrefixForField(Parameter.Conditions, ProductField.NAME_TOKEN)))
                        )
                )
             )
            .Sort(s => s
                .Field(SearchCondition.GetFiledName(Parameter.Order.field), (Parameter.Order.order == SortingOrder.ASC) ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc))
            .BuildBeautified();

            var ProductService = CatalogServiceFactory.GetProductService();
            
            List<Product> retrievedProducts = new List<Product>();

            int hitsTotal;
            
            bool IsPartOFDefaultStock = Parameter.Conditions.Any(x => x.field == ProductField.IS_PART_OF_DEFAULT_STOCK && x.query == "true");

            
            if (IsPartOFDefaultStock)
            {
                List<string> ITLs = new List<string>();
                ITLs = cls_Get_ITLS_for_Products_HaveFlag_IsProductPartOfDefaultStock.Invoke(Connection, Transaction, securityTicket).Result.Select(x => x.ProductITL).ToList();
                ProductDetailsRequest requestWithITLS = new ProductDetailsRequest { CatalogCode = catalogITL, ProductIDs = ITLs };
                
                var resWithITLS = ProductService.GetProductDetails(requestWithITLS);

                retrievedProducts = resWithITLS.ProductDetails.
                     Where(x => !Parameter.Conditions.Any(y => y.field == ProductField.PRODUCER &&  !string.IsNullOrEmpty(y.query)) || 
                       x.Producer.ToLower().Contains(Parameter.Conditions.SingleOrDefault(y => y.field == ProductField.PRODUCER).query.ToLower() ))

                    .Where(x => !(Parameter.Conditions.Any(y =>  y.field == ProductField.DOSAGE_FORM && !string.IsNullOrEmpty(y.query)))  || 
                       (x.Healthcare.DosageForm != null && x.Healthcare.DosageForm.ToLower().Contains(Parameter.Conditions.SingleOrDefault(y =>  y.field == ProductField.DOSAGE_FORM).query.ToLower()) )) 
                                       
                    .Where(x => !Parameter.Conditions.Any(y => y.field == ProductField.NAME &&  !string.IsNullOrEmpty(y.query)) || 
                       x.Name.ToLower().Contains(Parameter.Conditions.SingleOrDefault(y => y.field == ProductField.NAME).query.ToLower() ))

                    .Where(x => !Parameter.Conditions.Any(y => y.field == ProductField.CODE &&  !string.IsNullOrEmpty(y.query)) ||
                       x.Code.ToLower().Contains(Parameter.Conditions.SingleOrDefault(y => y.field == ProductField.CODE).query.ToLower() ))

                    .Where(x => !Parameter.Conditions.Any(y => y.field == ProductField.UNIT  &&  !string.IsNullOrEmpty(y.query)) || 
                       x.Packaging.Unit.ToLower().Contains(Parameter.Conditions.SingleOrDefault(y => y.field == ProductField.UNIT).query.ToLower()))
                 .ToList();

                hitsTotal = retrievedProducts.Count();

            }
            else
            {
                ProductQueryRequest request = new ProductQueryRequest() { CatalogCode = catalogITL };
                var res = ProductService.QueryProducts(request, query);
                hitsTotal = res.hits.total;
                retrievedProducts = res.Documents.ToList();
            }
            

            var catalogInfoRequest = new CatalogInfoRequest() { CatalogCode = catalogITL };
            var catalogService = CatalogServiceFactory.GetCatalogService();
            var catalogInfo = catalogService.GetCatalogInfo(catalogInfoRequest);

            // Find currency symbol
            var currencySymbol = string.Empty;
            if (catalogInfo != null && catalogInfo.CatalogInfo != null)
            {
                var currency = CL1_CMN.ORM_CMN_Currency.Query.Search(Connection, Transaction,
                    new CL1_CMN.ORM_CMN_Currency.Query
                    {
                        ISO4127 = catalogInfo.CatalogInfo.Currency,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                if (currency != null)
                    currencySymbol = currency.Symbol;
            }



            #region GetStandartPrices 

            L3PR_GSPfPITLL_1258 standardPrices = new L3PR_GSPfPITLL_1258();
            if (retrievedProducts.Count() != 0)
            {
                var spParam = new P_L3PR_GSPfPITLL_1258()
                {
                    ProductITLList = retrievedProducts.Select(i => i.ProductITL).ToArray()
                };

                standardPrices = cls_Get_StandardPrices_for_ProductITLList.Invoke(Connection, Transaction, spParam, securityTicket).Result;
            }

            #endregion


            // Set ABDA products from Catalog Products
            var abdaProducts = new List<ABDAProduct>();
            foreach (var product in retrievedProducts)
            {
                var abdaProduct = new ABDAProduct();
                abdaProduct.Product = product;
                abdaProduct.ABDAPrice = product.GetDefaultPrice();
                abdaProduct.Prices = standardPrices.Prices.Where(i=>i.ProductITL == product.ProductITL).SingleOrDefault();
                abdaProduct.CurrencySymbol = currencySymbol;
                abdaProduct.Producer = product.Producer;
                abdaProducts.Add(abdaProduct);
            }

            // Set ABDA results
            returnValue.Result.Result = new ABDASearchResult()
            {
                hitCount = hitsTotal,
                Products = abdaProducts
            };

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ABDA_GAPfSC_1435 Invoke(string ConnectionString,P_L3ABDA_GAPfSC_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAPfSC_1435 Invoke(DbConnection Connection,P_L3ABDA_GAPfSC_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAPfSC_1435 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ABDA_GAPfSC_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ABDA_GAPfSC_1435 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ABDA_GAPfSC_1435 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ABDA_GAPfSC_1435 functionReturn = new FR_L3ABDA_GAPfSC_1435();
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

				throw new Exception("Exception occured in method cls_Get_ABDA_Products_For_SearchConditions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ABDA_GAPfSC_1435 : FR_Base
	{
		public L3ABDA_GAPfSC_1435 Result	{ get; set; }

		public FR_L3ABDA_GAPfSC_1435() : base() {}

		public FR_L3ABDA_GAPfSC_1435(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ABDA_GAPfSC_1435 for attribute P_L3ABDA_GAPfSC_1435
		[DataContract]
		public class P_L3ABDA_GAPfSC_1435 
		{
			//Standard type parameters
			[DataMember]
			public SearchCondition[] Conditions { get; set; } 
			[DataMember]
			public SearchOrder Order { get; set; } 
			[DataMember]
			public int pageSize { get; set; } 
			[DataMember]
			public int pageIndex { get; set; } 

		}
		#endregion
		#region SClass L3ABDA_GAPfSC_1435 for attribute L3ABDA_GAPfSC_1435
		[DataContract]
		public class L3ABDA_GAPfSC_1435 
		{
			//Standard type parameters
			[DataMember]
			public ABDASearchResult Result { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ABDA_GAPfSC_1435 cls_Get_ABDA_Products_For_SearchConditions(,P_L3ABDA_GAPfSC_1435 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ABDA_GAPfSC_1435 invocationResult = cls_Get_ABDA_Products_For_SearchConditions.Invoke(connectionString,P_L3ABDA_GAPfSC_1435 Parameter,securityTicket);
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
var parameter = new CL3_ABDA.Atomic.Retrieval.P_L3ABDA_GAPfSC_1435();
parameter.Conditions = ...;
parameter.Order = ...;
parameter.pageSize = ...;
parameter.pageIndex = ...;

*/
