/* 
 * Generated on 1/20/2017 2:34:30 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_AccountID_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_AccountID_for_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GPAIDfPID_1522 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GPAIDfPID_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GPAIDfPID_1522();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_Practice_AccountID_for_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<DO_GPAIDfPID_1522> results = new List<DO_GPAIDfPID_1522>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "accountID","accountMail","DisplayName" });
				while(reader.Read())
				{
					DO_GPAIDfPID_1522 resultItem = new DO_GPAIDfPID_1522();
					//0:Parameter accountID of type Guid
					resultItem.accountID = reader.GetGuid(0);
					//1:Parameter accountMail of type String
					resultItem.accountMail = reader.GetString(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_AccountID_for_PracticeID",ex);
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
		public static FR_DO_GPAIDfPID_1522 Invoke(string ConnectionString,P_DO_GPAIDfPID_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GPAIDfPID_1522 Invoke(DbConnection Connection,P_DO_GPAIDfPID_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GPAIDfPID_1522 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GPAIDfPID_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GPAIDfPID_1522 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GPAIDfPID_1522 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GPAIDfPID_1522 functionReturn = new FR_DO_GPAIDfPID_1522();
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

				throw new Exception("Exception occured in method cls_Get_Practice_AccountID_for_PracticeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GPAIDfPID_1522 : FR_Base
	{
		public DO_GPAIDfPID_1522 Result	{ get; set; }

		public FR_DO_GPAIDfPID_1522() : base() {}

		public FR_DO_GPAIDfPID_1522(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GPAIDfPID_1522 for attribute P_DO_GPAIDfPID_1522
		[DataContract]
		public class P_DO_GPAIDfPID_1522 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass DO_GPAIDfPID_1522 for attribute DO_GPAIDfPID_1522
		[DataContract]
		public class DO_GPAIDfPID_1522 
		{
			//Standard type parameters
			[DataMember]
			public Guid accountID { get; set; } 
			[DataMember]
			public String accountMail { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GPAIDfPID_1522 cls_Get_Practice_AccountID_for_PracticeID(,P_DO_GPAIDfPID_1522 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GPAIDfPID_1522 invocationResult = cls_Get_Practice_AccountID_for_PracticeID.Invoke(connectionString,P_DO_GPAIDfPID_1522 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_DO_GPAIDfPID_1522();
parameter.PracticeID = ...;

*/
