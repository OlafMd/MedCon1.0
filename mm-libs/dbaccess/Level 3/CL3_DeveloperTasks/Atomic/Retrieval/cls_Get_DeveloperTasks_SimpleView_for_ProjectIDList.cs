/* 
 * Generated on 9/1/2014 14:00:54
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

namespace CL3_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// Get all DeveloperTasks (with or without archived) for ProjectIDList (SimpleView)
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTSVfPL_1458_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GDTSVfPL_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTSVfPL_1458_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProjectIDList"," IN $$ProjectIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProjectIDList$",Parameter.ProjectIDList);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Is_ArchivedTasks_Included", Parameter.Is_ArchivedTasks_Included);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShowOnly_IncompleteInfo", Parameter.ShowOnly_IncompleteInfo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShowOnly_CompletedTasks", Parameter.ShowOnly_CompletedTasks);



			List<L3DT_GDTSVfPL_1458> results = new List<L3DT_GDTSVfPL_1458>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","IdentificationNumber","DOC_Structure_Header_RefID","Project_RefID","Name","IsArchived","IsComplete","IsIncompleteInformation","Feature_RefID","IsBeingPrepared","GrabbedByMember_RefID","USR_Account_RefID" });
				while(reader.Read())
				{
					L3DT_GDTSVfPL_1458 resultItem = new L3DT_GDTSVfPL_1458();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(2);
					//3:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(3);
					//4:Parameter Name of type String
					resultItem.Name = reader.GetString(4);
					//5:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(5);
					//6:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(6);
					//7:Parameter IsIncompleteInformation of type Boolean
					resultItem.IsIncompleteInformation = reader.GetBoolean(7);
					//8:Parameter Feature_RefID of type Guid
					resultItem.Feature_RefID = reader.GetGuid(8);
					//9:Parameter IsBeingPrepared of type Boolean
					resultItem.IsBeingPrepared = reader.GetBoolean(9);
					//10:Parameter GrabbedByMember_RefID of type Guid
					resultItem.GrabbedByMember_RefID = reader.GetGuid(10);
					//11:Parameter USR_Account_RefID of type Guid
					resultItem.USR_Account_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList",ex);
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
		public static FR_L3DT_GDTSVfPL_1458_Array Invoke(string ConnectionString,P_L3DT_GDTSVfPL_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTSVfPL_1458_Array Invoke(DbConnection Connection,P_L3DT_GDTSVfPL_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTSVfPL_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GDTSVfPL_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTSVfPL_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GDTSVfPL_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTSVfPL_1458_Array functionReturn = new FR_L3DT_GDTSVfPL_1458_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTSVfPL_1458_Array : FR_Base
	{
		public L3DT_GDTSVfPL_1458[] Result	{ get; set; } 
		public FR_L3DT_GDTSVfPL_1458_Array() : base() {}

		public FR_L3DT_GDTSVfPL_1458_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GDTSVfPL_1458 for attribute P_L3DT_GDTSVfPL_1458
		[DataContract]
		public class P_L3DT_GDTSVfPL_1458 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectIDList { get; set; } 
			[DataMember]
			public Boolean Is_ArchivedTasks_Included { get; set; } 
			[DataMember]
			public Boolean ShowOnly_IncompleteInfo { get; set; } 
			[DataMember]
			public Boolean ShowOnly_CompletedTasks { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTSVfPL_1458 for attribute L3DT_GDTSVfPL_1458
		[DataContract]
		public class L3DT_GDTSVfPL_1458 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 
			[DataMember]
			public Boolean IsIncompleteInformation { get; set; } 
			[DataMember]
			public Guid Feature_RefID { get; set; } 
			[DataMember]
			public Boolean IsBeingPrepared { get; set; } 
			[DataMember]
			public Guid GrabbedByMember_RefID { get; set; } 
			[DataMember]
			public Guid USR_Account_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTSVfPL_1458_Array cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList(,P_L3DT_GDTSVfPL_1458 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTSVfPL_1458_Array invocationResult = cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList.Invoke(connectionString,P_L3DT_GDTSVfPL_1458 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GDTSVfPL_1458();
parameter.ProjectIDList = ...;
parameter.Is_ArchivedTasks_Included = ...;
parameter.ShowOnly_IncompleteInfo = ...;
parameter.ShowOnly_CompletedTasks = ...;

*/
