/* 
 * Generated on 2/19/2014 5:18:39 PM
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
    /// var result = cls_DeepDelete_StockReceiptPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_DeepDelete_StockReceiptPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_DDSRP_1715 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();
            foreach (var positionID in Parameter.ReceiptPositionIDs)
            {
                #region Delete receipt position
                CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query.SoftDelete(Connection, Transaction, new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position.Query()
                {
                    LOG_RCP_Receipt_PositionID = positionID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });
                #endregion

                #region Delete procurement order position
                var receiptToProcurementPosition = CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query.Search(Connection, Transaction,
                    new CL1_LOG_RCP.ORM_LOG_RCP_ReceiptPosition_2_ProcurementOrderPosition.Query()
                    {
                        LOG_RCP_Receipt_Position_RefID = positionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single();
                receiptToProcurementPosition.IsDeleted = true;
                receiptToProcurementPosition.Save(Connection, Transaction);

                var procurementPositionID = receiptToProcurementPosition.ORD_PRO_ProcurementOrder_Position_RefID;

                var procurementPosition = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query.SoftDelete(Connection, Transaction,
                    new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position.Query()
                    {
                        ORD_PRC_ProcurementOrder_PositionID = procurementPositionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                #endregion

                #region Expected delivery position delete
                var expectedDeliveryToProcurementPosition = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query.Search(Connection, Transaction,
                    new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_2_ProcurementOrderPosition.Query()
                    {
                        ORD_PRC_ProcurementOrder_Position_RefID = procurementPositionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();

                if (expectedDeliveryToProcurementPosition != null)
                {
                    expectedDeliveryToProcurementPosition.IsDeleted = true;
                    expectedDeliveryToProcurementPosition.Save(Connection, Transaction);

                    Guid expectedDeliveryPositionID = expectedDeliveryToProcurementPosition.ORD_PRC_ExpectedDelivery_Position_RefID;

                    CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position.Query.SoftDelete(Connection, Transaction,
                       new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Position.Query()
                       {
                           ORD_PRC_ExpectedDelivery_PositionID = expectedDeliveryPositionID,
                           IsDeleted = false,
                           Tenant_RefID = securityTicket.TenantID
                       });
                }

                #endregion
                
                #region Quality Control Items
                CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.SoftDelete(Connection, Transaction, 
                    new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query
                    {
                        Receipt_Position_RefID = positionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                #endregion

                #region Procurement Order Position Forwarding Instruction
                CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query.SoftDelete(Connection, Transaction,
                    new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_ForwardingInstruction.Query
                    {
                        ProcurementOrder_Position_RefID = procurementPositionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
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
		public static FR_Bool Invoke(string ConnectionString,P_L5SR_DDSRP_1715 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5SR_DDSRP_1715 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_DDSRP_1715 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_DDSRP_1715 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_DeepDelete_StockReceiptPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_DDSRP_1715 for attribute P_L5SR_DDSRP_1715
		[DataContract]
		public class P_L5SR_DDSRP_1715 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ReceiptPositionIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_DeepDelete_StockReceiptPositions(,P_L5SR_DDSRP_1715 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_DeepDelete_StockReceiptPositions.Invoke(connectionString,P_L5SR_DDSRP_1715 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_DDSRP_1715();
parameter.ReceiptPositionIDs = ...;

*/
