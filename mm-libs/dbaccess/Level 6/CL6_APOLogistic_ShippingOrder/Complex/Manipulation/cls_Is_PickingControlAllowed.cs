/* 
 * Generated on 11/14/2014 4:39:33 PM
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

namespace CL6_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Is_PickingControlAllowed.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Is_PickingControlAllowed
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_IPCA_1039 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_IPCA_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6SO_IPCA_1039();
            returnValue.Result = new L6SO_IPCA_1039();

            #region Check Header

            var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
            shipmentHeader.Load(Connection, Transaction, Parameter.LOG_SHP_Shipment_HeaderID);

            if ( shipmentHeader.IsReadyForPicking == false ) 
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = true;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "IsReadyForPicking == false";
                return returnValue;
            }

            if ( shipmentHeader.IsManuallyCleared_ForPicking == false )
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = true;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "IsManuallyCleared_ForPicking == false";
                return returnValue;
            }

            if ( shipmentHeader.HasPickingStarted == false )
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = true;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "HasPickingStarted == false";
                return returnValue;
            }

            if ( shipmentHeader.HasPickingFinished == true )
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = false;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "HasPickingFinished == true";
                return returnValue;
            }

            if (shipmentHeader.IsShipped == true)
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = false;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "IsShipped == true";
                return returnValue;
            }

            if (shipmentHeader.IsBilled == true)
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = false;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "IsBilled == true";
                return returnValue;
            }

            #endregion

            #region Check Positions

            var shipmentPositions = ORM_LOG_SHP_Shipment_Position.Query.Search(Connection, Transaction, new ORM_LOG_SHP_Shipment_Position.Query()
            {
                LOG_SHP_Shipment_Header_RefID = Parameter.LOG_SHP_Shipment_HeaderID,
                IsDeleted = false
            });

            if (shipmentPositions.Count() == 0)
            {
                returnValue.Result.IsPickingControlAllowed = false;
                returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = false;
                returnValue.Result.IfPickingControlNotAllowed_Reason = "shipmentPositions.Count() == 0";
                return returnValue;
            }

            foreach (var shipmentPosition in shipmentPositions)
            {
                var quantityToShip = shipmentPosition.QuantityToShip;

                var reservations = ORM_LOG_RSV_Reservation.Query.Search(Connection, Transaction, new ORM_LOG_RSV_Reservation.Query()
                {
                    LOG_SHP_Shipment_Position_RefID = shipmentPosition.LOG_SHP_Shipment_PositionID,
                    IsReservationExecuted = false,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

                var reservedQuantity = reservations.Sum(i => i.ReservedQuantity);

                if (quantityToShip != reservedQuantity || reservedQuantity == 0)
                {
                    returnValue.Result.IsPickingControlAllowed = false;
                    returnValue.Result.IfPickingControlNotAllowed_ResetShipmentFlags = true;
                    returnValue.Result.IfPickingControlNotAllowed_Reason = String.Format("Shipment position {0} with quantity {1}, has {2} reserved quantity",
                        shipmentPosition.LOG_SHP_Shipment_PositionID.ToString(),
                        shipmentPosition.QuantityToShip,
                        reservedQuantity);
                    return returnValue;
                }
            }

            #endregion

            returnValue.Result.IsPickingControlAllowed = true;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SO_IPCA_1039 Invoke(string ConnectionString,P_L6SO_IPCA_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_IPCA_1039 Invoke(DbConnection Connection,P_L6SO_IPCA_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_IPCA_1039 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_IPCA_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_IPCA_1039 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_IPCA_1039 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_IPCA_1039 functionReturn = new FR_L6SO_IPCA_1039();
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

				throw new Exception("Exception occured in method cls_Is_PickingControlAllowed",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_IPCA_1039 : FR_Base
	{
		public L6SO_IPCA_1039 Result	{ get; set; }

		public FR_L6SO_IPCA_1039() : base() {}

		public FR_L6SO_IPCA_1039(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_IPCA_1039 for attribute P_L6SO_IPCA_1039
		[DataContract]
		public class P_L6SO_IPCA_1039 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SO_IPCA_1039 for attribute L6SO_IPCA_1039
		[DataContract]
		public class L6SO_IPCA_1039 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsPickingControlAllowed { get; set; } 
			[DataMember]
			public Boolean IfPickingControlNotAllowed_ResetShipmentFlags { get; set; } 
			[DataMember]
			public String IfPickingControlNotAllowed_Reason { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_IPCA_1039 cls_Is_PickingControlAllowed(,P_L6SO_IPCA_1039 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_IPCA_1039 invocationResult = cls_Is_PickingControlAllowed.Invoke(connectionString,P_L6SO_IPCA_1039 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Complex.Manipulation.P_L6SO_IPCA_1039();
parameter.LOG_SHP_Shipment_HeaderID = ...;

*/
