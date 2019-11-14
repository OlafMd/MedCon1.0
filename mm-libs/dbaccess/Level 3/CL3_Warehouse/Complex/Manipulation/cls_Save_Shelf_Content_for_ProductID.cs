/* 
 * Generated on 16/7/2014 05:15:57
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Shelf_Content_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Shelf_Content_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_SSCfP_1635 Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_SSCfP_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3WH_SSCfP_1635();
            //Put your code here
            #region create shelf content

            var shelfContent = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content();
            shelfContent.LOG_WRH_Shelf_ContentID = Guid.NewGuid();            
            shelfContent.Shelf_RefID = Parameter.ShelfID;
            shelfContent.Quantity_Current = Parameter.Quantity;
            shelfContent.Quantity_Initial = Parameter.Quantity;
            shelfContent.Product_RefID = Parameter.ProductID;
            shelfContent.R_FreeQuantity = Parameter.Quantity;
            shelfContent.IsLocked = false;
            shelfContent.Creation_Timestamp = DateTime.Now;
            shelfContent.Tenant_RefID = securityTicket.TenantID;
            shelfContent.Save(Connection, Transaction);

            #endregion

            #region LOG_WRH_Shelf_ContentAdjustments

            var contentAdjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
            contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
            contentAdjustment.ShelfContent_RefID = shelfContent.LOG_WRH_Shelf_ContentID;

            contentAdjustment.QuantityChangedAmount = Parameter.Quantity ;
            contentAdjustment.QuantityChangedDate = DateTime.Now;

            contentAdjustment.IsInitialReceipt = true;

            /* PITATI PEJU SUTRA
            contentAdjustment.IsInventoryJobCorrection = false;
            contentAdjustment.IsShipmentWithdrawal = false;
            contentAdjustment.IsManualCorrection = false;
             */

            contentAdjustment.PerformedBy_Account_RefID = securityTicket.AccountID;
            contentAdjustment.PerformedAt_Date = DateTime.Now;

            contentAdjustment.Tenant_RefID = securityTicket.TenantID;
            contentAdjustment.Creation_Timestamp = DateTime.Now;
            contentAdjustment.Save(Connection, Transaction);

            #endregion

            #region create tracking instance

            var trackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
            trackingInstance.LOG_ProductTrackingInstanceID = Guid.NewGuid();
            trackingInstance.TrackingInstanceTakenFromSourceTrackingInstance_RefID = Guid.Empty;
            trackingInstance.TrackingCode = String.Empty;
            trackingInstance.SerialNumber = String.Empty;
            trackingInstance.BatchNumber = Parameter.BatchNumber;
            trackingInstance.OwnedBy_BusinessParticipant_RefID = Guid.Empty; //this is important if we want to persist owner of product (mobile phone in a service)
            trackingInstance.CMN_PRO_Product_RefID = Parameter.ProductID;
            trackingInstance.CMN_PRO_Product_Release_RefID = Guid.Empty;
            trackingInstance.CMN_PRO_Product_Variant_RefID = Guid.Empty;
            trackingInstance.ExpirationDate = Parameter.ExpirationDate;
            trackingInstance.InitialQuantityOnTrackingInstance = Parameter.Quantity;
            trackingInstance.CurrentQuantityOnTrackingInstance = Parameter.Quantity;
            trackingInstance.R_ReservedQuantity = 0;
            trackingInstance.R_FreeQuantity = Parameter.Quantity;
            trackingInstance.Creation_Timestamp = DateTime.Now;
            trackingInstance.Tenant_RefID = securityTicket.TenantID;
            trackingInstance.Save(Connection, Transaction);

            #endregion

            #region create tracking instance history
            var trackingInstanceHistory = new CL1_LOG.ORM_LOG_ProductTrackingInstance_HistoryEntry();
            trackingInstanceHistory.LOG_ProductTrackingInstance_HistoryEntryID = Guid.NewGuid();
            trackingInstanceHistory.ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
            trackingInstanceHistory.HistoryEntry_Text = "Product is added to inventory job process";
            trackingInstanceHistory.Creation_Timestamp = DateTime.Now;
            trackingInstanceHistory.Tenant_RefID = securityTicket.TenantID;
            trackingInstanceHistory.Save(Connection, Transaction);
            #endregion

            #region ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance

            var adjustment2tracking = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance();
            adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = Guid.NewGuid();
            adjustment2tracking.LOG_ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
            adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_RefID = contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
            adjustment2tracking.QuantityChangedAmount = Parameter.Quantity;
            adjustment2tracking.Creation_Timestamp = DateTime.Now;
            adjustment2tracking.Tenant_RefID = securityTicket.TenantID;
            adjustment2tracking.Save(Connection, Transaction);

            #endregion

            #region create ShelfContent_2_TrackingInstance

            var shelf2tracking = new CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance();
            shelf2tracking.AssignmentID = Guid.NewGuid();
            shelf2tracking.LOG_ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
            shelf2tracking.LOG_WRH_Shelf_Content_RefID = shelfContent.LOG_WRH_Shelf_ContentID;
            shelf2tracking.Creation_Timestamp = DateTime.Now;
            shelf2tracking.Tenant_RefID = securityTicket.TenantID;
            shelf2tracking.Save(Connection, Transaction);

            #endregion

            L3WH_SSCfP_1635 resultItem = new L3WH_SSCfP_1635();
            resultItem.ShelfContentID = shelfContent.LOG_WRH_Shelf_ContentID;
            resultItem.TrackingInstanceID = trackingInstance.LOG_ProductTrackingInstanceID;

            returnValue.Result = resultItem;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3WH_SSCfP_1635 Invoke(string ConnectionString,P_L3WH_SSCfP_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_SSCfP_1635 Invoke(DbConnection Connection,P_L3WH_SSCfP_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_SSCfP_1635 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_SSCfP_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_SSCfP_1635 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_SSCfP_1635 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_SSCfP_1635 functionReturn = new FR_L3WH_SSCfP_1635();
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

				throw new Exception("Exception occured in method cls_Save_Shelf_Content_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_SSCfP_1635 : FR_Base
	{
		public L3WH_SSCfP_1635 Result	{ get; set; }

		public FR_L3WH_SSCfP_1635() : base() {}

		public FR_L3WH_SSCfP_1635(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_SSCfP_1635 for attribute P_L3WH_SSCfP_1635
		[DataContract]
		public class P_L3WH_SSCfP_1635 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 

		}
		#endregion
		#region SClass L3WH_SSCfP_1635 for attribute L3WH_SSCfP_1635
		[DataContract]
		public class L3WH_SSCfP_1635 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid TrackingInstanceID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_SSCfP_1635 cls_Save_Shelf_Content_for_ProductID(,P_L3WH_SSCfP_1635 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_SSCfP_1635 invocationResult = cls_Save_Shelf_Content_for_ProductID.Invoke(connectionString,P_L3WH_SSCfP_1635 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Complex.Manipulation.P_L3WH_SSCfP_1635();
parameter.ProductID = ...;
parameter.ShelfID = ...;
parameter.Quantity = ...;
parameter.BatchNumber = ...;
parameter.ExpirationDate = ...;

*/
