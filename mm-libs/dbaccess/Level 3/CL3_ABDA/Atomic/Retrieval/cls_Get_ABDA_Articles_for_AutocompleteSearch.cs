/* 
 * Generated on 8/22/2014 1:52:24 PM
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
using CL3_ABDA.Utils;
using BOp.CatalogAPI;
using PlainElastic.Net.Serialization;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_CMN_PRO;

namespace CL3_ABDA.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ABDA_Articles_for_AutocompleteSearch.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ABDA_Articles_for_AutocompleteSearch
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ABDA_GAAfAS_1256_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3ABDA_GAAfAS_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L3ABDA_GAAfAS_1256_Array();

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

            var searchCondition = Parameter.SearchCondition;
            if (!searchCondition.Contains("*"))
                searchCondition = String.Format("*{0}*", searchCondition);

            string query = new QueryBuilder<Product>()
            .From(0)
            .Size(10000)
            .Query(q => q
                .Bool(b => b
                     .Must(m => m
                        .QueryString(qs => qs.Fields(
                            new string[] { 
                                SearchCondition.GetFiledName(ProductField.NAME), SearchCondition.GetFiledName(ProductField.CODE) 
                            })
                            .Query(SearchCondition.GetConditionForSearchText(Parameter.SearchCondition)))
                        )
                )
             )
            .Sort(s => s
                .Field(SearchCondition.GetFiledName(ProductField.NAME), PlainElastic.Net.SortDirection.asc ))
            .BuildBeautified();

            var ProductService = CatalogServiceFactory.GetProductService();
            
            
            ProductQueryRequest request = new ProductQueryRequest() { CatalogCode = catalogITL };
            

            SearchResult<Product> res = ProductService.QueryProducts(request, query);


            var retrievedProducts = res.Documents.ToList();
            var abdaProducts = new List<L3ABDA_GAAfAS_1256>();
            foreach (var product in retrievedProducts)
            {
                abdaProducts.Add(new L3ABDA_GAAfAS_1256()
                {
                    ProductITL = product.ProductITL,
                    ProductNumber = product.Code,
                    ProductName = product.Name
                });
            }

            returnValue.Result = abdaProducts.ToArray();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ABDA_GAAfAS_1256_Array Invoke(string ConnectionString,P_L3ABDA_GAAfAS_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAfAS_1256_Array Invoke(DbConnection Connection,P_L3ABDA_GAAfAS_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAfAS_1256_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ABDA_GAAfAS_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ABDA_GAAfAS_1256_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ABDA_GAAfAS_1256 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ABDA_GAAfAS_1256_Array functionReturn = new FR_L3ABDA_GAAfAS_1256_Array();
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

				throw new Exception("Exception occured in method cls_Get_ABDA_Articles_for_AutocompleteSearch",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ABDA_GAAfAS_1256_Array : FR_Base
	{
		public L3ABDA_GAAfAS_1256[] Result	{ get; set; } 
		public FR_L3ABDA_GAAfAS_1256_Array() : base() {}

		public FR_L3ABDA_GAAfAS_1256_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ABDA_GAAfAS_1256 for attribute P_L3ABDA_GAAfAS_1256
		[DataContract]
		public class P_L3ABDA_GAAfAS_1256 
		{
			//Standard type parameters
			[DataMember]
			public String SearchCondition { get; set; } 

		}
		#endregion
		#region SClass L3ABDA_GAAfAS_1256 for attribute L3ABDA_GAAfAS_1256
		[DataContract]
		public class L3ABDA_GAAfAS_1256 
		{
			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductNumber { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ABDA_GAAfAS_1256_Array cls_Get_ABDA_Articles_for_AutocompleteSearch(,P_L3ABDA_GAAfAS_1256 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ABDA_GAAfAS_1256_Array invocationResult = cls_Get_ABDA_Articles_for_AutocompleteSearch.Invoke(connectionString,P_L3ABDA_GAAfAS_1256 Parameter,securityTicket);
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
var parameter = new CL3_ABDA.Atomic.Retrieval.P_L3ABDA_GAAfAS_1256();
parameter.SearchCondition = ...;

*/
