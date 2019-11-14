/* 
 * Generated on 10/28/2013 10:09:23 AM
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

namespace CL2_Notification.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Notifications.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Notifications
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NT_GAN_1320_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2NT_GAN_1320_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Notification.Atomic.Retrieval.SQL.cls_Get_All_Notifications.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2NT_GAN_1320> results = new List<L2NT_GAN_1320>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_NOT_NotificationID","R_NotificationKey","Notification_Link","Notification_Text","NotificationSubscription_RefID" });
				while(reader.Read())
				{
					L2NT_GAN_1320 resultItem = new L2NT_GAN_1320();
					//0:Parameter USR_NOT_NotificationID of type Guid
					resultItem.USR_NOT_NotificationID = reader.GetGuid(0);
					//1:Parameter R_NotificationKey of type String
					resultItem.R_NotificationKey = reader.GetString(1);
					//2:Parameter Notification_Link of type String
					resultItem.Notification_Link = reader.GetString(2);
					//3:Parameter Notification_Text of type String
					resultItem.Notification_Text = reader.GetString(3);
					//4:Parameter NotificationSubscription_RefID of type Guid
					resultItem.NotificationSubscription_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Notifications",ex);
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
		public static FR_L2NT_GAN_1320_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NT_GAN_1320_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NT_GAN_1320_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NT_GAN_1320_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NT_GAN_1320_Array functionReturn = new FR_L2NT_GAN_1320_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Notifications",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NT_GAN_1320_Array : FR_Base
	{
		public L2NT_GAN_1320[] Result	{ get; set; } 
		public FR_L2NT_GAN_1320_Array() : base() {}

		public FR_L2NT_GAN_1320_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2NT_GAN_1320 for attribute L2NT_GAN_1320
		[DataContract]
		public class L2NT_GAN_1320 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_NOT_NotificationID { get; set; } 
			[DataMember]
			public String R_NotificationKey { get; set; } 
			[DataMember]
			public String Notification_Link { get; set; } 
			[DataMember]
			public String Notification_Text { get; set; } 
			[DataMember]
			public Guid NotificationSubscription_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NT_GAN_1320_Array cls_Get_All_Notifications(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NT_GAN_1320_Array invocationResult = cls_Get_All_Notifications.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

