/* 
 * Generated on 8/19/2014 11:27:02 AM
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
using CL3_Price.Complex.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceiptsPositions_for_ReceiptsHeaderID_by_ProductList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceiptsPositions_for_ReceiptsHeaderID_by_ProductList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GSRPfHbP_1522_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GSRPfHbP_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5SR_GSRPfHbP_1522_Array();

            #region Get Stock Receipt Positions

            var parameterPositions = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GSROfHA_1408();
            parameterPositions.ReceiptHeaderID = Parameter.ReceiptHeaderID;

            var positions = CL5_APOLogistic_StockReceipt.Atomic.Retrieval.cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic
                .Invoke(Connection, Transaction, parameterPositions, securityTicket).Result;

            #endregion

            #region Get Articles
            var arrayOfProductId = positions.Select(x => x.ReceiptPosition_Product_RefID).Distinct().ToArray<Guid>();


            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = arrayOfProductId;

            var articles = new CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942[0];

            if (arrayOfProductId.Length != 0)
            {
                articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;
            }

            var getPricesParam = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645();
            getPricesParam.ProductIDList = arrayOfProductId;

            List<CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645> prices = new List<L3PR_GSPfPIL_1645>();
            if (arrayOfProductId.Length > 0)
            {
                prices = CL3_Price.Complex.Retrieval.cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, getPricesParam, securityTicket).Result.ToList();
                
            }
            #endregion

            var lsrResult = new List<L5SR_GSRPfHbP_1522>();

            foreach (var position in positions)
            {
                var retObj = new L5SR_GSRPfHbP_1522();
                retObj.OrderPosition = position;
                retObj.Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == position.ReceiptPosition_Product_RefID);
                if (prices.Any())
                {
                    retObj.AEKPrice = prices.Single(pr => pr.ProductID == position.ReceiptPosition_Product_RefID).AbdaPrice;
                    retObj.Symbol = prices.Single(pr => pr.ProductID == position.ReceiptPosition_Product_RefID).Symbol;
                }

                lsrResult.Add(retObj);
            }

            returnValue.Result = lsrResult.ToArray();


            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SR_GSRPfHbP_1522_Array Invoke(string ConnectionString,P_L5SR_GSRPfHbP_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GSRPfHbP_1522_Array Invoke(DbConnection Connection,P_L5SR_GSRPfHbP_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GSRPfHbP_1522_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GSRPfHbP_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GSRPfHbP_1522_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GSRPfHbP_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GSRPfHbP_1522_Array functionReturn = new FR_L5SR_GSRPfHbP_1522_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceiptsPositions_for_ReceiptsHeaderID_by_ProductList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GSRPfHbP_1522_Array : FR_Base
	{
		public L5SR_GSRPfHbP_1522[] Result	{ get; set; } 
		public FR_L5SR_GSRPfHbP_1522_Array() : base() {}

		public FR_L5SR_GSRPfHbP_1522_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GSRPfHbP_1522 for attribute P_L5SR_GSRPfHbP_1522
		[DataContract]
		public class P_L5SR_GSRPfHbP_1522 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GSRPfHbP_1522 for attribute L5SR_GSRPfHbP_1522
		[DataContract]
		public class L5SR_GSRPfHbP_1522 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOLogistic_StockReceipt.Atomic.Retrieval.L5SR_GSROfHA_1408 OrderPosition { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public Decimal AEKPrice { get; set; } 
			[DataMember]
			public string Symbol { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GSRPfHbP_1522_Array cls_Get_StockReceiptsPositions_for_ReceiptsHeaderID_by_ProductList(,P_L5SR_GSRPfHbP_1522 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GSRPfHbP_1522_Array invocationResult = cls_Get_StockReceiptsPositions_for_ReceiptsHeaderID_by_ProductList.Invoke(connectionString,P_L5SR_GSRPfHbP_1522 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Retrieval.P_L5SR_GSRPfHbP_1522();
parameter.ReceiptHeaderID = ...;

*/
