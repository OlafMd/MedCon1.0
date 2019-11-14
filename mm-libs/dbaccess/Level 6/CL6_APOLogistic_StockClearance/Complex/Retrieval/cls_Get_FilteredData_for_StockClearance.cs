/* 
 * Generated on 10/16/2014 11:37:32 AM
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
using CL3_APOStatistic.Complex.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;
using CL3_TrackingInstance.Atomic.Retrieval;
using CL3_Supplier.Atomic.Retrieval;
using CL6_APOLogistic_StockClearance.Complex.Manipulation;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL6_APOLogistic_StockClearance.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FilteredData_for_StockClearance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FilteredData_for_StockClearance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SC_GFDfSC_1424 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SC_GFDfSC_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
			var returnValue = new FR_L6SC_GFDfSC_1424();
            returnValue.Result = new L6SC_GFDfSC_1424();

            var priceForAllProducts = new List<L3PR_GSPfPIL_1645>();
            var articles = new List<L3AR_GAfAL_0942>();
            var productsBySupplier = new List<L3SP_GPfSvSR_1524>();
            var productListId = new List<Guid>();

            #region Filter by storage and quantity
            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = Parameter.WarehouseStructure.Warehouse_GroupID,
                WarehouseID = Parameter.WarehouseStructure.WarehouseID,
                AreaID = Parameter.WarehouseStructure.AreaID,
                RackID = Parameter.WarehouseStructure.RackID,
                UseShelfIDList = Parameter.WarehouseStructure.ShelfID != null,
                ShelfIDs = new Guid[] { Parameter.WarehouseStructure.ShelfID == null 
                    ? Guid.Empty : new Guid(Parameter.WarehouseStructure.ShelfID.ToString()) },
                UseProductIDList = false,
                ProductIDs = new Guid[] { Guid.Empty },
                BottomShelfQuantity = (int?)Parameter.QuantityBottom,
                TopShelfQuantity = (int?)Parameter.QuantityTop,
                UseProductTrackingInstanceIDList = false,
                ProductTrackingInstanceIDs = new Guid[] { Guid.Empty },
                StartExpirationDate = null,
                EndExpirationDate = null
            };
            var resultStoragePlaces = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket);
            if (resultStoragePlaces.Status != FR_Status.Success || resultStoragePlaces.Result == null || resultStoragePlaces.Result.Count() <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = new L6SC_GFDfSC_1424() { };
                return returnValue;
            }
            var productsByStorage = resultStoragePlaces.Result.ToList();
            var productIDsByStorageAndQuantity = productsByStorage.Select(x => x.Product_RefID).Distinct().ToList();
            #endregion

            #region Filter by Supplier
            if (productIDsByStorageAndQuantity.Count != 0)
            {
                productsBySupplier = cls_Get_ProductIDs_for_SupplierID_via_StockReceipts.Invoke(Connection, Transaction,
                    new P_L3SP_GPfSvSR_1524
                    {
                        ProvidingSupplier = Parameter.ProvidingSupplier
                    },
                    securityTicket).Result.ToList();

                if (Parameter.ProvidingSupplier != null)
                {
                    var productIDsBySupplier = productsBySupplier.Select(x => x.ReceiptPosition_Product_RefID).ToList();
                    productListId = productIDsBySupplier.Intersect(productIDsByStorageAndQuantity).ToList();
                }
                else
                {
                    productListId = productIDsByStorageAndQuantity;
                }
            }
            #endregion

            #region Filter by date of shipment
            if (Parameter.DateOfShipmentFrom != null || Parameter.DateOfShipmentTo != null)
            {
                var dateOfShipmentParam = new P_L6SC_GDSfAL_1418();
                dateOfShipmentParam.ProductID_List = productListId.ToArray();
                dateOfShipmentParam.shipmentStatus = null; 
                dateOfShipmentParam.DateFrom = Parameter.DateOfShipmentFrom;
                var filterByDate = Get_DateOfShipment_for_ArticleList.Invoke(Connection, Transaction, dateOfShipmentParam, securityTicket).Result;
                productListId = filterByDate
                    .Where(x => x.GlobalPropertyMatchingID != EnumUtils.GetEnumDescription(EShipmentStatus.Shipped))
                    .Select(x => x.CMN_PRO_Product_RefID).Distinct().ToList();
            }
            #endregion

            #region Filter by Price
            if (productListId.Count != 0)
            {
                var filteredPrice = new List<L3PR_GSPfPIL_1645>();
                var priceParams = new P_L3PR_GSPfPIL_1645();
                bool isFilteredByPrice = false;
                priceParams.ProductIDList = productListId.ToArray();
                priceForAllProducts = cls_Get_StandardPrices_for_ProductIDList.Invoke(
                    Connection, 
                    Transaction, 
                    priceParams, 
                    securityTicket).Result.ToList();

                if (Parameter.Price.DefaultSalesPriceFrom != null || Parameter.Price.DefaultSalesPriceTo != null)
                {
                    filteredPrice = priceForAllProducts.Where(x =>
                        (Parameter.Price.DefaultSalesPriceFrom == null || x.SalesPrice >= Parameter.Price.DefaultSalesPriceFrom)
                        && (Parameter.Price.DefaultSalesPriceTo == null || x.SalesPrice <= Parameter.Price.DefaultSalesPriceTo)).ToList();
                    isFilteredByPrice = true;
                }

                if (Parameter.Price.AverageProcurementPriceFrom != null || Parameter.Price.AverageProcurementPriceTo != null)
                {
                    if (isFilteredByPrice)
                    {
                        filteredPrice = filteredPrice.Where(x =>
                            (Parameter.Price.AverageProcurementPriceFrom == null || x.AverageProcurementPrice >= Parameter.Price.AverageProcurementPriceFrom)
                            && (Parameter.Price.AverageProcurementPriceTo == null || x.AverageProcurementPrice <= Parameter.Price.AverageProcurementPriceTo)).ToList();
                    }
                    else
                    {
                        filteredPrice = priceForAllProducts.Where(x =>
                            (Parameter.Price.AverageProcurementPriceFrom == null || x.AverageProcurementPrice >= Parameter.Price.AverageProcurementPriceFrom)
                            && (Parameter.Price.AverageProcurementPriceTo == null || x.AverageProcurementPrice <= Parameter.Price.AverageProcurementPriceTo)).ToList();
                        isFilteredByPrice = true;
                    }
                }

                if (isFilteredByPrice)
                {
                    var productListByPrice = filteredPrice.Select(x => x.ProductID).ToList();
                    productListId = productListId.Intersect(productListByPrice).ToList();
                }
            }
            #endregion

            #region Get_Articles_for_ArticleList add producerID
            if (productListId.Count != 0)
            {
                var getArticlesParams = new P_L3AR_GAfAL_0942();
                getArticlesParams.ProducingBusinessParticipant = Parameter.ProducingBusinessParticipant;
                getArticlesParams.ProductID_List = productListId.ToArray();
                getArticlesParams.ProductGroupID = Parameter.ProductGroupID;

                articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, getArticlesParams, securityTicket).Result.ToList();
            }
            #endregion

            #region filter by producer
            if ((articles.Count != 0) && (String.IsNullOrEmpty(Parameter.Producer) == false))
            {
                articles = articles.Where(x => x.ProducerName.Contains(Parameter.Producer)).ToList();
            }
            #endregion

            #region Get Msr for products

            var productIDs = articles.Select(x => x.CMN_PRO_ProductID).ToArray();
            var msrForProducts = cls_Get_MSR_for_ProductIDList.Invoke(
                Connection, 
                Transaction, 
                new P_L3AS_GSMRfPL_1508 { ProductIDList = productIDs }, 
                securityTicket
            ).Result;
            
            #endregion

            if (productListId.Count != 0)
            {
                var returnItemList = new List<L6SC_GFDfSC_1424a>();
                foreach (var item in productsByStorage)
                {
                    var article = articles.SingleOrDefault(x => x.CMN_PRO_ProductID == item.Product_RefID);
                    var productMst = msrForProducts.SingleOrDefault(x => x.ProductID == item.Product_RefID);
                    var trackingInstances = cls_GetTrackingInstances_for_ShelfContent.Invoke(      
                        Connection,
                        Transaction,
                        new P_L3TI_GTIfSC_1455() { ShelfContentID = item.LOG_WRH_Shelf_ContentID },
                        securityTicket).Result;
                    if (article != null && trackingInstances != null && trackingInstances.Count() > 0) 
                    { 
                        var returnItem = new L6SC_GFDfSC_1424a();
                        returnItem.Storage = productsByStorage.Single(x => x.LOG_WRH_Shelf_ContentID == item.LOG_WRH_Shelf_ContentID);
                        returnItem.Price = priceForAllProducts.SingleOrDefault(x => x.ProductID == item.Product_RefID);
                        returnItem.Article = article;
                        returnItem.Supplier = productsBySupplier.Where(x => x.ReceiptPosition_Product_RefID == item.Product_RefID).ToArray();
                        returnItem.TrackingInstance = trackingInstances[0];
                        returnItem.MSR = (productMst != null) ? productMst.MSR : 0.0;
                        returnItemList.Add(returnItem);
                    }
                }
                returnValue.Result.FullGridData = returnItemList.ToArray();
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SC_GFDfSC_1424 Invoke(string ConnectionString,P_L6SC_GFDfSC_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SC_GFDfSC_1424 Invoke(DbConnection Connection,P_L6SC_GFDfSC_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SC_GFDfSC_1424 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SC_GFDfSC_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SC_GFDfSC_1424 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SC_GFDfSC_1424 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SC_GFDfSC_1424 functionReturn = new FR_L6SC_GFDfSC_1424();
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

				throw new Exception("Exception occured in method cls_Get_FilteredData_for_StockClearance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SC_GFDfSC_1424 : FR_Base
	{
		public L6SC_GFDfSC_1424 Result	{ get; set; }

		public FR_L6SC_GFDfSC_1424() : base() {}

		public FR_L6SC_GFDfSC_1424(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SC_GFDfSC_1424 for attribute P_L6SC_GFDfSC_1424
		[DataContract]
		public class P_L6SC_GFDfSC_1424 
		{
			[DataMember]
			public P_L6SC_GFDfSC_1424a WarehouseStructure { get; set; }
			[DataMember]
			public P_L6SC_GFDfSC_1424b Price { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid? ProvidingSupplier { get; set; } 
			[DataMember]
			public Guid? ProducingBusinessParticipant { get; set; } 
			[DataMember]
			public DateTime? DateOfShipmentFrom { get; set; } 
			[DataMember]
			public DateTime? DateOfShipmentTo { get; set; } 
			[DataMember]
			public float? QuantityTop { get; set; } 
			[DataMember]
			public float? QuantityBottom { get; set; } 
			[DataMember]
			public Guid? ProductGroupID { get; set; } 
			[DataMember]
			public String Producer { get; set; } 

		}
		#endregion
		#region SClass P_L6SC_GFDfSC_1424a for attribute WarehouseStructure
		[DataContract]
		public class P_L6SC_GFDfSC_1424a 
		{
			//Standard type parameters
			[DataMember]
			public Guid? Warehouse_GroupID { get; set; } 
			[DataMember]
			public Guid? WarehouseID { get; set; } 
			[DataMember]
			public Guid? AreaID { get; set; } 
			[DataMember]
			public Guid? RackID { get; set; } 
			[DataMember]
			public Guid? ShelfID { get; set; } 

		}
		#endregion
		#region SClass P_L6SC_GFDfSC_1424b for attribute Price
		[DataContract]
		public class P_L6SC_GFDfSC_1424b 
		{
			//Standard type parameters
			[DataMember]
			public decimal? DefaultSalesPriceFrom { get; set; } 
			[DataMember]
			public decimal? DefaultSalesPriceTo { get; set; } 
			[DataMember]
			public decimal? AverageProcurementPriceFrom { get; set; } 
			[DataMember]
			public decimal? AverageProcurementPriceTo { get; set; } 

		}
		#endregion
		#region SClass L6SC_GFDfSC_1424 for attribute L6SC_GFDfSC_1424
		[DataContract]
		public class L6SC_GFDfSC_1424 
		{
			[DataMember]
			public L6SC_GFDfSC_1424a[] FullGridData { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6SC_GFDfSC_1424a for attribute FullGridData
		[DataContract]
		public class L6SC_GFDfSC_1424a 
		{
			//Standard type parameters
			[DataMember]
			public L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public double MSR { get; set; } 
			[DataMember]
			public L3PR_GSPfPIL_1645 Price { get; set; } 
			[DataMember]
			public CL3_Warehouse.Atomic.Retrieval.L3WH_GSPfFC_1504 Storage { get; set; } 
			[DataMember]
			public L3SP_GPfSvSR_1524[] Supplier { get; set; } 
			[DataMember]
			public CL3_TrackingInstance.Atomic.Retrieval.L3TI_GTIfSC_1455 TrackingInstance { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SC_GFDfSC_1424 cls_Get_FilteredData_for_StockClearance(,P_L6SC_GFDfSC_1424 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SC_GFDfSC_1424 invocationResult = cls_Get_FilteredData_for_StockClearance.Invoke(connectionString,P_L6SC_GFDfSC_1424 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockClearance.Complex.Retrieval.P_L6SC_GFDfSC_1424();
parameter.WarehouseStructure = ...;
parameter.Price = ...;

parameter.ProvidingSupplier = ...;
parameter.ProducingBusinessParticipant = ...;
parameter.DateOfShipmentFrom = ...;
parameter.DateOfShipmentTo = ...;
parameter.QuantityTop = ...;
parameter.QuantityBottom = ...;
parameter.ProductGroupID = ...;
parameter.Producer = ...;

*/
