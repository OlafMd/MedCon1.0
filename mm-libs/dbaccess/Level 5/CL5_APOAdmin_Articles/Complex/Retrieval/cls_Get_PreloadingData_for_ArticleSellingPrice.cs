/* 
 * Generated on 4/25/2014 5:12:23 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL5_APOAdmin_Articles.Atomic.Retrieval;
using CL2_Products.Atomic.Retrieval;
using CL2_Price.Atomic.Retrieval;
using CL2_Currency.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;
namespace CL5_APOAdmin_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_ArticleSellingPrice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_ArticleSellingPrice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GPDfASP_1604 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GPDfASP_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AR_GPDfASP_1604();
            returnValue.Result = new L5AR_GPDfASP_1604();

            #region DefaultCurrency

            var dafaultCurrency = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region Prices

            P_L5AR_GPaPfAaCID_1020 pricesParam = new P_L5AR_GPaPfAaCID_1020();
            pricesParam.ArticleID = Parameter.ArticleID;
            pricesParam.CurrencyID = dafaultCurrency.CMN_CurrencyID;
            var pricesAndPricelists = cls_Get_Pricelists_and_Prices_for_Article_and_Currency_ID.Invoke(Connection, Transaction, pricesParam, securityTicket).Result;

            returnValue.Result.PricesAndPricelists = pricesAndPricelists;
            #endregion

            #region Articles

            var article = cls_Get_Product_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.Where(a => a.CMN_PRO_ProductID == Parameter.ArticleID).Single();
            returnValue.Result.Product = article;
            
            #endregion

            #region Formulas

            var formulas = cls_Get_AllDynamicPricingFormulas_for_TenantID.Invoke(Connection, Transaction,securityTicket).Result;
            returnValue.Result.Formulas = formulas;

            #endregion

            #region Standard Prices
            
            var standardPricesParam = new P_L3PR_GSPfPIL_1645(){
            
                ProductIDList= new Guid[1]{Parameter.ArticleID}
            };
            var standardprice = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, standardPricesParam, securityTicket).Result.SingleOrDefault();
            returnValue.Result.StandardPrices = standardprice;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AR_GPDfASP_1604 Invoke(string ConnectionString,P_L5AR_GPDfASP_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GPDfASP_1604 Invoke(DbConnection Connection,P_L5AR_GPDfASP_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GPDfASP_1604 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GPDfASP_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GPDfASP_1604 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GPDfASP_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GPDfASP_1604 functionReturn = new FR_L5AR_GPDfASP_1604();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_ArticleSellingPrice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GPDfASP_1604 : FR_Base
	{
		public L5AR_GPDfASP_1604 Result	{ get; set; }

		public FR_L5AR_GPDfASP_1604() : base() {}

		public FR_L5AR_GPDfASP_1604(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GPDfASP_1604 for attribute P_L5AR_GPDfASP_1604
		[DataContract]
		public class P_L5AR_GPDfASP_1604 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GPDfASP_1604 for attribute L5AR_GPDfASP_1604
		[DataContract]
		public class L5AR_GPDfASP_1604 
		{
			//Standard type parameters
			[DataMember]
			public L5AR_GPaPfAaCID_1020[] PricesAndPricelists { get; set; } 
			[DataMember]
			public L2PD_GAPfTI_1541 Product { get; set; } 
			[DataMember]
			public L2DF_GADPFfPL_1017[] Formulas { get; set; } 
			[DataMember]
			public L3PR_GSPfPIL_1645 StandardPrices { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GPDfASP_1604 cls_Get_PreloadingData_for_ArticleSellingPrice(,P_L5AR_GPDfASP_1604 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GPDfASP_1604 invocationResult = cls_Get_PreloadingData_for_ArticleSellingPrice.Invoke(connectionString,P_L5AR_GPDfASP_1604 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Retrieval.P_L5AR_GPDfASP_1604();
parameter.ArticleID = ...;

*/
