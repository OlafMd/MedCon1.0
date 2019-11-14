/* 
 * Generated on 10/21/2014 4:32:28 PM
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

namespace CL3_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Shelf_ContentAdjustments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Shelf_ContentAdjustments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_SSCA_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();
            returnValue.Result = false;

            double adjustedQuantity = 0.0;

            CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment adjustment = null;
            CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance contentAdjustmentTrackingInstance = null;
            CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content shelfContent = null;

            if (Parameter.Adjustments == null)
            {
                return returnValue;
            }

            var adjustmentsShelfContent = new Dictionary<Guid, Double>();

            #region Adjustments without TrackingInstances

            foreach (var item in Parameter.Adjustments.Where(x => x.TrackingInstanceID == Guid.Empty))
            {
                var productTrackingInstaces = CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query.Search(Connection, Transaction,
                   new CL1_LOG_WRH.ORM_LOG_WRH_ShelfContent_2_TrackingInstance.Query
                   {
                       LOG_WRH_Shelf_Content_RefID = item.ShelfContentID,
                       IsDeleted = false,
                       Tenant_RefID = securityTicket.TenantID
                   }).ToArray();

                shelfContent = CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query.Search(Connection, Transaction,
                     new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query()
                     {
                         LOG_WRH_Shelf_ContentID = item.ShelfContentID,
                         IsDeleted = false,
                         Tenant_RefID = securityTicket.TenantID
                     }).Single();

                double shelfContent_CurrentQuantity_Minus_TrackingInstances_CurrentQuantity = shelfContent.Quantity_Current;
                if (productTrackingInstaces != null)
                {
                    foreach (var assignment in productTrackingInstaces)
                    {
                        var productTrackingInstancesByShelfContent = CL1_LOG.ORM_LOG_ProductTrackingInstance.Query.Search(Connection, Transaction,
                           new CL1_LOG.ORM_LOG_ProductTrackingInstance.Query
                           {
                               LOG_ProductTrackingInstanceID = assignment.LOG_ProductTrackingInstance_RefID,
                               IsDeleted = false,
                               Tenant_RefID = securityTicket.TenantID
                           }).Single();
                        shelfContent_CurrentQuantity_Minus_TrackingInstances_CurrentQuantity -= productTrackingInstancesByShelfContent.CurrentQuantityOnTrackingInstance;
                    }
                }

                adjustedQuantity = item.AdjustedQuantity - shelfContent_CurrentQuantity_Minus_TrackingInstances_CurrentQuantity;

                adjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment
                {
                    LOG_WRH_Shelf_ContentAdjustmentID = item.IsRelocation ? item.RelocationAdjustmentID : Guid.NewGuid(),
                    ShelfContent_RefID = item.ShelfContentID,
                    QuantityChangedAmount = adjustedQuantity,
                    QuantityChangedDate = DateTime.Now,
                    IsManualCorrection = item.IsManualCorrection,
                    IfManualCorrection_InventoryChangeReason_RefID = item.IfManualCorrection_InventoryChangeReason_RefID,
                    IsRelocation = item.IsRelocation,
                    IfRelocation_CorrespondingAdjustment_RefID = item.IfRelocation_CorrespondingAdjustment_RefID,
                    IsShipmentWithdrawal = item.IsShipmentWithdrawal,
                    IfShipmentWithdrawal_ShipmentPosition_RefID = item.IfShipmentWithdrawal_ShipmentPosition_RefID,
                    PerformedAt_Date = DateTime.Now,
                    PerformedBy_Account_RefID = securityTicket.AccountID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                adjustment.Save(Connection, Transaction);

                if (adjustmentsShelfContent.ContainsKey(item.ShelfContentID))
                {
                    adjustmentsShelfContent[item.ShelfContentID] += adjustedQuantity;
                }
                else
                {
                    adjustmentsShelfContent[item.ShelfContentID] = adjustedQuantity;
                }
            }

            #endregion

            #region Adjustments with TrackingInstances

            // Adjustements that have tracking instances and memorize relative adjustement values by ShelfID
            foreach (var item in Parameter.Adjustments.Where(x => x.TrackingInstanceID != Guid.Empty))
            {
                var productTrackingInstance = new CL1_LOG.ORM_LOG_ProductTrackingInstance();
                productTrackingInstance.Load(Connection, Transaction, item.TrackingInstanceID);

                if (productTrackingInstance.LOG_ProductTrackingInstanceID == Guid.Empty || productTrackingInstance.IsDeleted == true)
                {
                    throw new Exception("Wrong Product tracking instance");
                }

                adjustedQuantity = item.AdjustedQuantity - productTrackingInstance.CurrentQuantityOnTrackingInstance;

                adjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment
                {
                    LOG_WRH_Shelf_ContentAdjustmentID = item.IsRelocation ? item.RelocationAdjustmentID : Guid.NewGuid(),
                    ShelfContent_RefID = item.ShelfContentID,
                    QuantityChangedAmount = adjustedQuantity,
                    QuantityChangedDate = DateTime.Now,
                    IsManualCorrection = item.IsManualCorrection,
                    IfManualCorrection_InventoryChangeReason_RefID = item.IfManualCorrection_InventoryChangeReason_RefID,
                    IsRelocation = item.IsRelocation,
                    IfRelocation_CorrespondingAdjustment_RefID = item.IfRelocation_CorrespondingAdjustment_RefID,
                    IsShipmentWithdrawal = item.IsShipmentWithdrawal,
                    IfShipmentWithdrawal_ShipmentPosition_RefID = item.IfShipmentWithdrawal_ShipmentPosition_RefID,
                    PerformedAt_Date = DateTime.Now,
                    PerformedBy_Account_RefID = securityTicket.AccountID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                };
                adjustment.Save(Connection, Transaction);

                contentAdjustmentTrackingInstance = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance
                {
                    LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    LOG_ProductTrackingInstance_RefID = item.TrackingInstanceID,
                    LOG_WRH_Shelf_ContentAdjustment_RefID = adjustment.LOG_WRH_Shelf_ContentAdjustmentID,
                    QuantityChangedAmount = item.AdjustedQuantity
                };
                contentAdjustmentTrackingInstance.Save(Connection, Transaction);

                productTrackingInstance.CurrentQuantityOnTrackingInstance = item.AdjustedQuantity;
                productTrackingInstance.Save(Connection, Transaction);

                if (adjustmentsShelfContent.ContainsKey(item.ShelfContentID))
                {
                    adjustmentsShelfContent[item.ShelfContentID] += adjustedQuantity;
                }
                else
                {
                    adjustmentsShelfContent[item.ShelfContentID] = adjustedQuantity;
                }
            }

            #endregion

            // update shelf content for all adjustments
            foreach (var item in adjustmentsShelfContent.Keys)
            {
                shelfContent = CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query.Search(Connection, Transaction,
                 new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_Content.Query()
                 {
                     LOG_WRH_Shelf_ContentID = item,
                     IsDeleted = false,
                     Tenant_RefID = securityTicket.TenantID
                 }).Single();

                shelfContent.Quantity_Current += adjustmentsShelfContent[item];
                shelfContent.Save(Connection, Transaction);
            }

            returnValue.Result = true;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3WH_SSCA_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3WH_SSCA_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_SSCA_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_SSCA_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Shelf_ContentAdjustments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3WH_SSCA_1732 for attribute P_L3WH_SSCA_1732
		[DataContract]
		public class P_L3WH_SSCA_1732 
		{
			[DataMember]
			public P_L3WH_SSCA_1732a[] Adjustments { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L3WH_SSCA_1732a for attribute Adjustments
		[DataContract]
		public class P_L3WH_SSCA_1732a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid TrackingInstanceID { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public double AdjustedQuantity { get; set; } 
			[DataMember]
			public bool IsManualCorrection { get; set; } 
			[DataMember]
			public Guid IfManualCorrection_InventoryChangeReason_RefID { get; set; } 
			[DataMember]
			public bool IsRelocation { get; set; } 
			[DataMember]
			public Guid IfRelocation_CorrespondingAdjustment_RefID { get; set; } 
			[DataMember]
			public bool IsShipmentWithdrawal { get; set; } 
			[DataMember]
			public Guid IfShipmentWithdrawal_ShipmentPosition_RefID { get; set; } 
			[DataMember]
			public Guid RelocationAdjustmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Shelf_ContentAdjustments(,P_L3WH_SSCA_1732 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_Shelf_ContentAdjustments.Invoke(connectionString,P_L3WH_SSCA_1732 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Complex.Manipulation.P_L3WH_SSCA_1732();
parameter.Adjustments = ...;


*/
