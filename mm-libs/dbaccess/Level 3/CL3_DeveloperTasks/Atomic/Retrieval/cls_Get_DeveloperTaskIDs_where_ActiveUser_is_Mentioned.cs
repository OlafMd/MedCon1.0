/* 
 * Generated on 8/11/2014 10:16:13 AM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTIDwAUiM_1712_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GDTIDwAUiM_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTIDwAUiM_1712_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectStatusExcluded", Parameter.ProjectStatusExcluded);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureStatusExcluded", Parameter.FeatureStatusExcluded);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BusinessTaskStatusExcluded", Parameter.BusinessTaskStatusExcluded);



			List<L3DT_GDTIDwAUiM_1712> results = new List<L3DT_GDTIDwAUiM_1712>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeveloperTask_ID","CommentMention" });
				while(reader.Read())
				{
					L3DT_GDTIDwAUiM_1712 resultItem = new L3DT_GDTIDwAUiM_1712();
					//0:Parameter DeveloperTask_ID of type Guid
					resultItem.DeveloperTask_ID = reader.GetGuid(0);
					//1:Parameter CommentMention of type string
					resultItem.CommentMention = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned",ex);
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
		public static FR_L3DT_GDTIDwAUiM_1712_Array Invoke(string ConnectionString,P_L3DT_GDTIDwAUiM_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTIDwAUiM_1712_Array Invoke(DbConnection Connection,P_L3DT_GDTIDwAUiM_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTIDwAUiM_1712_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GDTIDwAUiM_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTIDwAUiM_1712_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GDTIDwAUiM_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTIDwAUiM_1712_Array functionReturn = new FR_L3DT_GDTIDwAUiM_1712_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTIDwAUiM_1712_Array : FR_Base
	{
		public L3DT_GDTIDwAUiM_1712[] Result	{ get; set; } 
		public FR_L3DT_GDTIDwAUiM_1712_Array() : base() {}

		public FR_L3DT_GDTIDwAUiM_1712_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GDTIDwAUiM_1712 for attribute P_L3DT_GDTIDwAUiM_1712
		[DataContract]
		public class P_L3DT_GDTIDwAUiM_1712 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectStatusExcluded { get; set; } 
			[DataMember]
			public Guid FeatureStatusExcluded { get; set; } 
			[DataMember]
			public Guid BusinessTaskStatusExcluded { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTIDwAUiM_1712 for attribute L3DT_GDTIDwAUiM_1712
		[DataContract]
		public class L3DT_GDTIDwAUiM_1712 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_ID { get; set; } 
			[DataMember]
			public string CommentMention { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTIDwAUiM_1712_Array cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned(,P_L3DT_GDTIDwAUiM_1712 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTIDwAUiM_1712_Array invocationResult = cls_Get_DeveloperTaskIDs_where_ActiveUser_is_Mentioned.Invoke(connectionString,P_L3DT_GDTIDwAUiM_1712 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GDTIDwAUiM_1712();
parameter.ProjectStatusExcluded = ...;
parameter.FeatureStatusExcluded = ...;
parameter.BusinessTaskStatusExcluded = ...;

*/
