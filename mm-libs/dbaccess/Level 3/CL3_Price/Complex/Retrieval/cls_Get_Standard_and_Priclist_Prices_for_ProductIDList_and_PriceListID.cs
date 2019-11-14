/* 
 * Generated on 6/2/2014 3:02:27 PM
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
using DLUtils_Common.PriceFormula;
using CL2_Price.Atomic.Retrieval;

namespace CL3_Price.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Standard_and_Priclist_Prices_for_ProductIDList_and_PriceListID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Standard_and_Priclist_Prices_for_ProductIDList_and_PriceListID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GSaPLPfPLaPL_1602_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GSaPLPfPLaPL_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3PR_GSaPLPfPLaPL_1602_Array();

            #region Standard Prices

            var standardPricesParam = new P_L3PR_GSPfPIL_1645()
            {
                ProductIDList = Parameter.ProductIDList
            };
            var standardprices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, standardPricesParam, securityTicket).Result;
            
            #endregion

            #region Prices for specific PriceList

            var specificPricelistParam = new P_L2PR_GPVfPLR_1620();
            specificPricelistParam.PriceListRelaseID = Parameter.PriceListID;

            var specificPriceList = cls_Get_PriceValues_for_PriceListReleaseID.Invoke(Connection, Transaction, specificPricelistParam, securityTicket).Result;

            #endregion

            var result = new List<L3PR_GSaPLPfPLaPL_1602>();
            foreach (var productID in Parameter.ProductIDList) {

                var standardPrice = standardprices.Where(i=>i.ProductID == productID);
                var abdaPrice = standardPrice.Select(j=>j.AbdaPrice).SingleOrDefault();
                var recommendedAbdaSalesPrice = standardPrice.Select(j => j.RecommendedAbdaSalesPrice).SingleOrDefault();
                var averageProcurementPrice = standardPrice.Select(j=>j.AverageProcurementPrice).SingleOrDefault();
                var salesPrice = standardPrice.Select(j => j.SalesPrice).SingleOrDefault();
                
                #region Specific Price

                var specificPrice = specificPriceList.Where(i => i.CMN_PRO_Product_RefID == productID).SingleOrDefault();

                decimal pricelistPrice = 0;
                if (specificPrice != default(L2PR_GPVfPLR_1620))
                {
                    pricelistPrice = specificPrice.PriceAmount;

                    if (specificPrice.IsDynamicPricingUsed)
                    {
                        var standardPrices = new Dictionary<EPriceFormula, decimal>();
                        standardPrices.Add(EPriceFormula.ABDAPrice, abdaPrice);
                        standardPrices.Add(EPriceFormula.AverageProcurementPrice, averageProcurementPrice);

                        pricelistPrice = PriceFormulaUtil.GetCalculatedValue(specificPrice.DynamicPricingFormula, standardPrices);
                    }
                }

                #endregion

                result.Add(
                    new L3PR_GSaPLPfPLaPL_1602() {
                        ProductID = productID,
                        AbdaPrice = abdaPrice,
                        RecommendedAbdaSalesPrice = recommendedAbdaSalesPrice,
                        AverageProcurementPrice = averageProcurementPrice,
                        PriceListPrice = pricelistPrice,
                        SalesPrice = salesPrice
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
		public static FR_L3PR_GSaPLPfPLaPL_1602_Array Invoke(string ConnectionString,P_L3PR_GSaPLPfPLaPL_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GSaPLPfPLaPL_1602_Array Invoke(DbConnection Connection,P_L3PR_GSaPLPfPLaPL_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GSaPLPfPLaPL_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GSaPLPfPLaPL_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GSaPLPfPLaPL_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GSaPLPfPLaPL_1602 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GSaPLPfPLaPL_1602_Array functionReturn = new FR_L3PR_GSaPLPfPLaPL_1602_Array();
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

				throw new Exception("Exception occured in method cls_Get_Standard_and_Priclist_Prices_for_ProductIDList_and_PriceListID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GSaPLPfPLaPL_1602_Array : FR_Base
	{
		public L3PR_GSaPLPfPLaPL_1602[] Result	{ get; set; } 
		public FR_L3PR_GSaPLPfPLaPL_1602_Array() : base() {}

		public FR_L3PR_GSaPLPfPLaPL_1602_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GSaPLPfPLaPL_1602 for attribute P_L3PR_GSaPLPfPLaPL_1602
		[DataContract]
		public class P_L3PR_GSaPLPfPLaPL_1602 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductIDList { get; set; } 
			[DataMember]
			public Guid PriceListID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GSaPLPfPLaPL_1602 for attribute L3PR_GSaPLPfPLaPL_1602
		[DataContract]
		public class L3PR_GSaPLPfPLaPL_1602 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public decimal AbdaPrice { get; set; } 
			[DataMember]
			public decimal RecommendedAbdaSalesPrice { get; set; } 
			[DataMember]
			public decimal AverageProcurementPrice { get; set; } 
			[DataMember]
			public decimal SalesPrice { get; set; } 
			[DataMember]
			public decimal PriceListPrice { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GSaPLPfPLaPL_1602_Array cls_Get_Standard_and_Priclist_Prices_for_ProductIDList_and_PriceListID(,P_L3PR_GSaPLPfPLaPL_1602 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GSaPLPfPLaPL_1602_Array invocationResult = cls_Get_Standard_and_Priclist_Prices_for_ProductIDList_and_PriceListID.Invoke(connectionString,P_L3PR_GSaPLPfPLaPL_1602 Parameter,securityTicket);
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
var parameter = new CL3_Price.Complex.Retrieval.P_L3PR_GSaPLPfPLaPL_1602();
parameter.ProductIDList = ...;
parameter.PriceListID = ...;

*/
