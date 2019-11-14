/* 
 * Generated on 9/18/2014 14:04:59
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
    /// var result = cls_Get_DeveloperModule_Mentions_for_CommentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperModule_Mentions_for_CommentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDMMfC_1104_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDMMfC_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDMMfC_1104_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperModule_Mentions_for_CommentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CommentID", Parameter.CommentID);



			List<L6DT_GDMMfC_1104> results = new List<L6DT_GDMMfC_1104>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_Comment_MentionID","Comment_RefID","R_CommentMention_Text","CommentMention_Position","Creation_Timestamp","IsDeleted" });
				while(reader.Read())
				{
					L6DT_GDMMfC_1104 resultItem = new L6DT_GDMMfC_1104();
					//0:Parameter TMS_PRO_Comment_MentionID of type Guid
					resultItem.TMS_PRO_Comment_MentionID = reader.GetGuid(0);
					//1:Parameter Comment_RefID of type Guid
					resultItem.Comment_RefID = reader.GetGuid(1);
					//2:Parameter R_CommentMention_Text of type String
					resultItem.R_CommentMention_Text = reader.GetString(2);
					//3:Parameter CommentMention_Position of type int
					resultItem.CommentMention_Position = reader.GetInteger(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperModule_Mentions_for_CommentID",ex);
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
		public static FR_L6DT_GDMMfC_1104_Array Invoke(string ConnectionString,P_L6DT_GDMMfC_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMMfC_1104_Array Invoke(DbConnection Connection,P_L6DT_GDMMfC_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDMMfC_1104_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDMMfC_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDMMfC_1104_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDMMfC_1104 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDMMfC_1104_Array functionReturn = new FR_L6DT_GDMMfC_1104_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperModule_Mentions_for_CommentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDMMfC_1104_Array : FR_Base
	{
		public L6DT_GDMMfC_1104[] Result	{ get; set; } 
		public FR_L6DT_GDMMfC_1104_Array() : base() {}

		public FR_L6DT_GDMMfC_1104_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDMMfC_1104 for attribute P_L6DT_GDMMfC_1104
		[DataContract]
		public class P_L6DT_GDMMfC_1104 
		{
			//Standard type parameters
			[DataMember]
			public Guid CommentID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDMMfC_1104 for attribute L6DT_GDMMfC_1104
		[DataContract]
		public class L6DT_GDMMfC_1104 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_Comment_MentionID { get; set; } 
			[DataMember]
			public Guid Comment_RefID { get; set; } 
			[DataMember]
			public String R_CommentMention_Text { get; set; } 
			[DataMember]
			public int CommentMention_Position { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDMMfC_1104_Array cls_Get_DeveloperModule_Mentions_for_CommentID(,P_L6DT_GDMMfC_1104 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDMMfC_1104_Array invocationResult = cls_Get_DeveloperModule_Mentions_for_CommentID.Invoke(connectionString,P_L6DT_GDMMfC_1104 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDMMfC_1104();
parameter.CommentID = ...;

*/
