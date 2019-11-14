/* 
 * Generated on 11-Dec-14 12:29:57 PM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperModule_Comments_for_DTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperModule_Comments_for_DTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDMCfDT_1058_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDMCfDT_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDMCfDT_1058_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperModule_Comments_for_DTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DTaskID", Parameter.DTaskID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectID", Parameter.ProjectID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureID", Parameter.FeatureID);



			List<L6DT_GDMCfDT_1058> results = new List<L6DT_GDMCfDT_1058>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CommentID","CreationDate","CommentText","IsDeletedComment","CommentAccID","AuthorFirstName","AuthorLastName","File_SourceLocation","File_ServerLocation","Comment_BoundTo_DeveloperTask_RefID","Comment_BoundTo_Project_RefID","Comment_BoundTo_Feature_RefID" });
				while(reader.Read())
				{
					L6DT_GDMCfDT_1058 resultItem = new L6DT_GDMCfDT_1058();
					//0:Parameter CommentID of type Guid
					resultItem.CommentID = reader.GetGuid(0);
					//1:Parameter CreationDate of type DateTime
					resultItem.CreationDate = reader.GetDate(1);
					//2:Parameter CommentText of type String
					resultItem.CommentText = reader.GetString(2);
					//3:Parameter IsDeletedComment of type Boolean
					resultItem.IsDeletedComment = reader.GetBoolean(3);
					//4:Parameter CommentAccID of type Guid
					resultItem.CommentAccID = reader.GetGuid(4);
					//5:Parameter AuthorFirstName of type String
					resultItem.AuthorFirstName = reader.GetString(5);
					//6:Parameter AuthorLastName of type String
					resultItem.AuthorLastName = reader.GetString(6);
					//7:Parameter File_SourceLocation of type String
					resultItem.File_SourceLocation = reader.GetString(7);
					//8:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(8);
					//9:Parameter Comment_BoundTo_DeveloperTask_RefID of type Guid
					resultItem.Comment_BoundTo_DeveloperTask_RefID = reader.GetGuid(9);
					//10:Parameter Comment_BoundTo_Project_RefID of type Guid
					resultItem.Comment_BoundTo_Project_RefID = reader.GetGuid(10);
					//11:Parameter Comment_BoundTo_Feature_RefID of type Guid
					resultItem.Comment_BoundTo_Feature_RefID = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperModule_Comments_for_DTaskID",ex);
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
		public static FR_L6DT_GDMCfDT_1058_Array Invoke(string ConnectionString,P_L6DT_GDMCfDT_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMCfDT_1058_Array Invoke(DbConnection Connection,P_L6DT_GDMCfDT_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMCfDT_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDMCfDT_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDMCfDT_1058_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDMCfDT_1058 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDMCfDT_1058_Array functionReturn = new FR_L6DT_GDMCfDT_1058_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperModule_Comments_for_DTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDMCfDT_1058_Array : FR_Base
	{
		public L6DT_GDMCfDT_1058[] Result	{ get; set; } 
		public FR_L6DT_GDMCfDT_1058_Array() : base() {}

		public FR_L6DT_GDMCfDT_1058_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDMCfDT_1058 for attribute P_L6DT_GDMCfDT_1058
		[DataContract]
		public class P_L6DT_GDMCfDT_1058 
		{
			//Standard type parameters
			[DataMember]
			public Guid DTaskID { get; set; } 
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDMCfDT_1058 for attribute L6DT_GDMCfDT_1058
		[DataContract]
		public class L6DT_GDMCfDT_1058 
		{
			//Standard type parameters
			[DataMember]
			public Guid CommentID { get; set; } 
			[DataMember]
			public DateTime CreationDate { get; set; } 
			[DataMember]
			public String CommentText { get; set; } 
			[DataMember]
			public Boolean IsDeletedComment { get; set; } 
			[DataMember]
			public Guid CommentAccID { get; set; } 
			[DataMember]
			public String AuthorFirstName { get; set; } 
			[DataMember]
			public String AuthorLastName { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_DeveloperTask_RefID { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_Project_RefID { get; set; } 
			[DataMember]
			public Guid Comment_BoundTo_Feature_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDMCfDT_1058_Array cls_Get_DeveloperModule_Comments_for_DTaskID(,P_L6DT_GDMCfDT_1058 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDMCfDT_1058_Array invocationResult = cls_Get_DeveloperModule_Comments_for_DTaskID.Invoke(connectionString,P_L6DT_GDMCfDT_1058 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDMCfDT_1058();
parameter.DTaskID = ...;
parameter.ProjectID = ...;
parameter.FeatureID = ...;

*/
