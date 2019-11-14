/* 
 * Generated on 3/7/2014 3:05:54 PM
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

namespace CL2_ShelfContentAdjustment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_LOG_WRH_Shelf_ContentAdjustment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_LOG_WRH_Shelf_ContentAdjustment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2SA_SSCA_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

            var item = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
			if (Parameter.LOG_WRH_Shelf_ContentAdjustmentID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.LOG_WRH_Shelf_ContentAdjustmentID);
			    if (result.Status != FR_Status.Success || item.LOG_WRH_Shelf_ContentAdjustmentID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_Shelf_ContentAdjustmentID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.LOG_WRH_Shelf_ContentAdjustmentID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
                Parameter.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
			}

			item.ShelfContent_RefID = Parameter.ShelfContent_RefID;
			item.QuantityChangedAmount = Parameter.QuantityChangedAmount;
			item.QuantityChangedDate = Parameter.QuantityChangedDate;
			item.IsInitialReceipt = Parameter.IsInitialReceipt;
			item.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = Parameter.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID;
			item.IsInventoryJobCorrection = Parameter.IsInventoryJobCorrection;
			item.IfInventoryJobCorrection_InvenoryJobProcess_RefID = Parameter.IfInventoryJobCorrection_InvenoryJobProcess_RefID;
			item.IsShipmentWithdrawal = Parameter.IsShipmentWithdrawal;
			item.IfShipmentWithdrawal_ShipmentPosition_RefID = Parameter.IfShipmentWithdrawal_ShipmentPosition_RefID;
			item.IsManualCorrection = Parameter.IsManualCorrection;
			item.IfManualCorrection_InventoryChangeReason_RefID = Parameter.IfManualCorrection_InventoryChangeReason_RefID;
			item.PerformedBy_Account_RefID = Parameter.PerformedBy_Account_RefID;
			item.PerformedAt_Date = Parameter.PerformedAt_Date;
			item.ContentAdjustmentComment = Parameter.ContentAdjustmentComment;

			return new FR_Guid(item.Save(Connection, Transaction),item.LOG_WRH_Shelf_ContentAdjustmentID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2SA_SSCA_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2SA_SSCA_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SA_SSCA_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SA_SSCA_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_LOG_WRH_Shelf_ContentAdjustment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2SA_SSCA_1503 for attribute P_L2SA_SSCA_1503
		[DataContract]
		public class P_L2SA_SSCA_1503 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentAdjustmentID { get; set; } 
			[DataMember]
			public Guid ShelfContent_RefID { get; set; } 
			[DataMember]
			public double QuantityChangedAmount { get; set; } 
			[DataMember]
			public DateTime QuantityChangedDate { get; set; } 
			[DataMember]
			public Boolean IsInitialReceipt { get; set; } 
			[DataMember]
			public Guid IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID { get; set; } 
			[DataMember]
			public Boolean IsInventoryJobCorrection { get; set; } 
			[DataMember]
			public Guid IfInventoryJobCorrection_InvenoryJobProcess_RefID { get; set; } 
			[DataMember]
			public Boolean IsShipmentWithdrawal { get; set; } 
			[DataMember]
			public Guid IfShipmentWithdrawal_ShipmentPosition_RefID { get; set; } 
			[DataMember]
			public Boolean IsManualCorrection { get; set; } 
			[DataMember]
			public Guid IfManualCorrection_InventoryChangeReason_RefID { get; set; } 
			[DataMember]
			public Guid PerformedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime PerformedAt_Date { get; set; } 
			[DataMember]
			public String ContentAdjustmentComment { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_LOG_WRH_Shelf_ContentAdjustment(,P_L2SA_SSCA_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_LOG_WRH_Shelf_ContentAdjustment.Invoke(connectionString,P_L2SA_SSCA_1503 Parameter,securityTicket);
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
var parameter = new CL2_ShelfContentAdjustment.Atomic.Manipulation.P_L2SA_SSCA_1503();
parameter.LOG_WRH_Shelf_ContentAdjustmentID = ...;
parameter.ShelfContent_RefID = ...;
parameter.QuantityChangedAmount = ...;
parameter.QuantityChangedDate = ...;
parameter.IsInitialReceipt = ...;
parameter.IfInitialReceipt_ReceiptPosition_QualityControlItem_RefID = ...;
parameter.IsInventoryJobCorrection = ...;
parameter.IfInventoryJobCorrection_InvenoryJobProcess_RefID = ...;
parameter.IsShipmentWithdrawal = ...;
parameter.IfShipmentWithdrawal_ShipmentPosition_RefID = ...;
parameter.IsManualCorrection = ...;
parameter.IfManualCorrection_InventoryChangeReason_RefID = ...;
parameter.PerformedBy_Account_RefID = ...;
parameter.PerformedAt_Date = ...;
parameter.ContentAdjustmentComment = ...;
parameter.IsDeleted = ...;

*/
