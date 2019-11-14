/* 
 * Generated on 9/9/2014 9:49:35 AM
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
using CL3_ABDA.Utils;
using CL3_ABDA.Complex.Retrieval;
using CL3_Articles.Utils;
using CL3_Articles.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;

namespace CL3_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticlesMainTableModel_for_SearchContitions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticlesMainTableModel_for_SearchContitions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GAMTMfSC_1131 Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GAMTMfSC_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3AR_GAMTMfSC_1131();
            returnValue.Result = new L3AR_GAMTMfSC_1131();

            #region GetAbdaArticles

            var abdaParam = new P_L3ABDA_GAAMTMfSC_1714()
            {
                Conditions = Parameter.Conditions,
                Order = Parameter.Order,
                FromArticle = Parameter.FromArticle,
                NumberOfArticles = Parameter.NumberOfArticles,
            };

            var abdaResult = cls_Get_ABDA_ArticlesMainTableModel_for_SearchContitions.Invoke(Connection, Transaction, abdaParam, securityTicket).Result.Articles;

            #endregion

            #region GetLocalArticles

            //if false, we should return all articles
            Nullable<Boolean> isPartOfDefaultStock = null;
            if (Parameter.Conditions.IsDefaultStock != null && (Boolean)Parameter.Conditions.IsDefaultStock)
                isPartOfDefaultStock = true;

            var localParam = new P_L3AR_GLAfSC_1320();
            localParam.LanguageID = Parameter.LanguageID;
            localParam.ProductNameStartWith = Parameter.Conditions.ProductNameStartWith;
            localParam.ActiveComponentStartWith = Parameter.Conditions.ActiveComponentStartWith;
            localParam.PZNOrName = LocalDBSearchCondition.GetConditionForSearchText( Parameter.Conditions.PZNOrName );
            localParam.DosageForm = LocalDBSearchCondition.GetConditionForSearchText(Parameter.Conditions.DosageForm);
            localParam.Unit = LocalDBSearchCondition.GetConditionForSearchText(Parameter.Conditions.Unit);
            localParam.ProducerName = LocalDBSearchCondition.GetConditionForSearchText(Parameter.Conditions.ProducerName);
            localParam.ActiveComponent = LocalDBSearchCondition.GetConditionForSearchText(Parameter.Conditions.ActiveComponent);
            localParam.IsAvailableForOrdering = Parameter.Conditions.IsAvailableForOrdering;
            localParam.IsDefaultStock = isPartOfDefaultStock;

            var localArticles = cls_Get_LocalArticles_for_SearchConditions.Invoke(Connection, Transaction, localParam, securityTicket).Result;

            switch (Parameter.Order.field)
            {
                case ProductField.CODE:
                    localArticles = localArticles.Where(i => 
                        i.Product_Number.CompareTo(Parameter.SortingCriteriaLastItem) > 0).ToArray();

                    if (abdaResult.Count()==Parameter.NumberOfArticles) 
                        localArticles = localArticles.Where(i => 
                            i.Product_Number.CompareTo(abdaResult.Last().ProductNumber) < 0).ToArray();

                    break;
                case ProductField.NAME_TOKEN:
                    localArticles = localArticles.Where(i =>
                        i.ProductName.CompareTo(Parameter.SortingCriteriaLastItem) > 0).ToArray();

                    if (abdaResult.Count() == Parameter.NumberOfArticles) 
                        localArticles = localArticles.Where(i =>
                            i.ProductName.CompareTo(abdaResult.Last().ProductName) < 0).ToArray();
                    break;
                case ProductField.PRODUCER:
                    localArticles = localArticles.Where(i =>
                        i.ProducerName.CompareTo(Parameter.SortingCriteriaLastItem) > 0).ToArray();

                    if (abdaResult.Count() == Parameter.NumberOfArticles) 
                        localArticles = localArticles.Where(i =>
                            i.ProducerName.CompareTo(abdaResult.Last().ProducerName) < 0).ToArray();
                    break;
                case ProductField.DOSAGE_FORM:
                    localArticles = localArticles.Where(i =>
                        i.DossageFormName.CompareTo(Parameter.SortingCriteriaLastItem) > 0).ToArray();

                    if (abdaResult.Count() == Parameter.NumberOfArticles) 
                        localArticles = localArticles.Where(i =>
                            i.DossageFormName.CompareTo(abdaResult.Last().DosageFormName) < 0).ToArray();
                    break;
                case ProductField.UNIT:
                    localArticles = localArticles.Where(i =>
                        i.UnitIsoCode.CompareTo(Parameter.SortingCriteriaLastItem) > 0).ToArray();

                    if (abdaResult.Count() == Parameter.NumberOfArticles) 
                        localArticles = localArticles.Where(i =>
                            i.UnitIsoCode.CompareTo(abdaResult.Last().Unit) < 0).ToArray();
                    break;
            }
            #endregion

            #region Get StandartPrices for Local Articles

            L3PR_GSPfPITLL_1258 standardPrices = new L3PR_GSPfPITLL_1258();
            if (localArticles.Count() != 0)
            {
                var spParam = new P_L3PR_GSPfPITLL_1258()
                {
                    ProductITLList = localArticles.Select(i => i.ProductITL).ToArray()
                };

                standardPrices = cls_Get_StandardPrices_for_ProductITLList.Invoke(Connection, Transaction, spParam, securityTicket).Result;
            }

            #endregion

            #region Prepare result for local articles

            List<ArticleMainTableModel> localResult = new List<ArticleMainTableModel>();
            foreach (var article in localArticles)
            {
                var standardPrice = standardPrices.Prices.Single(i => i.ProductITL == article.ProductITL);

                var product = new ArticleMainTableModel();
                product.ProductID = article.CMN_PRO_ProductID;
                product.ProductITL = article.ProductITL;
                product.ProductName = article.ProductName;
                product.ProductNumber = article.Product_Number;
                product.DosageFormName = article.DossageFormName;
                product.Unit = article.UnitIsoCode;
                product.UnitAmount = article.UnitAmount_DisplayLabel;
                product.ABDAPrice = standardPrice == null ? 0 : standardPrice.AbdaPrice;
                product.SalesPrice = standardPrice == null ? 0 : standardPrice.SalesPrice;
                product.ProducerName = article.ProducerName;
                product.ActiveComponents = new List<ActiveComponents>();

                localResult.Add(product);
            }

            #endregion

            var result = new List<ArticleMainTableModel>();
            result.AddRange(abdaResult);
            result.AddRange(localResult);

            #region Append Free Quantity

            var quantityParam = new P_L3AR_GAQfP_1028()
            {
                ProductIDList = result.Select(i => i.ProductID).Where(j => j != Guid.Empty).ToArray()
            };

            var quantities = new List<L3AR_GAQfP_1028>();
            if(quantityParam.ProductIDList.Count() > 0)
                quantities = cls_Get_ArticlesQuantities_for_ProductIDList.Invoke(Connection, Transaction, quantityParam, securityTicket).Result.ToList();
  
            foreach (var item in result) {

                var quantity = quantities.SingleOrDefault(i => i.Product_RefID == item.ProductID);

                if (quantity != null) {
                    item.FreeStockQuantity = quantity.FreeQuantity; 
                }
            }

            #endregion

            #region Sort Result

            if (Parameter.Order.order == SortingOrder.ASC)
            {
                switch (Parameter.Order.field)
                {
                    case ProductField.CODE:
                        result = result.OrderBy(i => i.ProductNumber).ToList();
                        break;
                    case ProductField.NAME_TOKEN:
                        result = result.OrderBy(i => i.ProductName).ToList();
                        break;
                    case ProductField.PRODUCER:
                        result = result.OrderBy(i => i.ProducerName).ToList();
                        break;
                    case ProductField.DOSAGE_FORM:
                        result = result.OrderBy(i => i.DosageFormName).ToList();
                        break;
                    case ProductField.UNIT:
                        result = result.OrderBy(i => i.Unit).ToList();
                        break;
                }
            }
            else
            {
                switch (Parameter.Order.field)
                {
                    case ProductField.CODE:
                        result = result.OrderByDescending(i => i.ProductNumber).ToList();
                        break;
                    case ProductField.NAME_TOKEN:
                        result = result.OrderByDescending(i => i.ProductName).ToList();
                        break;
                    case ProductField.PRODUCER:
                        result = result.OrderByDescending(i => i.ProducerName).ToList();
                        break;
                    case ProductField.DOSAGE_FORM:
                        result = result.OrderByDescending(i => i.DosageFormName).ToList();
                        break;
                    case ProductField.UNIT:
                        result = result.OrderByDescending(i => i.Unit).ToList();
                        break;
                }

            }

            #endregion

            returnValue.Result.Articles = result.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3AR_GAMTMfSC_1131 Invoke(string ConnectionString,P_L3AR_GAMTMfSC_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GAMTMfSC_1131 Invoke(DbConnection Connection,P_L3AR_GAMTMfSC_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GAMTMfSC_1131 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GAMTMfSC_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GAMTMfSC_1131 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GAMTMfSC_1131 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GAMTMfSC_1131 functionReturn = new FR_L3AR_GAMTMfSC_1131();
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

				 throw new Exception("Exception occured in method cls_Get_ArticlesMainTableModel_for_SearchContitions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_GAMTMfSC_1131 : FR_Base
	{
		public L3AR_GAMTMfSC_1131 Result	{ get; set; }

		public FR_L3AR_GAMTMfSC_1131() : base() {}

		public FR_L3AR_GAMTMfSC_1131(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GAMTMfSC_1131 for attribute P_L3AR_GAMTMfSC_1131
		[DataContract]
		public class P_L3AR_GAMTMfSC_1131 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public ArticleSearchCondition Conditions { get; set; } 
			[DataMember]
			public ArticleSearchOrder Order { get; set; } 
			[DataMember]
			public int FromArticle { get; set; } 
			[DataMember]
			public int NumberOfArticles { get; set; } 
			[DataMember]
			public String SortingCriteriaLastItem { get; set; } 

		}
		#endregion
		#region SClass L3AR_GAMTMfSC_1131 for attribute L3AR_GAMTMfSC_1131
		[DataContract]
		public class L3AR_GAMTMfSC_1131 
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
FR_L3AR_GAMTMfSC_1131 cls_Get_ArticlesMainTableModel_for_SearchContitions(,P_L3AR_GAMTMfSC_1131 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GAMTMfSC_1131 invocationResult = cls_Get_ArticlesMainTableModel_for_SearchContitions.Invoke(connectionString,P_L3AR_GAMTMfSC_1131 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Complex.Retrieval.P_L3AR_GAMTMfSC_1131();
parameter.LanguageID = ...;
parameter.Conditions = ...;
parameter.Order = ...;
parameter.FromArticle = ...;
parameter.NumberOfArticles = ...;
parameter.SortingCriteriaLastItem = ...;

*/
