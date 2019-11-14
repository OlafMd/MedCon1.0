/* 
 * Generated on 9/17/2014 4:24:39 PM
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

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_SRPaEDP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var queryProcurement = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query()
            {
                LOG_RCP_Receipt_Header_RefID = Parameter.ReceiptHeaderID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            };
            var receiptToProcurementHeader = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction, queryProcurement).Single();
            Guid procurementHeaderID = receiptToProcurementHeader.ORD_PRO_ProcurementOrder_Header_RefID;

            #region Positions
            if (Parameter.StockPositions != null)
            {
                foreach (var item in Parameter.StockPositions)
                {
                    #region Receipt Positions
                    var receiptPosition = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position();

                    if (item.ReceiptPositionID == Guid.Empty)
                    {
                        // create new position
                        receiptPosition.LOG_RCP_Receipt_PositionID = Guid.NewGuid();
                        receiptPosition.Creation_Timestamp = DateTime.Now;
                        receiptPosition.Tenant_RefID = securityTicket.TenantID;
                        receiptPosition.ReceiptPositionITL = receiptPosition.LOG_RCP_Receipt_PositionID.ToString();
                        receiptPosition.Receipt_Header_RefID = Parameter.ReceiptHeaderID;
                        receiptPosition.ReceiptPosition_Product_RefID = item.ProductID;
                    }
                    else
                    {
                        // load and edit existing position
                        receiptPosition.Load(Connection, Transaction, item.ReceiptPositionID);
                    }
                    receiptPosition.TotalQuantityFreeOfCharge = 0.0;
                    receiptPosition.TotalQuantityTakenIntoStock = 0.0;
                    receiptPosition.ExpectedPositionPrice = item.UnitPrice;
                    receiptPosition.Save(Connection, Transaction);

                    #endregion

                    #region Procurement Order Positions

                    var procurementPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position();
                    var receiptToProcurementPosition = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition();

                    if (item.ReceiptPositionID == Guid.Empty)
                    {
                        #region Create new

                        var query2 = new CL1_CMN_PRO.ORM_CMN_PRO_Product.Query()
                        {
                            CMN_PRO_ProductID = item.ProductID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        var product = CL1_CMN_PRO.ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, query2).Single();

                        var query3 = new CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query()
                        {
                            CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        var packageInfo = CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction, query3).Single();
                        var unitID = packageInfo.PackageContent_MeasuredInUnit_RefID;

                        // Create procurement order position for this position
                        procurementPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position()
                        {
                            ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid(),
                            ProcurementOrder_Header_RefID = procurementHeaderID,
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_PRO_Product_RefID = item.ProductID,
                            Position_Unit_RefID = unitID,
                        };

                        receiptToProcurementPosition = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition()
                        {
                            AssignmentID = Guid.NewGuid(),
                            Creation_Timestamp = DateTime.Now,
                            Tenant_RefID = securityTicket.TenantID,
                            ORD_PRO_ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID,
                            LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                        };

                        #endregion
                    }
                    else
                    {
                        #region Load existing procurement order position
                        var query = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query()
                        {
                            LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        receiptToProcurementPosition = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query.Search(Connection, Transaction, query).Single();

                        var query2 = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query()
                        {
                            ORD_PRC_ProcurementOrder_PositionID = receiptToProcurementPosition.ORD_PRO_ProcurementOrder_Position_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        procurementPosition = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, query2).Single();
                        #endregion
                    }

                    // save changed or newly created procurement position and assignment
                    procurementPosition.Position_Quantity = item.OrderQuantity;
                    procurementPosition.Position_ValuePerUnit = item.UnitPrice;
                    procurementPosition.Position_ValueTotal = item.UnitPrice * (decimal)item.OrderQuantity;

                    procurementPosition.Save(Connection, Transaction);

                    receiptToProcurementPosition.ReceivedQuantityFromProcurementOrderPosition = item.OrderQuantity;
                    receiptToProcurementPosition.Save(Connection, Transaction);

                    #endregion

                    #region Expected Delivery

                    var expectedDeliveryPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position();
                    var expectedDeliveryToProcurementOrderPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition();
                    if (item.ReceiptPositionID == Guid.Empty)
                    {
                        #region Create new
                        // get expected delivery header assigned to receipt header of this position
                        var query2 = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query
                        {
                            LOG_RCP_Receipt_HeaderID = receiptPosition.Receipt_Header_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };

                        var receiptHeader = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query.Search(Connection, Transaction, query2).Single();

                        expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_PositionID = Guid.NewGuid();
                        expectedDeliveryPosition.Creation_Timestamp = DateTime.Now;
                        expectedDeliveryPosition.Tenant_RefID = securityTicket.TenantID;
                        expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_RefID = receiptHeader.ExpectedDeliveryHeader_RefID;
                        expectedDeliveryPosition.ExpectedDeliveryPositionITL = expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_PositionID.ToString();
                        //expectedDeliveryPosition.AlreadyReceivedQuantityOfDelivery = ?

                        expectedDeliveryToProcurementOrderPosition.AssignmentID = Guid.NewGuid();
                        expectedDeliveryToProcurementOrderPosition.ORD_PRC_ExpectedDelivery_Position_RefID = expectedDeliveryPosition.ORD_PRC_ExpectedDelivery_PositionID;
                        expectedDeliveryToProcurementOrderPosition.ORD_PRC_ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID;
                        expectedDeliveryToProcurementOrderPosition.Creation_Timestamp = DateTime.Now;
                        expectedDeliveryToProcurementOrderPosition.Tenant_RefID = securityTicket.TenantID;

                        #endregion
                    }
                    else
                    {
                        #region Load existing

                        var query = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query()
                        {
                            ORD_PRC_ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        expectedDeliveryToProcurementOrderPosition = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query.Search(Connection, Transaction, query).Single();

                        var query2 = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position.Query()
                        {
                            ORD_PRC_ExpectedDelivery_PositionID = expectedDeliveryToProcurementOrderPosition.ORD_PRC_ExpectedDelivery_Position_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        expectedDeliveryPosition = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position.Query.Search(Connection, Transaction, query2).Single();

                        #endregion
                    }

                    expectedDeliveryPosition.TotalExpectedQuantity = item.OrderQuantity;
                    expectedDeliveryPosition.Save(Connection, Transaction);

                    expectedDeliveryToProcurementOrderPosition.AssignedQuantityFromProcurementOrderPosition = procurementPosition.Position_Quantity;
                    expectedDeliveryToProcurementOrderPosition.Save(Connection, Transaction);

                    #endregion

                    #region Quality Control Items
                    var qualityControlItem = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                    if (item.ReceiptPositionID == Guid.Empty)
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
                    qualityControlItem.BatchNumber = item.BatchNumber;
                    qualityControlItem.ExpiryDate = item.ExpiryDate;
                    qualityControlItem.Quantity = procurementPosition.Position_Quantity;
                    qualityControlItem.Save(Connection, Transaction);

                    #endregion

                    #region Forwarding Instruction

                    var forwardingInstruction = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction();
                    if (item.ReceiptPositionID == Guid.Empty)
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
                        forwardingInstruction.ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID;
                        forwardingInstruction.ForwardTo_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;

                        #endregion
                    }
                    else
                    {
                        #region Load Existing

                        var query = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query()
                        {
                            ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        forwardingInstruction = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query.Search(Connection, Transaction, query).Single();

                        #endregion
                    }

                    forwardingInstruction.QuantityToForward = procurementPosition.Position_Quantity;
                    forwardingInstruction.Save(Connection, Transaction);

                    #endregion
                }
            }

            #endregion

            returnValue.Result = Parameter.ReceiptHeaderID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_SRPaEDP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_SRPaEDP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_SRPaEDP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_SRPaEDP_1406 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_SRPaEDP_1406 for attribute P_L5SR_SRPaEDP_1406
		[DataContract]
		public class P_L5SR_SRPaEDP_1406 
		{
			[DataMember]
			public P_L5SR_SRPaEDP_1406a[] StockPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass P_L5SR_SRPaEDP_1406a for attribute StockPositions
		[DataContract]
		public class P_L5SR_SRPaEDP_1406a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public double OrderQuantity { get; set; } 
			[DataMember]
			public decimal UnitPrice { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions(,P_L5SR_SRPaEDP_1406 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_StockReceipt_Procurement_and_ExpectedDelivery_Positions.Invoke(connectionString,P_L5SR_SRPaEDP_1406 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_SRPaEDP_1406();
parameter.StockPositions = ...;

parameter.ReceiptHeaderID = ...;

*/
