/* 
 * Generated on 8/19/2014 5:21:54 PM
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
using CL2_Shipment.Atomic.Manipulation;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;

namespace CL5_APOLogistic_ShippingOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Change_ShippigOrderHeader_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Change_ShippigOrderHeader_Status
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_CSOS_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
            shipmentHeader.Load(Connection, Transaction, Parameter.LOG_SHP_Shipment_HeaderID);

            if (Parameter.IsReadyForPicking != null)
            {
                shipmentHeader.IsReadyForPicking = (Boolean)Parameter.IsReadyForPicking;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.ReadyForPicking;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
                
            }
            if (Parameter.IsPartiallyReadyForPicking != null)
            {
                shipmentHeader.IsPartiallyReadyForPicking = (Boolean)Parameter.IsPartiallyReadyForPicking;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.PartiallyReadyForPicking;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }
            if (Parameter.IsManuallyCleared_ForPicking != null)
            {
                shipmentHeader.IsManuallyCleared_ForPicking = (Boolean)Parameter.IsManuallyCleared_ForPicking;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.ManuallyClearedForPicking;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }
            if (Parameter.HasPickingStarted != null)
            {
                shipmentHeader.HasPickingStarted = (Boolean)Parameter.HasPickingStarted;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.PickingStarted;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }
            if (Parameter.HasPickingFinished != null)
            {
                shipmentHeader.HasPickingFinished = (Boolean)Parameter.HasPickingFinished;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.PickingFinished;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }
            if (Parameter.IsBilled != null)
            {
                shipmentHeader.IsBilled = (Boolean)Parameter.IsBilled;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.Billed;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }

            if (Parameter.IsShipped != null)
            {
                shipmentHeader.IsShipped = (Boolean)Parameter.IsShipped;

                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.Shipped;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
            }

		    if (Parameter.IsDeleted != null)
		    {
                var param = new P_L2SH_SSSH_1210();
                param.ShipmentHeaderID = Parameter.LOG_SHP_Shipment_HeaderID;
                param.ShipmentHeaderStatus = EShipmentStatus.Deleted;

                cls_Save_ShipmentStatusHistory.Invoke(Connection, Transaction, param, securityTicket);
		    }

            shipmentHeader.Save(Connection, Transaction);
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SO_CSOS_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SO_CSOS_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_CSOS_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_CSOS_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Change_ShippigOrderHeader_Status",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SO_CSOS_1148 for attribute P_L5SO_CSOS_1148
		[DataContract]
		public class P_L5SO_CSOS_1148 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Boolean? IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean? HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean? IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Boolean? IsBilled { get; set; } 
			[DataMember]
			public Boolean? IsShipped { get; set; } 
			[DataMember]
			public Boolean? IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_ShippigOrderHeader_Status(,P_L5SO_CSOS_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_ShippigOrderHeader_Status.Invoke(connectionString,P_L5SO_CSOS_1148 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Manipulation.P_L5SO_CSOS_1148();
parameter.LOG_SHP_Shipment_HeaderID = ...;
parameter.IsPartiallyReadyForPicking = ...;
parameter.IsReadyForPicking = ...;
parameter.HasPickingStarted = ...;
parameter.HasPickingFinished = ...;
parameter.IsManuallyCleared_ForPicking = ...;
parameter.IsBilled = ...;
parameter.IsShipped = ...;
parameter.IsDeleted = ...;

*/
