/* 
 * Generated on 6/30/2014 12:02:20 PM
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
using CL3_Articles.Atomic.Retrieval;
using CL1_CMN_PRO;
using CL2_Price.Atomic.Retrieval;

namespace CL3_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WebShopArticles_for_ArticleGroup.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WebShopArticles_for_ArticleGroup
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GWSAfAG_0908_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GWSAfAG_0908 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5AR_GWSAfAG_0908_Array();

            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfT_0942
            {
                ActiveComponent = Parameter.ActiveComponent,
                ActiveComponentStartWith = Parameter.ActiveComponentStartWith,
                CustomArticlesGroupGlobalPropertyID = Parameter.ArticlesGroupGlobalPropertyID,
                DosageFormQuery = Parameter.DosageFormQuery,
                GeneralQuery = Parameter.GeneralQuery,
                IsAvailableForOrdering = true,
                LanguageID = Parameter.LanguageID,
                ProducerName = Parameter.ProducerName,
                ProductNameStartWith = Parameter.ProductNameStartWith,
                PZNQuery = Parameter.PZNQuery,
                UnitQuery = Parameter.UnitQuery,
            };

            List<L3AR_GAfT_0942> articles = cls_Get_Articles_for_Tenant.Invoke(Connection, Transaction, paramArticles, securityTicket).Result.ToList();

            #region Get Prices

            var subscribedCatalogID = articles.Select(i => i.IfImportedFromExternalCatalog_CatalogSubscription_RefID).Distinct().SingleOrDefault();

            var subscribedCatalog = new ORM_CMN_PRO_SubscribedCatalog();
            subscribedCatalog.Load(Connection,Transaction, subscribedCatalogID);

            var param = new P_L2PR_GPVfSC_1424()
            {
                SubscribedCatalogITL = subscribedCatalog.CatalogCodeITL
            };

            var prices = cls_Get_PriceValues_for_SubscribedCatalogITL.Invoke(Connection, Transaction, param, securityTicket).Result;
            #endregion

            List<L5AR_GWSAfAG_0908> results = new List<L5AR_GWSAfAG_0908>();
            foreach (var article in articles)
            {
                var articlesWithPrices = new L5AR_GWSAfAG_0908();

                articlesWithPrices.Article = article;
                articlesWithPrices.Price = prices.Where(x => x.CMN_PRO_Product_RefID == article.CMN_PRO_ProductID).Select(j => j.PriceAmount).SingleOrDefault();
                results.Add(articlesWithPrices);
            }

            returnValue.Result = results.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GWSAfAG_0908_Array Invoke(string ConnectionString,P_L5AR_GWSAfAG_0908 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GWSAfAG_0908_Array Invoke(DbConnection Connection,P_L5AR_GWSAfAG_0908 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GWSAfAG_0908_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GWSAfAG_0908 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GWSAfAG_0908_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GWSAfAG_0908 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GWSAfAG_0908_Array functionReturn = new FR_L5AR_GWSAfAG_0908_Array();
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

				throw new Exception("Exception occured in method cls_Get_WebShopArticles_for_ArticleGroup",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GWSAfAG_0908_Array : FR_Base
	{
		public L5AR_GWSAfAG_0908[] Result	{ get; set; } 
		public FR_L5AR_GWSAfAG_0908_Array() : base() {}

		public FR_L5AR_GWSAfAG_0908_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GWSAfAG_0908 for attribute P_L5AR_GWSAfAG_0908
		[DataContract]
		public class P_L5AR_GWSAfAG_0908 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public string ProductNameStartWith { get; set; } 
			[DataMember]
			public string ProducerName { get; set; } 
			[DataMember]
			public string GeneralQuery { get; set; } 
			[DataMember]
			public string DosageFormQuery { get; set; } 
			[DataMember]
			public string UnitQuery { get; set; } 
			[DataMember]
			public string PZNQuery { get; set; } 
			[DataMember]
			public string ActiveComponent { get; set; } 
			[DataMember]
			public string ActiveComponentStartWith { get; set; } 
			[DataMember]
			public string ArticlesGroupGlobalPropertyID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GWSAfAG_0908 for attribute L5AR_GWSAfAG_0908
		[DataContract]
		public class L5AR_GWSAfAG_0908 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfT_0942 Article { get; set; } 
			[DataMember]
			public decimal Price { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GWSAfAG_0908_Array cls_Get_WebShopArticles_for_ArticleGroup(,P_L5AR_GWSAfAG_0908 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GWSAfAG_0908_Array invocationResult = cls_Get_WebShopArticles_for_ArticleGroup.Invoke(connectionString,P_L5AR_GWSAfAG_0908 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L5AR_GWSAfAG_0908();
parameter.LanguageID = ...;
parameter.ProductNameStartWith = ...;
parameter.ProducerName = ...;
parameter.GeneralQuery = ...;
parameter.DosageFormQuery = ...;
parameter.UnitQuery = ...;
parameter.PZNQuery = ...;
parameter.ActiveComponent = ...;
parameter.ActiveComponentStartWith = ...;
parameter.ArticlesGroupGlobalPropertyID = ...;

*/
