/* 
 * Generated on 10/25/2013 9:44:00 AM
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

namespace CL5_VacationPlanner_Employees.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EmployeeWorkingContractTimes_For_EmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EmployeeWorkingContractTimes_For_EmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEWCTFE_1217 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEWCTFE_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EM_GEWCTFE_1217();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Employees.Atomic.Retrieval.SQL.cls_Get_EmployeeWorkingContractTimes_For_EmployeeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EmployeeID", Parameter.EmployeeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AbsenceReasonID", Parameter.AbsenceReasonID);



			List<L5EM_GEWCTFE_1217> results = new List<L5EM_GEWCTFE_1217>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ContractAllowedAbsence_per_Month","CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID" });
				while(reader.Read())
				{
					L5EM_GEWCTFE_1217 resultItem = new L5EM_GEWCTFE_1217();
					//0:Parameter ContractAllowedAbsence_per_Month of type String
					resultItem.ContractAllowedAbsence_per_Month = reader.GetString(0);
					//1:Parameter CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID of type Guid
					resultItem.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_EmployeeWorkingContractTimes_For_EmployeeID",ex);
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
		public static FR_L5EM_GEWCTFE_1217 Invoke(string ConnectionString,P_L5EM_GEWCTFE_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWCTFE_1217 Invoke(DbConnection Connection,P_L5EM_GEWCTFE_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWCTFE_1217 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEWCTFE_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEWCTFE_1217 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEWCTFE_1217 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEWCTFE_1217 functionReturn = new FR_L5EM_GEWCTFE_1217();
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

				throw new Exception("Exception occured in method cls_Get_EmployeeWorkingContractTimes_For_EmployeeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEWCTFE_1217 : FR_Base
	{
		public L5EM_GEWCTFE_1217 Result	{ get; set; }

		public FR_L5EM_GEWCTFE_1217() : base() {}

		public FR_L5EM_GEWCTFE_1217(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEWCTFE_1217 cls_Get_EmployeeWorkingContractTimes_For_EmployeeID(,P_L5EM_GEWCTFE_1217 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEWCTFE_1217 invocationResult = cls_Get_EmployeeWorkingContractTimes_For_EmployeeID.Invoke(connectionString,P_L5EM_GEWCTFE_1217 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Retrieval.P_L5EM_GEWCTFE_1217();
parameter.EmployeeID = ...;
parameter.AbsenceReasonID = ...;

*/