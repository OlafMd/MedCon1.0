/* 
 * Generated on 10/23/2014 7:17:42 PM
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
using CL1_ORD_PRC;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOProcurement_ProcurementOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ExpectedDelivery.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ExpectedDelivery
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_CED_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            List<Guid> positionsForCreating = new List<Guid>();
            Guid headerID = new Guid();

            var procurementHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header();
            procurementHeader.Load(Connection, Transaction, Parameter.ProcurementHeaderID);

            if (procurementHeader == null)
                throw new Exception("wrong procurment header!");

            #region Update Procurement Order

            var newProcurementOrderStatusID = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query()
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(EProcurementStatus.Ordered),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().ORD_PRC_ProcurementOrder_StatusID;

            procurementHeader.Current_ProcurementOrderStatus_RefID = newProcurementOrderStatusID;
            procurementHeader.Save(Connection, Transaction);

            // Create procurement order status history
            var procurementOrderStatusHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_StatusHistory();
            procurementOrderStatusHistory.Tenant_RefID = securityTicket.TenantID;
            procurementOrderStatusHistory.ProcurementOrder_Header_RefID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
            procurementOrderStatusHistory.ProcurementOrder_Status_RefID = newProcurementOrderStatusID;
            procurementOrderStatusHistory.StatusHistoryComment = "";
            procurementOrderStatusHistory.Save(Connection, Transaction);

            #endregion           

            var procurementPositionsQuery = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query();
            procurementPositionsQuery.ProcurementOrder_Header_RefID = Parameter.ProcurementHeaderID;
            procurementPositionsQuery.Tenant_RefID = securityTicket.TenantID;
            procurementPositionsQuery.IsDeleted = false;
            var foundProcurementPositions = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, procurementPositionsQuery).ToList();

            //positionIDs
            var positionIDs = foundProcurementPositions.Select(x => x.ORD_PRC_ProcurementOrder_PositionID);

            //find expected delivery data if exist
            P_L5PO_GEDfPOP_1132 expDeliveryParam = new P_L5PO_GEDfPOP_1132();
            expDeliveryParam.ProcurementOrderPositions = positionIDs.ToArray();
            var expectedDeliveries = cls_Get_ExpectedDeliveries_for_ProcurementOrderPositions.Invoke(Connection, Transaction, expDeliveryParam, securityTicket).Result;
            CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header expectedDeliveryHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header();

            if (expectedDeliveries != null && expectedDeliveries.Length > 0)
            {
                expectedDeliveryHeader = new ORM_ORD_PRC_ExpectedDelivery_Header();
                expectedDeliveryHeader.Load(Connection, Transaction, expectedDeliveries.First().ORD_PRC_ExpectedDelivery_HeaderID);
                expectedDeliveryHeader.ExpectedDeliveryDate = Parameter.ExpectedDeliveryDate;
                expectedDeliveryHeader.Save(Connection, Transaction);

                headerID = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID;

                foreach (var item in expectedDeliveries)
                {
                    if (!positionIDs.Contains(item.ORD_PRC_ProcurementOrder_Position_RefID))
                    {
                        positionsForCreating.Add(item.ORD_PRC_ProcurementOrder_Position_RefID);
                    }
                }
            }
            else
            {
                positionsForCreating.AddRange(positionIDs);
                //napraviti header
                
                expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID = Guid.NewGuid();
                expectedDeliveryHeader.ExpectedDeliveryHeaderITL = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID.ToString();

                //finding global property matchin id from number ranges for expected delivery
                var expectedDeliveryNumberParam = new CL2_NumberRange.Complex.Retrieval.P_L2NR_GaIINfUA_1454();
                expectedDeliveryNumberParam.GlobalStaticMatchingID = DLCore_DBCommons.Utils.EnumUtils.
                    GetEnumDescription(DLCore_DBCommons.APODemand.ENumberRangeUsageAreaType.ExpectedDeliveryNumber);

                expectedDeliveryHeader.ExpectedDeliveryNumber = CL2_NumberRange.Complex.Retrieval.cls_Get_and_Increase_IncreasingNumber_for_UsageArea.
                    Invoke(Connection, Transaction, expectedDeliveryNumberParam, securityTicket).Result.Current_IncreasingNumber;
                expectedDeliveryHeader.ExpectedDeliveryDate = Parameter.ExpectedDeliveryDate;
                expectedDeliveryHeader.LOG_WRH_Warehouse_RefID = Guid.Empty;
                expectedDeliveryHeader.IsDeleted = false;
                expectedDeliveryHeader.Tenant_RefID = securityTicket.TenantID;
                expectedDeliveryHeader.IsDeliveryOpen = true;
                expectedDeliveryHeader.IsDeliveryManuallyCreated = true;

                expectedDeliveryHeader.Save(Connection, Transaction);

                headerID = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID;
            }


            #region Get receiptHeader or create it if don't exist

            var queryProcurement = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query()
            {
                ORD_PRO_ProcurementOrder_Header_RefID = Parameter.ProcurementHeaderID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            };
            var receiptToProcurementHeader = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction, queryProcurement).SingleOrDefault();

            var receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
            Guid receiptHeaderID = Guid.Empty;
            if (receiptToProcurementHeader == null)
            {
                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.StockReceiptNumber)
                };
                var receiptNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
                receiptHeader.ReceiptNumber = receiptNumber;
                receiptHeader.ExpectedDeliveryHeader_RefID = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID;
                receiptHeader.ProvidingSupplier_RefID = procurementHeader.ProcurementOrder_Supplier_RefID;
                receiptHeader.LOG_RCP_Receipt_HeaderID = Guid.NewGuid();
                receiptHeader.Creation_Timestamp = DateTime.Now;
                receiptHeader.ReceiptHeaderITL = receiptHeader.LOG_RCP_Receipt_HeaderID.ToString();
                receiptHeader.IsTakenIntoStock = false;
                receiptHeader.Tenant_RefID = securityTicket.TenantID;
                receiptHeader.Save(Connection, Transaction);

                receiptHeaderID = receiptHeader.LOG_RCP_Receipt_HeaderID;

                var receipt2sProcurementHeader = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader();
                receipt2sProcurementHeader.LOG_RCP_Receipt_Header_RefID = receiptHeaderID;
                receipt2sProcurementHeader.ORD_PRO_ProcurementOrder_Header_RefID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
                receipt2sProcurementHeader.Tenant_RefID = securityTicket.TenantID;
                receipt2sProcurementHeader.IsDeleted = false;
                receipt2sProcurementHeader.Creation_Timestamp = DateTime.Now;
                receipt2sProcurementHeader.Save(Connection, Transaction);

            }
            else
            {
                receiptHeaderID = receiptToProcurementHeader.LOG_RCP_Receipt_Header_RefID;
            }

            var receiptPositions = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query.Search(Connection, Transaction,
              new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query
              {
                  Tenant_RefID = securityTicket.TenantID,
                  IsDeleted = false,
                  Receipt_Header_RefID = receiptHeaderID
              });


            #endregion

            foreach (var position in foundProcurementPositions)
            {

                #region Expected Delivery
                CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position deliveryPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position();
                deliveryPosition.ORD_PRC_ExpectedDelivery_PositionID = Guid.NewGuid();
                deliveryPosition.AlreadyReceivedQuantityOfDelivery = 0;
                deliveryPosition.ExpectedDeliveryPositionITL = deliveryPosition.ORD_PRC_ExpectedDelivery_PositionID.ToString();
                deliveryPosition.TotalExpectedQuantity = position.Position_Quantity;
                deliveryPosition.ORD_PRC_ExpectedDelivery_RefID = headerID;
                deliveryPosition.Tenant_RefID = securityTicket.TenantID;
                deliveryPosition.IsDeleted = false;
                deliveryPosition.Creation_Timestamp = DateTime.Now;
                deliveryPosition.Save(Connection, Transaction);

                CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition assignment = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition();
                assignment.AssignmentID = Guid.NewGuid();
                assignment.ORD_PRC_ProcurementOrder_Position_RefID = position.ORD_PRC_ProcurementOrder_PositionID;
                assignment.ORD_PRC_ExpectedDelivery_Position_RefID = deliveryPosition.ORD_PRC_ExpectedDelivery_PositionID;
                assignment.AssignedQuantityFromProcurementOrderPosition = position.Position_Quantity;
                assignment.Tenant_RefID = securityTicket.TenantID;
                assignment.IsDeleted = false;
                assignment.Creation_Timestamp = DateTime.Now;
                assignment.Save(Connection, Transaction);

                #endregion

                #region Receipt Positions
                var receiptPosition = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position();

                if (receiptPositions.Count == 0)
                {
                    // create new position
                    receiptPosition.LOG_RCP_Receipt_PositionID = Guid.NewGuid();
                    receiptPosition.Creation_Timestamp = DateTime.Now;
                    receiptPosition.Tenant_RefID = securityTicket.TenantID;
                    receiptPosition.ReceiptPositionITL = receiptPosition.LOG_RCP_Receipt_PositionID.ToString();
                    receiptPosition.Receipt_Header_RefID = receiptHeaderID;
                    receiptPosition.ReceiptPosition_Product_RefID = position.CMN_PRO_Product_RefID;
                    receiptPosition.TotalQuantityFreeOfCharge = 0.0;
                    receiptPosition.TotalQuantityTakenIntoStock = 0.0;
                    receiptPosition.ExpectedPositionPrice = position.Position_ValuePerUnit;
                    receiptPosition.Save(Connection, Transaction);


                    var receiptPosition2procurementorderposition = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition();
                    receiptPosition2procurementorderposition.AssignmentID = Guid.NewGuid();
                    receiptPosition2procurementorderposition.LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                    receiptPosition2procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = position.ORD_PRC_ProcurementOrder_PositionID;
                    receiptPosition2procurementorderposition.Tenant_RefID = securityTicket.TenantID;
                    receiptPosition2procurementorderposition.Creation_Timestamp = DateTime.Now;
                    receiptPosition2procurementorderposition.IsDeleted = false;
                    receiptPosition2procurementorderposition.Save(Connection,Transaction);


                }

            

                
                #endregion

                #region Quality Control Items
                var qualityControlItem = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                if (receiptPositions.Count == 0)
                {
                    qualityControlItem.LOG_RCP_Receipt_Position_QualityControlItem = Guid.NewGuid();
                    qualityControlItem.ReceiptPositionCountedItemITL = qualityControlItem.LOG_RCP_Receipt_Position_QualityControlItem.ToString();
                    qualityControlItem.Creation_Timestamp = DateTime.Now;
                    qualityControlItem.Tenant_RefID = securityTicket.TenantID;
                    qualityControlItem.Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                }
                else
                {
                    var query = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query()
                    {
                        Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    };

                    qualityControlItem = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.Search(Connection, Transaction, query).Single();

                }
                //qualityControlItem.BatchNumber = position.Position_OrdinalNumber;
                //qualityControlItem.ExpiryDate = position.date
                qualityControlItem.Quantity = position.Position_Quantity;
                qualityControlItem.Save(Connection, Transaction);

                #endregion

                #region Forwarding Instruction

                var forwardingInstruction = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction();
                if (receiptPositions.Count == 0)
                {
                    #region Create new

                    var businessParticipant = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                      new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query()
                      {
                          IfTenant_Tenant_RefID = securityTicket.TenantID,
                          IsDeleted = false
                      }).Single();

                    forwardingInstruction.ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID = Guid.NewGuid();
                    forwardingInstruction.Creation_Timestamp = DateTime.Now;
                    forwardingInstruction.Tenant_RefID = securityTicket.TenantID;
                    forwardingInstruction.ProcurementOrder_Position_RefID = position.ORD_PRC_ProcurementOrder_PositionID;
                    forwardingInstruction.ForwardTo_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;

                    #endregion
                }
                else
                {
                    #region Load Existing

                    var query = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query()
                    {
                        ProcurementOrder_Position_RefID = position.ORD_PRC_ProcurementOrder_PositionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    };
                    forwardingInstruction = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query.Search(Connection, Transaction, query).Single();

                    #endregion
                }

                forwardingInstruction.QuantityToForward = position.Position_Quantity;
                forwardingInstruction.Save(Connection, Transaction);

                #endregion

            }

            //returning created expected delivery header id
            returnValue.Result = headerID;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PO_CED_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PO_CED_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_CED_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_CED_1410 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_ExpectedDelivery",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PO_CED_1410 for attribute P_L5PO_CED_1410
		[DataContract]
		public class P_L5PO_CED_1410 
		{
			[DataMember]
			public P_L5PO_CED_1410a[] ProcurmentPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProcurementHeaderID { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 
			[DataMember]
			public DateTime LatestPaymentDate { get; set; } 

		}
		#endregion
		#region SClass P_L5PO_CED_1410a for attribute ProcurmentPositions
		[DataContract]
		public class P_L5PO_CED_1410a 
		{
			//Standard type parameters
			[DataMember]
			public decimal UnitPrice { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid ProcurementOrderPositionId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ExpectedDelivery(,P_L5PO_CED_1410 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ExpectedDelivery.Invoke(connectionString,P_L5PO_CED_1410 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Complex.Manipulation.P_L5PO_CED_1410();
parameter.ProcurmentPositions = ...;

parameter.ProcurementHeaderID = ...;
parameter.ExpectedDeliveryDate = ...;
parameter.LatestPaymentDate = ...;

*/
