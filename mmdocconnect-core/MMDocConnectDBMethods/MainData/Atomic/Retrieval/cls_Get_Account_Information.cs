/* 
 * Generated on 02/03/17 11:43:28
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Account_Information.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Account_Information
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GAI_1617 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GAI_1617();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Account_Information.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<MD_GAI_1617> results = new List<MD_GAI_1617>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Username","name","role","group_id","email","AccountType","USR_AccountID","Title","CMN_BPT_BusinessParticipantID" });
				while(reader.Read())
				{
					MD_GAI_1617 resultItem = new MD_GAI_1617();
					//0:Parameter Username of type String
					resultItem.Username = reader.GetString(0);
					//1:Parameter name of type String
					resultItem.name = reader.GetString(1);
					//2:Parameter role of type String
					resultItem.role = reader.GetString(2);
					//3:Parameter group_id of type String
					resultItem.group_id = reader.GetString(3);
					//4:Parameter email of type String
					resultItem.email = reader.GetString(4);
					//5:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(5);
					//6:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(6);
					//7:Parameter Title of type String
					resultItem.Title = reader.GetString(7);
					//8:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Account_Information",ex);
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
		public static FR_MD_GAI_1617 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GAI_1617 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GAI_1617 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GAI_1617 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GAI_1617 functionReturn = new FR_MD_GAI_1617();
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

				throw new Exception("Exception occured in method cls_Get_Account_Information",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GAI_1617 : FR_Base
	{
		public MD_GAI_1617 Result	{ get; set; }

		public FR_MD_GAI_1617() : base() {}

		public FR_MD_GAI_1617(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass MD_GAI_1617 for attribute MD_GAI_1617
		[DataContract]
		public class MD_GAI_1617 
		{
			//Standard type parameters
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public String name { get; set; } 
			[DataMember]
			public String role { get; set; } 
			[DataMember]
			public String group_id { get; set; } 
			[DataMember]
			public String email { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GAI_1617 cls_Get_Account_Information(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GAI_1617 invocationResult = cls_Get_Account_Information.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

