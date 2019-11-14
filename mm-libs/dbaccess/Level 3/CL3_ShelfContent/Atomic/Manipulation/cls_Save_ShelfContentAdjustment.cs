/* 
 * Generated on 3/17/2015 03:09:44
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
using CL1_LOG_WRH;

namespace CL3_ShelfContent.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ShelfContentAdjustment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShelfContentAdjustment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3SC_SSCA_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            if (Parameter.StockItems.Count() > 0)
            {
                foreach (var item in Parameter.StockItems)
                {
                    var shelfContent = new ORM_LOG_WRH_Shelf_Content();
                    shelfContent.Load(Connection, Transaction, item.ShelfContentID);

                    if (shelfContent != null)
                    {
                        var oldQuantity = shelfContent.Quantity_Current;

                        shelfContent.Quantity_Current = item.CountedQuantity;
                        shelfContent.Save(Connection, Transaction);

                        var shelfContentAdjustment = new ORM_LOG_WRH_Shelf_ContentAdjustment();
                        shelfContentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
                        shelfContentAdjustment.ShelfContent_RefID = item.ShelfContentID;
                        shelfContentAdjustment.QuantityChangedAmount = item.CountedQuantity - oldQuantity;
                        shelfContentAdjustment.QuantityChangedDate = DateTime.Now;
                        shelfContentAdjustment.IsManualCorrection = item.IsManualCorrection;
                        shelfContentAdjustment.IfManualCorrection_InventoryChangeReason_RefID = item.InventoryChangeReason;
                        shelfContentAdjustment.PerformedAt_Date = DateTime.Now;
                        shelfContentAdjustment.PerformedBy_Account_RefID = securityTicket.AccountID;
                        shelfContentAdjustment.Creation_Timestamp = DateTime.Now;
                        shelfContentAdjustment.Tenant_RefID = securityTicket.TenantID;
                        shelfContentAdjustment.Save(Connection, Transaction);

                        ORM_LOG_WRH_Shelf_Content_AdjustmentHistory adjustmentHistory = new ORM_LOG_WRH_Shelf_Content_AdjustmentHistory();
                        adjustmentHistory.LOG_WRH_Shelf_Content_AdjustmentHistoryID = Guid.NewGuid();
                        adjustmentHistory.Shelf_Content_RefID = item.ShelfContentID;
                        adjustmentHistory.ContentAdjustments_RefID = shelfContentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
                        adjustmentHistory.Tenant_RefID = securityTicket.TenantID;
                        adjustmentHistory.Creation_Timestamp = DateTime.Now;
                        adjustmentHistory.Save(Connection, Transaction);                       
                    }
                }
            }



			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3SC_SSCA_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3SC_SSCA_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SC_SSCA_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SC_SSCA_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ShelfContentAdjustment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3SC_SSCA_1433 for attribute P_L3SC_SSCA_1433
		[DataContract]
		public class P_L3SC_SSCA_1433 
		{
			[DataMember]
			public P_L3SC_SSCA_1433a[] StockItems { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L3SC_SSCA_1433a for attribute StockItems
		[DataContract]
		public class P_L3SC_SSCA_1433a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public double CountedQuantity { get; set; } 
			[DataMember]
			public Guid InventoryChangeReason { get; set; } 
			[DataMember]
			public bool IsManualCorrection { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ShelfContentAdjustment(,P_L3SC_SSCA_1433 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ShelfContentAdjustment.Invoke(connectionString,P_L3SC_SSCA_1433 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Atomic.Manipulation.P_L3SC_SSCA_1433();
parameter.StockItems = ...;


*/
