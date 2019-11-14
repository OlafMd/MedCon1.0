/* 
 * Generated on 11/4/2014 5:03:03 PM
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
using CL2_Shipment.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;
using CL2_Price.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_LOG_RSV;
using CL1_ORD_CUO;

namespace CL5_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GSPwPaSfSH_1141_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GSPwPaSfSH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5SO_GSPwPaSfSH_1141_Array();

            #region Get Shipment Positions

            P_L2SH_GSPfToSH_1334 positionsGetParam = new P_L2SH_GSPfToSH_1334();
            positionsGetParam.ShipmentHeaderID = Parameter.ShippmentHeaderID;
            var shipmentPositions = cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID.Invoke(Connection, Transaction, positionsGetParam, securityTicket).Result.ToList();

            #endregion

            if(shipmentPositions.Count()==0){
                returnValue.Result = new L5SO_GSPwPaSfSH_1141[0];
                return returnValue;
            }

            #region Get Articles For ShipmentPositions

            P_L3AR_GAfAL_0942 articlesGetParam = new P_L3AR_GAfAL_0942();
            articlesGetParam.ProductID_List = shipmentPositions.Select(i=>i.CMN_PRO_Product_RefID).Distinct().ToArray();

            var articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articlesGetParam, securityTicket).Result;

            #endregion

            #region Get Quantities on Shelf contents per product

            var articleIDs = shipmentPositions.Select(x => x.CMN_PRO_Product_RefID).Distinct();
            var qntsPerProduct = new L3WH_GASCQfPL_1239[] { };
            if (articleIDs.Count() > 0)
            {
                var qntParam = new P_L3WH_GASCQfPL_1239 { ProductIDList = articleIDs.ToArray() };
                qntsPerProduct = cls_Get_All_ShelfContent_Quantities_for_ProductListID.Invoke(Connection, Transaction, qntParam, securityTicket).Result;
            }

            #endregion

            #region Get ABDAPrices 

            var abdaPricesParam = new P_L2PR_GPVfSC_1424()
            {
                SubscribedCatalogITL = EnumUtils.GetEnumDescription(EPublicCatalogs.ABDA)
            };

            var abdaPrices = cls_Get_PriceValues_for_SubscribedCatalogITL.Invoke(Connection, Transaction, abdaPricesParam, securityTicket).Result;

            #endregion

            #region cls_Get_AllGeneralAverageProcurementPrices_for_TenantID

            var avgProcPrice = cls_Get_AllGeneralAverageProcurementPrices_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            #endregion

            List<L5SO_GSPwPaSfSH_1141> listOfPositionsWithPrices = new List<L5SO_GSPwPaSfSH_1141>();

            foreach (var position in shipmentPositions)
            {
                var quantity = qntsPerProduct.Where(i=>i.Product_RefID == position.CMN_PRO_Product_RefID).SingleOrDefault();
                if(quantity==null)
                {
                    quantity = new L3WH_GASCQfPL_1239() {
                        Product_RefID = position.CMN_PRO_Product_RefID,
                        Sum_Quantity_Current = 0,
                        Sum_R_ReservedQuantity = 0,
                        Sum_R_FreeQuantity = 0
                    };
                }

                var tempPositionWithPrice = new L5SO_GSPwPaSfSH_1141();
                tempPositionWithPrice.ShipmentPositionID = position.LOG_SHP_Shipment_PositionID;

                var reservationSum = ORM_LOG_RSV_Reservation.Query.Search(Connection, Transaction, new ORM_LOG_RSV_Reservation.Query()
                {
                    LOG_SHP_Shipment_Position_RefID = position.LOG_SHP_Shipment_PositionID,
                    IsDeleted = false,
                    IsReservationExecuted = false
                }).Sum(x => x.ReservedQuantity);

                var correspodingCustomerOrderPosition = new ORM_ORD_CUO_CustomerOrder_Position();

                var positionArticle = articles.Where(ar => ar.CMN_PRO_ProductID == position.CMN_PRO_Product_RefID).Single();
                tempPositionWithPrice.Product_Number = positionArticle.Product_Number;
                tempPositionWithPrice.Product_Name = positionArticle.Product_Name;
                tempPositionWithPrice.UnitAmount = positionArticle.UnitAmount;
                tempPositionWithPrice.UnitIsoCode = positionArticle.UnitIsoCode;
                tempPositionWithPrice.DossageFormName = positionArticle.DossageFormName;
                tempPositionWithPrice.Producer = positionArticle.ProducerName;
                tempPositionWithPrice.CMN_PRO_ProductID = positionArticle.CMN_PRO_ProductID;

                tempPositionWithPrice.ReservedQuantity = reservationSum;
                tempPositionWithPrice.QuantityToShip = position.QuantityToShip;
                tempPositionWithPrice.QuantityInStock = quantity.Sum_Quantity_Current;
                tempPositionWithPrice.QuantityAvailable = quantity.Sum_R_FreeQuantity;

                tempPositionWithPrice.ABDAPrice = abdaPrices.Where(i => i.CMN_PRO_Product_RefID == position.CMN_PRO_Product_RefID).Select(j => j.PriceAmount).SingleOrDefault();
                tempPositionWithPrice.SalesPrice = position.ShipmentPosition_ValueWithoutTax;
                tempPositionWithPrice.AverageProcurementPrice = avgProcPrice.Where(i => i.Product_RefID == position.CMN_PRO_Product_RefID).Select(j=>j.PriceValue_Amount).SingleOrDefault();
                tempPositionWithPrice.ShipmentPosition_PricePerUnitValueWithoutTax = position.ShipmentPosition_PricePerUnitValueWithoutTax;

                #region Product Replacement Allowed

                var assignmentToCustomerOrderPositionQuery = new ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query();
                assignmentToCustomerOrderPositionQuery.LOG_SHP_Shipment_Position_RefID = position.LOG_SHP_Shipment_PositionID;
                assignmentToCustomerOrderPositionQuery.Tenant_RefID = securityTicket.TenantID;
                assignmentToCustomerOrderPositionQuery.IsDeleted = false;
                var foundAssignment = ORM_ORD_CUO_CustomerOrder_Position_2_ShipmentPosition.Query.
                    Search(Connection, Transaction, assignmentToCustomerOrderPositionQuery).SingleOrDefault();

                if (foundAssignment != null)
                {
                    correspodingCustomerOrderPosition.Load(Connection, Transaction, foundAssignment.ORD_CUO_CustomerOrder_Position_RefID);
                    tempPositionWithPrice.IsProductReplacementAllowed = correspodingCustomerOrderPosition.IsProductReplacementAllowed;
                }
                else
                {
                    tempPositionWithPrice.IsProductReplacementAllowed = true;
                }
                
                #endregion

                listOfPositionsWithPrices.Add(tempPositionWithPrice);
            }

            returnValue.Result = listOfPositionsWithPrices.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GSPwPaSfSH_1141_Array Invoke(string ConnectionString,P_L5SO_GSPwPaSfSH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GSPwPaSfSH_1141_Array Invoke(DbConnection Connection,P_L5SO_GSPwPaSfSH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GSPwPaSfSH_1141_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GSPwPaSfSH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GSPwPaSfSH_1141_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GSPwPaSfSH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GSPwPaSfSH_1141_Array functionReturn = new FR_L5SO_GSPwPaSfSH_1141_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GSPwPaSfSH_1141_Array : FR_Base
	{
		public L5SO_GSPwPaSfSH_1141[] Result	{ get; set; } 
		public FR_L5SO_GSPwPaSfSH_1141_Array() : base() {}

		public FR_L5SO_GSPwPaSfSH_1141_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GSPwPaSfSH_1141 for attribute P_L5SO_GSPwPaSfSH_1141
		[DataContract]
		public class P_L5SO_GSPwPaSfSH_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShippmentHeaderID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GSPwPaSfSH_1141 for attribute L5SO_GSPwPaSfSH_1141
		[DataContract]
		public class L5SO_GSPwPaSfSH_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentPositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public double UnitAmount { get; set; } 
			[DataMember]
			public String UnitIsoCode { get; set; } 
			[DataMember]
			public string DossageFormName { get; set; } 
			[DataMember]
			public string Producer { get; set; } 
			[DataMember]
			public double ReservedQuantity { get; set; } 
			[DataMember]
			public double QuantityToShip { get; set; } 
			[DataMember]
			public double QuantityInStock { get; set; } 
			[DataMember]
			public double QuantityAvailable { get; set; } 
			[DataMember]
			public decimal ABDAPrice { get; set; } 
			[DataMember]
			public decimal SalesPrice { get; set; } 
			[DataMember]
			public decimal AverageProcurementPrice { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_PricePerUnitValueWithoutTax { get; set; } 
			[DataMember]
			public Boolean IsProductReplacementAllowed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GSPwPaSfSH_1141_Array cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID(,P_L5SO_GSPwPaSfSH_1141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GSPwPaSfSH_1141_Array invocationResult = cls_Get_ShipmentPositions_with_Prices_and_Stock_for_ShipmentHeaderID.Invoke(connectionString,P_L5SO_GSPwPaSfSH_1141 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Retrieval.P_L5SO_GSPwPaSfSH_1141();
parameter.ShippmentHeaderID = ...;
parameter.LanguageID = ...;

*/
