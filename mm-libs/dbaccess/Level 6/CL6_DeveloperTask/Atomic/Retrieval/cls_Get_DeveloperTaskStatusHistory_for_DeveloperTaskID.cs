/* 
 * Generated on 10/3/2014 5:11:21 PM
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
    /// Get status history for Developer task ID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTSHfDT_1646_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTSHfDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDTSHfDT_1646_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeveloperTaskID", Parameter.DeveloperTaskID);



			List<L6DT_GDTSHfDT_1646> results = new List<L6DT_GDTSHfDT_1646>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeveloperTask_Status_RefID","Comment","Creation_Timestamp","TriggeredBy_ProjectMember_RefID","Label_DictID","FirstName","LastName","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L6DT_GDTSHfDT_1646 resultItem = new L6DT_GDTSHfDT_1646();
					//0:Parameter DeveloperTask_Status_RefID of type Guid
					resultItem.DeveloperTask_Status_RefID = reader.GetGuid(0);
					//1:Parameter Comment of type string
					resultItem.Comment = reader.GetString(1);
					//2:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(2);
					//3:Parameter TriggeredBy_ProjectMember_RefID of type Guid
					resultItem.TriggeredBy_ProjectMember_RefID = reader.GetGuid(3);
					//4:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(4);
					resultItem.Label.SourceTable = "tms_pro_developertask_statuses";
					loader.Append(resultItem.Label);
					//5:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(5);
					//6:Parameter LastName of type string
					resultItem.LastName = reader.GetString(6);
					//7:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID",ex);
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
		public static FR_L6DT_GDTSHfDT_1646_Array Invoke(string ConnectionString,P_L6DT_GDTSHfDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSHfDT_1646_Array Invoke(DbConnection Connection,P_L6DT_GDTSHfDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSHfDT_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTSHfDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTSHfDT_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTSHfDT_1646 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTSHfDT_1646_Array functionReturn = new FR_L6DT_GDTSHfDT_1646_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTSHfDT_1646_Array : FR_Base
	{
		public L6DT_GDTSHfDT_1646[] Result	{ get; set; } 
		public FR_L6DT_GDTSHfDT_1646_Array() : base() {}

		public FR_L6DT_GDTSHfDT_1646_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTSHfDT_1646 for attribute P_L6DT_GDTSHfDT_1646
		[DataContract]
		public class P_L6DT_GDTSHfDT_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTSHfDT_1646 for attribute L6DT_GDTSHfDT_1646
		[DataContract]
		public class L6DT_GDTSHfDT_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_Status_RefID { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid TriggeredBy_ProjectMember_RefID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTSHfDT_1646_Array cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID(,P_L6DT_GDTSHfDT_1646 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTSHfDT_1646_Array invocationResult = cls_Get_DeveloperTaskStatusHistory_for_DeveloperTaskID.Invoke(connectionString,P_L6DT_GDTSHfDT_1646 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDTSHfDT_1646();
parameter.DeveloperTaskID = ...;

*/
