/* 
 * Generated on 28/7/2014 03:45:20
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
using CL2_Currency.Atomic.Retrieval;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_ORD_PRC;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StockReceiptHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StockReceiptHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_SRH_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            Guid HeaderID = Parameter.ReceiptHeaderID;

            var businessParticipant = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    IfTenant_Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
            }).Single();

            bool isNew = HeaderID == Guid.Empty;
            var expectedDeliveryHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header();
            var receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
            var procurementHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header();
            var receiptToProcurement = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader();

            #region Receipt Header
            if (isNew)
            {
                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.StockReceiptNumber)
                };
                var receiptNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
                receiptHeader.ReceiptNumber = receiptNumber;
                receiptHeader.LOG_RCP_Receipt_HeaderID = Guid.NewGuid();
                receiptHeader.Creation_Timestamp = DateTime.Now;
                receiptHeader.Tenant_RefID = securityTicket.TenantID;
                receiptHeader.ReceiptHeaderITL = receiptHeader.LOG_RCP_Receipt_HeaderID.ToString();
                receiptHeader.IsTakenIntoStock = false;
            }
            else
            {
                var query = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query
                {
                    LOG_RCP_Receipt_HeaderID = Parameter.ReceiptHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                receiptHeader = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query.Search(Connection, Transaction, query).Single();
            }
            HeaderID = receiptHeader.LOG_RCP_Receipt_HeaderID;
            receiptHeader.ProvidingSupplier_RefID = Parameter.SupplierID;
            receiptHeader.Save(Connection, Transaction);

            #endregion Receipt Header

            #region Expected Delivery Header
            if (isNew)
            {
                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ExpectedDeliveryNumber)
                };
                var expectedDeliveryNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                expectedDeliveryHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header
                {
                    ORD_PRC_ExpectedDelivery_HeaderID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    Creation_Timestamp = DateTime.Now,
                    ExpectedDeliveryNumber = expectedDeliveryNumber,
                    IsDeliveryOpen = true,
                    IsDeliveryClosed = false,

                };
                expectedDeliveryHeader.ExpectedDeliveryHeaderITL = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID.ToString();

                // save receipt header with new expected delivery header
                receiptHeader.ExpectedDeliveryHeader_RefID = expectedDeliveryHeader.ORD_PRC_ExpectedDelivery_HeaderID;
                receiptHeader.Save(Connection, Transaction);
            }
            else
            {
                var query = new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query
                {
                    ORD_PRC_ExpectedDelivery_HeaderID = receiptHeader.ExpectedDeliveryHeader_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                expectedDeliveryHeader = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query.Search(Connection, Transaction, query).Single();
            }
            if (Parameter.LatestDeliveryDate != null)
            {
                expectedDeliveryHeader.ExpectedDeliveryDate = Parameter.LatestDeliveryDate.Value;
            }
            expectedDeliveryHeader.Save(Connection, Transaction);
            
            #endregion Expected Delivery Header

            #region Procurement Order

            if (isNew)
            {
                procurementHeader = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header();
                procurementHeader.ORD_PRC_ProcurementOrder_HeaderID = Guid.NewGuid();
                procurementHeader.Creation_Timestamp = DateTime.Now;
                procurementHeader.Tenant_RefID = securityTicket.TenantID;
                procurementHeader.CreatedBy_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                procurementHeader.IsCreatedForExpectedDelivery = true;
                procurementHeader.ProcurementOrder_Currency_RefID = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID;

                receiptToProcurement = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader();
                receiptToProcurement.AssignmentID = Guid.NewGuid();
                receiptToProcurement.Creation_Timestamp = DateTime.Now;
                receiptToProcurement.Tenant_RefID = securityTicket.TenantID;
                receiptToProcurement.LOG_RCP_Receipt_Header_RefID = receiptHeader.LOG_RCP_Receipt_HeaderID;
                receiptToProcurement.ORD_PRO_ProcurementOrder_Header_RefID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
                receiptToProcurement.Save(Connection, Transaction);
            }
            else
            {
                var query = new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query
                {
                    LOG_RCP_Receipt_Header_RefID = HeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                receiptToProcurement = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction, query).Single();
                
                var query2 = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query
                {
                    ORD_PRC_ProcurementOrder_HeaderID = receiptToProcurement.ORD_PRO_ProcurementOrder_Header_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                procurementHeader = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, query2).Single();

            }

            #region get status for procurement order
            
            var newProcurementOrderStatusID = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction,
            new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query()
            {
                GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(EProcurementStatus.Ordered),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single().ORD_PRC_ProcurementOrder_StatusID;
            #endregion

            procurementHeader.Current_ProcurementOrderStatus_RefID = newProcurementOrderStatusID;
            procurementHeader.ProcurementOrder_Supplier_RefID = Parameter.SupplierID;
            procurementHeader.Save(Connection, Transaction);

            if (!string.IsNullOrEmpty(Parameter.ProcurementOrderStatus))
            {
                var queryStatus = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query()
                {
                    GlobalPropertyMatchingID = Parameter.ProcurementOrderStatus,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                };
                var status = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, queryStatus).Single();

                var statusHistory = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                statusHistory.ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.NewGuid();
                statusHistory.ProcurementOrder_Header_RefID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
                statusHistory.ProcurementOrder_Status_RefID = status.ORD_PRC_ProcurementOrder_StatusID;
                statusHistory.IsDeleted = false;
                statusHistory.Tenant_RefID = securityTicket.TenantID;
                statusHistory.Creation_Timestamp = DateTime.Now;

                statusHistory.Save(Connection, Transaction);
            }

            #endregion Procurement Order

            returnValue.Result = HeaderID;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_SRH_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_SRH_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_SRH_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_SRH_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_StockReceiptHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_SRH_1545 for attribute P_L5SR_SRH_1545
		[DataContract]
		public class P_L5SR_SRH_1545 
		{
			//Standard type parameters
			[DataMember]
			public string ProcurementOrderStatus { get; set; } 
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public DateTime? LatestDeliveryDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StockReceiptHeader(,P_L5SR_SRH_1545 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_StockReceiptHeader.Invoke(connectionString,P_L5SR_SRH_1545 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_SRH_1545();
parameter.ProcurementOrderStatus = ...;
parameter.ReceiptHeaderID = ...;
parameter.SupplierID = ...;
parameter.LatestDeliveryDate = ...;

*/
