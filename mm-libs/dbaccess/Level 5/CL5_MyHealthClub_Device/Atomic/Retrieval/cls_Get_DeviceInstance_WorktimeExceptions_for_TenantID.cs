/* 
 * Generated on 9/11/2014 3:11:56 PM
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

namespace CL5_MyHealthClub_Device.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DE_GDIWEfTID_1234_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DE_GDIWEfTID_1234_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Device.Atomic.Retrieval.SQL.cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5DE_GDIWEfTID_1234> results = new List<L5DE_GDIWEfTID_1234>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeviceDisplayName","DeviceInventoryNumber","Description","IsRepetitive","IsWholeDayEvent","StartTime","EndTime","IsDaily","IsWeekly","IsMonthly","IsYearly","Office_Name_DictID" });
				while(reader.Read())
				{
					L5DE_GDIWEfTID_1234 resultItem = new L5DE_GDIWEfTID_1234();
					//0:Parameter DeviceDisplayName of type String
					resultItem.DeviceDisplayName = reader.GetString(0);
					//1:Parameter DeviceInventoryNumber of type String
					resultItem.DeviceInventoryNumber = reader.GetString(1);
					//2:Parameter Description of type String
					resultItem.Description = reader.GetString(2);
					//3:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(3);
					//4:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(4);
					//5:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(5);
					//6:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(6);
					//7:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(7);
					//8:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(8);
					//9:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(9);
					//10:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(10);
					//11:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(11);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID",ex);
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
		public static FR_L5DE_GDIWEfTID_1234_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DE_GDIWEfTID_1234_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DE_GDIWEfTID_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DE_GDIWEfTID_1234_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DE_GDIWEfTID_1234_Array functionReturn = new FR_L5DE_GDIWEfTID_1234_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DE_GDIWEfTID_1234_Array : FR_Base
	{
		public L5DE_GDIWEfTID_1234[] Result	{ get; set; } 
		public FR_L5DE_GDIWEfTID_1234_Array() : base() {}

		public FR_L5DE_GDIWEfTID_1234_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DE_GDIWEfTID_1234 for attribute L5DE_GDIWEfTID_1234
		[DataContract]
		public class L5DE_GDIWEfTID_1234 
		{
			//Standard type parameters
			[DataMember]
			public String DeviceDisplayName { get; set; } 
			[DataMember]
			public String DeviceInventoryNumber { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DE_GDIWEfTID_1234_Array cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DE_GDIWEfTID_1234_Array invocationResult = cls_Get_DeviceInstance_WorktimeExceptions_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

