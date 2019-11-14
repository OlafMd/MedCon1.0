/* 
 * Generated on 03.11.2014 19:14:52
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
using CL3_Price.Complex.Retrieval;
using CL3_ABDA.Atomic.Retrieval;
using CL3_ABDA.Utils;

namespace CL3_ABDA.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ABDA_GAAMTMfSC_1714 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ABDA_GAAMTMfSC_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3ABDA_GAAMTMfSC_1714();
            returnValue.Result = new L3ABDA_GAAMTMfSC_1714();

            #region GetAbdaArticles

            var abdaParam = new P_L3ABDA_GAAfSC_1147()
            {
                Conditions = Parameter.Conditions,
                Order = Parameter.Order,
                FromArticle = Parameter.FromArticle,
                NumberOfArticles = Parameter.NumberOfArticles,
            };

            var abdaArticles = cls_Get_ABDA_Articles_for_SearchConditions.Invoke(Connection, Transaction, abdaParam, securityTicket).Result.Articles;

            #endregion

            #region GetStandartPrices

            L3PR_GSPfPITLL_1258 standardPrices = new L3PR_GSPfPITLL_1258();
            if (abdaArticles.Count() != 0)
            {
                var spParam = new P_L3PR_GSPfPITLL_1258()
                {
                    ProductITLList = abdaArticles.Select(i => i.ProductITL).ToArray()
                };

                standardPrices = cls_Get_StandardPrices_for_ProductITLList.Invoke(Connection, Transaction, spParam, securityTicket).Result;
            }

            #endregion

            #region Get All Articles From OmniDB 

            var omniDBArticles = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            #endregion

            #region Prepare result

            List<ArticleMainTableModel> abdaResult = new List<ArticleMainTableModel>();
            foreach (var article in abdaArticles)
            {
                var standardPrice = standardPrices.Prices.SingleOrDefault(i=>i.ProductITL == article.ProductITL);

                var omniDBArticle = omniDBArticles.SingleOrDefault(i=>i.ProductITL == article.ProductITL);

                var product = new ArticleMainTableModel();
                product.ProductID = (omniDBArticle != null) ? omniDBArticle.CMN_PRO_ProductID : Guid.Empty;
                product.ProductITL = article.ProductITL;
                product.ProductName = article.Name;
                product.ProductNumber = article.Code;
                product.DosageFormName = article.Healthcare.DosageForm;
                product.Unit = article.Packaging.Unit;
                product.UnitAmount = article.Packaging.Amount;
                product.ABDAPrice = article.GetDefaultPrice().Value;
                product.SalesPrice = standardPrice == null ? 0 : standardPrice.SalesPrice;
                product.ProducerName = article.Producer;
                product.ActiveComponents = new List<ActiveComponents>();
                foreach (var ac in article.Healthcare.Components)
                {
                    foreach (var sub in ac.Substances)
                    {
                        product.ActiveComponents.Add(
                            new ActiveComponents
                            {
                                SubstanceName = sub.Name,
                                IsActive = sub.Active
                            });
                    }
                }
                abdaResult.Add(product);
            }

            #endregion

            returnValue.Result.Articles = abdaResult.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3ABDA_GAAMTMfSC_1714 Invoke(string ConnectionString,P_L3ABDA_GAAMTMfSC_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAMTMfSC_1714 Invoke(DbConnection Connection,P_L3ABDA_GAAMTMfSC_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ABDA_GAAMTMfSC_1714 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ABDA_GAAMTMfSC_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ABDA_GAAMTMfSC_1714 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ABDA_GAAMTMfSC_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ABDA_GAAMTMfSC_1714 functionReturn = new FR_L3ABDA_GAAMTMfSC_1714();
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

				throw new Exception("Exception occured in method cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ABDA_GAAMTMfSC_1714 : FR_Base
	{
		public L3ABDA_GAAMTMfSC_1714 Result	{ get; set; }

		public FR_L3ABDA_GAAMTMfSC_1714() : base() {}

		public FR_L3ABDA_GAAMTMfSC_1714(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ABDA_GAAMTMfSC_1714 for attribute P_L3ABDA_GAAMTMfSC_1714
		[DataContract]
		public class P_L3ABDA_GAAMTMfSC_1714 
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

		}
		#endregion
		#region SClass L3ABDA_GAAMTMfSC_1714 for attribute L3ABDA_GAAMTMfSC_1714
		[DataContract]
		public class L3ABDA_GAAMTMfSC_1714 
		{
			//Standard type parameters
			[DataMember]
			public ArticleMainTableModel[] Articles { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ABDA_GAAMTMfSC_1714 cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions(,P_L3ABDA_GAAMTMfSC_1714 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ABDA_GAAMTMfSC_1714 invocationResult = cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions.Invoke(connectionString,P_L3ABDA_GAAMTMfSC_1714 Parameter,securityTicket);
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
var parameter = new CL3_ABDA.Complex.Retrieval.P_L3ABDA_GAAMTMfSC_1714();
parameter.Conditions = ...;
parameter.Order = ...;
parameter.FromArticle = ...;
parameter.NumberOfArticles = ...;

*/
