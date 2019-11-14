/* 
 * Generated on 11/5/2014 10:46:08 AM
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

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ShipmentPositions_Corrections.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShipmentPositions_Corrections
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_SSPC_1240 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_SSPC_1240 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SO_SSPC_1240();
			//Put your code here
            returnValue.Result = new L5SO_SSPC_1240();
                           
            //saving quantities and prices for positions
            foreach (var correction in Parameter.Corrections)
            {
                var shipmentPosition = new ORM_LOG_SHP_Shipment_Position();
                shipmentPosition.Load(Connection, Transaction, correction.PositionID);
             
                shipmentPosition.QuantityToShip = correction.ChangedQuantity;
                shipmentPosition.ShipmentPosition_PricePerUnitValueWithoutTax = correction.UnitPrice;
                shipmentPosition.ShipmentPosition_ValueWithoutTax = Convert.ToDecimal(shipmentPosition.QuantityToShip) * correction.UnitPrice;
                shipmentPosition.Save(Connection, Transaction);                         
            }

            //update shipment header
            cls_Update_Current_TotalValue_on_ShipmentHeader_from_Positions.
                    Invoke(Connection, Transaction, new P_L5SO_UCTVoSHfP_1549 { ShipmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket);      

            #endregion

            returnValue.Result.IsSaved = true;

			return returnValue;
			#endregion UserCode
		}


		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_SSPC_1240 Invoke(string ConnectionString,P_L5SO_SSPC_1240 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_SSPC_1240 Invoke(DbConnection Connection,P_L5SO_SSPC_1240 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_SSPC_1240 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_SSPC_1240 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_SSPC_1240 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_SSPC_1240 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_SSPC_1240 functionReturn = new FR_L5SO_SSPC_1240();
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

				throw new Exception("Exception occured in method cls_Save_ShipmentPositions_Corrections",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_SSPC_1240 : FR_Base
	{
		public L5SO_SSPC_1240 Result	{ get; set; }

		public FR_L5SO_SSPC_1240() : base() {}

		public FR_L5SO_SSPC_1240(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_SSPC_1240 for attribute P_L5SO_SSPC_1240
		[DataContract]
		public class P_L5SO_SSPC_1240 
		{
			[DataMember]
			public P_L5SO_SSPC_1240a[] Corrections { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass P_L5SO_SSPC_1240a for attribute Corrections
		[DataContract]
		public class P_L5SO_SSPC_1240a 
		{
			//Standard type parameters
			[DataMember]
			public Guid PositionID { get; set; } 
			[DataMember]
			public double ChangedQuantity { get; set; } 
			[DataMember]
			public decimal UnitPrice { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5SO_SSPC_1240 for attribute L5SO_SSPC_1240
		[DataContract]
		public class L5SO_SSPC_1240 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsSaved { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_SSPC_1240 cls_Save_ShipmentPositions_Corrections(,P_L5SO_SSPC_1240 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_SSPC_1240 invocationResult = cls_Save_ShipmentPositions_Corrections.Invoke(connectionString,P_L5SO_SSPC_1240 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Manipulation.P_L5SO_SSPC_1240();
parameter.Corrections = ...;

parameter.ShipmentHeaderID = ...;

*/
