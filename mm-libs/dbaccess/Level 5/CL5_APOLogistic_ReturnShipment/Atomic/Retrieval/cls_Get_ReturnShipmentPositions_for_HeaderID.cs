/* 
 * Generated on 5/5/2014 6:25:47 PM
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

namespace CL5_APOLogistic_ReturnShipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReturnShipmentPositions_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReturnShipmentPositions_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_GRSPfH_1105_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_GRSPfH_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5RS_GRSPfH_1105_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.SQL.cls_Get_ReturnShipmentPositions_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReturnShipmentHeaderID", Parameter.ReturnShipmentHeaderID);



			List<L5RS_GRSPfH_1105> results = new List<L5RS_GRSPfH_1105>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_ReturnShipment_PositionID","LOG_SHP_Shipment_PositionID","ProductId","ReturnedQuantity","ReceiptQuantity","ShipmentPosition_ValueWithoutTax","Supplier","ShipmentHeader_ValueWithoutTax","LOG_RET_ReturnPolicyID" });
				while(reader.Read())
				{
					L5RS_GRSPfH_1105 resultItem = new L5RS_GRSPfH_1105();
					//0:Parameter LOG_SHP_ReturnShipment_PositionID of type Guid
					resultItem.LOG_SHP_ReturnShipment_PositionID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);
					//2:Parameter ProductId of type Guid
					resultItem.ProductId = reader.GetGuid(2);
					//3:Parameter ReturnedQuantity of type int
					resultItem.ReturnedQuantity = reader.GetInteger(3);
					//4:Parameter ReceiptQuantity of type int
					resultItem.ReceiptQuantity = reader.GetInteger(4);
					//5:Parameter ShipmentPosition_ValueWithoutTax of type Decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(5);
					//6:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(6);
					//7:Parameter ShipmentHeader_ValueWithoutTax of type Decimal
					resultItem.ShipmentHeader_ValueWithoutTax = reader.GetDecimal(7);
					//8:Parameter LOG_RET_ReturnPolicyID of type Guid
					resultItem.LOG_RET_ReturnPolicyID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ReturnShipmentPositions_for_HeaderID",ex);
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
		public static FR_L5RS_GRSPfH_1105_Array Invoke(string ConnectionString,P_L5RS_GRSPfH_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfH_1105_Array Invoke(DbConnection Connection,P_L5RS_GRSPfH_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfH_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_GRSPfH_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_GRSPfH_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_GRSPfH_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_GRSPfH_1105_Array functionReturn = new FR_L5RS_GRSPfH_1105_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReturnShipmentPositions_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_GRSPfH_1105_Array : FR_Base
	{
		public L5RS_GRSPfH_1105[] Result	{ get; set; } 
		public FR_L5RS_GRSPfH_1105_Array() : base() {}

		public FR_L5RS_GRSPfH_1105_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_GRSPfH_1105 for attribute P_L5RS_GRSPfH_1105
		[DataContract]
		public class P_L5RS_GRSPfH_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid? ReturnShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5RS_GRSPfH_1105 for attribute L5RS_GRSPfH_1105
		[DataContract]
		public class L5RS_GRSPfH_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_ReturnShipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid ProductId { get; set; } 
			[DataMember]
			public int ReturnedQuantity { get; set; } 
			[DataMember]
			public int ReceiptQuantity { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public Decimal ShipmentHeader_ValueWithoutTax { get; set; } 
			[DataMember]
			public Guid LOG_RET_ReturnPolicyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_GRSPfH_1105_Array cls_Get_ReturnShipmentPositions_for_HeaderID(,P_L5RS_GRSPfH_1105 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_GRSPfH_1105_Array invocationResult = cls_Get_ReturnShipmentPositions_for_HeaderID.Invoke(connectionString,P_L5RS_GRSPfH_1105 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.P_L5RS_GRSPfH_1105();
parameter.ReturnShipmentHeaderID = ...;

*/
