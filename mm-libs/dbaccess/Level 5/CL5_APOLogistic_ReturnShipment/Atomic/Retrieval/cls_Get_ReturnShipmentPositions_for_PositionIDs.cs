/* 
 * Generated on 7/8/2014 10:57:14 AM
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
    /// var result = cls_Get_ReturnShipmentPositions_for_PositionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReturnShipmentPositions_for_PositionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_GRSPfP_1523_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_GRSPfP_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5RS_GRSPfP_1523_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.SQL.cls_Get_ReturnShipmentPositions_for_PositionIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShipmentPositionIDs"," IN $$ShipmentPositionIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShipmentPositionIDs$",Parameter.ShipmentPositionIDs);


			List<L5RS_GRSPfP_1523> results = new List<L5RS_GRSPfP_1523>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_ReturnShipment_PositionID","ReturnPolicy_RefID","ReturnPolicy_Reason_DictID","CMN_PRO_Product_RefID","QuantityToShip","TotalValue","Supplier","SupplierID","ReturnShipment_Header_RefID","ReceiptPositionID","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_HeaderID","ShipmentHeader_Currency_RefID","HeaderTotalValue","ShipmentHeader_Number" });
				while(reader.Read())
				{
					L5RS_GRSPfP_1523 resultItem = new L5RS_GRSPfP_1523();
					//0:Parameter LOG_SHP_ReturnShipment_PositionID of type Guid
					resultItem.LOG_SHP_ReturnShipment_PositionID = reader.GetGuid(0);
					//1:Parameter ReturnPolicy_RefID of type Guid
					resultItem.ReturnPolicy_RefID = reader.GetGuid(1);
					//2:Parameter ReturnPolicyDescription of type Dict
					resultItem.ReturnPolicyDescription = reader.GetDictionary(2);
					resultItem.ReturnPolicyDescription.SourceTable = "log_ret_returnpolicies";
					loader.Append(resultItem.ReturnPolicyDescription);
					//3:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(3);
					//4:Parameter QuantityToShip of type decimal
					resultItem.QuantityToShip = reader.GetDecimal(4);
					//5:Parameter TotalValue of type decimal
					resultItem.TotalValue = reader.GetDecimal(5);
					//6:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(6);
					//7:Parameter SupplierID of type Guid
					resultItem.SupplierID = reader.GetGuid(7);
					//8:Parameter ReturnShipment_Header_RefID of type Guid
					resultItem.ReturnShipment_Header_RefID = reader.GetGuid(8);
					//9:Parameter ReceiptPositionID of type Guid
					resultItem.ReceiptPositionID = reader.GetGuid(9);
					//10:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(10);
					//11:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(11);
					//12:Parameter ShipmentHeader_Currency_RefID of type Guid
					resultItem.ShipmentHeader_Currency_RefID = reader.GetGuid(12);
					//13:Parameter HeaderTotalValue of type decimal
					resultItem.HeaderTotalValue = reader.GetDecimal(13);
					//14:Parameter ShipmentHeader_Number of type string
					resultItem.ShipmentHeader_Number = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ReturnShipmentPositions_for_PositionIDs",ex);
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
		public static FR_L5RS_GRSPfP_1523_Array Invoke(string ConnectionString,P_L5RS_GRSPfP_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfP_1523_Array Invoke(DbConnection Connection,P_L5RS_GRSPfP_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_GRSPfP_1523_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_GRSPfP_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_GRSPfP_1523_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_GRSPfP_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_GRSPfP_1523_Array functionReturn = new FR_L5RS_GRSPfP_1523_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReturnShipmentPositions_for_PositionIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_GRSPfP_1523_Array : FR_Base
	{
		public L5RS_GRSPfP_1523[] Result	{ get; set; } 
		public FR_L5RS_GRSPfP_1523_Array() : base() {}

		public FR_L5RS_GRSPfP_1523_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_GRSPfP_1523 for attribute P_L5RS_GRSPfP_1523
		[DataContract]
		public class P_L5RS_GRSPfP_1523 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShipmentPositionIDs { get; set; } 

		}
		#endregion
		#region SClass L5RS_GRSPfP_1523 for attribute L5RS_GRSPfP_1523
		[DataContract]
		public class L5RS_GRSPfP_1523 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_ReturnShipment_PositionID { get; set; } 
			[DataMember]
			public Guid ReturnPolicy_RefID { get; set; } 
			[DataMember]
			public Dict ReturnPolicyDescription { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public decimal QuantityToShip { get; set; } 
			[DataMember]
			public decimal TotalValue { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public Guid ReturnShipment_Header_RefID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid ShipmentHeader_Currency_RefID { get; set; } 
			[DataMember]
			public decimal HeaderTotalValue { get; set; } 
			[DataMember]
			public string ShipmentHeader_Number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_GRSPfP_1523_Array cls_Get_ReturnShipmentPositions_for_PositionIDs(,P_L5RS_GRSPfP_1523 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_GRSPfP_1523_Array invocationResult = cls_Get_ReturnShipmentPositions_for_PositionIDs.Invoke(connectionString,P_L5RS_GRSPfP_1523 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.P_L5RS_GRSPfP_1523();
parameter.ShipmentPositionIDs = ...;

*/
