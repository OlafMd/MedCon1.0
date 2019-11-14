/* 
 * Generated on 12/2/2014 5:10:34 PM
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
using BOp.CatalogAPI;
using BOp.CatalogAPI.data;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using BOp.CatalogAPI.service;
using CL5_Zugseil_Product.Utils;

namespace CL5_Zugseil_Product.Complex.Retrieval
{
	/// <summary>
    /// Get_Catalogs_Products_from_CatalogAPI_for_Tenant
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GCPfCAfT_1705 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GCPfCAfT_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_GCPfCAfT_1705();
			//Put your code here

            L5PR_GCPfCAfT_1705 retVal = new L5PR_GCPfCAfT_1705();
            List<L5PR_GPwCPbSCfT_1237> retValProducts = new List<L5PR_GPwCPbSCfT_1237>();
            
            var _service = CatalogServiceFactory.GetProductService();

            var request = new ProductQueryRequest();
            request.CatalogCode = Parameter.LastIncludedCatalog.CatalogITL;

            if (String.IsNullOrEmpty(Parameter.SearchCriteria))
            {
                retValProducts = GetProductsWithoutSearchCriteria(Connection, Transaction, Parameter, securityTicket, retValProducts, _service, request);
            }
            else
            {
                retValProducts = GetProductsWithSearchCriteria(Connection, Transaction, Parameter, securityTicket, retValProducts, _service, request);
            }

            retVal.Products = retValProducts.ToArray();
            returnValue.Result = retVal;
			return returnValue;
			#endregion UserCode
		}
		#endregion

        #region Support Methods
        private static List<L5PR_GPwCPbSCfT_1237> GetProductsWithoutSearchCriteria(DbConnection Connection, DbTransaction Transaction, P_L5PR_GCPfCAfT_1705 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, List<L5PR_GPwCPbSCfT_1237> retValProducts, IProductService _service, ProductQueryRequest request)
        {
            var query = new QueryBuilder<Product>()
                .From(Parameter.IncludedProductsCountFromLastCatalog)
                .Size(Parameter.Size).BuildBeautified();

            var result = _service.QueryProducts<Product>(request, query);

            retValProducts = PopulateProductList(retValProducts, result, Parameter);

            if (Parameter.CatalogsToInclude != null && Parameter.CatalogsToInclude.Count() > 0)
            {
                var leftedCatalogs = Parameter.CatalogsToInclude.SkipWhile(x => x.CatalogITL != Parameter.LastIncludedCatalog.CatalogITL).ToList();
                if (retValProducts.Count < Parameter.Size && leftedCatalogs.Count > 1)
                {
                    var nextCatalog = leftedCatalogs[1];
                    P_L5PR_GCPfCAfT_1705 newParam = new P_L5PR_GCPfCAfT_1705();
                    newParam.From = 0;
                    newParam.Size = Parameter.Size - retValProducts.Count;
                    newParam.IncludedProductsCountFromLastCatalog = 0;
                    newParam.LastIncludedCatalog = nextCatalog;
                    newParam.CatalogsToInclude = Parameter.CatalogsToInclude;
                    newParam.SearchCriteria = Parameter.SearchCriteria;
                    newParam.LanguageID = Parameter.LanguageID;

                    retValProducts.AddRange(cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(Connection, Transaction, newParam, securityTicket).Result.Products);
                }
            }

            return retValProducts;
        }

        private static List<L5PR_GPwCPbSCfT_1237> GetProductsWithSearchCriteria(DbConnection Connection, DbTransaction Transaction, P_L5PR_GCPfCAfT_1705 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, List<L5PR_GPwCPbSCfT_1237> retValProducts, IProductService _service, ProductQueryRequest request)
        {
            #region Search by ProductName and ProductNumber
            var query = new QueryBuilder<Product>()
                    .From(Parameter.IncludedProductsCountFromLastCatalog)
                    .Size(Parameter.Size)
                    .Query(q => q
                        .Bool(b => b
                            .Must(m => m
                                .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.NAME)).Query(SearchCondition.GetConditionForSearchText(Parameter.SearchCriteria)))
                            )
                        )
                    )
                    .BuildBeautified();

            var result = _service.QueryProducts<Product>(request, query);

            retValProducts = PopulateProductList(retValProducts, result, Parameter);

            if (retValProducts.Count < Parameter.Size)
            {
                query = new QueryBuilder<Product>()
                    .From(0)
                    .Size(Parameter.Size - retValProducts.Count)
                    .Query(q => q
                        .Bool(b => b
                            .Must(m => m
                                .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.CODE)).Query(SearchCondition.GetConditionForSearchText(Parameter.SearchCriteria)))
                            )
                        )
                    )
                    .BuildBeautified();

                result = _service.QueryProducts<Product>(request, query);

                retValProducts = PopulateProductList(retValProducts, result, Parameter);
            } 
            #endregion

            if (Parameter.CatalogsToInclude != null && Parameter.CatalogsToInclude.Count() > 0)
            {
                var leftedCatalogs = Parameter.CatalogsToInclude.SkipWhile(x => x.CatalogITL != Parameter.LastIncludedCatalog.CatalogITL).ToList();
                if (retValProducts.Count < Parameter.Size && leftedCatalogs.Count > 1)
                {
                    var nextCatalog = leftedCatalogs[1];
                    P_L5PR_GCPfCAfT_1705 newParam = new P_L5PR_GCPfCAfT_1705();
                    newParam.From = 0;
                    newParam.Size = Parameter.Size - retValProducts.Count;
                    newParam.IncludedProductsCountFromLastCatalog = 0;
                    newParam.LastIncludedCatalog = nextCatalog;
                    newParam.CatalogsToInclude = Parameter.CatalogsToInclude;
                    newParam.SearchCriteria = Parameter.SearchCriteria;
                    newParam.LanguageID = Parameter.LanguageID;

                    retValProducts.AddRange(cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(Connection, Transaction, newParam, securityTicket).Result.Products);
                }
            }

            return retValProducts;
        }

        private static List<L5PR_GPwCPbSCfT_1237> PopulateProductList(List<L5PR_GPwCPbSCfT_1237> retValProducts, SearchResult<Product> result, P_L5PR_GCPfCAfT_1705 Parameter)
        {
            L5PR_GPwCPbSCfT_1237 productItem;
            foreach (var product in result.Documents)
            {
                productItem = new L5PR_GPwCPbSCfT_1237();

                productItem.ProductITL = product.ProductITL;
                productItem.Product_Number = product.Code;
                productItem.Product_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                productItem.Product_Name.AddEntry(Parameter.LanguageID, product.Name);
                productItem.Product_Description = new Dict() { DictionaryID = Guid.NewGuid() };
                productItem.Product_Description.AddEntry(Parameter.LanguageID, product.Description);
                productItem.CatalogITL = Parameter.LastIncludedCatalog.CatalogITL;
                productItem.CatalogName = Parameter.LastIncludedCatalog.CatalogName;

                retValProducts.Add(productItem);
            }

            return retValProducts;
        } 
        #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GCPfCAfT_1705 Invoke(string ConnectionString,P_L5PR_GCPfCAfT_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GCPfCAfT_1705 Invoke(DbConnection Connection,P_L5PR_GCPfCAfT_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GCPfCAfT_1705 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GCPfCAfT_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GCPfCAfT_1705 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GCPfCAfT_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GCPfCAfT_1705 functionReturn = new FR_L5PR_GCPfCAfT_1705();
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

				throw new Exception("Exception occured in method cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GCPfCAfT_1705 : FR_Base
	{
		public L5PR_GCPfCAfT_1705 Result	{ get; set; }

		public FR_L5PR_GCPfCAfT_1705() : base() {}

		public FR_L5PR_GCPfCAfT_1705(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GCPfCAfT_1705 for attribute P_L5PR_GCPfCAfT_1705
		[DataContract]
		public class P_L5PR_GCPfCAfT_1705 
		{
			//Standard type parameters
			[DataMember]
			public int From { get; set; } 
			[DataMember]
			public int Size { get; set; } 
			[DataMember]
			public P_L5PR_GPwCPbSCfT_1237_CatalogsToInclude LastIncludedCatalog { get; set; } 
			[DataMember]
			public int IncludedProductsCountFromLastCatalog { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public P_L5PR_GPwCPbSCfT_1237_CatalogsToInclude[] CatalogsToInclude { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5PR_GCPfCAfT_1705 for attribute L5PR_GCPfCAfT_1705
		[DataContract]
		public class L5PR_GCPfCAfT_1705 
		{
			//Standard type parameters
			[DataMember]
			public L5PR_GPwCPbSCfT_1237[] Products { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GCPfCAfT_1705 cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant(,P_L5PR_GCPfCAfT_1705 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GCPfCAfT_1705 invocationResult = cls_Get_Catalogs_Products_from_CatalogAPI_for_Tenant.Invoke(connectionString,P_L5PR_GCPfCAfT_1705 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Complex.Retrieval.P_L5PR_GCPfCAfT_1705();
parameter.From = ...;
parameter.Size = ...;
parameter.LastIncludedCatalog = ...;
parameter.IncludedProductsCountFromLastCatalog = ...;
parameter.SearchCriteria = ...;
parameter.CatalogsToInclude = ...;
parameter.LanguageID = ...;

*/
