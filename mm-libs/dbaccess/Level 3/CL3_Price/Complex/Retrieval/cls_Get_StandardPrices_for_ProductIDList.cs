/* 
 * Generated on 11/6/2014 2:31:00 PM
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
using CL2_Price.Atomic.Retrieval;
using CL2_Products.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using CL1_CMN_SLS;
using DLCore_DBCommons.APODemand;
using DLUtils_Common.PriceFormula;
using CL1_CMN_BPT_CTM;

namespace CL3_Price.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StandardPrices_for_ProductIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StandardPrices_for_ProductIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GSPfPIL_1645_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GSPfPIL_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3PR_GSPfPIL_1645_Array();
            returnValue.Result = new L3PR_GSPfPIL_1645[0] { };

            #region ProductIDs
            var param = new P_L2PR_GPfPID_1321()
            {
                ProductIDs = Parameter.ProductIDList
            };

            var products = cls_Get_ProductITLs_for_ProductIDs.Invoke(Connection, Transaction, param, securityTicket).Result;

            if (products == null || products.Count() == 0)
                return returnValue;

            #endregion

            #region Get ABDAPrices

            var abdaPricesParam = new P_L2PR_GPVfSC_1424()
            {
                SubscribedCatalogITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA)
            };

            var abdaPrices = cls_Get_PriceValues_for_SubscribedCatalogITL.Invoke(Connection, Transaction, abdaPricesParam, securityTicket).Result;
            
            #endregion

            #region Prices for specific PriceList

            var recommendedABDASalsesPrice_priceList = ORM_CMN_SLS_Pricelist.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Pricelist.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EPriceList.RecommendedABDASalesPriceList),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();


            var recommendedABDASalesPrices = new List<L2PR_GPVfPLR_1620>();
            if (recommendedABDASalsesPrice_priceList != null) 
            {
                var recommendedABDASalsesPrice_pricelist_Release = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction, new ORM_CMN_SLS_Pricelist_Release.Query()
                {
                    Pricelist_RefID = recommendedABDASalsesPrice_priceList.CMN_SLS_PricelistID,
                    IsDeleted = false
                }).Single();

                var recommendedABDASalesPricelistParam = new P_L2PR_GPVfPLR_1620();
                recommendedABDASalesPricelistParam.PriceListRelaseID = recommendedABDASalsesPrice_pricelist_Release.CMN_SLS_Pricelist_ReleaseID;

                recommendedABDASalesPrices = cls_Get_PriceValues_for_PriceListReleaseID.Invoke(Connection, Transaction, recommendedABDASalesPricelistParam, securityTicket).Result.ToList();
                
            }

            #endregion

            #region cls_Get_AllGeneralAverageProcurementPrices_for_TenantID

            var avgProcPrice = cls_Get_AllGeneralAverageProcurementPrices_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region Default Prices

            var defaultPrices = cls_Get_PriceValues_for_DefaultPricelist_and_CurrentDate.Invoke(Connection, Transaction,  securityTicket).Result.ToList();
            
            #endregion

            #region Customers Default Pricelist

            var customerDefaultPrices = new List<L2PR_GPVfPLR_1620>();

            var customerPriceListReleaseID = Guid.Empty;

            var customerPriceList = ORM_CMN_BPT_CTM_Customer_Pricelist.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer_Pricelist.Query()
            {
                CMN_BPT_CTM_Customer_RefID = Parameter.CustomerID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (customerPriceList != null) {

                var releases = ORM_CMN_SLS_Pricelist_Release.Query.Search(Connection, Transaction,
                    new ORM_CMN_SLS_Pricelist_Release.Query()
                    {
                        Pricelist_RefID = customerPriceList.CMN_SLS_Pricelist_RefID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                var currentRelease = releases.SingleOrDefault(i=>i.PricelistRelease_ValidFrom <=  DateTime.Now && DateTime.Now <= i.PricelistRelease_ValidTo);

                if(currentRelease != null)
                    customerPriceListReleaseID = currentRelease.CMN_SLS_Pricelist_ReleaseID;
            }

            if (customerPriceListReleaseID != Guid.Empty)
            {
                var specificPricelistParam = new P_L2PR_GPVfPLR_1620();
                specificPricelistParam.PriceListRelaseID = customerPriceListReleaseID;

                customerDefaultPrices = cls_Get_PriceValues_for_PriceListReleaseID.Invoke(Connection, Transaction, specificPricelistParam, securityTicket).Result.ToList();
            }

            #endregion

            var result = new List<L3PR_GSPfPIL_1645>();
            foreach (var productID in Parameter.ProductIDList) {

                decimal? salesPrice = null;

                var abdaPrice = abdaPrices.Where(i => i.CMN_PRO_Product_RefID == productID).Select(j => j.PriceAmount).SingleOrDefault();
                var symbol = abdaPrices.Where(i => i.CMN_PRO_Product_RefID == productID).Select(j => j.Symbol).SingleOrDefault();
                var averageProcurementPrice = avgProcPrice.Where(i => i.Product_RefID == productID).Select(j => j.PriceValue_Amount).SingleOrDefault();

                #region Sales Price

                //This is how the correct price is retrieved:
                //  1. Retrieve the sales price from the price list configured.
                //      1.1 If the customer has a default price list assigned, try to find a price in there.
                //      1.2 If the customer assigend price list has no price for the product or the customer has no assigned price list, 
                //          then we have to check if there is a price in the price list that is set as default
                //  2. If the first case does not apply then take the AEK as the sales price

                #region 1.1 Customer has a default price list assigned

                var defaultCustomerPrice = customerDefaultPrices.SingleOrDefault(i=>i.CMN_PRO_Product_RefID == productID);

                if (defaultCustomerPrice != null) 
                {
                    salesPrice = defaultCustomerPrice.PriceAmount;

                    if (defaultCustomerPrice.IsDynamicPricingUsed)
                    {
                        var standardPrices = new Dictionary<EPriceFormula, decimal>();
                        standardPrices.Add(EPriceFormula.ABDAPrice, abdaPrice);
                        standardPrices.Add(EPriceFormula.AverageProcurementPrice, averageProcurementPrice);

                        salesPrice = PriceFormulaUtil.GetCalculatedValue(defaultCustomerPrice.DynamicPricingFormula, standardPrices);
                    }
                }

                #endregion

                #region 1.2 PriceList that is set as Default

                if (salesPrice == null)
                {
                    var defaultPrice = defaultPrices.Where(i => i.CMN_PRO_Product_RefID == productID).SingleOrDefault();

                    if (defaultPrice != null)
                    {
                        salesPrice = defaultPrice.PriceAmount;

                        if (defaultPrice.IsDynamicPricingUsed)
                        {
                            var standardPrices = new Dictionary<EPriceFormula, decimal>();
                            standardPrices.Add(EPriceFormula.ABDAPrice, abdaPrice);
                            standardPrices.Add(EPriceFormula.AverageProcurementPrice, averageProcurementPrice);

                            salesPrice = PriceFormulaUtil.GetCalculatedValue(defaultPrice.DynamicPricingFormula, standardPrices);
                        }
                    }
                }

                #endregion

                #region 2. Abda Price

                if (salesPrice == null) 
                {
                    salesPrice = abdaPrice;
                }

                #endregion

                #endregion

                #region Recommended ABDA Sales Price

                var recommendedABDASalesPrice = recommendedABDASalesPrices.Where(i => i.CMN_PRO_Product_RefID == productID).SingleOrDefault();

                #endregion

                result.Add(
                    new L3PR_GSPfPIL_1645()
                    {
                        ProductID = productID,
                        ProductITL = products.Where(i=>i.CMN_PRO_ProductID == productID).Select(j=>j.ProductITL).SingleOrDefault(),
                        AbdaPrice = abdaPrice,
                        RecommendedAbdaSalesPrice = (recommendedABDASalesPrice == null) ? 0 : recommendedABDASalesPrice.PriceAmount,
                        AverageProcurementPrice = averageProcurementPrice,
                        SalesPrice = salesPrice ?? 0,
                        Symbol = symbol
                    }
                );
            
            }

            returnValue.Result = result.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PR_GSPfPIL_1645_Array Invoke(string ConnectionString,P_L3PR_GSPfPIL_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GSPfPIL_1645_Array Invoke(DbConnection Connection,P_L3PR_GSPfPIL_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GSPfPIL_1645_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GSPfPIL_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GSPfPIL_1645_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GSPfPIL_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GSPfPIL_1645_Array functionReturn = new FR_L3PR_GSPfPIL_1645_Array();
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

				throw new Exception("Exception occured in method cls_Get_StandardPrices_for_ProductIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GSPfPIL_1645_Array : FR_Base
	{
		public L3PR_GSPfPIL_1645[] Result	{ get; set; } 
		public FR_L3PR_GSPfPIL_1645_Array() : base() {}

		public FR_L3PR_GSPfPIL_1645_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GSPfPIL_1645 for attribute P_L3PR_GSPfPIL_1645
		[DataContract]
		public class P_L3PR_GSPfPIL_1645 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 
			[DataMember]
			public Guid[] ProductIDList { get; set; } 

		}
		#endregion
		#region SClass L3PR_GSPfPIL_1645 for attribute L3PR_GSPfPIL_1645
		[DataContract]
		public class L3PR_GSPfPIL_1645 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public decimal AbdaPrice { get; set; } 
			[DataMember]
			public decimal RecommendedAbdaSalesPrice { get; set; } 
			[DataMember]
			public decimal AverageProcurementPrice { get; set; } 
			[DataMember]
			public decimal SalesPrice { get; set; } 
			[DataMember]
			public string Symbol { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GSPfPIL_1645_Array cls_Get_StandardPrices_for_ProductIDList(,P_L3PR_GSPfPIL_1645 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GSPfPIL_1645_Array invocationResult = cls_Get_StandardPrices_for_ProductIDList.Invoke(connectionString,P_L3PR_GSPfPIL_1645 Parameter,securityTicket);
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
var parameter = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645();
parameter.CustomerID = ...;
parameter.ProductIDList = ...;

*/
