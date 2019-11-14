/* 
 * Generated on 11/12/2014 2:26:50 PM
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
using CL3_Warehouse.Atomic.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceiptsPositions_for_ReceiptHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GSRPfH_1544_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GSRPfH_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5SR_GSRPfH_1544_Array();

            #region Get StockReceiptPositions Position

            var parameterPositions = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GSROfHA_1408();
            parameterPositions.ReceiptHeaderID = Parameter.ReceiptHeaderID;

            var positions = CL5_APOLogistic_StockReceipt.Atomic.Retrieval.cls_Get_StockReceiptsPositions_for_ReceiptHeaderID_Atomic
                .Invoke(Connection, Transaction, parameterPositions, securityTicket).Result;

            #endregion

            if (positions.Count() == 0)
            {
                returnValue.Result = new L5SR_GSRPfH_1544[0];
                return returnValue;
            }

            #region Get Articles

            var paramArticles = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942();
            paramArticles.ProductID_List = positions.Select(x => x.ReceiptPosition_Product_RefID).Distinct().ToArray();

            var articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, paramArticles, securityTicket).Result;

            #endregion

            #region Get All StoragePlaces for TenantID
            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = null,
                WarehouseID = null,
                AreaID = null,
                RackID = null,
                UseShelfIDList = true,
                ShelfIDs = positions.Select(i => i.Target_WRH_Shelf_RefID).Distinct().ToArray(),
                UseProductIDList = false,
                ProductIDs = new Guid[] { Guid.Empty },
                BottomShelfQuantity =null,
                TopShelfQuantity = null,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            var allStoragePlacesForTenant = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket).Result;

            #endregion

            #region Get_StandardPrices_for_ProductIDList

            var priceParam = new P_L3PR_GSPfPIL_1645
            {
                ProductIDList = positions.Select(x => x.ReceiptPosition_Product_RefID).Distinct().ToArray()
            };

            var prices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, priceParam, securityTicket).Result;

            #endregion

            var result = new List<L5SR_GSRPfH_1544>();

            foreach (var position in positions)
            {
                var retObj = new L5SR_GSRPfH_1544();
                retObj.OrderPosition = position;
                retObj.Article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == position.ReceiptPosition_Product_RefID);
                retObj.StandardPrices = prices.SingleOrDefault(x => x.ProductID == position.ReceiptPosition_Product_RefID);

                if (position.Target_WRH_Shelf_RefID != Guid.Empty)
                {
                    var storagePlace = allStoragePlacesForTenant.Where(i => i.LOG_WRH_ShelfID == position.Target_WRH_Shelf_RefID).FirstOrDefault();

                    if (storagePlace != null)
                        retObj.StoragePlace = String.Format("{0}-{1}-{2}-{3}",
                            storagePlace.WarehouseCoordinateCode,
                            storagePlace.AreaCoordinateCode,
                            storagePlace.RackCoordinateCode,
                            storagePlace.ShelfCoordinateCode);
                }
                result.Add(retObj);
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
		public static FR_L5SR_GSRPfH_1544_Array Invoke(string ConnectionString,P_L5SR_GSRPfH_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GSRPfH_1544_Array Invoke(DbConnection Connection,P_L5SR_GSRPfH_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GSRPfH_1544_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GSRPfH_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GSRPfH_1544_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GSRPfH_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GSRPfH_1544_Array functionReturn = new FR_L5SR_GSRPfH_1544_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceiptsPositions_for_ReceiptHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GSRPfH_1544_Array : FR_Base
	{
		public L5SR_GSRPfH_1544[] Result	{ get; set; } 
		public FR_L5SR_GSRPfH_1544_Array() : base() {}

		public FR_L5SR_GSRPfH_1544_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GSRPfH_1544 for attribute P_L5SR_GSRPfH_1544
		[DataContract]
		public class P_L5SR_GSRPfH_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GSRPfH_1544 for attribute L5SR_GSRPfH_1544
		[DataContract]
		public class L5SR_GSRPfH_1544 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOLogistic_StockReceipt.Atomic.Retrieval.L5SR_GSROfHA_1408 OrderPosition { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Price.Complex.Retrieval.L3PR_GSPfPIL_1645 StandardPrices { get; set; } 
			[DataMember]
			public String StoragePlace { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GSRPfH_1544_Array cls_Get_StockReceiptsPositions_for_ReceiptHeaderID(,P_L5SR_GSRPfH_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GSRPfH_1544_Array invocationResult = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID.Invoke(connectionString,P_L5SR_GSRPfH_1544 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Retrieval.P_L5SR_GSRPfH_1544();
parameter.ReceiptHeaderID = ...;

*/
