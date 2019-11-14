/* 
 * Generated on 5/19/2014 5:17:42 PM
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
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Preload_TargetShelves_for_StockReceipt.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Preload_TargetShelves_for_StockReceipt
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_PTSfSR Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var paramQCI = new P_L5SR_GQCIfRHId_1359()
            {
                HeaderID = Parameter.ReceiptHeaderID
            };

            var qualityControlItems = cls_Get_QualityControlItems_for_ReceiptHeaderID.Invoke(Connection, Transaction, paramQCI, securityTicket).Result;
            
            Guid[] articleIDs = qualityControlItems.Select(x => x.ProductID).Distinct().ToArray();

            var paramArticleStorage = new P_L3WH_GASfA_1924
            {
                ArticleID_List = articleIDs
            };
            var storages = CL3_Warehouse.Atomic.Retrieval.cls_Get_ArticleStorages_for_ArticleIDList.Invoke(Connection, Transaction, paramArticleStorage, securityTicket).Result.
                Where(x => x.QLShelfID != Guid.Empty && x.IsPointOfSalesArea == true);

            foreach (var item in qualityControlItems)
            {
                var shelf = storages.FirstOrDefault(x => x.ArticleID == item.ProductID);
                if (shelf == null || shelf.ShelfID == Guid.Empty)
                {
                    continue;
                }

                var query = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query
                {
                    LOG_RCP_Receipt_Position_QualityControlItem = item.LOG_RCP_Receipt_Position_QualityControlItem,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                };
                var values = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query
                {
                    Target_WRH_Shelf_RefID = shelf.ShelfID
                };
                CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.Update(Connection, Transaction, query, values);
                
            }
			
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_PTSfSR Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_PTSfSR Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_PTSfSR Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_PTSfSR Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Preload_TargetShelves_for_StockReceipt",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_PTSfSR for attribute P_L5SR_PTSfSR
		[DataContract]
		public class P_L5SR_PTSfSR 
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
FR_Guid cls_Preload_TargetShelves_for_StockReceipt(,P_L5SR_PTSfSR Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Preload_TargetShelves_for_StockReceipt.Invoke(connectionString,P_L5SR_PTSfSR Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_PTSfSR();
parameter.ReceiptHeaderID = ...;

*/
