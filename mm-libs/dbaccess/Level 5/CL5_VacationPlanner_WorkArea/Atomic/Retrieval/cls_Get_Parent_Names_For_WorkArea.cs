/* 
 * Generated on 8/26/2013 2:06:57 PM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkArea.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Parent_Names_For_WorkArea.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Parent_Names_For_WorkArea
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WA_GPNFWA_1326 Execute(DbConnection Connection,DbTransaction Transaction,P_L5WA_GPNFWA_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5WA_GPNFWA_1326();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_WorkArea.Atomic.Retrieval.SQL.cls_Get_Parent_Names_For_WorkArea.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"WorkAreaID", Parameter.WorkAreaID);


			List<L5WA_GPNFWA_1326> results = new List<L5WA_GPNFWA_1326>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Office_Name_DictID","WorkAreaParentName_DictID" });
				while(reader.Read())
				{
					L5WA_GPNFWA_1326 resultItem = new L5WA_GPNFWA_1326();
					//0:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(0);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//1:Parameter WorkAreaParentName of type Dict
					resultItem.WorkAreaParentName = reader.GetDictionary(1);
					resultItem.WorkAreaParentName.SourceTable = "cmn_str_pps_workareas";
					loader.Append(resultItem.WorkAreaParentName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5WA_GPNFWA_1326 Invoke(string ConnectionString,P_L5WA_GPNFWA_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WA_GPNFWA_1326 Invoke(DbConnection Connection,P_L5WA_GPNFWA_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WA_GPNFWA_1326 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WA_GPNFWA_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WA_GPNFWA_1326 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WA_GPNFWA_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WA_GPNFWA_1326 functionReturn = new FR_L5WA_GPNFWA_1326();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WA_GPNFWA_1326 : FR_Base
	{
		public L5WA_GPNFWA_1326 Result	{ get; set; }

		public FR_L5WA_GPNFWA_1326() : base() {}

		public FR_L5WA_GPNFWA_1326(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WA_GPNFWA_1326 cls_Get_Parent_Names_For_WorkArea(P_L5WA_GPNFWA_1326 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5WA_GPNFWA_1326 result = cls_Get_Parent_Names_For_WorkArea.Invoke(connectionString,P_L5WA_GPNFWA_1326 Parameter,securityTicket);
	 return result;
}
*/