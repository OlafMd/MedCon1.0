/* 
 * Generated on 9/25/2014 3:07:09 PM
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
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL5_APOLogistic_StockReceipt.Complex.Retrieval;
using CL1_LOG_RCP;
using CL1_ORD_PRC;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ExpectedDeliveries_for_UndeliveredPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ExpectedDeliveries_for_UndeliveredPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_CEDfUP_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			
            #region Save Header

            #region Expected Delivery Header

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ExpectedDeliveryNumber)
            };
            var expectedDeliveryNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            var expectedDeliveryHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header();
            expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID = Guid.NewGuid();
            expectedDeliveryHeader.ExpectedDeliveryNumber = expectedDeliveryNumber;
            expectedDeliveryHeader.IsDeliveryOpen = true;
            expectedDeliveryHeader.IsDeliveryClosed = false;
            expectedDeliveryHeader.ExpectedDeliveryHeaderITL = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID.ToString();
            expectedDeliveryHeader.ExpectedDeliveryDate = Parameter.ExpectedDeliveryDate;
            expectedDeliveryHeader.Tenant_RefID = securityTicket.TenantID;
            expectedDeliveryHeader.Creation_Timestamp = DateTime.Now;
            expectedDeliveryHeader.Save(Connection, Transaction);

            #endregion

            #region Receipt Header

            var oldReceiptHeader = new ORM_LOG_RCP_Receipt_Header();
            oldReceiptHeader.Load(Connection, Transaction, Parameter.ReceiptHeaderID);

            incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.StockReceiptNumber)
            };
            var receiptNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            var receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
            receiptHeader.ReceiptNumber = receiptNumber;
            receiptHeader.LOG_RCP_Receipt_HeaderID = Guid.NewGuid();
            receiptHeader.Creation_Timestamp = DateTime.Now;
            receiptHeader.Tenant_RefID = securityTicket.TenantID;
            receiptHeader.ReceiptHeaderITL = receiptHeader.LOG_RCP_Receipt_HeaderID.ToString();
            receiptHeader.IsTakenIntoStock = false;
            receiptHeader.ProvidingSupplier_RefID = oldReceiptHeader.ProvidingSupplier_RefID;
            receiptHeader.ExpectedDeliveryHeader_RefID = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID;
            receiptHeader.Save(Connection, Transaction);

            #endregion Receipt Header

            #region Procurement Order

            var oldReceiptToProcurement = ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction, new ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query()
            {
                LOG_RCP_Receipt_Header_RefID = Parameter.ReceiptHeaderID,
                IsDeleted = false
            }).First();

            var receiptToProcurement = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader();
            receiptToProcurement.AssignmentID = Guid.NewGuid();
            receiptToProcurement.Creation_Timestamp = DateTime.Now;
            receiptToProcurement.Tenant_RefID = securityTicket.TenantID;
            receiptToProcurement.LOG_RCP_Receipt_Header_RefID = receiptHeader.LOG_RCP_Receipt_HeaderID;
            receiptToProcurement.ORD_PRO_ProcurementOrder_Header_RefID = oldReceiptToProcurement.ORD_PRO_ProcurementOrder_Header_RefID;
            receiptToProcurement.Save(Connection, Transaction);
           
            #endregion

            #endregion

            #region Save Positions

            P_L5SR_GSRPfH_1544 param = new P_L5SR_GSRPfH_1544();
            param.ReceiptHeaderID = Parameter.ReceiptHeaderID;
            var stockReceiptsPositions = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID.Invoke(Connection, Transaction, param, securityTicket).Result;

            foreach (var positionParam in Parameter.ReceiptPositions)
            {
                var item = stockReceiptsPositions.Single(i => i.OrderPosition.LOG_RCP_Receipt_PositionID == positionParam.ReceipPositionID);

                #region Receipt Position

                var receiptPosition = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position();
                receiptPosition.LOG_RCP_Receipt_PositionID = Guid.NewGuid();
                receiptPosition.Receipt_Header_RefID = receiptHeader.LOG_RCP_Receipt_HeaderID;
                receiptPosition.ReceiptPosition_Product_RefID = item.OrderPosition.ReceiptPosition_Product_RefID;
                receiptPosition.TotalQuantityFreeOfCharge = 0.0;
                receiptPosition.TotalQuantityTakenIntoStock = 0.0;
                receiptPosition.ExpectedPositionPrice = item.OrderPosition.Receipt_ExpectedPositionPrice;
                receiptPosition.Creation_Timestamp = DateTime.Now;
                receiptPosition.Tenant_RefID = securityTicket.TenantID;
                receiptPosition.Save(Connection, Transaction);

                #endregion

                #region ReceiptPosition to ProcurementOrderPosition

                var receiptToProcurementPosition = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition();
                receiptToProcurementPosition.AssignmentID = Guid.NewGuid();
                receiptToProcurementPosition.ORD_PRO_ProcurementOrder_Position_RefID = item.OrderPosition.ORD_PRC_ProcurementOrder_PositionID;
                receiptToProcurementPosition.LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                receiptToProcurementPosition.ReceivedQuantityFromProcurementOrderPosition = positionParam.ExpectedQuantity;
                receiptToProcurementPosition.Creation_Timestamp = DateTime.Now;
                receiptToProcurementPosition.Tenant_RefID = securityTicket.TenantID;
                receiptToProcurementPosition.Save(Connection, Transaction);

                #endregion

                #region Expected Delivery

                var expectedDeliveryPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position();
                expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_PositionID = Guid.NewGuid();
                expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_RefID = receiptHeader.ExpectedDeliveryHeader_RefID;
                expectedDeliveryPosition.TotalExpectedQuantity = positionParam.ExpectedQuantity;
                expectedDeliveryPosition.Creation_Timestamp = DateTime.Now;
                expectedDeliveryPosition.Tenant_RefID = securityTicket.TenantID;
                expectedDeliveryPosition.Save(Connection, Transaction);

                var expectedDeliveryToProcurementOrderPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition();
                expectedDeliveryToProcurementOrderPosition.AssignmentID = Guid.NewGuid();
                expectedDeliveryToProcurementOrderPosition.ORD_PRC_ExpectedDelivery_Position_RefID = expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_PositionID;
                expectedDeliveryToProcurementOrderPosition.ORD_PRC_ProcurementOrder_Position_RefID = item.OrderPosition.ORD_PRC_ProcurementOrder_PositionID;
                expectedDeliveryToProcurementOrderPosition.AssignedQuantityFromProcurementOrderPosition = positionParam.ExpectedQuantity;
                expectedDeliveryToProcurementOrderPosition.Creation_Timestamp = DateTime.Now;
                expectedDeliveryToProcurementOrderPosition.Tenant_RefID = securityTicket.TenantID;
                expectedDeliveryToProcurementOrderPosition.Save(Connection, Transaction);

                #endregion

                #region Quality Control Items

                var oldQualityControlItem = ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.Search(Connection, Transaction, new ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query()
                {
                    Receipt_Position_RefID = item.OrderPosition.LOG_RCP_Receipt_PositionID,
                    IsDeleted = false
                }).First();

                var qualityControlItem = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                qualityControlItem.LOG_RCP_Receipt_Position_QualityControlItem = Guid.NewGuid();
                qualityControlItem.ReceiptPositionCountedItemITL = qualityControlItem.LOG_RCP_Receipt_Position_QualityControlItem.ToString();
                qualityControlItem.Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                qualityControlItem.BatchNumber = oldQualityControlItem.BatchNumber;
                qualityControlItem.ExpiryDate = oldQualityControlItem.ExpiryDate;
                qualityControlItem.Quantity = positionParam.ExpectedQuantity;
                qualityControlItem.Creation_Timestamp = DateTime.Now;
                qualityControlItem.Tenant_RefID = securityTicket.TenantID;
                qualityControlItem.Save(Connection, Transaction);

                #endregion

                #region Forwarding Instruction

                var oldForwardingInstruction = ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query()
                {
                    ProcurementOrder_Position_RefID = item.OrderPosition.ORD_PRC_ProcurementOrder_PositionID,
                    IsDeleted = false
                }).First();

                var forwardingInstruction = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction();
                forwardingInstruction.ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID = Guid.NewGuid();
                forwardingInstruction.ProcurementOrder_Position_RefID = item.OrderPosition.ORD_PRC_ProcurementOrder_PositionID;
                forwardingInstruction.ForwardTo_BusinessParticipant_RefID = oldForwardingInstruction.ForwardTo_BusinessParticipant_RefID;
                forwardingInstruction.QuantityToForward = positionParam.ExpectedQuantity;
                forwardingInstruction.Creation_Timestamp = DateTime.Now;
                forwardingInstruction.Tenant_RefID = securityTicket.TenantID;
                forwardingInstruction.Save(Connection, Transaction);

                #endregion
            }

            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_CEDfUP_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_CEDfUP_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_CEDfUP_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_CEDfUP_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_ExpectedDeliveries_for_UndeliveredPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_CEDfUP_1438 for attribute P_L5SR_CEDfUP_1438
		[DataContract]
		public class P_L5SR_CEDfUP_1438 
		{
			[DataMember]
			public P_L5SR_CEDfUP_1438a[] ReceiptPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 

		}
		#endregion
		#region SClass P_L5SR_CEDfUP_1438a for attribute ReceiptPositions
		[DataContract]
		public class P_L5SR_CEDfUP_1438a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceipPositionID { get; set; } 
			[DataMember]
			public double ExpectedQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ExpectedDeliveries_for_UndeliveredPositions(,P_L5SR_CEDfUP_1438 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ExpectedDeliveries_for_UndeliveredPositions.Invoke(connectionString,P_L5SR_CEDfUP_1438 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_CEDfUP_1438();
parameter.ReceiptPositions = ...;

parameter.ReceiptHeaderID = ...;
parameter.ExpectedDeliveryDate = ...;

*/
