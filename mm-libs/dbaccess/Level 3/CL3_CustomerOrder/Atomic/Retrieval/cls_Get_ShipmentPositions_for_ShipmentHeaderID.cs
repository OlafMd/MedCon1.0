/* 
 * Generated on 5/22/2014 7:53:16 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentPositions_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentPositions_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL3_GSPfSH_1047_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL3_GSPfSH_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CL3_GSPfSH_1047_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_ShipmentPositions_for_ShipmentHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);



			List<CL3_GSPfSH_1047> results = new List<CL3_GSPfSH_1047>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_PositionID","QuantityToShip","ShipmentPosition_ValueWithoutTax","CMN_PRO_Product_RefID","CurrencySymbol","Warehouse_Name","QuantityInStock","PrescriptionsCount" });
				while(reader.Read())
				{
					CL3_GSPfSH_1047 resultItem = new CL3_GSPfSH_1047();
					//0:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(0);
					//1:Parameter QuantityToShip of type decimal
					resultItem.QuantityToShip = reader.GetDecimal(1);
					//2:Parameter ShipmentPosition_ValueWithoutTax of type decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(2);
					//3:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(3);
					//4:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(4);
					//5:Parameter Warehouse_Name of type string
					resultItem.Warehouse_Name = reader.GetString(5);
					//6:Parameter QuantityInStock of type decimal
					resultItem.QuantityInStock = reader.GetDecimal(6);
					//7:Parameter PrescriptionsCount of type decimal
					resultItem.PrescriptionsCount = reader.GetDecimal(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShipmentPositions_for_ShipmentHeaderID",ex);
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
		public static FR_CL3_GSPfSH_1047_Array Invoke(string ConnectionString,P_CL3_GSPfSH_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL3_GSPfSH_1047_Array Invoke(DbConnection Connection,P_CL3_GSPfSH_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL3_GSPfSH_1047_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL3_GSPfSH_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL3_GSPfSH_1047_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL3_GSPfSH_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL3_GSPfSH_1047_Array functionReturn = new FR_CL3_GSPfSH_1047_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentPositions_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL3_GSPfSH_1047_Array : FR_Base
	{
		public CL3_GSPfSH_1047[] Result	{ get; set; } 
		public FR_CL3_GSPfSH_1047_Array() : base() {}

		public FR_CL3_GSPfSH_1047_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL3_GSPfSH_1047 for attribute P_CL3_GSPfSH_1047
		[DataContract]
		public class P_CL3_GSPfSH_1047 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass CL3_GSPfSH_1047 for attribute CL3_GSPfSH_1047
		[DataContract]
		public class CL3_GSPfSH_1047 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public decimal QuantityToShip { get; set; } 
			[DataMember]
			public decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 
			[DataMember]
			public string Warehouse_Name { get; set; } 
			[DataMember]
			public decimal QuantityInStock { get; set; } 
			[DataMember]
			public decimal PrescriptionsCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL3_GSPfSH_1047_Array cls_Get_ShipmentPositions_for_ShipmentHeaderID(,P_CL3_GSPfSH_1047 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL3_GSPfSH_1047_Array invocationResult = cls_Get_ShipmentPositions_for_ShipmentHeaderID.Invoke(connectionString,P_CL3_GSPfSH_1047 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Retrieval.P_CL3_GSPfSH_1047();
parameter.ShipmentHeaderID = ...;

*/
