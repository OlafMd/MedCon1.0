/* 
 * Generated on 03.11.2014 17:04:23
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
using BOp.CatalogAPI.data;
using CL3_ABDA.Utils;
using BOp.CatalogAPI;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_CMN_PRO;
using PlainElastic.Net.Queries;

namespace CL3_ABDA.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ABDA_Articles_for_SearchConditions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ABDA_Articles_for_SearchConditions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ABDA_GAAfSC_1147 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ABDA_GAAfSC_1147 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3ABDA_GAAfSC_1147();
            returnValue.Result = new L3ABDA_GAAfSC_1147();

            #region Check ABDA Catalog Subscription

            string catalogITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA);

            var sbsCatalog = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, new ORM_CMN_PRO_SubscribedCatalog.Query()
            {
                CatalogCodeITL = catalogITL,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();

            if (sbsCatalog == null)
                return returnValue;

            #endregion

            string query = new QueryBuilder<Product>()
            .From(Parameter.FromArticle)
            .Size(Parameter.NumberOfArticles)
            .Query(q => q
                .Bool(b => b
                     .Must(m => m
                        .QueryString(qs => qs.Fields(new string[] { SearchCondition.GetFiledName(ProductField.NAME), SearchCondition.GetFiledName(ProductField.CODE) }).Query(SearchCondition.GetConditionForSearchText(Parameter.Conditions.PZNOrName)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.UNIT)).Query(SearchCondition.GetConditionForSearchText(Parameter.Conditions.Unit)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.DOSAGE_FORM)).Query(SearchCondition.GetConditionForSearchText(Parameter.Conditions.DosageForm)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.SUBSTANCE)).Query(SearchCondition.GetConditionForSearchText(Parameter.Conditions.ActiveComponent)))
                        .QueryString(qs => qs.Fields(SearchCondition.GetFiledName(ProductField.PRODUCER)).Query(SearchCondition.GetConditionForSearchText(Parameter.Conditions.ProducerName)))
                        .Prefix(p => p.Field(SearchCondition.GetFiledName(ProductField.NAME_TOKEN)).Prefix(Parameter.Conditions.ProductNameStartWith))
                        )
                )
             )
            .Sort(s => s
                .Field(SearchCondition.GetFiledName(Parameter.Order.field), (Parameter.Order.order == SortingOrder.ASC) ? PlainElastic.Net.SortDirection.asc : PlainElastic.Net.SortDirection.desc))
            .BuildBeautified();


            var ProductService = CatalogServiceFactory.GetProductService();

            if ((bool)Parameter.Conditions.IsDefaultStock)  
            {
                List<string> ITLs = new List<string>();
                ITLs = cls_Get_ITLS_for_Products_HaveFlag_IsProductPartOfDefaultStock.Invoke(Connection, Transaction, securityTicket).Result.Select(x=> x.ProductITL).ToList();
                ProductDetailsRequest requestWithITLS = new ProductDetailsRequest { CatalogCode = catalogITL, ProductIDs = ITLs };
                var resWithITLS = ProductService.GetProductDetails(requestWithITLS);
                returnValue.Result.Articles = resWithITLS.ProductDetails.Where(x => Parameter.Conditions.ProducerName == string.Empty || x.Producer.ToLower().Contains(Parameter.Conditions.ProducerName.ToLower()))
                                                                        .Where(x => (Parameter.Conditions.DosageForm == string.Empty) || (x.Healthcare.DosageForm != null && x.Healthcare.DosageForm.ToLower().Contains(Parameter.Conditions.DosageForm.ToLower())))
                                                                        .Where(x => Parameter.Conditions.PZNOrName == string.Empty || x.Name.ToLower().Contains(Parameter.Conditions.PZNOrName.ToLower()) || x.Code.ToLower().Contains(Parameter.Conditions.PZNOrName.ToLower()))
                                                                        .Where(x => Parameter.Conditions.Unit == string.Empty || x.Packaging.Unit.ToLower().Contains(Parameter.Conditions.Unit.ToLower()))
                                                                        .ToArray();
            } else 
            {
                ProductQueryRequest request = new ProductQueryRequest() { CatalogCode = catalogITL };
                var res = ProductService.QueryProducts(request, query);
                returnValue.Result.Articles = res.Documents.ToArray();
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ABDA_GAAfSC_1147 Invoke(string ConnectionString,P_L3ABDA_GAAfSC_1147 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAfSC_1147 Invoke(DbConnection Connection,P_L3ABDA_GAAfSC_1147 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAfSC_1147 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ABDA_GAAfSC_1147 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ABDA_GAAfSC_1147 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ABDA_GAAfSC_1147 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ABDA_GAAfSC_1147 functionReturn = new FR_L3ABDA_GAAfSC_1147();
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

				throw new Exception("Exception occured in method cls_Get_ABDA_Articles_for_SearchConditions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ABDA_GAAfSC_1147 : FR_Base
	{
		public L3ABDA_GAAfSC_1147 Result	{ get; set; }

		public FR_L3ABDA_GAAfSC_1147() : base() {}

		public FR_L3ABDA_GAAfSC_1147(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ABDA_GAAfSC_1147 for attribute P_L3ABDA_GAAfSC_1147
		[DataContract]
		public class P_L3ABDA_GAAfSC_1147 
		{
			//Standard type parameters
			[DataMember]
			public ArticleSearchCondition Conditions { get; set; } 
			[DataMember]
			public ArticleSearchOrder Order { get; set; } 
			[DataMember]
			public int FromArticle { get; set; } 
			[DataMember]
			public int NumberOfArticles { get; set; } 
			[DataMember]
			public bool? IsProductPartOfDefaultStock { get; set; } 

		}
		#endregion
		#region SClass L3ABDA_GAAfSC_1147 for attribute L3ABDA_GAAfSC_1147
		[DataContract]
		public class L3ABDA_GAAfSC_1147 
		{
			//Standard type parameters
			[DataMember]
			public Product[] Articles { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ABDA_GAAfSC_1147 cls_Get_ABDA_Articles_for_SearchConditions(,P_L3ABDA_GAAfSC_1147 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ABDA_GAAfSC_1147 invocationResult = cls_Get_ABDA_Articles_for_SearchConditions.Invoke(connectionString,P_L3ABDA_GAAfSC_1147 Parameter,securityTicket);
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
var parameter = new CL3_ABDA.Atomic.Retrieval.P_L3ABDA_GAAfSC_1147();
parameter.Conditions = ...;
parameter.Order = ...;
parameter.FromArticle = ...;
parameter.NumberOfArticles = ...;
parameter.IsProductPartOfDefaultStock = ...;

*/
