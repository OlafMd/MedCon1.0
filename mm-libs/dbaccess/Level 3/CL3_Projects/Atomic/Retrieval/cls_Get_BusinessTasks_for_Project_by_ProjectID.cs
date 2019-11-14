/* 
 * Generated on 7/31/2014 12:43:31 PM
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

namespace CL3_Project.Atomic.Retrieval
{
	/// <summary>
    /// Retrieve business tasks ID and name for ProjectID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BusinessTasks_for_Project_by_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BusinessTasks_for_Project_by_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GBTfPbP_1241_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GBTfPbP_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GBTfPbP_1241_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Project.Atomic.Retrieval.SQL.cls_Get_BusinessTasks_for_Project_by_ProjectID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectID", Parameter.ProjectID);



			List<L3PR_GBTfPbP_1241> results = new List<L3PR_GBTfPbP_1241>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_BusinessTaskID","Task_Name_DictID" });
				while(reader.Read())
				{
					L3PR_GBTfPbP_1241 resultItem = new L3PR_GBTfPbP_1241();
					//0:Parameter TMS_PRO_BusinessTaskID of type Guid
					resultItem.TMS_PRO_BusinessTaskID = reader.GetGuid(0);
					//1:Parameter Task_Name_DictID of type Dict
					resultItem.Task_Name_DictID = reader.GetDictionary(1);
					resultItem.Task_Name_DictID.SourceTable = "tms_pro_businesstasks";
					loader.Append(resultItem.Task_Name_DictID);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BusinessTasks_for_Project_by_ProjectID",ex);
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
		public static FR_L3PR_GBTfPbP_1241_Array Invoke(string ConnectionString,P_L3PR_GBTfPbP_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GBTfPbP_1241_Array Invoke(DbConnection Connection,P_L3PR_GBTfPbP_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GBTfPbP_1241_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GBTfPbP_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GBTfPbP_1241_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GBTfPbP_1241 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GBTfPbP_1241_Array functionReturn = new FR_L3PR_GBTfPbP_1241_Array();
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

				throw new Exception("Exception occured in method cls_Get_BusinessTasks_for_Project_by_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GBTfPbP_1241_Array : FR_Base
	{
		public L3PR_GBTfPbP_1241[] Result	{ get; set; } 
		public FR_L3PR_GBTfPbP_1241_Array() : base() {}

		public FR_L3PR_GBTfPbP_1241_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GBTfPbP_1241 for attribute P_L3PR_GBTfPbP_1241
		[DataContract]
		public class P_L3PR_GBTfPbP_1241 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GBTfPbP_1241 for attribute L3PR_GBTfPbP_1241
		[DataContract]
		public class L3PR_GBTfPbP_1241 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_BusinessTaskID { get; set; } 
			[DataMember]
			public Dict Task_Name_DictID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GBTfPbP_1241_Array cls_Get_BusinessTasks_for_Project_by_ProjectID(,P_L3PR_GBTfPbP_1241 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GBTfPbP_1241_Array invocationResult = cls_Get_BusinessTasks_for_Project_by_ProjectID.Invoke(connectionString,P_L3PR_GBTfPbP_1241 Parameter,securityTicket);
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
var parameter = new CL3_Project.Atomic.Retrieval.P_L3PR_GBTfPbP_1241();
parameter.ProjectID = ...;

*/
