/* 
 * Generated on 10/22/2014 4:31:12 PM
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
using CL3_ShippingOrder.Atomic.Retrieval;
using CL1_LOG_RSV;
using CL1_LOG_SHP;

namespace CL3_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3SO_DARaUSHfPTIL_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();

            var param = new P_L3SO_GSaUERfPTIL_1153()
            {
                ProductTrackingInstanceIDList = Parameter.TracknigInstances.Select(i=>i.ProductTrackingInstanceID).ToArray()
            };
            var shippingsAndActiveReservations = cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList.Invoke(Connection, Transaction, param, securityTicket).Result;

            var param2 = new P_L3SO_GARQfMCFPSH_1450()
            {
                ProductTrackingInstanceList = Parameter.TracknigInstances.Select(i => i.ProductTrackingInstanceID).ToArray()
            };
            var activeAndStartedReservations = cls_Get_ActiveReservedQuantities_for_ManuallyClearedForPickingShippmentHeaders.Invoke(Connection, Transaction, param2, securityTicket).Result;


            foreach(var trackingInstance in shippingsAndActiveReservations)
            {
                var inParam = Parameter.TracknigInstances.SingleOrDefault(i=>i.ProductTrackingInstanceID == trackingInstance.LOG_ProductTrackingInstance_RefID);

                var activeAndStartedReservation = activeAndStartedReservations.SingleOrDefault(i=>i.LOG_ProductTrackingInstance_RefID == trackingInstance.LOG_ProductTrackingInstance_RefID);
                var activeAndStartedQuantities = (activeAndStartedReservation == null) ? 0 : activeAndStartedReservation.ReservedQuantityFromTrackingInstance;

                if (inParam != null && (inParam.CurrentQuantityOnTrackingInstance - activeAndStartedQuantities) < inParam.RemovedQuantityFromTrackingInstance)
                {
                    throw new Exception("Reservation can't be deleted because picking has been started.");
                }

                foreach(var item in trackingInstance.Reservations)
                {
                    #region ShipmentHeaders

                    var shipmentHeader = new ORM_LOG_SHP_Shipment_Header();
                    shipmentHeader.Load(Connection, Transaction, item.LOG_SHP_Shipment_HeaderID);
                    shipmentHeader.IsPartiallyReadyForPicking = false;
                    shipmentHeader.IsReadyForPicking = false;
                    shipmentHeader.IsManuallyCleared_ForPicking = false;
                    shipmentHeader.HasPickingStarted = false;
                    shipmentHeader.Save(Connection, Transaction);

                    #endregion
            
                    #region Reservation

                    var reservation = new ORM_LOG_RSV_Reservation();
                    reservation.Load(Connection, Transaction, item.LOG_RSV_ReservationID);
                    reservation.IsDeleted = true;
                    reservation.Save(Connection, Transaction);

                    #endregion

                    #region Reservation Tracking Instance

                    var reservationTrackingInstance = new ORM_LOG_RSV_Reservation_TrackingInstance();
                    reservationTrackingInstance.Load(Connection, Transaction, item.LOG_RSV_Reservation_TrackingInstanceID);
                    reservationTrackingInstance.IsDeleted = true;
                    reservationTrackingInstance.Save(Connection, Transaction);

                    #endregion
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
		public static FR_Bool Invoke(string ConnectionString,P_L3SO_DARaUSHfPTIL_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3SO_DARaUSHfPTIL_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SO_DARaUSHfPTIL_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SO_DARaUSHfPTIL_1159 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3SO_DARaUSHfPTIL_1159 for attribute P_L3SO_DARaUSHfPTIL_1159
		[DataContract]
		public class P_L3SO_DARaUSHfPTIL_1159 
		{
			[DataMember]
			public P_L3SO_DARaUSHfPTIL_1159a[] TracknigInstances { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L3SO_DARaUSHfPTIL_1159a for attribute TracknigInstances
		[DataContract]
		public class P_L3SO_DARaUSHfPTIL_1159a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public Double CurrentQuantityOnTrackingInstance { get; set; } 
			[DataMember]
			public Double RemovedQuantityFromTrackingInstance { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList(,P_L3SO_DARaUSHfPTIL_1159 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Delete_ActiveReservations_and_UpdateShipmentHeaders_for_ProductTrackingInstanceIDList.Invoke(connectionString,P_L3SO_DARaUSHfPTIL_1159 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Complex.Manipulation.P_L3SO_DARaUSHfPTIL_1159();
parameter.TracknigInstances = ...;


*/
