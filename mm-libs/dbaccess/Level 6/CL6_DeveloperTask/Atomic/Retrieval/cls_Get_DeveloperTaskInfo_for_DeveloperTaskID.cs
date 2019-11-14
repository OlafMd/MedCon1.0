/* 
 * Generated on 10/3/2014 2:07:43 PM
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
    /// Get developer task informations for selected developer task
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTaskInfo_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskInfo_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTIfDT_1505 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTIfDT_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDTIfDT_1505();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskInfo_for_DeveloperTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskID", Parameter.TaskID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBeingPrepared_Only", Parameter.IsBeingPrepared_Only);



			List<L6DT_GDTIfDT_1505> results = new List<L6DT_GDTIfDT_1505>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Task_ID","Task_Identification","Task_Name","Task_Deadline","Task_PercentageComplete","Task_CompletionStamp","Task_CreationStamp","Task_CurrentInvestment","Task_RequiredEstimation","Label_DictID","CreatedByFirstName","CreatedByLastName","Task_Description","Task_Involvement","IsActive","DeveloperInvested","Developer_CompletionEstimation","Assignment_Timestamp","IsIncompleteInformation","IsComplete" });
				while(reader.Read())
				{
					L6DT_GDTIfDT_1505 resultItem = new L6DT_GDTIfDT_1505();
					//0:Parameter Task_ID of type Guid
					resultItem.Task_ID = reader.GetGuid(0);
					//1:Parameter Task_Identification of type String
					resultItem.Task_Identification = reader.GetString(1);
					//2:Parameter Task_Name of type String
					resultItem.Task_Name = reader.GetString(2);
					//3:Parameter Task_Deadline of type DateTime
					resultItem.Task_Deadline = reader.GetDate(3);
					//4:Parameter Task_PercentageComplete of type Double
					resultItem.Task_PercentageComplete = reader.GetDouble(4);
					//5:Parameter Task_CompletionStamp of type DateTime
					resultItem.Task_CompletionStamp = reader.GetDate(5);
					//6:Parameter Task_CreationStamp of type DateTime
					resultItem.Task_CreationStamp = reader.GetDate(6);
					//7:Parameter Task_CurrentInvestment of type long
					resultItem.Task_CurrentInvestment = reader.GetLong(7);
					//8:Parameter Task_RequiredEstimation of type long
					resultItem.Task_RequiredEstimation = reader.GetLong(8);
					//9:Parameter Priority_Label of type Dict
					resultItem.Priority_Label = reader.GetDictionary(9);
					resultItem.Priority_Label.SourceTable = "tms_pro_developertask_priorities";
					loader.Append(resultItem.Priority_Label);
					//10:Parameter CreatedByFirstName of type String
					resultItem.CreatedByFirstName = reader.GetString(10);
					//11:Parameter CreatedByLastName of type String
					resultItem.CreatedByLastName = reader.GetString(11);
					//12:Parameter Task_Description of type String
					resultItem.Task_Description = reader.GetString(12);
					//13:Parameter Task_Involvement of type Guid
					resultItem.Task_Involvement = reader.GetGuid(13);
					//14:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(14);
					//15:Parameter DeveloperInvested of type long
					resultItem.DeveloperInvested = reader.GetLong(15);
					//16:Parameter Developer_CompletionEstimation of type long
					resultItem.Developer_CompletionEstimation = reader.GetLong(16);
					//17:Parameter Assignment_Timestamp of type DateTime
					resultItem.Assignment_Timestamp = reader.GetDate(17);
					//18:Parameter IsIncompleteInformation of type bool
					resultItem.IsIncompleteInformation = reader.GetBoolean(18);
					//19:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(19);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskInfo_for_DeveloperTaskID",ex);
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
		public static FR_L6DT_GDTIfDT_1505 Invoke(string ConnectionString,P_L6DT_GDTIfDT_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIfDT_1505 Invoke(DbConnection Connection,P_L6DT_GDTIfDT_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIfDT_1505 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTIfDT_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTIfDT_1505 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTIfDT_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTIfDT_1505 functionReturn = new FR_L6DT_GDTIfDT_1505();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskInfo_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTIfDT_1505 : FR_Base
	{
		public L6DT_GDTIfDT_1505 Result	{ get; set; }

		public FR_L6DT_GDTIfDT_1505() : base() {}

		public FR_L6DT_GDTIfDT_1505(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTIfDT_1505 for attribute P_L6DT_GDTIfDT_1505
		[DataContract]
		public class P_L6DT_GDTIfDT_1505 
		{
			//Standard type parameters
			[DataMember]
			public Guid TaskID { get; set; } 
			[DataMember]
			public bool IsBeingPrepared_Only { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIfDT_1505 for attribute L6DT_GDTIfDT_1505
		[DataContract]
		public class L6DT_GDTIfDT_1505 
		{
			//Standard type parameters
			[DataMember]
			public Guid Task_ID { get; set; } 
			[DataMember]
			public String Task_Identification { get; set; } 
			[DataMember]
			public String Task_Name { get; set; } 
			[DataMember]
			public DateTime Task_Deadline { get; set; } 
			[DataMember]
			public Double Task_PercentageComplete { get; set; } 
			[DataMember]
			public DateTime Task_CompletionStamp { get; set; } 
			[DataMember]
			public DateTime Task_CreationStamp { get; set; } 
			[DataMember]
			public long Task_CurrentInvestment { get; set; } 
			[DataMember]
			public long Task_RequiredEstimation { get; set; } 
			[DataMember]
			public Dict Priority_Label { get; set; } 
			[DataMember]
			public String CreatedByFirstName { get; set; } 
			[DataMember]
			public String CreatedByLastName { get; set; } 
			[DataMember]
			public String Task_Description { get; set; } 
			[DataMember]
			public Guid Task_Involvement { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public long DeveloperInvested { get; set; } 
			[DataMember]
			public long Developer_CompletionEstimation { get; set; } 
			[DataMember]
			public DateTime Assignment_Timestamp { get; set; } 
			[DataMember]
			public bool IsIncompleteInformation { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTIfDT_1505 cls_Get_DeveloperTaskInfo_for_DeveloperTaskID(,P_L6DT_GDTIfDT_1505 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTIfDT_1505 invocationResult = cls_Get_DeveloperTaskInfo_for_DeveloperTaskID.Invoke(connectionString,P_L6DT_GDTIfDT_1505 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDTIfDT_1505();
parameter.TaskID = ...;
parameter.IsBeingPrepared_Only = ...;

*/
