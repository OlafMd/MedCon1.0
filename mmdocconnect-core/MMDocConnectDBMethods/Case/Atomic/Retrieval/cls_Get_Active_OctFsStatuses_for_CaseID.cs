/* 
 * Generated on 10/07/16 15:15:44
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Active_OctFsStatuses_for_CaseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Active_OctFsStatuses_for_CaseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GAFNEOctFsSIDfCID_1344_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GAFNEOctFsSIDfCID_1344_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Active_OctFsStatuses_for_CaseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CaseID", Parameter.CaseID);



			List<CAS_GAFNEOctFsSIDfCID_1344> results = new List<CAS_GAFNEOctFsSIDfCID_1344>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "fs_status_code" });
				while(reader.Read())
				{
					CAS_GAFNEOctFsSIDfCID_1344 resultItem = new CAS_GAFNEOctFsSIDfCID_1344();
					//0:Parameter fs_status_code of type int
					resultItem.fs_status_code = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Active_OctFsStatuses_for_CaseID",ex);
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
		public static FR_CAS_GAFNEOctFsSIDfCID_1344_Array Invoke(string ConnectionString,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GAFNEOctFsSIDfCID_1344_Array Invoke(DbConnection Connection,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GAFNEOctFsSIDfCID_1344_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GAFNEOctFsSIDfCID_1344_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GAFNEOctFsSIDfCID_1344_Array functionReturn = new FR_CAS_GAFNEOctFsSIDfCID_1344_Array();
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

				throw new Exception("Exception occured in method cls_Get_Active_OctFsStatuses_for_CaseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GAFNEOctFsSIDfCID_1344_Array : FR_Base
	{
		public CAS_GAFNEOctFsSIDfCID_1344[] Result	{ get; set; } 
		public FR_CAS_GAFNEOctFsSIDfCID_1344_Array() : base() {}

		public FR_CAS_GAFNEOctFsSIDfCID_1344_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GAFNEOctFsSIDfCID_1344 for attribute P_CAS_GAFNEOctFsSIDfCID_1344
		[DataContract]
		public class P_CAS_GAFNEOctFsSIDfCID_1344 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GAFNEOctFsSIDfCID_1344 for attribute CAS_GAFNEOctFsSIDfCID_1344
		[DataContract]
		public class CAS_GAFNEOctFsSIDfCID_1344 
		{
			//Standard type parameters
			[DataMember]
			public int fs_status_code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GAFNEOctFsSIDfCID_1344_Array cls_Get_Active_OctFsStatuses_for_CaseID(,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GAFNEOctFsSIDfCID_1344_Array invocationResult = cls_Get_Active_OctFsStatuses_for_CaseID.Invoke(connectionString,P_CAS_GAFNEOctFsSIDfCID_1344 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GAFNEOctFsSIDfCID_1344();
parameter.CaseID = ...;

*/
