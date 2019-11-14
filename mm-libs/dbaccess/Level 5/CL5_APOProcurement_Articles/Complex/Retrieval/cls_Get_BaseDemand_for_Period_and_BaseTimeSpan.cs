/* 
 * Generated on 10/16/2014 1:18:47 PM
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
using CL3_APOStatistic.Complex.Retrieval;
using CL1_ORD_PRC;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using CL2_ProcurementOrder.Atomic.Retrieval;
using CL1_LOG_WRH;
using CL3_Articles.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;
using CL2_Shipment.Atomic.Retrieval;

namespace CL5_APOProcurement_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BaseDemand_for_Period_and_BaseTimeSpan.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BaseDemand_for_Period_and_BaseTimeSpan
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GBDfPABTS_1202_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GBDfPABTS_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AR_GBDfPABTS_1202_Array();

            var productRates = new List<Tuple<Guid, Double>>();

            if (Parameter.BaseTimeSpan_EndDate == null || Parameter.BaseTimeSpan_StartDate == null)
            {
                #region Get MSR (Monthly sales rate) - If no base time span

                var msrResult = cls_Get_MSR_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

                productRates = msrResult.Select(i => new Tuple<Guid, Double>(i.ProductID, i.MSR)).ToList();

                #endregion
            }
            else
            {
                #region Get MSRB (Monthly sales rate base) - If there is base time span

                var msrbParam = new P_L3AS_GMSRfBS_1404()
                {
                    StartDate = (DateTime)Parameter.BaseTimeSpan_StartDate ,
                    EndDate = (DateTime)Parameter.BaseTimeSpan_EndDate
                };

                var msrbResult = cls_Get_MSRB_for_BaseSpan.Invoke(Connection, Transaction, msrbParam, securityTicket).Result;

                productRates = msrbResult.Select(i => new Tuple<Guid, Double>(i.ProductID, i.MSRB)).ToList();

                #endregion
            }

            if (productRates == null || productRates.Count() == 0)
            {
                returnValue.Result = new L5AR_GBDfPABTS_1202[0];
                return returnValue;
            }

            #region Get articles

            var articleParam = new CL3_Articles.Atomic.Retrieval.P_L3AR_GAfAL_0942
            {
                ProductID_List = productRates.Select(i=>i.Item1).ToArray()
            };

            var articles = CL3_Articles.Atomic.Retrieval.cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articleParam, securityTicket).Result;

            #endregion

            #region Minimum Quantities

            //This list needs GroupBy

            var tenantQuanityLevels = ORM_LOG_WRH_QuantityLevel.Query.Search(Connection, Transaction, new ORM_LOG_WRH_QuantityLevel.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            #endregion

            #region Quantities In ShipmentPositions

            var quantitiesInShipmentPositions = cls_Get_ProductQuantities_for_UnshippedAndUnfinishedShipments.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            #region Current ShelContent Quantities

            var paramShelfContentQuantities = new P_L3WH_GASCQfPL_1239(){
                ProductIDList = productRates.Select(i => i.Item1).ToArray()
            };

            var currentShelContentQuantities = cls_Get_All_ShelfContent_Quantities_for_ProductListID.Invoke(Connection, Transaction, paramShelfContentQuantities, securityTicket).Result;

            #endregion

            #region Quantities In Procurement

            var activeStatus = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Status.Query(){
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProcurementStatus.Active),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var paramQuantitiesInProcurementPositions = new P_L2PO_GPQfPHwS_1553(){
                CurrentProcurementOrderStatus = activeStatus.ORD_PRC_ProcurementOrder_StatusID
            };

            var quantitiesInProcurementPositions = cls_Get_ProductQuantities_for_ProcurementHeader_with_Status.Invoke(Connection, Transaction, paramQuantitiesInProcurementPositions, securityTicket).Result;

            #endregion

            #region Unstored Expected Deliveries

            var confirmedOrderStatus = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Status.Query(){
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EProcurementStatus.Confirmed),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var paramQuantitiesInExpectedDeliveries = new P_L2PO_GPQfUED_1637(){
                OrderedProcurementStatusID = confirmedOrderStatus.ORD_PRC_ProcurementOrder_StatusID,
                ExpectedDateBefore = DateTime.Now.AddDays(365) //this is hardcoded, because we don't have setup for it right now
            };

            var quantitiesInExpectedDeliveries = cls_Get_ProductQuantities_for_UnstoredExpectedDelivery.Invoke(Connection, Transaction, paramQuantitiesInExpectedDeliveries, securityTicket).Result;

            #endregion

            #region Filter

            if (Parameter.ProducerBPID != null)
            {
                articles = articles.Where(x => x.ProducerId == Parameter.ProducerBPID).ToArray();

                if (articles == null || articles.Count() == 0)
                {
                    returnValue.Result = new L5AR_GBDfPABTS_1202[0];
                    return returnValue;
                }
            }

            var paramFilterBySupplier = new P_L5AR_FPfDS_1324(){
                ProductIDList = articles.Select(i=>i.CMN_PRO_ProductID).ToArray(),
                SupplierID = Parameter.SupplierID
            };

            var articlesFilteredBySupplierID = cls_Filter_ProductIDs_for_DefaultSupplierID.Invoke(Connection, Transaction, paramFilterBySupplier, securityTicket).Result;

            var filteredArticlesIDs = articlesFilteredBySupplierID.Select(i => i.ProductID);

            articles = articles.Where(x => filteredArticlesIDs.Contains(x.CMN_PRO_ProductID)).ToArray();
            
            #endregion

            var result = new List<L5AR_GBDfPABTS_1202>();

            foreach (var article in articles) 
            {
                #region Recalculation

                var quantityParam = new P_L3AR_GSQfP_1220()
                {
                    ProductID = article.CMN_PRO_ProductID
                };

                var stockQuantities = cls_Get_StockQuantities_for_ProductID.Invoke(Connection, Transaction, quantityParam, securityTicket).Result;

                var defaultSupplier = articlesFilteredBySupplierID.Where(i => i.ProductID == article.CMN_PRO_ProductID).Single();

                var msrOrMsrb = productRates.Where(i => i.Item1 == article.CMN_PRO_ProductID).Select(i => i.Item2).SingleOrDefault();
                
                var minimumQuantity = tenantQuanityLevels.Where(i=>i.Product_RefID == article.CMN_PRO_ProductID && i.Quantity_Minimum != 0).Sum(i=>i.Quantity_Minimum);
                minimumQuantity += tenantQuanityLevels.Where(i=>i.Product_RefID == article.CMN_PRO_ProductID && i.Quantity_Minimum == 0).Sum(i=>i.Quantity_RecommendedMinimumCalculation);
                
                var qunatityInShipmentPositions = quantitiesInShipmentPositions.Where(i=>i.CMN_PRO_Product_RefID == article.CMN_PRO_ProductID).Select(i=>i.QuantityToShip).SingleOrDefault();

                var currentShelContentQuantity = currentShelContentQuantities.Where(i=>i.Product_RefID == article.CMN_PRO_ProductID).Select(i=>i.Sum_Quantity_Current).SingleOrDefault();

                var quantityInProcurementPositions = quantitiesInProcurementPositions.Where(i=>i.CMN_PRO_Product_RefID == article.CMN_PRO_ProductID).Select(i=>i.Quantity).SingleOrDefault();

                var quantityInExpectedDeliveries = quantitiesInExpectedDeliveries.Where(i=>i.CMN_PRO_Product_RefID == article.CMN_PRO_ProductID).Select(i=>i.TotalExpectedQuantity).SingleOrDefault();

                #endregion

                var resultItem = new L5AR_GBDfPABTS_1202();
                resultItem.Article = article;

                resultItem.SupplierName = defaultSupplier.SupplierName;
                resultItem.SupplierID = defaultSupplier.SupplierID;
                resultItem.CurrentQuantity = Math.Ceiling(stockQuantities.Quantity_Current);

                resultItem.MSR_or_MSRB = Math.Ceiling(msrOrMsrb);
                var baseDemand = (msrOrMsrb / 30 )* Parameter.OrderingPeriodInDays + minimumQuantity + qunatityInShipmentPositions - currentShelContentQuantity - quantityInProcurementPositions - quantityInExpectedDeliveries;
                resultItem.BaseDemand = Math.Ceiling(baseDemand);

                //this happens when there is more quantities in shelf than we expect to sell for that period
                if (resultItem.BaseDemand <= 0)
                    continue;

                if ((Parameter.FromAmount == null || Parameter.FromAmount <= resultItem.BaseDemand) &&
                    (Parameter.ToAmount == null || resultItem.BaseDemand <= Parameter.ToAmount))
                    result.Add(resultItem);
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
		public static FR_L5AR_GBDfPABTS_1202_Array Invoke(string ConnectionString,P_L5AR_GBDfPABTS_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GBDfPABTS_1202_Array Invoke(DbConnection Connection,P_L5AR_GBDfPABTS_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GBDfPABTS_1202_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GBDfPABTS_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GBDfPABTS_1202_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GBDfPABTS_1202 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GBDfPABTS_1202_Array functionReturn = new FR_L5AR_GBDfPABTS_1202_Array();
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

				throw new Exception("Exception occured in method cls_Get_BaseDemand_for_Period_and_BaseTimeSpan",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GBDfPABTS_1202_Array : FR_Base
	{
		public L5AR_GBDfPABTS_1202[] Result	{ get; set; } 
		public FR_L5AR_GBDfPABTS_1202_Array() : base() {}

		public FR_L5AR_GBDfPABTS_1202_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GBDfPABTS_1202 for attribute P_L5AR_GBDfPABTS_1202
		[DataContract]
		public class P_L5AR_GBDfPABTS_1202 
		{
			//Standard type parameters
			[DataMember]
			public int OrderingPeriodInDays { get; set; } 
			[DataMember]
			public DateTime? BaseTimeSpan_EndDate { get; set; } 
			[DataMember]
			public DateTime? BaseTimeSpan_StartDate { get; set; } 
			[DataMember]
			public int? FromAmount { get; set; } 
			[DataMember]
			public int? ToAmount { get; set; } 
			[DataMember]
			public Guid? SupplierID { get; set; } 
			[DataMember]
			public Guid? ProducerBPID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GBDfPABTS_1202 for attribute L5AR_GBDfPABTS_1202
		[DataContract]
		public class L5AR_GBDfPABTS_1202 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public string SupplierName { get; set; } 
			[DataMember]
			public Double CurrentQuantity { get; set; } 
			[DataMember]
			public Double MSR_or_MSRB { get; set; } 
			[DataMember]
			public Double BaseDemand { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GBDfPABTS_1202_Array cls_Get_BaseDemand_for_Period_and_BaseTimeSpan(,P_L5AR_GBDfPABTS_1202 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GBDfPABTS_1202_Array invocationResult = cls_Get_BaseDemand_for_Period_and_BaseTimeSpan.Invoke(connectionString,P_L5AR_GBDfPABTS_1202 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Articles.Complex.Retrieval.P_L5AR_GBDfPABTS_1202();
parameter.OrderingPeriodInDays = ...;
parameter.BaseTimeSpan_EndDate = ...;
parameter.BaseTimeSpan_StartDate = ...;
parameter.FromAmount = ...;
parameter.ToAmount = ...;
parameter.SupplierID = ...;
parameter.ProducerBPID = ...;

*/
