/* 
 * Generated on 10/10/2014 4:33:37 PM
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
using CL3_Warehouse.Atomic.Retrieval;
using CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL3_Price.Complex.Retrieval;
using CL1_ORD_PRC;
using CL3_APOStatistic.Complex.Retrieval;

namespace CL5_APOProcurement_ProcurementOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementOrderPositions_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrderPositions_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GPOPfH_1015 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5PO_GPOPfH_1015();
            var result = new L5PO_GPOPfH_1015();

            #region Get ProcurementOrder Header
            var resultHeader = cls_Get_ProcurementOrderHeader_for_HeaderID.Invoke(Connection, Transaction
                , new P_L5PO_GPOHfH_1406()
                {
                    ProcurementOrderHeaderID = Parameter.ProcurementOrderHeaderID
                }, securityTicket).Result.FirstOrDefault();
            result.Header = resultHeader;
            #endregion

            #region Get Procurement Order Positions
            var procurementOrderPositions = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction
                , new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                {
                    ProcurementOrder_Header_RefID = Parameter.ProcurementOrderHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
            if (procurementOrderPositions == null || procurementOrderPositions.Count() <= 0)
            {
                returnValue.Status = FR_Status.Success;
                result.Positions = new L5PO_GPOPfH_1015a[0];
                returnValue.Result = result;
                return returnValue;
            }
            var productIds = procurementOrderPositions.Select(i => i.CMN_PRO_Product_RefID).Distinct().ToArray();
            #endregion

            #region get expected delivery
            P_L5PO_GEDfPOP_1132 expectedDeliveryParam = new P_L5PO_GEDfPOP_1132();
            expectedDeliveryParam.ProcurementOrderPositions = procurementOrderPositions.Select(i => i.ORD_PRC_ProcurementOrder_PositionID).ToArray();
            var expectedDeliveries = cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions.Invoke(Connection, Transaction, expectedDeliveryParam, securityTicket).Result;

            if (expectedDeliveries != null && expectedDeliveries.Length > 0)
            {
                result.ExpectedDeliveryDate = expectedDeliveries.First().ExpectedDeliveryDate;
            }
            #endregion

            #region Get cash discount
            var discountTypeParam = new P_L2DT_GDTfGPMIL_1546();
            discountTypeParam.GlobalPropertyMatchingID_List = new string[] 
            {
                EnumUtils.GetEnumDescription(EDiscountType.CashDiscount),                      
            };
            var discountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypeParam, securityTicket).Result;

            if (discountTypes != null && discountTypes.Length > 0)
            {
                var discountTypeID = discountTypes.First().ORD_PRC_DiscountTypeID;
                var positionIDs = procurementOrderPositions.Select(i => i.ORD_PRC_ProcurementOrder_PositionID).ToArray();
                foreach (var item in positionIDs)
                { 
                    var positionDiscount = ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query.Search(Connection, Transaction,
                        new ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            ORD_PRC_ProcurementOrder_Position_RefID = item,
                            ORD_PRC_DiscountType_RefID = discountTypeID
                        });

                    if (positionDiscount != null && positionDiscount.Count > 0)
                    {
                        result.CashDiscount = positionDiscount.First().DiscountValue;
                        break;
                    }
                }
            }
            
            #endregion

            #region Get discounts for procurement order positions
            var discounts = cls_Get_Discounts_for_ProcurementOrderPositions.Invoke(Connection, Transaction,
                new P_L5PO_GDfPOP_1706()
                {
                    ProcOrderPositionsList = procurementOrderPositions.Select(i => i.ORD_PRC_ProcurementOrder_PositionID).ToArray()
                }
                ,securityTicket).Result;
            #endregion

            #region Get Articles For ShipmentPositions
            var articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction
                , new P_L3AR_GAfAL_0942()
                {
                    ProductID_List = productIds
                }
                , securityTicket).Result;
            #endregion

            #region Get Available Product Quantities
            var shelfContents = cls_Get_CurrentShelfContents_and_ActiveReservations_for_ProductIDList.Invoke(Connection, Transaction
                , new P_L3WH_GCSCaARfP_1835()
                {
                    ProductIDList = productIds
                }
                , securityTicket).Result.ToList();
            #endregion

            #region Get Standard Price
            var standardPrices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction
                , new P_L3PR_GSPfPIL_1645()
                {
                    ProductIDList = productIds
                }
                , securityTicket).Result;
            #endregion

            #region Get MSR

            var msrForProducts = cls_Get_MSR_for_ProductIDList.Invoke(Connection, Transaction, new P_L3AS_GSMRfPL_1508 { ProductIDList = productIds }, securityTicket).Result;
            
            #endregion

            #region Set Result
            var resultsPositions = new List<L5PO_GPOPfH_1015a>();
            foreach (var pop in procurementOrderPositions)
            {
                var productMsr = msrForProducts.SingleOrDefault(x => x.ProductID == pop.CMN_PRO_Product_RefID);
                
                var standardPrice = standardPrices.Where(ap => ap.ProductID == pop.CMN_PRO_Product_RefID).ToList();
                var aekPrice = standardPrice.Single().AverageProcurementPrice == 0
                    ? standardPrice.Single().AbdaPrice : standardPrice.Single().AverageProcurementPrice;
                var inStock = shelfContents.Where(sc => sc.Product_RefID == pop.CMN_PRO_Product_RefID).ToList();
                var position = new L5PO_GPOPfH_1015a1()
                {
                    ProcurementOrderHeaderId = pop.ProcurementOrder_Header_RefID,
                    ProcurementOrderPositionId = pop.ORD_PRC_ProcurementOrder_PositionID,
                    CreationTimestamp = pop.Creation_Timestamp,
                    PositionQuantity = pop.Position_Quantity,
                    PositionValuePerUnit = pop.Position_ValuePerUnit,
                    PositionValueTotal = pop.Position_ValueTotal,
                    QuantityInStock = inStock.Count <= 0 ? 0 : inStock.Single().CurrentQuantity,
                    AEKPrice = aekPrice,
                    MSR = (productMsr != null) ? productMsr.MSR : 0.0
                };

                var discount = discounts.Where(a => a.ord_prc_procurementOrder_Position_RefID == pop.ORD_PRC_ProcurementOrder_PositionID).ToArray();

                resultsPositions.Add(new L5PO_GPOPfH_1015a()
                {
                    Position = position,
                    Discount = ((discount == null) || (discount.Length == 0)) ? null : discount,
                    Article = articles.Where(a => a.CMN_PRO_ProductID == pop.CMN_PRO_Product_RefID).Single()
                });
            }
            result.Positions = resultsPositions.ToArray();

            returnValue.Result = result;
            returnValue.Status = FR_Status.Success;
            #endregion
             
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PO_GPOPfH_1015 Invoke(string ConnectionString,P_L5PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOPfH_1015 Invoke(DbConnection Connection,P_L5PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GPOPfH_1015 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GPOPfH_1015 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GPOPfH_1015 functionReturn = new FR_L5PO_GPOPfH_1015();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrderPositions_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GPOPfH_1015 : FR_Base
	{
		public L5PO_GPOPfH_1015 Result	{ get; set; }

		public FR_L5PO_GPOPfH_1015() : base() {}

		public FR_L5PO_GPOPfH_1015(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PO_GPOPfH_1015 for attribute P_L5PO_GPOPfH_1015
		[DataContract]
		public class P_L5PO_GPOPfH_1015 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5PO_GPOPfH_1015 for attribute L5PO_GPOPfH_1015
		[DataContract]
		public class L5PO_GPOPfH_1015 
		{
			[DataMember]
			public L5PO_GPOPfH_1015a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.L5PO_GPOHfH_1406 Header { get; set; } 
			[DataMember]
			public double CashDiscount { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 

		}
		#endregion
		#region SClass L5PO_GPOPfH_1015a for attribute Positions
		[DataContract]
		public class L5PO_GPOPfH_1015a 
		{
			[DataMember]
			public L5PO_GPOPfH_1015a1 Position { get; set; }

			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval.L5PO_GDfPOP_1706[] Discount { get; set; } 

		}
		#endregion
		#region SClass L5PO_GPOPfH_1015a1 for attribute Position
		[DataContract]
		public class L5PO_GPOPfH_1015a1 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderId { get; set; } 
			[DataMember]
			public Guid ProcurementOrderPositionId { get; set; } 
			[DataMember]
			public double PositionQuantity { get; set; } 
			[DataMember]
			public decimal PositionValuePerUnit { get; set; } 
			[DataMember]
			public decimal PositionValueTotal { get; set; } 
			[DataMember]
			public decimal AEKPrice { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public double QuantityInStock { get; set; } 
			[DataMember]
			public double MSR { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GPOPfH_1015 cls_Get_ProcurementOrderPositions_for_HeaderID(,P_L5PO_GPOPfH_1015 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GPOPfH_1015 invocationResult = cls_Get_ProcurementOrderPositions_for_HeaderID.Invoke(connectionString,P_L5PO_GPOPfH_1015 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Complex.Retrieval.P_L5PO_GPOPfH_1015();
parameter.ProcurementOrderHeaderID = ...;

*/
