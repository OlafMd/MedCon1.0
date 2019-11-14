/* 
 * Generated on 2/11/2014 3:25:14 PM
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
using CL5_VacationPlanner_Company.Complex.Retrieval;
using PlannicoModel.Models;
using VacationPlannerCore.Utils;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEAAWCFTAE_1403 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEAAWCFTAE_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EM_GEAAWCFTAE_1403();
            returnValue.Result = new L5EM_GEAAWCFTAE_1403();
            //Put your code here

            L5EM_GEAAWCFT_1210[] employees = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            if (employees == null)
            {
                employees = new L5EM_GEAAWCFT_1210[0];
                returnValue.Result.Employees = employees;
                return returnValue;

            }
            L5EM_GEAAWCFT_1210 loggedEmployee = employees.Where(i => i.CMN_BPT_EMP_EmployeeID == Parameter.EmployeeID).FirstOrDefault();
            L5CM_GCSFT_1157 company = cls_Get_Company_Structure_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;


            EmployeeUtils employeeUtils = new EmployeeUtils();
            employeeUtils.ComapnyStructure = company;
            List<Guid> employeesUnderManager = employeeUtils.getEmployeesForManager(Parameter.appStartDate, employees, company, Parameter.EmployeeID, securityTicket.SessionTicket);
            if (loggedEmployee == null)
            {
                employees = employees.Where(i => employeesUnderManager.Contains(i.CMN_BPT_EMP_EmployeeID)).ToArray();
            }


            employees = employees.Where(i => employeesUnderManager.Contains(i.CMN_BPT_EMP_EmployeeID) || EmployeeUtils.getEmployeeWorkplaceHistoriesFromAppStartDate(i.EmployeeWorkplaceHistory, Parameter.appStartDate).Intersect(EmployeeUtils.getEmployeeWorkplaceHistoriesFromAppStartDate(loggedEmployee.EmployeeWorkplaceHistory, Parameter.appStartDate)).Any()).ToArray();
            if (employees.Where(i => i.CMN_BPT_EMP_EmployeeID == Parameter.EmployeeID).ToArray().Length == 0)
            {
                if (loggedEmployee != null)
                {
                    if (employees.Length == 0)
                    {
                        employees = new L5EM_GEAAWCFT_1210[1];
                        employees[0] = loggedEmployee;
                    }
                    else
                    {
                        L5EM_GEAAWCFT_1210[] employeeList = new L5EM_GEAAWCFT_1210[employees.Length + 1];
                        for (int i = 0; i < employees.Length; i++)
                        {
                            employeeList[i] = employees[i];
                        }
                        employeeList[employees.Length] = loggedEmployee;
                        employees = employeeList;
                    }
                }
            }
            returnValue.Result.Employees = employees;

            if (employees.Length == 0)
            {
                returnValue.Result = null;
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEAAWCFTAE_1403 Invoke(string ConnectionString,P_L5EM_GEAAWCFTAE_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEAAWCFTAE_1403 Invoke(DbConnection Connection,P_L5EM_GEAAWCFTAE_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEAAWCFTAE_1403 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEAAWCFTAE_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEAAWCFTAE_1403 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEAAWCFTAE_1403 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEAAWCFTAE_1403 functionReturn = new FR_L5EM_GEAAWCFTAE_1403();
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

				throw new Exception("Exception occured in method cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEAAWCFTAE_1403 : FR_Base
	{
		public L5EM_GEAAWCFTAE_1403 Result	{ get; set; }

		public FR_L5EM_GEAAWCFTAE_1403() : base() {}

		public FR_L5EM_GEAAWCFTAE_1403(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEAAWCFTAE_1403 cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID(,P_L5EM_GEAAWCFTAE_1403 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEAAWCFTAE_1403 invocationResult = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant_And_EmployeID.Invoke(connectionString,P_L5EM_GEAAWCFTAE_1403 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Complex.Retrieval.P_L5EM_GEAAWCFTAE_1403();
parameter.EmployeeID = ...;
parameter.appStartDate = ...;

*/