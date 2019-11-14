/* 
 * Generated on 06/08/2014 15:11:53
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
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_WorkplaceHistories.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_WorkplaceHistories
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SWPH_1625 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query workplaceHistoryQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
            workplaceHistoryQuery.CMN_BPT_EMP_Employee_RefID = Parameter.Employee_RefID;
            workplaceHistoryQuery.Tenant_RefID = securityTicket.TenantID;
            workplaceHistoryQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> workplaceHistoryList = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, workplaceHistoryQuery);

            //delete workplace histories from database witch doesn't exist in passed parameter
            List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> deletedWorkplaceHistoryList = new List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment>();
            foreach (var item in workplaceHistoryList)
            {
                if (Parameter.WorkplaceHistories.Any(p => p.CMN_BPT_EMP_Employee_WorkplaceAssignmentID == item.CMN_BPT_EMP_Employee_WorkplaceAssignment))
                    continue;

                item.Remove(Connection, Transaction);
                deletedWorkplaceHistoryList.Add(item);
            }
            workplaceHistoryList = workplaceHistoryList.Except(deletedWorkplaceHistoryList).ToList();

            //add or edit every workplace history from parameter
            foreach (var workplaceHistoryItem in Parameter.WorkplaceHistories)
            {
                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment workplaceHistory = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment();

                if (workplaceHistoryList.Any(e => e.CMN_BPT_EMP_Employee_WorkplaceAssignment == workplaceHistoryItem.CMN_BPT_EMP_Employee_WorkplaceAssignmentID))
                    workplaceHistory.Load(Connection, Transaction, workplaceHistoryItem.CMN_BPT_EMP_Employee_WorkplaceAssignmentID);

                workplaceHistory.BoundTo_Workplace_RefID = workplaceHistoryItem.BoundTo_Workplace_RefID;
                workplaceHistory.CMN_BPT_EMP_Employee_PlanGroup_RefID = workplaceHistoryItem.CMN_BPT_EMP_Employee_PlanGroup_RefID;
                workplaceHistory.CMN_BPT_EMP_Employee_RefID = Parameter.Employee_RefID;
                workplaceHistory.Default_BreakTime_Template_RefID = workplaceHistoryItem.Default_BreakTime_Template_RefID;
                workplaceHistory.IsBreakTimeCalculated_Actual = workplaceHistoryItem.IsBreakTimeCalculated_Actual;
                workplaceHistory.IsBreakTimeCalculated_Planning = workplaceHistoryItem.IsBreakTimeCalculated_Planning;
                workplaceHistory.SequenceNumber = workplaceHistoryItem.SequenceNumber;
                workplaceHistory.Tenant_RefID = securityTicket.TenantID;
                workplaceHistory.WorkplaceAssignment_StartDate = workplaceHistoryItem.WorkplaceAssignment_StartDate;

                workplaceHistory.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SWPH_1625 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SWPH_1625 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SWPH_1625 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SWPH_1625 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_WorkplaceHistories",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_WorkplaceHistories(,P_L5EM_SWPH_1625 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_WorkplaceHistories.Invoke(connectionString,P_L5EM_SWPH_1625 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SWPH_1625();
parameter.WorkplaceHistories = ...;

parameter.Employee_RefID = ...;

*/
