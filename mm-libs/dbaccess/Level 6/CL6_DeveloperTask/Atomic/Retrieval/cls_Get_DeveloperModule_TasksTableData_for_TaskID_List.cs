/* 
 * Generated on 10/2/2014 10:42:13 AM
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
    /// Get all tasks table data for danutask V2 dashboard
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperModule_TasksTableData_for_TaskID_List.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperModule_TasksTableData_for_TaskID_List
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDMTTDfTL_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDMTTDfTL_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDMTTDfTL_1449_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperModule_TasksTableData_for_TaskID_List.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TaskIDList"," IN $$TaskIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TaskIDList$",Parameter.TaskIDList);


			List<L6DT_GDMTTDfTL_1449> results = new List<L6DT_GDMTTDfTL_1449>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Task_ID","Task_Identification","Task_Name","Task_Involvement","Name_DictID","Task_Deadline","Task_PercentageComplete","Task_PriorityColor","Task_CompletionStamp","Task_CreationStamp","FirstName","LastName","Task_Description","IsComplete","IsIncompleteInformation","IsArchived","IsActive" });
				while(reader.Read())
				{
					L6DT_GDMTTDfTL_1449 resultItem = new L6DT_GDMTTDfTL_1449();
					//0:Parameter Task_ID of type Guid
					resultItem.Task_ID = reader.GetGuid(0);
					//1:Parameter Task_Identification of type String
					resultItem.Task_Identification = reader.GetString(1);
					//2:Parameter Task_Name of type String
					resultItem.Task_Name = reader.GetString(2);
					//3:Parameter Task_Involvement of type Guid
					resultItem.Task_Involvement = reader.GetGuid(3);
					//4:Parameter Name_DictID of type Dict
					resultItem.Name_DictID = reader.GetDictionary(4);
					resultItem.Name_DictID.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Name_DictID);
					//5:Parameter Task_Deadline of type DateTime
					resultItem.Task_Deadline = reader.GetDate(5);
					//6:Parameter Task_PercentageComplete of type Double
					resultItem.Task_PercentageComplete = reader.GetDouble(6);
					//7:Parameter Task_PriorityColor of type String
					resultItem.Task_PriorityColor = reader.GetString(7);
					//8:Parameter Task_CompletionStamp of type DateTime
					resultItem.Task_CompletionStamp = reader.GetDate(8);
					//9:Parameter Task_CreationStamp of type DateTime
					resultItem.Task_CreationStamp = reader.GetDate(9);
					//10:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(10);
					//11:Parameter LastName of type String
					resultItem.LastName = reader.GetString(11);
					//12:Parameter Task_Description of type String
					resultItem.Task_Description = reader.GetString(12);
					//13:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(13);
					//14:Parameter IsIncompleteInformation of type bool
					resultItem.IsIncompleteInformation = reader.GetBoolean(14);
					//15:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(15);
					//16:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperModule_TasksTableData_for_TaskID_List",ex);
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
		public static FR_L6DT_GDMTTDfTL_1449_Array Invoke(string ConnectionString,P_L6DT_GDMTTDfTL_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMTTDfTL_1449_Array Invoke(DbConnection Connection,P_L6DT_GDMTTDfTL_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMTTDfTL_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDMTTDfTL_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDMTTDfTL_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDMTTDfTL_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDMTTDfTL_1449_Array functionReturn = new FR_L6DT_GDMTTDfTL_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperModule_TasksTableData_for_TaskID_List",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDMTTDfTL_1449_Array : FR_Base
	{
		public L6DT_GDMTTDfTL_1449[] Result	{ get; set; } 
		public FR_L6DT_GDMTTDfTL_1449_Array() : base() {}

		public FR_L6DT_GDMTTDfTL_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDMTTDfTL_1449 for attribute P_L6DT_GDMTTDfTL_1449
		[DataContract]
		public class P_L6DT_GDMTTDfTL_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TaskIDList { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDMTTDfTL_1449 for attribute L6DT_GDMTTDfTL_1449
		[DataContract]
		public class L6DT_GDMTTDfTL_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid Task_ID { get; set; } 
			[DataMember]
			public String Task_Identification { get; set; } 
			[DataMember]
			public String Task_Name { get; set; } 
			[DataMember]
			public Guid Task_Involvement { get; set; } 
			[DataMember]
			public Dict Name_DictID { get; set; } 
			[DataMember]
			public DateTime Task_Deadline { get; set; } 
			[DataMember]
			public Double Task_PercentageComplete { get; set; } 
			[DataMember]
			public String Task_PriorityColor { get; set; } 
			[DataMember]
			public DateTime Task_CompletionStamp { get; set; } 
			[DataMember]
			public DateTime Task_CreationStamp { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Task_Description { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 
			[DataMember]
			public bool IsIncompleteInformation { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDMTTDfTL_1449_Array cls_Get_DeveloperModule_TasksTableData_for_TaskID_List(,P_L6DT_GDMTTDfTL_1449 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDMTTDfTL_1449_Array invocationResult = cls_Get_DeveloperModule_TasksTableData_for_TaskID_List.Invoke(connectionString,P_L6DT_GDMTTDfTL_1449 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDMTTDfTL_1449();
parameter.TaskIDList = ...;

*/
