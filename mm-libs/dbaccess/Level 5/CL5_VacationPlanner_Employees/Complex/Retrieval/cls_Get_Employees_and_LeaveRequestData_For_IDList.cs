/* 
 * Generated on 2/11/2014 2:50:05 PM
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
using CL5_VacationPlanner_Employees.Atomic.Retrieval;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_And_LeaveRequestData_For_IDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_And_LeaveRequestData_For_IDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEALRDFIDL_1138_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEALRDFIDL_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EM_GEALRDFIDL_1138_Array();
            List<L5EM_GEALRDFIDL_1138> resultList = new List<L5EM_GEALRDFIDL_1138>();
			//Put your code here



            L5EM_GEAAWCFT_1210[] allEmployees = cls_Get_Employees_And_ActiveWorkingContracts_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            L5AR_GART_1118[] allReasons = cls_Get_AbsenceReasons_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var employeeID in Parameter.EmployeeIDList)
            {
                L5EM_GEALRDFIDL_1138 result = new L5EM_GEALRDFIDL_1138();
                L5EM_GEAAWCFT_1210 employee = allEmployees.Where(x => x.CMN_BPT_EMP_EmployeeID == employeeID).FirstOrDefault();
                if (employee == null)
                    continue;
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.CMN_BPT_BusinessParticipantID = employee.CMN_BPT_BusinessParticipantID;
                result.CMN_BPT_EMP_EmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                result.CMN_BPT_EMP_EmploymentRelationshipID = employee.CMN_BPT_EMP_EmploymentRelationshipID;
                result.Work_StartDate = employee.Work_StartDate;
                result.Work_EndDate = employee.Work_EndDate;
                result.CMN_BPT_EMP_WorkingContractID = employee.ActiveWorkingContract.CMN_BPT_EMP_WorkingContractID;
                result.IsContractEndDateDefined = employee.ActiveWorkingContract.IsContractEndDateDefined;
                result.IsWorkTimeCalculated_InDays = employee.ActiveWorkingContract.IsWorkTimeCalculated_InDays;
                result.IsWorkTimeCalculated_InHours = employee.ActiveWorkingContract.IsWorkTimeCalculated_InHours;
                result.Contract_StartDate = employee.ActiveWorkingContract.Contract_StartDate;
                result.Contract_EndDate = employee.ActiveWorkingContract.Contract_EndDate;
                result.R_WorkTime_DaysPerWeek = employee.ActiveWorkingContract.R_WorkTime_DaysPerWeek;
                result.R_WorkTime_HoursPerWeek = employee.ActiveWorkingContract.R_WorkTime_HoursPerWeek;

                List<L5EM_GEALRDFIDL_1138_WeeklyOfficeHour> weeklyOfficeHoursResult = new List<L5EM_GEALRDFIDL_1138_WeeklyOfficeHour>();
                foreach (var weeklyOfficeHours in employee.ActiveWorkingContract.WeeklyOfficeHours)
                {
                    L5EM_GEALRDFIDL_1138_WeeklyOfficeHour weeklyOfficeHourInterval = new L5EM_GEALRDFIDL_1138_WeeklyOfficeHour();
                    weeklyOfficeHourInterval.CMN_CAL_WeeklyOfficeHours_IntervalID = weeklyOfficeHours.CMN_CAL_WeeklyOfficeHours_IntervalID;
                    weeklyOfficeHourInterval.IsWholeDay = weeklyOfficeHours.IsWholeDay;
                    weeklyOfficeHourInterval.TimeFrom_InMinutes = weeklyOfficeHours.TimeFrom_InMinutes;
                    weeklyOfficeHourInterval.TimeTo_InMinutes = weeklyOfficeHours.TimeTo_InMinutes;
                    weeklyOfficeHourInterval.IsMonday = weeklyOfficeHours.IsMonday;
                    weeklyOfficeHourInterval.IsTuesday = weeklyOfficeHours.IsTuesday;
                    weeklyOfficeHourInterval.IsWednesday = weeklyOfficeHours.IsWednesday;
                    weeklyOfficeHourInterval.IsThursday = weeklyOfficeHours.IsThursday;
                    weeklyOfficeHourInterval.IsFriday = weeklyOfficeHours.IsFriday;
                    weeklyOfficeHourInterval.IsSaturday = weeklyOfficeHours.IsSaturday;
                    weeklyOfficeHourInterval.IsSunday = weeklyOfficeHours.IsSunday;
                    weeklyOfficeHoursResult.Add(weeklyOfficeHourInterval);
                }
                result.WeeklyOfficeHours = weeklyOfficeHoursResult.ToArray();
                P_L5EM_GAFE_1216 adjustmentsParam = new P_L5EM_GAFE_1216();
                adjustmentsParam.EmployeeID = employeeID;
                L5EM_GAFE_1216[] adjustmentsForEmployee = cls_get_Adjustments_For_Employee.Invoke(Connection, Transaction, adjustmentsParam, securityTicket).Result;
                List<L5EM_GEALRDFIDL_1138_WorkingContract2LeaveRequest> workingContract2LeaveRequestResult = new List<L5EM_GEALRDFIDL_1138_WorkingContract2LeaveRequest>();

                List<L5EM_GEALRDFIDL_1138_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEALRDFIDL_1138_EmployeeWorkplaceHistory>();

     
                foreach (var workplaceAssignemns in employee.EmployeeWorkplaceHistory)
                {
                    L5EM_GEALRDFIDL_1138_EmployeeWorkplaceHistory item = new L5EM_GEALRDFIDL_1138_EmployeeWorkplaceHistory();
                    item.BoundTo_Workplace_RefID = workplaceAssignemns.BoundTo_Workplace_RefID;
                    item.CMN_BPT_EMP_Employee_PlanGroup_RefID = workplaceAssignemns.CMN_BPT_EMP_Employee_PlanGroup_RefID;
                    item.CMN_BPT_EMP_Employee_WorkplaceAssignmentID = workplaceAssignemns.CMN_BPT_EMP_Employee_WorkplaceAssignmentID;
                    item.Default_BreakTime_Template_RefID = workplaceAssignemns.Default_BreakTime_Template_RefID;
                    item.IsBreakTimeCalculated_Actual = workplaceAssignemns.IsBreakTimeCalculated_Actual;
                    item.IsBreakTimeCalculated_Planning = workplaceAssignemns.IsBreakTimeCalculated_Planning;
                    item.SequenceNumber = workplaceAssignemns.SequenceNumber;
                    item.WorkplaceAssignment_StartDate = workplaceAssignemns.WorkplaceAssignment_StartDate;

                    employeeWorkplaceAssignments.Add(item);
                }

                result.EmployeeWorkplaceHistory = employeeWorkplaceAssignments.ToArray();

                foreach (var absence in employee.ActiveWorkingContract.WorkingContract2LeaveRequest)
                {
                    L5EM_GEALRDFIDL_1138_WorkingContract2LeaveRequest workingContract2LeaveRequest = new L5EM_GEALRDFIDL_1138_WorkingContract2LeaveRequest();
                    L5AR_GART_1118 reason = allReasons.Where(x => x.CMN_BPT_STA_AbsenceReasonID == absence.STA_AbsenceReason_RefID).FirstOrDefault();

                    if (reason == null)
                        continue;

                    workingContract2LeaveRequest.CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID = absence.CMN_BPT_EMP_Employee_WorkingContract_AllowedAbsenceReasonID;
                    workingContract2LeaveRequest.IsAbsenceCalculated_InDays = absence.IsAbsenceCalculated_InDays;
                    workingContract2LeaveRequest.IsAbsenceCalculated_InHours = absence.IsAbsenceCalculated_InHours;
                    workingContract2LeaveRequest.ContractAllowedAbsence_per_Month = absence.ContractAllowedAbsence_per_Month;
                    workingContract2LeaveRequest.AbsenceReasonName = reason.ReasonName;
                    workingContract2LeaveRequest.CMN_BPT_STA_AbsenceReasonID = reason.CMN_BPT_STA_AbsenceReasonID;
                    workingContract2LeaveRequest.AbsenceReason_ParentID = reason.Parent_RefID;
                    workingContract2LeaveRequest.IsAuthorizationRequired = reason.IsAuthorizationRequired;
                    workingContract2LeaveRequest.IsIncludedInCapacityCalculation = reason.IsIncludedInCapacityCalculation;
                    workingContract2LeaveRequest.IsAllowedAbsence = reason.IsAllowedAbsence;
                    workingContract2LeaveRequest.IsDeactivated = reason.IsDeactivated;
                    workingContract2LeaveRequest.IsCarryOverEnabled = reason.IsCarryOverEnabled;
                    
                    L5EM_GAFE_1216[] adjustmentsForAbsenceReason = adjustmentsForEmployee.Where(x => x.CMN_BPT_STA_AbsenceReasonID == workingContract2LeaveRequest.CMN_BPT_STA_AbsenceReasonID).ToArray();

                    List<L5EM_GEALRDFIDL_1138_adjustments> adjustmentsResult = new List<L5EM_GEALRDFIDL_1138_adjustments>();

                    foreach(var adjustment in adjustmentsForAbsenceReason)
                    {
                        L5EM_GEALRDFIDL_1138_adjustments adjustmentResult = new L5EM_GEALRDFIDL_1138_adjustments();
                        adjustmentResult.CMN_BPT_EMP_ContractAbsenceAdjustmentID = adjustment.CMN_BPT_EMP_ContractAbsenceAdjustmentID;
                        adjustmentResult.AbsenceTime_InMinutes = adjustment.AbsenceTime_InMinutes;
                        adjustmentResult.ContractAbsenceAdjustment_Group_RefID = adjustment.CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID;
                        adjustmentResult.IsManual = adjustment.IsManual;
                        adjustmentResult.TriggeringAccount_RefID = adjustment.TriggeringAccount_RefID;
                        adjustmentResult.AdjustmentComment = adjustment.AdjustmentComment;
                        adjustmentResult.AdjustmentDate = adjustment.AdjustmentDate;
                        adjustmentsResult.Add(adjustmentResult);
                    }

                    workingContract2LeaveRequest.Adjustments = adjustmentsResult.ToArray();
                    workingContract2LeaveRequestResult.Add(workingContract2LeaveRequest);
                }
                result.WorkingContract2LeaveRequest = workingContract2LeaveRequestResult.ToArray();
                resultList.Add(result);
            }
            returnValue.Result = resultList.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEALRDFIDL_1138_Array Invoke(string ConnectionString,P_L5EM_GEALRDFIDL_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEALRDFIDL_1138_Array Invoke(DbConnection Connection,P_L5EM_GEALRDFIDL_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEALRDFIDL_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEALRDFIDL_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEALRDFIDL_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEALRDFIDL_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEALRDFIDL_1138_Array functionReturn = new FR_L5EM_GEALRDFIDL_1138_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employees_And_LeaveRequestData_For_IDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEALRDFIDL_1138_Array : FR_Base
	{
		public L5EM_GEALRDFIDL_1138[] Result	{ get; set; } 
		public FR_L5EM_GEALRDFIDL_1138_Array() : base() {}

		public FR_L5EM_GEALRDFIDL_1138_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEALRDFIDL_1138_Array cls_Get_Employees_And_LeaveRequestData_For_IDList(,P_L5EM_GEALRDFIDL_1138 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEALRDFIDL_1138_Array invocationResult = cls_Get_Employees_And_LeaveRequestData_For_IDList.Invoke(connectionString,P_L5EM_GEALRDFIDL_1138 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Complex.Retrieval.P_L5EM_GEALRDFIDL_1138();
parameter.EmployeeIDList = ...;
parameter.CalculationTimeFrameID = ...;

*/