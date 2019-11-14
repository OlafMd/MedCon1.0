/* 
 * Generated on 29.05.2014 13:37:16
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

namespace CL3_Device.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Devices_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Devices_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DE_GADfTID_1101_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DE_GADfTID_1101_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Device.Atomic.Retrieval.SQL.cls_Get_Devices_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3DE_GADfTID_1101> results = new List<L3DE_GADfTID_1101>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_DEV_Device_InstanceID","PPS_DEV_DeviceID","PPS_DEV_Device_Instance_OfficeLocationID","DeviceDisplayName","DeviceInventoryNumber","Office_Name_DictID" });
				while(reader.Read())
				{
					L3DE_GADfTID_1101 resultItem = new L3DE_GADfTID_1101();
					//0:Parameter PPS_DEV_Device_InstanceID of type Guid
					resultItem.PPS_DEV_Device_InstanceID = reader.GetGuid(0);
					//1:Parameter PPS_DEV_DeviceID of type Guid
					resultItem.PPS_DEV_DeviceID = reader.GetGuid(1);
					//2:Parameter PPS_DEV_Device_Instance_OfficeLocationID of type Guid
					resultItem.PPS_DEV_Device_Instance_OfficeLocationID = reader.GetGuid(2);
					//3:Parameter DeviceDisplayName of type string
					resultItem.DeviceDisplayName = reader.GetString(3);
					//4:Parameter DeviceInventoryNumber of type string
					resultItem.DeviceInventoryNumber = reader.GetString(4);
					//5:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(5);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Devices_for_TenantID",ex);
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
		public static FR_L3DE_GADfTID_1101_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DE_GADfTID_1101_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DE_GADfTID_1101_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DE_GADfTID_1101_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DE_GADfTID_1101_Array functionReturn = new FR_L3DE_GADfTID_1101_Array();
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

				throw new Exception("Exception occured in method cls_Get_Devices_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DE_GADfTID_1101_Array : FR_Base
	{
		public L3DE_GADfTID_1101[] Result	{ get; set; } 
		public FR_L3DE_GADfTID_1101_Array() : base() {}

		public FR_L3DE_GADfTID_1101_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3DE_GADfTID_1101 for attribute L3DE_GADfTID_1101
		[DataContract]
		public class L3DE_GADfTID_1101 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_DEV_Device_InstanceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_DeviceID { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_Instance_OfficeLocationID { get; set; } 
			[DataMember]
			public string DeviceDisplayName { get; set; } 
			[DataMember]
			public string DeviceInventoryNumber { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DE_GADfTID_1101_Array cls_Get_Devices_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DE_GADfTID_1101_Array invocationResult = cls_Get_Devices_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

