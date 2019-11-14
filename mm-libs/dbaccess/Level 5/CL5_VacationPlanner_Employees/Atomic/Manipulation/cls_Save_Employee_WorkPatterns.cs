/* 
 * Generated on 12/17/2013 3:57:35 PM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_WorkPatterns.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_WorkPatterns
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SEWP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query workPatternQuery = new ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query();
            workPatternQuery.BoundTo_WorkplaceAssignment_RefID = Parameter.BoundTo_WorkplaceAssignment_RefID;
            workPatternQuery.IsDeleted = false;
            workPatternQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query.SoftDelete(Connection, Transaction, workPatternQuery);
            foreach (var pWorkpattern in Parameter.WorkPatterns)
            {
                ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern workpattern = new ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern();
                if (pWorkpattern.CMN_BPT_EMP_WorkplaceAssignments_WorkPatternID != Guid.Empty)
                {
                    var result = workpattern.Load(Connection, Transaction, pWorkpattern.CMN_BPT_EMP_WorkplaceAssignments_WorkPatternID);
                    if (result.Status != FR_Status.Success || pWorkpattern.CMN_BPT_EMP_WorkplaceAssignments_WorkPatternID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                workpattern.BoundTo_WorkplaceAssignment_RefID = Parameter.BoundTo_WorkplaceAssignment_RefID;
                workpattern.CMN_BPT_STA_AbsenceReason_RefID = pWorkpattern.CMN_BPT_STA_AbsenceReason_RefID;
                workpattern.CMN_PPS_ShiftTemplate_RefID = pWorkpattern.CMN_PPS_ShiftTemplate_RefID;
                workpattern.IsFriday = pWorkpattern.IsFriday;
                workpattern.IsMonday = pWorkpattern.IsMonday;
                workpattern.IsSaturday = pWorkpattern.IsSaturday;
                workpattern.IsSunday = pWorkpattern.IsSunday;
                workpattern.IsThursday = pWorkpattern.IsThursday;
                workpattern.IsTuesday = pWorkpattern.IsTuesday;
                workpattern.IsWednesday = pWorkpattern.IsWednesday;
                workpattern.IsWeek_Even = pWorkpattern.IsWeek_Even;
                workpattern.IsWeek_Odd = pWorkpattern.IsWeek_Odd;
                workpattern.Tenant_RefID = securityTicket.TenantID;
                workpattern.Save(Connection, Transaction);

            }


			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SEWP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SEWP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SEWP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SEWP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Employee_WorkPatterns",ex);
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
FR_Guid cls_Save_Employee_WorkPatterns(,P_L5EM_SEWP_1532 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Employee_WorkPatterns.Invoke(connectionString,P_L5EM_SEWP_1532 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SEWP_1532();
parameter.WorkPatterns = ...;

parameter.BoundTo_WorkplaceAssignment_RefID = ...;

*/