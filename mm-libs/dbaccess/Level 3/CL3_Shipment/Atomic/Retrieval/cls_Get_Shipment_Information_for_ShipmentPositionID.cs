/* 
 * Generated on 3/3/2015 2:18:36 PM
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

namespace CL3_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// Get_Shipment_Information_for_ShipmentPositionID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipment_Information_for_ShipmentPositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipment_Information_for_ShipmentPositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3S_GSIfSP_1437 Execute(DbConnection Connection,DbTransaction Transaction,P_L3S_GSIfSP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3S_GSIfSP_1437();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Shipment.Atomic.Retrieval.SQL.cls_Get_Shipment_Information_for_ShipmentPositionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentPositionID", Parameter.ShipmentPositionID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);



			List<L3S_GSIfSP_1437> results = new List<L3S_GSIfSP_1437>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","LOG_SHP_Shipment_PositionID","ShipmentHeader_Number","ShipmentType","Warehouse_Name","Shipping_Address" });
				while(reader.Read())
				{
					L3S_GSIfSP_1437 resultItem = new L3S_GSIfSP_1437();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);
					//2:Parameter ShipmentHeader_Number of type string
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter ShipmentType of type string
					resultItem.ShipmentType = reader.GetString(3);
					//4:Parameter Warehouse_Name of type string
					resultItem.Warehouse_Name = reader.GetString(4);
					//5:Parameter Shipping_Address of type string
					resultItem.Shipping_Address = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipment_Information_for_ShipmentPositionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3S_GSIfSP_1437 Invoke(string ConnectionString,P_L3S_GSIfSP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3S_GSIfSP_1437 Invoke(DbConnection Connection,P_L3S_GSIfSP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3S_GSIfSP_1437 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3S_GSIfSP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3S_GSIfSP_1437 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3S_GSIfSP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3S_GSIfSP_1437 functionReturn = new FR_L3S_GSIfSP_1437();
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

				throw new Exception("Exception occured in method cls_Get_Shipment_Information_for_ShipmentPositionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3S_GSIfSP_1437 : FR_Base
	{
		public L3S_GSIfSP_1437 Result	{ get; set; }

		public FR_L3S_GSIfSP_1437() : base() {}

		public FR_L3S_GSIfSP_1437(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3S_GSIfSP_1437 for attribute P_L3S_GSIfSP_1437
		[DataContract]
		public class P_L3S_GSIfSP_1437 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentPositionID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L3S_GSIfSP_1437 for attribute L3S_GSIfSP_1437
		[DataContract]
		public class L3S_GSIfSP_1437 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public string ShipmentHeader_Number { get; set; } 
			[DataMember]
			public string ShipmentType { get; set; } 
			[DataMember]
			public string Warehouse_Name { get; set; } 
			[DataMember]
			public string Shipping_Address { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3S_GSIfSP_1437 cls_Get_Shipment_Information_for_ShipmentPositionID(,P_L3S_GSIfSP_1437 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3S_GSIfSP_1437 invocationResult = cls_Get_Shipment_Information_for_ShipmentPositionID.Invoke(connectionString,P_L3S_GSIfSP_1437 Parameter,securityTicket);
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
var parameter = new CL3_Shipment.Atomic.Retrieval.P_L3S_GSIfSP_1437();
parameter.ShipmentPositionID = ...;
parameter.LanguageID = ...;

*/
