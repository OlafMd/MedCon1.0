/* 
 * Generated on 6/24/2014 1:24:34 PM
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
using CL5_APOProcurement_ProcurementOrder.Atomic.Retrieval;
using CL3_ProcurementOrder.Atomic.Retrieval;
using CL3_APOProcurement_ProcurementOrder.Complex.Manipulation;
using CL3_ProcurementOrder.Complex.Manipulation;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL5_APOProcurement_ProcurementOrder.Atomic.Manipulation;

namespace CL5_APOProcurement_ProcurementOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_ExtraDemandProduct_to_ProcurementOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_ExtraDemandProduct_to_ProcurementOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_AEDPtPO_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode
			var returnValue = new FR_Guid();

            CL1_ORD_PRC.ORM_ORD_PRC_ExtraDemandProduct extraDemandProduct = null;

            foreach (var item in Parameter.ExtraDemandProductIDs)
            {
                extraDemandProduct = new CL1_ORD_PRC.ORM_ORD_PRC_ExtraDemandProduct();
                extraDemandProduct.Load(Connection, Transaction, item);

                #region Procurement Order Header

                var pohSupplierParam = new P_L3PO_GAPOHfS_1412();
                string statusActive = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EProcurementStatus.Active);
                pohSupplierParam.ActiveStatus_GlobalPropertyMatchingID = statusActive;
                pohSupplierParam.SupplierID = extraDemandProduct.Supplier_RefID;
                
                var procurementHeader = cls_Get_Active_ProcurementOrderHeader_for_SupplierID.Invoke(
                    Connection, Transaction, pohSupplierParam, securityTicket).Result.SingleOrDefault();

                Guid ProcurementOrderHeaderID = Guid.Empty;

                if (procurementHeader == null || procurementHeader.ORD_PRC_ProcurementOrder_HeaderID == Guid.Empty)
                {
                    // Create new procurement header
                    var pohParam = new P_L3PO_SPOH_0323();
                    pohParam.SupplierID = extraDemandProduct.Supplier_RefID;
                    pohParam.GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ProcurementOrderNumber);

                    ProcurementOrderHeaderID = cls_Save_ProcurementOrder_Header.Invoke(Connection, Transaction, pohParam, securityTicket).Result;
                }
                else
                {
                    ProcurementOrderHeaderID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
                }

                #endregion
                
                #region Create Procurement Order Position
                var priceParam = new CL3_Price.Complex.Retrieval.P_L3PR_GSPfPIL_1645
                {
                    ProductIDList = new Guid[] { extraDemandProduct.Product_RefID }
                };

                var price = CL3_Price.Complex.Retrieval.cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, priceParam, securityTicket).Result.Single();

                var positionParam = new P_L3PO_SPOP_0331
                {
                    ORD_PRC_ProcurementOrder_HeaderID = ProcurementOrderHeaderID,
                    Positions = new P_L3PO_SPOP_0331a[]
                    {
                        new P_L3PO_SPOP_0331a
                        {
                            ORD_PRC_ProcurementOrder_PositionID = Guid.Empty,
                            IsDeleted = false,
                            Position_Quantity = extraDemandProduct.RequestedQuantity,
                            PricePerUnit = price.AverageProcurementPrice,
                            ProductID = extraDemandProduct.Product_RefID
                        }
                    }
                };
                Guid[] result = cls_Save_ProcurementOrder_Positions.Invoke(Connection, Transaction, positionParam, securityTicket).Result;

                #region create cash discount
                //Create cash discount type for positions
                P_L5PO_GDVfHaDT_1607 param = new P_L5PO_GDVfHaDT_1607();
                param.DiscountType = EnumUtils.GetEnumDescription(EDiscountType.CashDiscount);
                param.HeaderID = ProcurementOrderHeaderID;

                var discounts = cls_Get_DiscountValues_for_HeaderID_and_DiscountType.Invoke(Connection, Transaction, param, securityTicket).Result.ToList();

                if (discounts != null && discounts.Count > 0)
                {
                    P_L5PO_SCDfHoP_1117 newDiscountParam = new P_L5PO_SCDfHoP_1117();
                    newDiscountParam.DiscountValue = discounts.First().DiscountValue;
                    newDiscountParam.ProcurementOrderPositionIDList = result;

                    cls_Save_CashDiscount_for_Header_or_Position.Invoke(Connection, Transaction, newDiscountParam, securityTicket);
                }
                #endregion

                #endregion

                extraDemandProduct.ProcurementOrderPosition_RefID = result[0];

                extraDemandProduct.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PO_AEDPtPO_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PO_AEDPtPO_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_AEDPtPO_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_AEDPtPO_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Add_ExtraDemandProduct_to_ProcurementOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PO_AEDPtPO_1324 for attribute P_L5PO_AEDPtPO_1324
		[DataContract]
		public class P_L5PO_AEDPtPO_1324 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ExtraDemandProductIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_ExtraDemandProduct_to_ProcurementOrder(,P_L5PO_AEDPtPO_1324 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_ExtraDemandProduct_to_ProcurementOrder.Invoke(connectionString,P_L5PO_AEDPtPO_1324 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Complex.Manipulation.P_L5PO_AEDPtPO_1324();
parameter.ExtraDemandProductIDs = ...;

*/
