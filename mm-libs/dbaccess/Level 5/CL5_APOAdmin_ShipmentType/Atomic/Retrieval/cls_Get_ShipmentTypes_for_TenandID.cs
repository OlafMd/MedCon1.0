/* 
 * Generated on 10/17/2013 2:23:56 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_ShipmentType.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentTypes_for_TenandID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentTypes_for_TenandID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ST_GSTfT_1210_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ST_GSTfT_1210_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_ShipmentType.Atomic.Retrieval.SQL.cls_Get_ShipmentTypes_for_TenandID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5ST_GSTfT_1210> results = new List<L5ST_GSTfT_1210>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_TypeID","ShipmentType_Name_DictID","ShipmentType_Description_DictID","GlobalPropertyMatchingID","IfFixedPricePerShipment_Price_RefID","IsFixedPricePerShipment","IsPartialPickingPermitted","IsCustomerPickup" });
				while(reader.Read())
				{
					L5ST_GSTfT_1210 resultItem = new L5ST_GSTfT_1210();
					//0:Parameter LOG_SHP_Shipment_TypeID of type Guid
					resultItem.LOG_SHP_Shipment_TypeID = reader.GetGuid(0);
					//1:Parameter ShipmentType_Name of type Dict
					resultItem.ShipmentType_Name = reader.GetDictionary(1);
					resultItem.ShipmentType_Name.SourceTable = "log_shp_shipment_types";
					loader.Append(resultItem.ShipmentType_Name);
					//2:Parameter ShipmentType_Descriptio of type Dict
					resultItem.ShipmentType_Descriptio = reader.GetDictionary(2);
					resultItem.ShipmentType_Descriptio.SourceTable = "log_shp_shipment_types";
					loader.Append(resultItem.ShipmentType_Descriptio);
					//3:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(3);
					//4:Parameter IfFixedPricePerShipment_Price_RefID of type Guid
					resultItem.IfFixedPricePerShipment_Price_RefID = reader.GetGuid(4);
					//5:Parameter IsFixedPricePerShipment of type bool
					resultItem.IsFixedPricePerShipment = reader.GetBoolean(5);
					//6:Parameter IsPartialPickingPermitted of type bool
					resultItem.IsPartialPickingPermitted = reader.GetBoolean(6);
					//7:Parameter IsCustomerPickup of type bool
					resultItem.IsCustomerPickup = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShipmentTypes_for_TenandID",ex);
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
		public static FR_L5ST_GSTfT_1210_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTfT_1210_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ST_GSTfT_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ST_GSTfT_1210_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ST_GSTfT_1210_Array functionReturn = new FR_L5ST_GSTfT_1210_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_ShipmentTypes_for_TenandID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5ST_GSTfT_1210_Array : FR_Base
	{
		public L5ST_GSTfT_1210[] Result	{ get; set; } 
		public FR_L5ST_GSTfT_1210_Array() : base() {}

		public FR_L5ST_GSTfT_1210_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ST_GSTfT_1210 for attribute L5ST_GSTfT_1210
		[DataContract]
		public class L5ST_GSTfT_1210 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_TypeID { get; set; } 
			[DataMember]
			public Dict ShipmentType_Name { get; set; } 
			[DataMember]
			public Dict ShipmentType_Descriptio { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid IfFixedPricePerShipment_Price_RefID { get; set; } 
			[DataMember]
			public bool IsFixedPricePerShipment { get; set; } 
			[DataMember]
			public bool IsPartialPickingPermitted { get; set; } 
			[DataMember]
			public bool IsCustomerPickup { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ST_GSTfT_1210_Array cls_Get_ShipmentTypes_for_TenandID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ST_GSTfT_1210_Array invocationResult = cls_Get_ShipmentTypes_for_TenandID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

