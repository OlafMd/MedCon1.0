/* 
 * Generated on 4/7/2014 11:30:11 AM
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
    /// var result = cls_DeepDelete_StockReceipt.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_DeepDelete_StockReceipt
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_DSR_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Delete Receipt header and other headers created with it

            var receiptHeader = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query.Search(Connection, Transaction,
                new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header.Query
                {
                    LOG_RCP_Receipt_HeaderID = Parameter.ReceiptHeaderID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            receiptHeader.IsDeleted = true;
            receiptHeader.Save(Connection, Transaction);

            CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query.SoftDelete(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query
                {
                    ORD_PRC_ExpectedDelivery_HeaderID = receiptHeader.ExpectedDeliveryHeader_RefID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            var receiptToProcurementOrderHeader = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query.Search(Connection, Transaction,
               new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptHeader_2_ProcurementOrderHeader.Query
               {
                   LOG_RCP_Receipt_Header_RefID = Parameter.ReceiptHeaderID,
                   IsDeleted = false,
                   Tenant_RefID = securityTicket.TenantID
               }).Single();

            receiptToProcurementOrderHeader.IsDeleted = true;
            receiptToProcurementOrderHeader.Save(Connection, Transaction);

            CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query.SoftDelete(Connection, Transaction,
               new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Header.Query
               {
                   ORD_PRC_ProcurementOrder_HeaderID = receiptToProcurementOrderHeader.ORD_PRO_ProcurementOrder_Header_RefID,
                   IsDeleted = false,
                   Tenant_RefID = securityTicket.TenantID
               });

            #endregion

            #region Deep Delete Receipt Positions

            var positionIDs = CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query.Search(Connection, Transaction, 
                new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query
                {
                   Receipt_Header_RefID = receiptHeader.LOG_RCP_Receipt_HeaderID,
                   IsDeleted = false,
                   Tenant_RefID = securityTicket.TenantID
                }).Select(x => x.LOG_RCP_Receipt_PositionID).ToArray();

            bool deletedPositionsSuccess = cls_DeepDelete_StockReceiptPositions.Invoke(Connection, Transaction, new P_L5SR_DDSRP_1715 { ReceiptPositionIDs = positionIDs }, securityTicket).Result;

            #endregion

            returnValue.Result = receiptHeader.LOG_RCP_Receipt_HeaderID;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_DSR_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_DSR_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_DSR_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_DSR_1126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_DeepDelete_StockReceipt",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_DSR_1126 for attribute P_L5SR_DSR_1126
		[DataContract]
		public class P_L5SR_DSR_1126 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_DeepDelete_StockReceipt(,P_L5SR_DSR_1126 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_DeepDelete_StockReceipt.Invoke(connectionString,P_L5SR_DSR_1126 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_DSR_1126();
parameter.ReceiptHeaderID = ...;

*/
