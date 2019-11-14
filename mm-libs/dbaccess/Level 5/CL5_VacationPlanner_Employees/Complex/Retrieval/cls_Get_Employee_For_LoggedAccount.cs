/* 
 * Generated on 2/13/2014 4:06:29 PM
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
using CL1_USR;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employee_For_LoggedAccount.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employee_For_LoggedAccount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEFU_445 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5EM_GEFU_445();
            L5EM_GEFU_445 result=new L5EM_GEFU_445();


                ORM_USR_Account account=new ORM_USR_Account();
                account.Load(Connection,Transaction,securityTicket.AccountID);
            if(account.USR_AccountID==Guid.Empty){
                return null;
            }

            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.IsDeleted = false;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            employeeQuery.BusinessParticipant_RefID=account.BusinessParticipant_RefID;
            List<ORM_CMN_BPT_EMP_Employee> employeeList = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery);
            if(employeeList.Count!=0){

                ORM_CMN_BPT_EMP_Employee employee=employeeList[0];
                result.CMN_BPT_EMP_EmployeeID=employee.CMN_BPT_EMP_EmployeeID;
                result.Staff_Number=employee.Staff_Number;
                result.StandardFunction=employee.StandardFunction;
                

                ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query employeeWorkplaceAssignmentsQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                employeeWorkplaceAssignmentsQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employeeWorkplaceAssignmentsQuery.Tenant_RefID = securityTicket.TenantID;
                employeeWorkplaceAssignmentsQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> employeeWorkplaceAssignemntsList = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, employeeWorkplaceAssignmentsQuery);
                List<L5EM_GEFU_445_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEFU_445_EmployeeWorkplaceHistory>();

                foreach (var workplaceAssignemns in employeeWorkplaceAssignemntsList)
                {
                    L5EM_GEFU_445_EmployeeWorkplaceHistory item = new L5EM_GEFU_445_EmployeeWorkplaceHistory();
                    item.BoundTo_Workplace_RefID = workplaceAssignemns.BoundTo_Workplace_RefID;
                    item.CMN_BPT_EMP_Employee_PlanGroup_RefID = workplaceAssignemns.CMN_BPT_EMP_Employee_PlanGroup_RefID;
                    item.CMN_BPT_EMP_Employee_WorkplaceAssignmentID = workplaceAssignemns.CMN_BPT_EMP_Employee_WorkplaceAssignment;
                    item.Default_BreakTime_Template_RefID = workplaceAssignemns.Default_BreakTime_Template_RefID;
                    item.IsBreakTimeCalculated_Actual = workplaceAssignemns.IsBreakTimeCalculated_Actual;
                    item.IsBreakTimeCalculated_Planning = workplaceAssignemns.IsBreakTimeCalculated_Planning;
                    item.SequenceNumber = workplaceAssignemns.SequenceNumber;
                    item.WorkplaceAssignment_StartDate = workplaceAssignemns.WorkplaceAssignment_StartDate;

                    employeeWorkplaceAssignments.Add(item);
                }

                result.EmployeeWorkplaceHistory = employeeWorkplaceAssignments.ToArray();
            }
            returnValue.Result=result;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEFU_445 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFU_445 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEFU_445 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEFU_445 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEFU_445 functionReturn = new FR_L5EM_GEFU_445();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_Employee_For_LoggedAccount",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEFU_445 : FR_Base
	{
		public L5EM_GEFU_445 Result	{ get; set; }

		public FR_L5EM_GEFU_445() : base() {}

		public FR_L5EM_GEFU_445(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEFU_445 cls_Get_Employee_For_LoggedAccount(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEFU_445 invocationResult = cls_Get_Employee_For_LoggedAccount.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
