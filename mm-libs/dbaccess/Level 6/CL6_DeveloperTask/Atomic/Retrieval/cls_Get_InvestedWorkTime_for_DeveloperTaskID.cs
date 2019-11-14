/* 
 * Generated on 7/24/2014 12:51:49 PM
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

namespace CL6_DanuTask_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// Get invested work time for Developer task ID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_InvestedWorkTime_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_InvestedWorkTime_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GIWTfDT_1649_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GIWTfDT_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GIWTfDT_1649_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
            var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_InvestedWorkTime_for_DeveloperTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeveloperTaskID", Parameter.DeveloperTaskID);



			List<L6DT_GIWTfDT_1649> results = new List<L6DT_GIWTfDT_1649>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_AccountID","InvestedWorkTime" });
				while(reader.Read())
				{
					L6DT_GIWTfDT_1649 resultItem = new L6DT_GIWTfDT_1649();
					//0:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(0);
					//1:Parameter InvestedWorkTime of type long
					resultItem.InvestedWorkTime = reader.GetLong(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_InvestedWorkTime_for_DeveloperTaskID",ex);
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
		public static FR_L6DT_GIWTfDT_1649_Array Invoke(string ConnectionString,P_L6DT_GIWTfDT_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GIWTfDT_1649_Array Invoke(DbConnection Connection,P_L6DT_GIWTfDT_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GIWTfDT_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GIWTfDT_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GIWTfDT_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GIWTfDT_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GIWTfDT_1649_Array functionReturn = new FR_L6DT_GIWTfDT_1649_Array();
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

				throw new Exception("Exception occured in method cls_Get_InvestedWorkTime_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GIWTfDT_1649_Array : FR_Base
	{
		public L6DT_GIWTfDT_1649[] Result	{ get; set; } 
		public FR_L6DT_GIWTfDT_1649_Array() : base() {}

		public FR_L6DT_GIWTfDT_1649_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GIWTfDT_1649 for attribute P_L6DT_GIWTfDT_1649
		[DataContract]
		public class P_L6DT_GIWTfDT_1649 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GIWTfDT_1649 for attribute L6DT_GIWTfDT_1649
		[DataContract]
		public class L6DT_GIWTfDT_1649 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public long InvestedWorkTime { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GIWTfDT_1649_Array cls_Get_InvestedWorkTime_for_DeveloperTaskID(,P_L6DT_GIWTfDT_1649 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GIWTfDT_1649_Array invocationResult = cls_Get_InvestedWorkTime_for_DeveloperTaskID.Invoke(connectionString,P_L6DT_GIWTfDT_1649 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Atomic.Retrieval.P_L6DT_GIWTfDT_1649();
parameter.DeveloperTaskID = ...;

*/
