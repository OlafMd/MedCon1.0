/* 
 * Generated on 11/14/2014 3:08:02 PM
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
using CL3_ShippingOrder.Complex.Manipulation;
using CL6_APOLogistic_ShippingOrder.Utils;
using CL5_APOLogistic_ShippingOrder.Atomic.Manipulation;
using CL1_LOG_SHP;
using CL1_LOG_RSV;
using CL1_LOG;
using CL1_LOG_WRH;

namespace CL6_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Finish_PickingControl.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Finish_PickingControl
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_FPC_1548 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_FPC_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6SO_FPC_1548();
            returnValue.Result = new L6SO_FPC_1548();

            #region Validation

            var isAllowedParam = new P_L6SO_IPCA_1039()
            {
                LOG_SHP_Shipment_HeaderID = Parameter.LOG_SHP_Shipment_HeaderID
            };
            var validationResult = cls_Is_PickingControlAllowed.Invoke(Connection, Transaction, isAllowedParam, securityTicket).Result;

            if (!validationResult.IsPickingControlAllowed) 
            {
                if (validationResult.IfPickingControlNotAllowed_ResetShipmentFlags)
                {
                    var updateHeaderParam = new P_L3SO_USHSaDARfSH_1054()
                    {
                        ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID
                    };

                    var result = cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID.Invoke(Connection, Transaction, updateHeaderParam, securityTicket).Result;

                    if (result)
                        returnValue.Result.Status = EPickingControlStatus.Error_InconsistentData;
                    else
                        returnValue.Result.Status = EPickingControlStatus.Error_AlreadyFinished;
                }
                else 
                {
                    returnValue.Result.Status = EPickingControlStatus.Error_AlreadyFinished;
                }

                return returnValue;
            }

            #endregion

            #region GetAllShippingorderPositions

            var positions = ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Position.Query()
            {
                LOG_SHP_Shipment_Header_RefID = Parameter.LOG_SHP_Shipment_HeaderID,
                IsDeleted = false
            });
            
            #endregion

            foreach (var position in positions)
            {
                var reservations = ORM_LOG_RSV_Reservation.Query.Search(Connection, Transaction, new ORM_LOG_RSV_Reservation.Query()
                {
                    LOG_SHP_Shipment_Position_RefID = position.LOG_SHP_Shipment_PositionID,
                    IsReservationExecuted = false,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                #region Update Contents and positions

                foreach (var reservation in reservations)
                {
                    reservation.IsReservationExecuted = true;
                    reservation.Save(Connection, Transaction);

                    #region Shelf Conent

                    var shelfContent = new ORM_LOG_WRH_Shelf_Content();
                    shelfContent.Load(Connection, Transaction, reservation.LOG_WRH_Shelf_Content_RefID);
                    shelfContent.Quantity_Current -= reservation.ReservedQuantity;
                    shelfContent.Save(Connection, Transaction);

                    #endregion

                    #region Shelf Content Adjustments

                    var contentAdjustment = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment();
                    contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID = Guid.NewGuid();
                    contentAdjustment.ShelfContent_RefID = shelfContent.LOG_WRH_Shelf_ContentID;

                    contentAdjustment.QuantityChangedAmount = -reservation.ReservedQuantity;;
                    contentAdjustment.QuantityChangedDate = DateTime.Now;

                    contentAdjustment.IsInitialReceipt = false;
                    contentAdjustment.IsInventoryJobCorrection = false;
                    contentAdjustment.IsShipmentWithdrawal = false;
                    contentAdjustment.IsManualCorrection = false;

                    contentAdjustment.IsShipmentWithdrawal = true;
                    contentAdjustment.IfShipmentWithdrawal_ShipmentPosition_RefID = reservation.LOG_SHP_Shipment_Position_RefID;

                    contentAdjustment.PerformedBy_Account_RefID = securityTicket.AccountID;
                    contentAdjustment.PerformedAt_Date = DateTime.Now;

                    contentAdjustment.ContentAdjustmentComment = "Product is being moved from the shelf after picking control";

                    contentAdjustment.Tenant_RefID = securityTicket.TenantID;
                    contentAdjustment.Creation_Timestamp = DateTime.Now;
                    contentAdjustment.Save(Connection, Transaction);

                    #endregion

                    #region Reservation TrackingInstance

                    var reservationTrackingInstance = ORM_LOG_RSV_Reservation_TrackingInstance.Query.Search(Connection, Transaction, new ORM_LOG_RSV_Reservation_TrackingInstance.Query()
                    {
                        LOG_RSV_Reservation_RefID = reservation.LOG_RSV_ReservationID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).SingleOrDefault();

                    if (reservationTrackingInstance != default(ORM_LOG_RSV_Reservation_TrackingInstance))
                    {

                        var trackingInstance = new ORM_LOG_ProductTrackingInstance();
                        trackingInstance.Load(Connection, Transaction, reservationTrackingInstance.LOG_ProductTrackingInstance_RefID);

                        trackingInstance.CurrentQuantityOnTrackingInstance -= reservationTrackingInstance.ReservedQuantityFromTrackingInstance;
                        trackingInstance.R_FreeQuantity -= reservationTrackingInstance.ReservedQuantityFromTrackingInstance;
                        trackingInstance.R_ReservedQuantity -= reservationTrackingInstance.ReservedQuantityFromTrackingInstance;

                        trackingInstance.Save(Connection, Transaction);

                        #region ORM_LOG_ProductTrackingInstance_HistoryEntry

                        var trackingInstanceHistory = new CL1_LOG.ORM_LOG_ProductTrackingInstance_HistoryEntry();
                        trackingInstanceHistory.LOG_ProductTrackingInstance_HistoryEntryID = Guid.NewGuid();
                        trackingInstanceHistory.ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
                        trackingInstanceHistory.HistoryEntry_Text = "Products are being removed from the shelf after picking control finish";
                        trackingInstanceHistory.Creation_Timestamp = DateTime.Now;
                        trackingInstanceHistory.Tenant_RefID = securityTicket.TenantID;
                        trackingInstanceHistory.Save(Connection, Transaction);

                        #endregion

                        #region ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance

                        var adjustment2tracking = new CL1_LOG_WRH.ORM_LOG_WRH_Shelf_ContentAdjustment_TrackingInstance();
                        adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_TrackingInstanceID = Guid.NewGuid();
                        adjustment2tracking.LOG_ProductTrackingInstance_RefID = trackingInstance.LOG_ProductTrackingInstanceID;
                        adjustment2tracking.LOG_WRH_Shelf_ContentAdjustment_RefID = contentAdjustment.LOG_WRH_Shelf_ContentAdjustmentID;
                        adjustment2tracking.QuantityChangedAmount = - reservation.ReservedQuantity;
                        adjustment2tracking.Creation_Timestamp = DateTime.Now;
                        adjustment2tracking.Tenant_RefID = securityTicket.TenantID;
                        adjustment2tracking.Save(Connection, Transaction);

                        #endregion
                    }

                    #endregion
                }

                #endregion
            }

            #region Change ShipmentOrderStatus Status

            var parameter = new P_L5SO_CSOS_1148();
            parameter.LOG_SHP_Shipment_HeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
            parameter.HasPickingFinished = true;
            parameter.IsShipped = true;

            cls_Change_ShippigOrderHeader_Status.Invoke(Connection, Transaction, parameter, securityTicket);

            #endregion

            returnValue.Result.Status = EPickingControlStatus.Finished;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SO_FPC_1548 Invoke(string ConnectionString,P_L6SO_FPC_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_FPC_1548 Invoke(DbConnection Connection,P_L6SO_FPC_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_FPC_1548 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_FPC_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_FPC_1548 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_FPC_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_FPC_1548 functionReturn = new FR_L6SO_FPC_1548();
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

				throw new Exception("Exception occured in method cls_Finish_PickingControl",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_FPC_1548 : FR_Base
	{
		public L6SO_FPC_1548 Result	{ get; set; }

		public FR_L6SO_FPC_1548() : base() {}

		public FR_L6SO_FPC_1548(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_FPC_1548 for attribute P_L6SO_FPC_1548
		[DataContract]
		public class P_L6SO_FPC_1548 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_FPC_1548 for attribute L6SO_FPC_1548
		[DataContract]
		public class L6SO_FPC_1548 
		{
			//Standard type parameters
			[DataMember]
			public EPickingControlStatus Status { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_FPC_1548 cls_Finish_PickingControl(,P_L6SO_FPC_1548 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_FPC_1548 invocationResult = cls_Finish_PickingControl.Invoke(connectionString,P_L6SO_FPC_1548 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Complex.Manipulation.P_L6SO_FPC_1548();
parameter.LOG_SHP_Shipment_HeaderID = ...;

*/
