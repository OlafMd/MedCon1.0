/* 
 * Generated on 3/20/2015 9:05:16 AM
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeviceActivityHistory_for_DeviceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeviceActivityHistory_for_DeviceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDAHfDID_0919_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDAHfDID_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDAHfDID_0919_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.SQL.cls_Get_DeviceActivityHistory_for_DeviceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceID", Parameter.DeviceID);



			List<L5DO_GDAHfDID_0919> results = new List<L5DO_GDAHfDID_0919>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeviceName","Username","ActivityComment","Device_RefID","USR_Device_ActivityHistoryID","DeviceVendor","Creation_Timestamp","AccountComment" });
				while(reader.Read())
				{
					L5DO_GDAHfDID_0919 resultItem = new L5DO_GDAHfDID_0919();
					//0:Parameter DeviceName of type String
					resultItem.DeviceName = reader.GetString(0);
					//1:Parameter Username of type String
					resultItem.Username = reader.GetString(1);
					//2:Parameter ActivityComment of type String
					resultItem.ActivityComment = reader.GetString(2);
					//3:Parameter Device_RefID of type Guid
					resultItem.Device_RefID = reader.GetGuid(3);
					//4:Parameter USR_Device_ActivityHistoryID of type Guid
					resultItem.USR_Device_ActivityHistoryID = reader.GetGuid(4);
					//5:Parameter DeviceVendor of type String
					resultItem.DeviceVendor = reader.GetString(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter AccountComment of type String
					resultItem.AccountComment = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeviceActivityHistory_for_DeviceID",ex);
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
		public static FR_L5DO_GDAHfDID_0919_Array Invoke(string ConnectionString,P_L5DO_GDAHfDID_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDAHfDID_0919_Array Invoke(DbConnection Connection,P_L5DO_GDAHfDID_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDAHfDID_0919_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDAHfDID_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDAHfDID_0919_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDAHfDID_0919 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDAHfDID_0919_Array functionReturn = new FR_L5DO_GDAHfDID_0919_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeviceActivityHistory_for_DeviceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDAHfDID_0919_Array : FR_Base
	{
		public L5DO_GDAHfDID_0919[] Result	{ get; set; } 
		public FR_L5DO_GDAHfDID_0919_Array() : base() {}

		public FR_L5DO_GDAHfDID_0919_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDAHfDID_0919 for attribute P_L5DO_GDAHfDID_0919
		[DataContract]
		public class P_L5DO_GDAHfDID_0919 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDAHfDID_0919 for attribute L5DO_GDAHfDID_0919
		[DataContract]
		public class L5DO_GDAHfDID_0919 
		{
			//Standard type parameters
			[DataMember]
			public String DeviceName { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public String ActivityComment { get; set; } 
			[DataMember]
			public Guid Device_RefID { get; set; } 
			[DataMember]
			public Guid USR_Device_ActivityHistoryID { get; set; } 
			[DataMember]
			public String DeviceVendor { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String AccountComment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDAHfDID_0919_Array cls_Get_DeviceActivityHistory_for_DeviceID(,P_L5DO_GDAHfDID_0919 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDAHfDID_0919_Array invocationResult = cls_Get_DeviceActivityHistory_for_DeviceID.Invoke(connectionString,P_L5DO_GDAHfDID_0919 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.P_L5DO_GDAHfDID_0919();
parameter.DeviceID = ...;

*/
