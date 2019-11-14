/* 
 * Generated on 10/14/2013 12:18:40 PM
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

namespace CL2_ApplicationSettings.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Application_Settings_ForUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Application_Settings_ForUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2USR_GASFU_1224_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2USR_GASFU_1224_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_ApplicationSettings.Atomic.Retrieval.SQL.cls_Get_Application_Settings_ForUser.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2USR_GASFU_1224> results = new List<L2USR_GASFU_1224>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ItemKey","USR_Account_ApplicationSetting_DefinitionID","ItemValue","USR_Account_ApplicationSettingID" });
				while(reader.Read())
				{
					L2USR_GASFU_1224 resultItem = new L2USR_GASFU_1224();
					//0:Parameter ItemKey of type String
					resultItem.ItemKey = reader.GetString(0);
					//1:Parameter USR_Account_ApplicationSetting_DefinitionID of type Guid
					resultItem.USR_Account_ApplicationSetting_DefinitionID = reader.GetGuid(1);
					//2:Parameter ItemValue of type String
					resultItem.ItemValue = reader.GetString(2);
					//3:Parameter USR_Account_ApplicationSettingID of type Guid
					resultItem.USR_Account_ApplicationSettingID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Application_Settings_ForUser",ex);
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
		public static FR_L2USR_GASFU_1224_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2USR_GASFU_1224_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2USR_GASFU_1224_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2USR_GASFU_1224_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2USR_GASFU_1224_Array functionReturn = new FR_L2USR_GASFU_1224_Array();
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

				throw new Exception("Exception occured in method cls_Get_Application_Settings_ForUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2USR_GASFU_1224_Array : FR_Base
	{
		public L2USR_GASFU_1224[] Result	{ get; set; } 
		public FR_L2USR_GASFU_1224_Array() : base() {}

		public FR_L2USR_GASFU_1224_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2USR_GASFU_1224 for attribute L2USR_GASFU_1224
		[DataContract]
		public class L2USR_GASFU_1224 
		{
			//Standard type parameters
			[DataMember]
			public String ItemKey { get; set; } 
			[DataMember]
			public Guid USR_Account_ApplicationSetting_DefinitionID { get; set; } 
			[DataMember]
			public String ItemValue { get; set; } 
			[DataMember]
			public Guid USR_Account_ApplicationSettingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2USR_GASFU_1224_Array cls_Get_Application_Settings_ForUser(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2USR_GASFU_1224_Array invocationResult = cls_Get_Application_Settings_ForUser.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
