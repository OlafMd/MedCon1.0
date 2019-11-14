/* 
 * Generated on 12/18/2013 11:21:19 AM
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

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employee_WorkPatterns.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employee_WorkPatterns
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEWP_1623_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEWP_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EM_GEWP_1623_Array();
            List<L5EM_GEWP_1623> resultWorkPatterns = new List<L5EM_GEWP_1623>();

            ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query workPatternQuery = new ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query();
            workPatternQuery.BoundTo_WorkplaceAssignment_RefID = Parameter.BoundTo_WorkplaceAssignment_RefID;
            workPatternQuery.IsDeleted = false;
            workPatternQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern> workPatterns=ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query.Search(Connection, Transaction, workPatternQuery);
            foreach (var Workpattern in workPatterns)
            {
                L5EM_GEWP_1623 workPatternItem = new L5EM_GEWP_1623();
                workPatternItem.BoundTo_WorkplaceAssignment_RefID = Workpattern.BoundTo_WorkplaceAssignment_RefID;
                workPatternItem.CMN_BPT_EMP_WorkplaceAssignments_WorkPatternID = Workpattern.CMN_BPT_EMP_WorkplaceAssignments_WorkPatternID;
                workPatternItem.CMN_BPT_STA_AbsenceReason_RefID = Workpattern.CMN_BPT_STA_AbsenceReason_RefID;
                workPatternItem.CMN_PPS_ShiftTemplate_RefID = Workpattern.CMN_PPS_ShiftTemplate_RefID;
                workPatternItem.IsFriday = Workpattern.IsFriday;
                workPatternItem.IsMonday = Workpattern.IsMonday;
                workPatternItem.IsSaturday = Workpattern.IsSaturday;
                workPatternItem.IsSunday = Workpattern.IsSunday;
                workPatternItem.IsThursday = Workpattern.IsThursday;
                workPatternItem.IsTuesday = Workpattern.IsTuesday;
                workPatternItem.IsWednesday = Workpattern.IsWednesday;
                workPatternItem.IsWeek_Even = Workpattern.IsWeek_Even;
                workPatternItem.IsWeek_Odd = Workpattern.IsWeek_Odd;
                resultWorkPatterns.Add(workPatternItem);

            }
            returnValue.Result = resultWorkPatterns.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEWP_1623_Array Invoke(string ConnectionString,P_L5EM_GEWP_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWP_1623_Array Invoke(DbConnection Connection,P_L5EM_GEWP_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWP_1623_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEWP_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEWP_1623_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEWP_1623 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEWP_1623_Array functionReturn = new FR_L5EM_GEWP_1623_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employee_WorkPatterns",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEWP_1623_Array : FR_Base
	{
		public L5EM_GEWP_1623[] Result	{ get; set; } 
		public FR_L5EM_GEWP_1623_Array() : base() {}

		public FR_L5EM_GEWP_1623_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEWP_1623_Array cls_Get_Employee_WorkPatterns(,P_L5EM_GEWP_1623 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEWP_1623_Array invocationResult = cls_Get_Employee_WorkPatterns.Invoke(connectionString,P_L5EM_GEWP_1623 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Complex.Retrieval.P_L5EM_GEWP_1623();
parameter.BoundTo_WorkplaceAssignment_RefID = ...;

*/