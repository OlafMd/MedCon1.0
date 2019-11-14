/* 
 * Generated on 9/10/2014 3:03:27 PM
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
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL5_APOLogistic_ShippingOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReservationsInfo_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReservationsInfo_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GRIfPID_1455_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GRIfPID_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SO_GRIfPID_1455_Array();
			//Put your code here

            List<L5SO_GRIfPID_1455> retVal = new List<L5SO_GRIfPID_1455>();

            var allReservation = cls_Get_Reservations_for_ProductID.Invoke(Connection, Transaction, new P_L5SO_GRfPID_1516 { ProductID = Parameter.ProductID }, securityTicket).Result;

            P_L3WH_GASCQfPL_1239 shelfContentQuantitiesParam = new P_L3WH_GASCQfPL_1239();
            shelfContentQuantitiesParam.ProductIDList = new Guid[1];
            shelfContentQuantitiesParam.ProductIDList[0] = Parameter.ProductID;
            var shelfContentQuantities = cls_Get_All_ShelfContent_Quantities_for_ProductListID.Invoke(Connection, Transaction, shelfContentQuantitiesParam, securityTicket).Result;

            foreach (var reservation in allReservation)
            {
                L5SO_GRIfPID_1455 retItem = new L5SO_GRIfPID_1455();
                retItem.CMN_BPT_BusinessParticipantID = reservation.CMN_BPT_BusinessParticipantID;
                retItem.CompanyName_Line1 = reservation.CompanyName_Line1;
                retItem.LOG_SHP_Shipment_HeaderID = reservation.LOG_SHP_Shipment_HeaderID;
                retItem.LOG_SHP_Shipment_PositionID = reservation.LOG_SHP_Shipment_PositionID;
                retItem.PositionQuantity = shelfContentQuantities.Select(x => x.Sum_Quantity_Current).FirstOrDefault();
                retItem.ReservedQuantity = shelfContentQuantities.Select(x => x.Sum_R_ReservedQuantity).FirstOrDefault();
                retItem.ShipmentHeader_Number = reservation.ShipmentHeader_Number;

                retVal.Add(retItem);
            }

            returnValue.Result = retVal.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_GRIfPID_1455_Array Invoke(string ConnectionString,P_L5SO_GRIfPID_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GRIfPID_1455_Array Invoke(DbConnection Connection,P_L5SO_GRIfPID_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GRIfPID_1455_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GRIfPID_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GRIfPID_1455_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GRIfPID_1455 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GRIfPID_1455_Array functionReturn = new FR_L5SO_GRIfPID_1455_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReservationsInfo_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GRIfPID_1455_Array : FR_Base
	{
		public L5SO_GRIfPID_1455[] Result	{ get; set; } 
		public FR_L5SO_GRIfPID_1455_Array() : base() {}

		public FR_L5SO_GRIfPID_1455_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GRIfPID_1455 for attribute P_L5SO_GRIfPID_1455
		[DataContract]
		public class P_L5SO_GRIfPID_1455 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GRIfPID_1455 for attribute L5SO_GRIfPID_1455
		[DataContract]
		public class L5SO_GRIfPID_1455 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public double PositionQuantity { get; set; } 
			[DataMember]
			public double ReservedQuantity { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GRIfPID_1455_Array cls_Get_ReservationsInfo_for_ProductID(,P_L5SO_GRIfPID_1455 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GRIfPID_1455_Array invocationResult = cls_Get_ReservationsInfo_for_ProductID.Invoke(connectionString,P_L5SO_GRIfPID_1455 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Retrieval.P_L5SO_GRIfPID_1455();
parameter.ProductID = ...;

*/
