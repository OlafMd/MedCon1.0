/* 
 * Generated on 29.10.2018 14:36:30
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
    /// var result = cls_Get_RelevantActionData_for_ActionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RelevantActionData_for_ActionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GRADfAIDs_1217_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GRADfAIDs_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GRADfAIDs_1217_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_RelevantActionData_for_ActionIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ActionIDs"," IN $$ActionIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ActionIDs$",Parameter.ActionIDs);


			List<CAS_GRADfAIDs_1217> results = new List<CAS_GRADfAIDs_1217>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CaseID","ActionID","PerformingBptID","PerformedOnDate","PerformedActionCreationTime","PerformedActionTypeID" });
				while(reader.Read())
				{
					CAS_GRADfAIDs_1217 resultItem = new CAS_GRADfAIDs_1217();
					//0:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(0);
					//1:Parameter ActionID of type Guid
					resultItem.ActionID = reader.GetGuid(1);
					//2:Parameter PerformingBptID of type Guid
					resultItem.PerformingBptID = reader.GetGuid(2);
					//3:Parameter PerformedOnDate of type DateTime
					resultItem.PerformedOnDate = reader.GetDate(3);
					//4:Parameter PerformedActionCreationTime of type DateTime
					resultItem.PerformedActionCreationTime = reader.GetDate(4);
					//5:Parameter PerformedActionTypeID of type Guid
					resultItem.PerformedActionTypeID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RelevantActionData_for_ActionIDs",ex);
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
		public static FR_CAS_GRADfAIDs_1217_Array Invoke(string ConnectionString,P_CAS_GRADfAIDs_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GRADfAIDs_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GRADfAIDs_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GRADfAIDs_1217_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GRADfAIDs_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GRADfAIDs_1217_Array functionReturn = new FR_CAS_GRADfAIDs_1217_Array();
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

				throw new Exception("Exception occured in method cls_Get_RelevantActionData_for_ActionIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GRADfAIDs_1217_Array : FR_Base
	{
		public CAS_GRADfAIDs_1217[] Result	{ get; set; } 
		public FR_CAS_GRADfAIDs_1217_Array() : base() {}

		public FR_CAS_GRADfAIDs_1217_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GRADfAIDs_1217 for attribute P_CAS_GRADfAIDs_1217
		[DataContract]
		public class P_CAS_GRADfAIDs_1217 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ActionIDs { get; set; } 

		}
		#endregion
		#region SClass CAS_GRADfAIDs_1217 for attribute CAS_GRADfAIDs_1217
		[DataContract]
		public class CAS_GRADfAIDs_1217 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid ActionID { get; set; } 
			[DataMember]
			public Guid PerformingBptID { get; set; } 
			[DataMember]
			public DateTime PerformedOnDate { get; set; } 
			[DataMember]
			public DateTime PerformedActionCreationTime { get; set; } 
			[DataMember]
			public Guid PerformedActionTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GRADfAIDs_1217_Array cls_Get_RelevantActionData_for_ActionIDs(,P_CAS_GRADfAIDs_1217 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GRADfAIDs_1217_Array invocationResult = cls_Get_RelevantActionData_for_ActionIDs.Invoke(connectionString,P_CAS_GRADfAIDs_1217 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GRADfAIDs_1217();
parameter.ActionIDs = ...;

*/
