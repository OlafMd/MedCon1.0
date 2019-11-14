/* 
 * Generated on 11/4/2014 4:48:20 PM
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

namespace CL2_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2SH_GSPfToSH_1334_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2SH_GSPfToSH_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2SH_GSPfToSH_1334_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Shipment.Atomic.Retrieval.SQL.cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<L2SH_GSPfToSH_1334> results = new List<L2SH_GSPfToSH_1334>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_Header_RefID","LOG_SHP_Shipment_PositionID","CMN_PRO_Product_RefID","TrackingInstance_ToShip_RefID","QuantityToShip","ShipmentPositionITL","ShipmentPosition_ValueWithoutTax","ShipmentPosition_PricePerUnitValueWithoutTax" });
				while(reader.Read())
				{
					L2SH_GSPfToSH_1334 resultItem = new L2SH_GSPfToSH_1334();
					//0:Parameter LOG_SHP_Shipment_Header_RefID of type Guid
					resultItem.LOG_SHP_Shipment_Header_RefID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);
					//2:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(2);
					//3:Parameter TrackingInstance_ToShip_RefID of type Guid
					resultItem.TrackingInstance_ToShip_RefID = reader.GetGuid(3);
					//4:Parameter QuantityToShip of type Double
					resultItem.QuantityToShip = reader.GetDouble(4);
					//5:Parameter ShipmentPositionITL of type String
					resultItem.ShipmentPositionITL = reader.GetString(5);
					//6:Parameter ShipmentPosition_ValueWithoutTax of type Decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(6);
					//7:Parameter ShipmentPosition_PricePerUnitValueWithoutTax of type Decimal
					resultItem.ShipmentPosition_PricePerUnitValueWithoutTax = reader.GetDecimal(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2SH_GSPfToSH_1334_Array Invoke(string ConnectionString,P_L2SH_GSPfToSH_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2SH_GSPfToSH_1334_Array Invoke(DbConnection Connection,P_L2SH_GSPfToSH_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2SH_GSPfToSH_1334_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SH_GSPfToSH_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2SH_GSPfToSH_1334_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SH_GSPfToSH_1334 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2SH_GSPfToSH_1334_Array functionReturn = new FR_L2SH_GSPfToSH_1334_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2SH_GSPfToSH_1334_Array : FR_Base
	{
		public L2SH_GSPfToSH_1334[] Result	{ get; set; } 
		public FR_L2SH_GSPfToSH_1334_Array() : base() {}

		public FR_L2SH_GSPfToSH_1334_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2SH_GSPfToSH_1334 for attribute P_L2SH_GSPfToSH_1334
		[DataContract]
		public class P_L2SH_GSPfToSH_1334 
		{
			//Standard type parameters
			[DataMember]
			public Guid? ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L2SH_GSPfToSH_1334 for attribute L2SH_GSPfToSH_1334
		[DataContract]
		public class L2SH_GSPfToSH_1334 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_Header_RefID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid TrackingInstance_ToShip_RefID { get; set; } 
			[DataMember]
			public Double QuantityToShip { get; set; } 
			[DataMember]
			public String ShipmentPositionITL { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_PricePerUnitValueWithoutTax { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2SH_GSPfToSH_1334_Array cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID(,P_L2SH_GSPfToSH_1334 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2SH_GSPfToSH_1334_Array invocationResult = cls_Get_ShipmentPositions_for_Tenant_or_ShipmentHeaderID.Invoke(connectionString,P_L2SH_GSPfToSH_1334 Parameter,securityTicket);
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
var parameter = new CL2_Shipment.Atomic.Retrieval.P_L2SH_GSPfToSH_1334();
parameter.ShipmentHeaderID = ...;

*/
