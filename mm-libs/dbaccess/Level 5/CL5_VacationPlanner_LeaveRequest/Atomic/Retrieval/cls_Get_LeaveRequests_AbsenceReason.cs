/* 
 * Generated on 8/26/2013 2:51:17 PM
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

namespace CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LeaveRequests_AbsenceReason.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LeaveRequests_AbsenceReason
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_GLRFAR_1351_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_GLRFAR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5LR_GLRFAR_1351_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_LeaveRequest.Atomic.Retrieval.SQL.cls_Get_LeaveRequests_AbsenceReason.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReasonID", Parameter.ReasonID);


			List<L5LR_GLRFAR_1351> results = new List<L5LR_GLRFAR_1351>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_Employee_LeaveRequestID" });
				while(reader.Read())
				{
					L5LR_GLRFAR_1351 resultItem = new L5LR_GLRFAR_1351();
					//0:Parameter CMN_BPT_EMP_Employee_LeaveRequestID of type Guid
					resultItem.CMN_BPT_EMP_Employee_LeaveRequestID = reader.GetGuid(0);

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

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LR_GLRFAR_1351_Array Invoke(string ConnectionString,P_L5LR_GLRFAR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFAR_1351_Array Invoke(DbConnection Connection,P_L5LR_GLRFAR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFAR_1351_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_GLRFAR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_GLRFAR_1351_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_GLRFAR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_GLRFAR_1351_Array functionReturn = new FR_L5LR_GLRFAR_1351_Array();
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
	public class FR_L5LR_GLRFAR_1351_Array : FR_Base
	{
		public L5LR_GLRFAR_1351[] Result	{ get; set; } 
		public FR_L5LR_GLRFAR_1351_Array() : base() {}

		public FR_L5LR_GLRFAR_1351_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LR_GLRFAR_1351_Array cls_Get_LeaveRequests_AbsenceReason(P_L5LR_GLRFAR_1351 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5LR_GLRFAR_1351_Array result = cls_Get_LeaveRequests_AbsenceReason.Invoke(connectionString,P_L5LR_GLRFAR_1351 Parameter,securityTicket);
	 return result;
}
*/