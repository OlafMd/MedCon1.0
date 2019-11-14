/* 
 * Generated on 11/5/2014 10:54:11 AM
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
using CL1_LOG_SHP;
using CL1_LOG_RSV;
using CL1_LOG;
using CL2_Shipment.Atomic.Manipulation;
using DLCore_DBCommons.APODemand;

namespace CL3_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3SO_USHSaDARfSH_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Reset Shipment Header

            var shipmentHeader = new ORM_LOG_SHP_Shipment_Header();
            shipmentHeader.Load(Connection, Transaction, Parameter.ShipmentHeaderID);

            if (shipmentHeader.IsShipped) 
            {
                returnValue.Result = false;
                return returnValue;
            }

            shipmentHeader.IsPartiallyReadyForPicking = false;
            shipmentHeader.IsManuallyCleared_ForPicking = false;
            shipmentHeader.IsReadyForPicking = false;
            shipmentHeader.HasPickingStarted = false;
            shipmentHeader.Save(Connection, Transaction);

            #endregion

            #region Save EShipmentStatus.FlagsCleared

            var param = new P_L2SH_SSSH_1210();
            param.ShipmentHeaderID = Parameter.ShipmentHeaderID;
            param.ShipmentHeaderStatus = EShipmentStatus.FlagsCleared;

            cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);

            #endregion

            var positions = ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Position.Query()
            {
                LOG_SHP_Shipment_Header_RefID = Parameter.ShipmentHeaderID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            });

            foreach (var position in positions)
            {
                var reservations = ORM_LOG_RSV_Reservation.Query.Search(Connection, Transaction, new ORM_LOG_RSV_Reservation.Query()
                {
                    LOG_SHP_Shipment_Position_RefID = position.LOG_SHP_Shipment_PositionID,
                    IsReservationExecuted = false,      //this is impossible, but I still want to keep better trace if somehow happen  @Pedja
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                foreach (var reservation in reservations)
                {
                    #region Delete Reservation

                    reservation.IsDeleted = true;
                    reservation.Save(Connection, Transaction);

                    #endregion

                    #region Delete Reservation TrackingInstance

                    var reservationTrackingInstance = ORM_LOG_RSV_Reservation_TrackingInstance.Query.SoftDelete(Connection, Transaction, new ORM_LOG_RSV_Reservation_TrackingInstance.Query()
                    {
                        LOG_RSV_Reservation_RefID = reservation.LOG_RSV_ReservationID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });

                    #endregion
                }
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
		public static FR_Bool Invoke(string ConnectionString,P_L3SO_USHSaDARfSH_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3SO_USHSaDARfSH_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SO_USHSaDARfSH_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SO_USHSaDARfSH_1054 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3SO_USHSaDARfSH_1054 for attribute P_L3SO_USHSaDARfSH_1054
		[DataContract]
		public class P_L3SO_USHSaDARfSH_1054 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID(,P_L3SO_USHSaDARfSH_1054 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Update_ShipmentHeaderStatus_and_DeleteActiveReservations_for_ShipmentHeaderID.Invoke(connectionString,P_L3SO_USHSaDARfSH_1054 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Complex.Manipulation.P_L3SO_USHSaDARfSH_1054();
parameter.ShipmentHeaderID = ...;

*/
