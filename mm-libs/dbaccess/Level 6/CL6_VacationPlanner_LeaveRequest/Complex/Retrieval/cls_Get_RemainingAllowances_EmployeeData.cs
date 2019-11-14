/* 
 * Generated on 8/30/2013 11:29:47 AM
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
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using CL5_VacationPlanner_Company.Complex.Retrieval;

namespace CL6_VacationPlanner_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RemainingAllowances_EmployeeData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RemainingAllowances_EmployeeData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_GRAED_1400 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_GRAED_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6LR_GRAED_1400();
            L6LR_GRAED_1400 result = new L6LR_GRAED_1400();
            result.Company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            L5EM_GEFT_0959[] allEmployees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            result.Employees = allEmployees;

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_GRAED_1400 Invoke(string ConnectionString,P_L6LR_GRAED_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_GRAED_1400 Invoke(DbConnection Connection,P_L6LR_GRAED_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_GRAED_1400 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_GRAED_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_GRAED_1400 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_GRAED_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_GRAED_1400 functionReturn = new FR_L6LR_GRAED_1400();
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

				throw new Exception("Exception occured in method cls_Get_RemainingAllowances_EmployeeData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_GRAED_1400 : FR_Base
	{
		public L6LR_GRAED_1400 Result	{ get; set; }

		public FR_L6LR_GRAED_1400() : base() {}

		public FR_L6LR_GRAED_1400(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_GRAED_1400 cls_Get_RemainingAllowances_EmployeeData(,P_L6LR_GRAED_1400 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_GRAED_1400 invocationResult = cls_Get_RemainingAllowances_EmployeeData.Invoke(connectionString,P_L6LR_GRAED_1400 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_LeaveRequest.Complex.Retrieval.P_L6LR_GRAED_1400();
parameter.ListOfEmployees = ...;

*/