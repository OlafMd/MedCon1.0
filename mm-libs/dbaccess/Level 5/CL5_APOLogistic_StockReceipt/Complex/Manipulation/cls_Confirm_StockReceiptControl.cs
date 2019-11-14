/* 
 * Generated on 5/17/2014 6:11:37 PM
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
    /// var result = cls_Confirm_StockReceiptControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Confirm_StockReceiptControl
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSR_CSRC_1200 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            #region Receipt Position (Update)

            var receiptPosition = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position();
            receiptPosition.Load(Connection, Transaction, Parameter.LOG_RCP_Receipt_PositionID);

            receiptPosition.TotalQuantityTakenIntoStock = Parameter.AlreadyReceivedQuantityOfDelivery;
            receiptPosition.Save(Connection, Transaction);

            #endregion

            #region ProcurementOrderPosition (Read)

            var query1 = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query()
            {
                LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            };
            var receiptToProcurementPosition = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query.Search(Connection, Transaction, query1).Single();

            var query2 = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query()
            {
                ORD_PRC_ProcurementOrder_PositionID = receiptToProcurementPosition.ORD_PRO_ProcurementOrder_Position_RefID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            };
            var procurementPosition = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, query2).Single();

            #endregion

            #region Assingment Tables (Read)
            var assReceiptPos2ProcuPos = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query.Search(Connection, Transaction,
                new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query
                {
                    LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

            var procurementOrderPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position();
            procurementOrderPosition.Load(Connection, Transaction, assReceiptPos2ProcuPos.ORD_PRO_ProcurementOrder_Position_RefID);

            var assExpectedDlv2ProcurementOrderPos = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query.Search(Connection, Transaction,
                 new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query
                 {
                     ORD_PRC_ProcurementOrder_Position_RefID = procurementOrderPosition.ORD_PRC_ProcurementOrder_PositionID,
                     Tenant_RefID = securityTicket.TenantID,
                     IsDeleted = false
                 }).SingleOrDefault();
            #endregion

            #region Expected Delivery Positions (Update)

            if (assExpectedDlv2ProcurementOrderPos != null) 
            {

                var expectedDeliveryPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position();
                expectedDeliveryPosition.Load(Connection, Transaction, assExpectedDlv2ProcurementOrderPos.ORD_PRC_ExpectedDelivery_Position_RefID);

                expectedDeliveryPosition.AlreadyReceivedQuantityOfDelivery = Parameter.AlreadyReceivedQuantityOfDelivery;
                expectedDeliveryPosition.Save(Connection, Transaction);
            }

            #endregion

            #region Receipt Position Quality Control Items
            {

                // Delete all Quality Control Items because they are dummy
                var qualityControlItems = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.Search(Connection, Transaction,
                    new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query
                    {
                        Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    });

                qualityControlItems.ForEach(x => x.IsDeleted = true);
                qualityControlItems.ForEach(x => x.Save(Connection, Transaction));

                // Add new Quality Control Items 
                foreach (var sp in Parameter.StockPackets)
                {
                    var qualityControlItem = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                    qualityControlItem.Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID;
                    qualityControlItem.ReceiptPositionCountedItemITL = Guid.NewGuid().ToString();
                    qualityControlItem.Tenant_RefID = securityTicket.TenantID;
                    qualityControlItem.BatchNumber = sp.SerialNumber;
                    qualityControlItem.Quantity = sp.ProductQuantity;
                    if (sp.ExpirationDate.HasValue)
                    {
                        qualityControlItem.ExpiryDate = sp.ExpirationDate.Value;
                    }
                    qualityControlItem.QualityControl_PerformedByBusinessParticipant_RefID = sp.QualityControl_PerformedByBusinessParticipant_RefID;
                    qualityControlItem.QualityControl_PerformedAtDate = sp.QualityControl_PerformedAtDate;
                    qualityControlItem.Save(Connection, Transaction);
                }
            }
            #endregion

            #region Request Quantity Forwarding
            foreach (var company in Parameter.Companies)
            {
                #region Forwarding Instruction

                var query = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query()
                {
                    ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID,
                    ForwardTo_BusinessParticipant_RefID = company.CompanyBusinessParticipantID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                var forwardingInstruction = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query.Search(Connection, Transaction, query).SingleOrDefault();

                if (forwardingInstruction == null)
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

                forwardingInstruction.QuantityToForward = company.CompanyStockPackets.Sum(i=>i.QuantityToTransfer);
                forwardingInstruction.Save(Connection, Transaction);

                #endregion

                var rqfHeader = new CL1_LOG_RCP_RQF.ORM_LOG_RCP_RQF_RequestQuantityForwarding_Header();
                rqfHeader.Tenant_RefID = securityTicket.TenantID;
                rqfHeader.SplitFrom_ReceiptHeader_RefID = receiptPosition.Receipt_Header_RefID;
                rqfHeader.ExecutingBusinessParticipant_RefID = company.CompanyBusinessParticipantID;
                rqfHeader.Save(Connection, Transaction);

                var rqfPosition = new CL1_LOG_RCP_RQF.ORM_LOG_RCP_RQF_RequestQuantityForwarding_Position();
                rqfPosition.Tenant_RefID = securityTicket.TenantID;
                rqfPosition.ReceivedQuantityForwarding_Header_RefID = rqfHeader.SplitFrom_ReceiptHeader_RefID;

                foreach (var rqfItem in company.CompanyStockPackets)
                {
                    var rqfPositionItem = new CL1_LOG_RCP_RQF.ORM_LOG_RCP_RQF_Position_MemberItem();
                    rqfPositionItem.RequestQuantityForwarding_Position_RefID = rqfPosition.LOG_RCP_RQF_RequestQuantityForwarding_PositionID;
                    rqfPositionItem.BatchNumber = rqfItem.SerialNumber;
                    rqfPositionItem.Quantity = rqfItem.QuantityToTransfer;
                    rqfPositionItem.Save(Connection, Transaction);
                }

                rqfPosition.TotalReceivedQuantity = company.CompanyStockPackets.Sum(x => x.QuantityToTransfer);
                rqfPosition.ExpectedQuantity = procurementPosition.Position_Quantity;
                rqfPosition.CreatedFrom_PositionForwardingInstruction_RefID = forwardingInstruction.ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID;
                rqfPosition.Save(Connection, Transaction);
            }
            #endregion

            return new FR_Guid(receiptPosition.LOG_RCP_Receipt_PositionID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ALSR_CSRC_1200 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ALSR_CSRC_1200 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSR_CSRC_1200 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSR_CSRC_1200 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Confirm_StockReceiptControl",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ALSR_CSRC_1200 for attribute P_L5ALSR_CSRC_1200
		[DataContract]
		public class P_L5ALSR_CSRC_1200 
		{
			[DataMember]
			public P_L5ALSR_CSRC_1200_Company[] Companies { get; set; }
			[DataMember]
			public P_L5ALSR_CSRC_1200_StockPacket[] StockPackets { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_RCP_Receipt_PositionID { get; set; } 
			[DataMember]
			public double AlreadyReceivedQuantityOfDelivery { get; set; } 

		}
		#endregion
		#region SClass P_L5ALSR_CSRC_1200_Company for attribute Companies
		[DataContract]
		public class P_L5ALSR_CSRC_1200_Company 
		{
			[DataMember]
			public P_L5ALSR_CSRC_1200_CompanyStockPacket[] CompanyStockPackets { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CompanyBusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass P_L5ALSR_CSRC_1200_CompanyStockPacket for attribute CompanyStockPackets
		[DataContract]
		public class P_L5ALSR_CSRC_1200_CompanyStockPacket 
		{
			//Standard type parameters
			[DataMember]
			public string SerialNumber { get; set; } 
			[DataMember]
			public int QuantityToTransfer { get; set; } 
			[DataMember]
			public DateTime? ExpirationDate { get; set; } 

		}
		#endregion
		#region SClass P_L5ALSR_CSRC_1200_StockPacket for attribute StockPackets
		[DataContract]
		public class P_L5ALSR_CSRC_1200_StockPacket 
		{
			//Standard type parameters
			[DataMember]
			public string SerialNumber { get; set; } 
			[DataMember]
			public int ProductQuantity { get; set; } 
			[DataMember]
			public DateTime? ExpirationDate { get; set; } 
			[DataMember]
			public DateTime QualityControl_PerformedAtDate { get; set; } 
			[DataMember]
			public Guid QualityControl_PerformedByBusinessParticipant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Confirm_StockReceiptControl(,P_L5ALSR_CSRC_1200 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Confirm_StockReceiptControl.Invoke(connectionString,P_L5ALSR_CSRC_1200 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5ALSR_CSRC_1200();
parameter.Companies = ...;
parameter.StockPackets = ...;

parameter.LOG_RCP_Receipt_PositionID = ...;
parameter.AlreadyReceivedQuantityOfDelivery = ...;

*/
