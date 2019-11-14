/* 
 * Generated on 9/1/2014 14:04:09
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

namespace CL3_BusinessTasks.Atomic.Retrieval
{
	/// <summary>
    /// Get all projects (with or without archived) for ProjectIDList (SimpleView)
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BusinessTasks_SimpleView_for_ProjectIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BusinessTasks_SimpleView_for_ProjectIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3BT_GBTSVfPL_1423_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3BT_GBTSVfPL_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3BT_GBTSVfPL_1423_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_BusinessTasks.Atomic.Retrieval.SQL.cls_Get_BusinessTasks_SimpleView_for_ProjectIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProjectIDList"," IN $$ProjectIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProjectIDList$",Parameter.ProjectIDList);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Is_ArchivedTasks_Included", Parameter.Is_ArchivedTasks_Included);



			List<L3BT_GBTSVfPL_1423> results = new List<L3BT_GBTSVfPL_1423>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_BusinessTaskID","IdentificationNumber","Task_Name_DictID","Project_RefID","DOC_Structure_Header_RefID","BusinessTasksPackage_RefID","IsArchived","Task_Status_RefID" });
				while(reader.Read())
				{
					L3BT_GBTSVfPL_1423 resultItem = new L3BT_GBTSVfPL_1423();
					//0:Parameter TMS_PRO_BusinessTaskID of type Guid
					resultItem.TMS_PRO_BusinessTaskID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter Task_Name of type Dict
					resultItem.Task_Name = reader.GetDictionary(2);
					resultItem.Task_Name.SourceTable = "tms_pro_businesstasks";
					loader.Append(resultItem.Task_Name);
					//3:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(3);
					//4:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(4);
					//5:Parameter BusinessTasksPackage_RefID of type Guid
					resultItem.BusinessTasksPackage_RefID = reader.GetGuid(5);
					//6:Parameter IsArchived of type Boolean
					resultItem.IsArchived = reader.GetBoolean(6);
					//7:Parameter Task_Status_RefID of type Guid
					resultItem.Task_Status_RefID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BusinessTasks_SimpleView_for_ProjectIDList",ex);
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
		public static FR_L3BT_GBTSVfPL_1423_Array Invoke(string ConnectionString,P_L3BT_GBTSVfPL_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3BT_GBTSVfPL_1423_Array Invoke(DbConnection Connection,P_L3BT_GBTSVfPL_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3BT_GBTSVfPL_1423_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BT_GBTSVfPL_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3BT_GBTSVfPL_1423_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BT_GBTSVfPL_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3BT_GBTSVfPL_1423_Array functionReturn = new FR_L3BT_GBTSVfPL_1423_Array();
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

				throw new Exception("Exception occured in method cls_Get_BusinessTasks_SimpleView_for_ProjectIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3BT_GBTSVfPL_1423_Array : FR_Base
	{
		public L3BT_GBTSVfPL_1423[] Result	{ get; set; } 
		public FR_L3BT_GBTSVfPL_1423_Array() : base() {}

		public FR_L3BT_GBTSVfPL_1423_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3BT_GBTSVfPL_1423 for attribute P_L3BT_GBTSVfPL_1423
		[DataContract]
		public class P_L3BT_GBTSVfPL_1423 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectIDList { get; set; } 
			[DataMember]
			public Boolean Is_ArchivedTasks_Included { get; set; } 

		}
		#endregion
		#region SClass L3BT_GBTSVfPL_1423 for attribute L3BT_GBTSVfPL_1423
		[DataContract]
		public class L3BT_GBTSVfPL_1423 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_BusinessTaskID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Dict Task_Name { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid BusinessTasksPackage_RefID { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Guid Task_Status_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3BT_GBTSVfPL_1423_Array cls_Get_BusinessTasks_SimpleView_for_ProjectIDList(,P_L3BT_GBTSVfPL_1423 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3BT_GBTSVfPL_1423_Array invocationResult = cls_Get_BusinessTasks_SimpleView_for_ProjectIDList.Invoke(connectionString,P_L3BT_GBTSVfPL_1423 Parameter,securityTicket);
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
var parameter = new CL3_BusinessTasks.Atomic.Retrieval.P_L3BT_GBTSVfPL_1423();
parameter.ProjectIDList = ...;
parameter.Is_ArchivedTasks_Included = ...;

*/
