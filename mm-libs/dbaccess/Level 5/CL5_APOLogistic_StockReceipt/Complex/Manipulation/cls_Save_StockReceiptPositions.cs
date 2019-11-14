/* 
 * Generated on 3/7/2014 2:48:04 PM
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
using CL1_LOG_RCP;
using CL3_Price.Complex.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StockReceiptPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StockReceiptPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_SRP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

                #region Get_StandardPrices_for_ProductIDList

                var priceParam = new P_L3PR_GSPfPIL_1645
                {
                    ProductIDList = Parameter.StockPositions.Select(x => x.ProductID).ToArray()
                };

                var prices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction, priceParam, securityTicket).Result;

                #endregion

                #region ProcurementHeader 

                var procurementHeader = ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction, 
                    new ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query() {
                        LOG_RCP_Receipt_Header_RefID = Parameter.ReceiptHeaderID,
                        IsDeleted = false
                    }).Single();

                #endregion

                foreach (var item in Parameter.StockPositions)
                {
                    var pricePerUnit = prices.Where(i => i.ProductID == item.ProductID).Select(j => j.AbdaPrice).SingleOrDefault();

                    #region Receipt Header and Positions

                    // create new position
                    var receiptPosition = new ORM_LOG_RCP_Receipt_Position();
                    receiptPosition.LOG_RCP_Receipt_PositionID = Guid.NewGuid();
                    receiptPosition.Creation_Timestamp = DateTime.Now;
                    receiptPosition.Tenant_RefID = securityTicket.TenantID;
                    receiptPosition.ReceiptPositionITL = receiptPosition.LOG_RCP_Receipt_PositionID.ToString();
                    receiptPosition.Receipt_Header_RefID = Parameter.ReceiptHeaderID;
                    receiptPosition.ReceiptPosition_Product_RefID = item.ProductID;
                    receiptPosition.TotalQuantityFreeOfCharge = 0.0;
                    receiptPosition.TotalQuantityTakenIntoStock = 0.0;
                    receiptPosition.ExpectedPositionPrice = pricePerUnit;
                    receiptPosition.Save(Connection, Transaction);

                    #endregion

                    #region Procurement Order Positions

                    var product = CL1_CMN_PRO.ORM_CMN_PRO_Product.Query.Search(Connection, Transaction,
                        new CL1_CMN_PRO.ORM_CMN_PRO_Product.Query()
                        {
                            CMN_PRO_ProductID = item.ProductID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var packageInfo = CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query.Search(Connection, Transaction, 
                        new CL1_CMN_PRO_PAC.ORM_CMN_PRO_PAC_PackageInfo.Query()
                        {
                            CMN_PRO_PAC_PackageInfoID = product.PackageInfo_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).Single();

                    var procurementPosition = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position()
                    {
                        ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid(),
                        ProcurementOrder_Header_RefID = procurementHeader.ORD_PRO_ProcurementOrder_Header_RefID,
                        CMN_PRO_Product_RefID = item.ProductID,
                        Position_Unit_RefID = packageInfo.PackageContent_MeasuredInUnit_RefID,
                        Position_Quantity = item.OrderQuantity,
                        Position_ValuePerUnit = pricePerUnit,
                        Position_ValueTotal = pricePerUnit * (decimal)item.OrderQuantity,
                        IsBonusDelivery_WasNotOrdered = true,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID,
                    };

                    procurementPosition.Save(Connection, Transaction);

                    var receiptToProcurementPosition = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition()
                    {
                        AssignmentID = Guid.NewGuid(),
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID,
                        ORD_PRO_ProcurementOrder_Position_RefID = procurementPosition.ORD_PRC_ProcurementOrder_PositionID,
                        LOG_RCP_Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                        ReceivedQuantityFromProcurementOrderPosition = item.OrderQuantity
                    };
                    receiptToProcurementPosition.Save(Connection, Transaction);

                    #endregion

                    #region Forwarding Instruction

                    var forwardingInstruction = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction();
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
                    forwardingInstruction.QuantityToForward = 0;
                    forwardingInstruction.Save(Connection, Transaction);

                    #endregion
                }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_SRP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_SRP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_SRP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_SRP_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_StockReceiptPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_SRP_1447 for attribute P_L5SR_SRP_1447
		[DataContract]
		public class P_L5SR_SRP_1447 
		{
			[DataMember]
			public P_L5SR_SRP_1447a[] StockPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass P_L5SR_SRP_1447a for attribute StockPositions
		[DataContract]
		public class P_L5SR_SRP_1447a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public double OrderQuantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StockReceiptPositions(,P_L5SR_SRP_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_StockReceiptPositions.Invoke(connectionString,P_L5SR_SRP_1447 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_SRP_1447();
parameter.StockPositions = ...;

parameter.ReceiptHeaderID = ...;

*/
