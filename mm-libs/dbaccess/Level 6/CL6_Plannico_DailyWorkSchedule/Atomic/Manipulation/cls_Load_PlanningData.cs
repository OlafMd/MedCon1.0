/* 
 * Generated on 08/05/2014 14:02:15
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
using CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation;
using VacationPlaner.Utils;
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using CL1_CMN_STR_PPS;
using CL1_CMN_CAL;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_LeaveRequest.Atomic.Manipulation;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using VacationPlannerCore.Utils;
using CL1_CMN_PPS;
using System.Threading.Tasks;
using CL5_VacationPlanner_Tenant.Complex.Retrieval;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using VacationPlaner;

namespace CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Load_PlanningData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Load_PlanningData
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L6DWS_LPD_1451_Array Execute(DbConnection Connection, DbTransaction Transaction, P_L6DWS_LPD_1451 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6DWS_LPD_1451_Array();

            LeaveRequestUtils leaveRequestUtil = new LeaveRequestUtils();

            var dayCount = 1;
            if (Parameter.LoadFor_Week)
                dayCount = 7;

            for (int i = 0; i < dayCount; i++)
            {
                var date = Parameter.WorkSheduleDate.Date.AddDays(i);
                if (Parameter.LoadFrom_LastWeek || Parameter.LoadFrom_Specific_Date_Or_Week)
                {
                    P_L5DWS_GDWSWDFT_0946 param = new P_L5DWS_GDWSWDFT_0946();
                    if (Parameter.LoadFrom_Specific_Date_Or_Week)
                        param.WorkSheduleDate = Parameter.IfLoadFrom_Specific_Date_Or_Week_DateTime.AddDays(i);
                    else
                        param.WorkSheduleDate = Parameter.WorkSheduleDate.AddDays(-7).AddDays(i);

                    var lastWeekSchedules = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, param, securityTicket).Result;

                    foreach (var lastWeekSchedule in lastWeekSchedules)
                    {
                        var empInfo = Parameter.EmployeeInformation.FirstOrDefault(x => x.EmployeeID == lastWeekSchedule.Employee_RefID);

                        ORM_CMN_STR_PPS_DailyWorkSchedule.Query dailyWorkScheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                        dailyWorkScheduleQuery.Employee_RefID = lastWeekSchedule.Employee_RefID;
                        dailyWorkScheduleQuery.WorkSheduleDate = date;
                        dailyWorkScheduleQuery.IsDeleted = false;
                        dailyWorkScheduleQuery.Tenant_RefID = securityTicket.TenantID;

                        var oldDailyWorkSchedule = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, dailyWorkScheduleQuery).FirstOrDefault();

                        if (oldDailyWorkSchedule != null)
                        {
                            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query oldDailyWorkScheduleDetailQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query();
                            oldDailyWorkScheduleDetailQuery.DailyWorkSchedule_RefID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                            oldDailyWorkScheduleDetailQuery.IsDeleted = false;
                            oldDailyWorkScheduleDetailQuery.Tenant_RefID = securityTicket.TenantID;

                            var oldDailyWorkScheduleDetails = ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query.Search(Connection, Transaction, oldDailyWorkScheduleDetailQuery);

                            List<P_L6DWS_DDWS_1126_Details> detailsList = new List<P_L6DWS_DDWS_1126_Details>();

                            foreach (var detail in oldDailyWorkScheduleDetails)
                            {
                                ORM_CMN_CAL_Event.Query eventQuery = new ORM_CMN_CAL_Event.Query();
                                eventQuery.CMN_CAL_EventID = detail.CMN_CAL_Event_RefID;
                                eventQuery.IsDeleted = false;
                                eventQuery.Tenant_RefID = securityTicket.TenantID;

                                var detailEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, eventQuery).FirstOrDefault();

                                if (detailEvent != null)
                                {
                                    P_L6DWS_DDWS_1126_Details detailParam = new P_L6DWS_DDWS_1126_Details();
                                    detailParam.DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;
                                    detailParam.durationInDays = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == lastWeekSchedule.Employee_RefID), true);
                                    detailParam.durationInHours = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == lastWeekSchedule.Employee_RefID), false);
                                    detailsList.Add(detailParam);
                                }
                            }


                            P_L6DWS_DDWS_1126 deleteParam = new P_L6DWS_DDWS_1126();
                            deleteParam.CMN_STR_PPS_DailyWorkScheduleID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                            deleteParam.Details = detailsList.ToArray();
                            cls_Delete_DailyWorkSchedule.Invoke(Connection, Transaction, deleteParam, securityTicket);
                        }

                        ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkSchedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                        dailyWorkSchedule.BreakDurationTime_in_sec = lastWeekSchedule.BreakDurationTime_in_sec;
                        dailyWorkSchedule.ContractWorkerText = lastWeekSchedule.ContractWorkerText;
                        dailyWorkSchedule.Employee_RefID = lastWeekSchedule.Employee_RefID;
                        dailyWorkSchedule.InstantiatedWithShiftTemplate_RefID = lastWeekSchedule.InstantiatedWithShiftTemplate_RefID;
                        dailyWorkSchedule.IsBreakTimeManualySpecified = lastWeekSchedule.IsBreakTimeManualySpecified;
                        dailyWorkSchedule.IsWorkShedule_Confirmed = lastWeekSchedule.IsWorkShedule_Confirmed;
                        dailyWorkSchedule.R_ContractSpecified_WorkingTime_in_sec = empInfo.ContractInfo.FirstOrDefault(x => x.Date.Date == date.Date).ContractSpecified_WorkingTime_in_sec;
                        dailyWorkSchedule.R_WorkDay_Duration_in_sec = lastWeekSchedule.R_WorkDay_Duration_in_sec;
                        dailyWorkSchedule.R_WorkDay_End_in_sec = lastWeekSchedule.R_WorkDay_End_in_sec;
                        dailyWorkSchedule.R_WorkDay_Start_in_sec = lastWeekSchedule.R_WorkDay_Start_in_sec;
                        dailyWorkSchedule.SheduleBreakTemplate_RefID = lastWeekSchedule.SheduleBreakTemplate_RefID;
                        dailyWorkSchedule.Tenant_RefID = securityTicket.TenantID;
                        dailyWorkSchedule.WorkingSheduleComment = lastWeekSchedule.WorkingSheduleComment;
                        dailyWorkSchedule.WorkShedule_ConfirmedBy_Account_RefID = lastWeekSchedule.WorkShedule_ConfirmedBy_Account_RefID;
                        dailyWorkSchedule.WorkSheduleDate = date;
                        dailyWorkSchedule.Save(Connection, Transaction);

                        foreach (var lastWeekDetail in lastWeekSchedule.Details)
                        {
                            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail detail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                            detail.AbsenceReason_RefID = lastWeekDetail.AbsenceReason_RefID;
                            if (lastWeekDetail.CMN_CAL_Event_RefID != Guid.Empty)
                            {
                                ORM_CMN_CAL_Event.Query eventQuery = new ORM_CMN_CAL_Event.Query();
                                eventQuery.CMN_CAL_EventID = lastWeekDetail.CMN_CAL_Event_RefID;
                                eventQuery.Tenant_RefID = securityTicket.TenantID;
                                eventQuery.IsDeleted = false;

                                var eventResult = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, eventQuery).FirstOrDefault();
                                ORM_CMN_CAL_Event newEvent = new ORM_CMN_CAL_Event();
                                newEvent.CalendarInstance_RefID = eventResult.CalendarInstance_RefID;
                                newEvent.EndTime = date.AddHours(eventResult.EndTime.TimeOfDay.TotalHours);
                                newEvent.IsCalendarEvent_Editable = eventResult.IsCalendarEvent_Editable;
                                newEvent.IsRepetitive = eventResult.IsRepetitive;
                                newEvent.IsWholeDayEvent = eventResult.IsWholeDayEvent;
                                newEvent.R_EventDuration_sec = eventResult.R_EventDuration_sec;
                                newEvent.Repetition_RefID = eventResult.Repetition_RefID;
                                newEvent.StartTime = date.AddHours(eventResult.StartTime.TimeOfDay.TotalHours);
                                newEvent.Tenant_RefID = securityTicket.TenantID;
                                newEvent.Save(Connection, Transaction);
                                detail.CMN_CAL_Event_RefID = newEvent.CMN_CAL_EventID;

                            }
                            else
                                detail.CMN_CAL_Event_RefID = Guid.Empty;
                            detail.DailyWorkSchedule_RefID = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                            detail.IsWorkBreak = lastWeekDetail.IsWorkBreak;
                            detail.SheduleForWorkplace_RefID = lastWeekDetail.SheduleForWorkplace_RefID;
                            detail.Tenant_RefID = securityTicket.TenantID;


                            if (detail.AbsenceReason_RefID != Guid.Empty)
                            {

                                ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                                leaveRequestEvent.EndTime = date.AddSeconds(lastWeekDetail.ToTime_as_DateTime.TimeOfDay.TotalSeconds);
                                leaveRequestEvent.StartTime = date.AddSeconds(lastWeekDetail.FromTime_as_DateTime.TimeOfDay.TotalSeconds);
                                leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                                leaveRequestEvent.Save(Connection, Transaction);

                                var approvalItem = new ORM_CMN_CAL_Event_Approval();
                                approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                approvalItem.IsApprovalProcessDenied = false;
                                approvalItem.IsApprovalProcessOpened = false;
                                approvalItem.IsApproved = true;

                                var authRequired = true;

                                var absenceReasons = cls_get_Active_AbsenceReason_For_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
                                if (absenceReasons != null)
                                {
                                    if (absenceReasons.Any(r => r.CMN_BPT_STA_AbsenceReasonID == detail.AbsenceReason_RefID))
                                    {
                                        var reason = absenceReasons.FirstOrDefault(r => r.CMN_BPT_STA_AbsenceReasonID == detail.AbsenceReason_RefID);
                                        if (reason != null)
                                        {
                                            authRequired = reason.IsAuthorizationRequired;
                                        }
                                    }
                                }

                                L6TN_GSFT_1017 settings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                                if (settings.NumberOfResponsiblePersonsRequiredToApprove == 0 || !authRequired)
                                {
                                    approvalItem.IsApprovalProcessOpened = false;
                                    approvalItem.IsApproved = true;
                                }
                                else
                                {
                                    approvalItem.IsApprovalProcessOpened = true;
                                    approvalItem.IsApproved = false;
                                }

                                approvalItem.IsApprovalProcessCanceledByUser = false;
                                approvalItem.IsDeleted = false;
                                approvalItem.Creation_Timestamp = DateTime.Now;
                                approvalItem.Tenant_RefID = securityTicket.TenantID;
                                approvalItem.Save(Connection, Transaction);

                                var leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                                leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = detail.AbsenceReason_RefID;
                                leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                                leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                leaveRequest.IsDeleted = false;
                                leaveRequest.RequestedBy_Employee_RefID = Parameter.LoggedEmployeeID;
                                leaveRequest.RequestedFor_Employee_RefID = lastWeekSchedule.Employee_RefID;
                                leaveRequest.Tenant_RefID = securityTicket.TenantID;
                                leaveRequest.Creation_Timestamp = DateTime.Now;
                                leaveRequest.Save(Connection, Transaction);
                                detail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;

                                detail.Save(Connection, Transaction);

                                #region updateStatistics

                                P_L5TN_GCTFFTAY_1320 timeFrameParam = new P_L5TN_GCTFFTAY_1320();
                                timeFrameParam.Year = leaveRequestEvent.StartTime.Year;
                                var timeFrame = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result.CalculationTimeFrame;

                                P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                                statParam.absenceReasonID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                                statParam.employeeID = leaveRequest.RequestedFor_Employee_RefID;
                                statParam.timeFrameID = timeFrame.CMN_CAL_CalculationTimeframeID;
                                var statistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statParam, securityTicket).Result;
                                if (statistics != null)
                                {
                                    P_L5EM_SEARTFS_1356 updateStatisticsParam = new P_L5EM_SEARTFS_1356();
                                    updateStatisticsParam.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                                    updateStatisticsParam.Employee_RefID = statistics.Employee_RefID;
                                    updateStatisticsParam.CalculationTimeframe_RefID = statistics.CalculationTimeframe_RefID;
                                    updateStatisticsParam.AbsenceReason_RefID = statistics.AbsenceReason_RefID;

                                    var durationInDays = leaveRequestUtil.LeaveRequestDuration(leaveRequestEvent.StartTime, leaveRequestEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == leaveRequest.RequestedFor_Employee_RefID), true);
                                    var durationInHours = leaveRequestUtil.LeaveRequestDuration(leaveRequestEvent.StartTime, leaveRequestEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == leaveRequest.RequestedFor_Employee_RefID), false);

                                    if (approvalItem.IsApproved)
                                    {
                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - durationInDays;
                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - durationInHours;

                                        updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                                        updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + durationInDays;
                                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + durationInHours;
                                    }
                                    else
                                    {
                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;

                                        updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays + durationInDays;
                                        updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours + durationInHours;

                                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;
                                    }


                                    var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);

                                }
                                #endregion
                            }
                            else
                            {
                                detail.Save(Connection, Transaction);
                            }

                        }
                    }

                }
                else if (Parameter.LoadFrom_StandardTimes)
                {
                    bool isEven = false;

                    if (CronExtender.weekNumber(date) % 2 == 0)
                        isEven = true;

                    ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query workplaceAssignementQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                    foreach (var empInfo in Parameter.EmployeeInformation)
                    {
                        var empID = empInfo.EmployeeID;
                        workplaceAssignementQuery.CMN_BPT_EMP_Employee_RefID = empID;
                        workplaceAssignementQuery.Tenant_RefID = securityTicket.TenantID;
                        workplaceAssignementQuery.IsDeleted = false;

                        var workplaceAssignements = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, workplaceAssignementQuery);

                        if (workplaceAssignements != null)
                        {

                            var workplaceAssignement = workplaceAssignements.FirstOrDefault(x => x.WorkplaceAssignment_StartDate <= date && (x.WorkplaceAssignment_EndDate >= date || x.WorkplaceAssignment_EndDate == new DateTime()));

                            if (workplaceAssignement != null)
                            {
                                ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query patternQuery = new ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query();
                                patternQuery.BoundTo_WorkplaceAssignment_RefID = workplaceAssignement.CMN_BPT_EMP_Employee_WorkplaceAssignment;
                                patternQuery.Tenant_RefID = securityTicket.TenantID;
                                patternQuery.IsDeleted = false;

                                var patterns = ORM_CMN_BPT_EMP_WorkplaceAssignments_WorkPattern.Query.Search(Connection, Transaction, patternQuery);
                                if (patterns != null)
                                {
                                    foreach (var pattern in patterns)
                                    {
                                        if (pattern.IsWeek_Even == isEven || !pattern.IsWeek_Even && pattern.IsWeek_Odd)
                                        {
                                            switch (date.DayOfWeek)
                                            {
                                                case DayOfWeek.Monday:
                                                    if (!pattern.IsMonday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Tuesday:
                                                    if (!pattern.IsTuesday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Wednesday:
                                                    if (!pattern.IsWednesday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Thursday:
                                                    if (!pattern.IsThursday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Friday:
                                                    if (!pattern.IsFriday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Saturday:
                                                    if (!pattern.IsSaturday)
                                                        continue;
                                                    break;
                                                case DayOfWeek.Sunday:
                                                    if (!pattern.IsSunday)
                                                        continue;
                                                    break;
                                            }


                                            if (pattern.CMN_PPS_ShiftTemplate_RefID == Guid.Empty && pattern.CMN_BPT_STA_AbsenceReason_RefID != Guid.Empty)
                                            {
                                                double totalTime = 0;
                                                DateTime startTime = date.AddMinutes(empInfo.ContractInfo.FirstOrDefault(x => x.Date == date).startTime);
                                                DateTime endTime = date.AddMinutes(empInfo.ContractInfo.FirstOrDefault(x => x.Date == date).endTime);


                                                double startTimeInSec = startTime.TimeOfDay.TotalSeconds;
                                                double endTimeInSec = endTime.TimeOfDay.TotalSeconds;


                                                ORM_CMN_STR_PPS_DailyWorkSchedule.Query dailyWorkScheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                                                dailyWorkScheduleQuery.Employee_RefID = empID;
                                                dailyWorkScheduleQuery.WorkSheduleDate = date;
                                                dailyWorkScheduleQuery.IsDeleted = false;
                                                dailyWorkScheduleQuery.Tenant_RefID = securityTicket.TenantID;

                                                var oldDailyWorkSchedule = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, dailyWorkScheduleQuery).FirstOrDefault();

                                                if (oldDailyWorkSchedule != null)
                                                {
                                                    ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query oldDailyWorkScheduleDetailQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query();
                                                    oldDailyWorkScheduleDetailQuery.DailyWorkSchedule_RefID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                                                    oldDailyWorkScheduleDetailQuery.IsDeleted = false;
                                                    oldDailyWorkScheduleDetailQuery.Tenant_RefID = securityTicket.TenantID;

                                                    var oldDailyWorkScheduleDetails = ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query.Search(Connection, Transaction, oldDailyWorkScheduleDetailQuery);

                                                    List<P_L6DWS_DDWS_1126_Details> detailsList = new List<P_L6DWS_DDWS_1126_Details>();

                                                    foreach (var detail in oldDailyWorkScheduleDetails)
                                                    {
                                                        ORM_CMN_CAL_Event.Query eventQuery = new ORM_CMN_CAL_Event.Query();
                                                        eventQuery.CMN_CAL_EventID = detail.CMN_CAL_Event_RefID;
                                                        eventQuery.IsDeleted = false;
                                                        eventQuery.Tenant_RefID = securityTicket.TenantID;

                                                        var detailEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, eventQuery).FirstOrDefault();

                                                        if (detailEvent != null)
                                                        {
                                                            P_L6DWS_DDWS_1126_Details deleteDetailParam = new P_L6DWS_DDWS_1126_Details();
                                                            deleteDetailParam.DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;
                                                            deleteDetailParam.durationInDays = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), true);
                                                            deleteDetailParam.durationInHours = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), false);
                                                            detailsList.Add(deleteDetailParam);
                                                        }
                                                    }


                                                    P_L6DWS_DDWS_1126 deleteParam = new P_L6DWS_DDWS_1126();
                                                    deleteParam.CMN_STR_PPS_DailyWorkScheduleID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                                                    deleteParam.Details = detailsList.ToArray();
                                                    cls_Delete_DailyWorkSchedule.Invoke(Connection, Transaction, deleteParam, securityTicket);
                                                }

                                                ORM_CMN_STR_PPS_DailyWorkSchedule dailyWorkSchedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                                                dailyWorkSchedule.IsBreakTimeManualySpecified = false;
                                                dailyWorkSchedule.BreakDurationTime_in_sec = 0;

                                                dailyWorkSchedule.R_WorkDay_Start_in_sec = (int)startTimeInSec;
                                                dailyWorkSchedule.R_WorkDay_Duration_in_sec = (int)totalTime;
                                                dailyWorkSchedule.R_WorkDay_End_in_sec = (int)endTimeInSec;
                                                dailyWorkSchedule.R_ContractSpecified_WorkingTime_in_sec = 0;
                                                dailyWorkSchedule.ContractWorkerText = "";
                                                dailyWorkSchedule.Employee_RefID = empID;
                                                dailyWorkSchedule.WorkSheduleDate = date;
                                                dailyWorkSchedule.Tenant_RefID = securityTicket.TenantID;

                                                dailyWorkSchedule.Save(Connection, Transaction);


                                                var durationInDays = leaveRequestUtil.LeaveRequestDuration(date.AddSeconds(startTimeInSec), date.AddSeconds(endTimeInSec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), true);
                                                var durationInHours = leaveRequestUtil.LeaveRequestDuration(date.AddSeconds(startTimeInSec), date.AddSeconds(endTimeInSec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), false);

                                                P_L6DWS_SDWSD_1130 detailParam = new P_L6DWS_SDWSD_1130();
                                                detailParam.WorkTime_Start = dailyWorkSchedule.WorkSheduleDate.AddSeconds(startTimeInSec);
                                                detailParam.WorkTime_End = dailyWorkSchedule.WorkSheduleDate.AddSeconds(endTimeInSec);
                                                detailParam.DailyWorkSchedule_RefID = dailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                                                detailParam.IsWorkBreak = false;
                                                detailParam.SheduleForWorkplace_RefID = Guid.Empty;
                                                detailParam.AbsenceReason_RefID = pattern.CMN_BPT_STA_AbsenceReason_RefID;
                                                detailParam.RequestedBy_Employee_RefID = Guid.Empty;
                                                detailParam.RequestedFor_Employee_RefID = empID;
                                                detailParam.durationInDays = durationInDays;
                                                detailParam.durationInHours = durationInHours;
                                                cls_Save_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, detailParam, securityTicket);
                                            }
                                            else if (pattern.CMN_PPS_ShiftTemplate_RefID != Guid.Empty)
                                            {

                                                ORM_CMN_PPS_ShiftTemplate.Query shiftTemplateQuery = new ORM_CMN_PPS_ShiftTemplate.Query();
                                                shiftTemplateQuery.CMN_PPS_ShiftTemplateID = pattern.CMN_PPS_ShiftTemplate_RefID;
                                                shiftTemplateQuery.Tenant_RefID = securityTicket.TenantID;
                                                shiftTemplateQuery.IsDeleted = false;


                                                var shiftTemplate = ORM_CMN_PPS_ShiftTemplate.Query.Search(Connection, Transaction, shiftTemplateQuery).FirstOrDefault();

                                                if (shiftTemplate != null)
                                                {

                                                    ORM_CMN_STR_PPS_DailyWorkSchedule.Query dailyWorkScheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                                                    dailyWorkScheduleQuery.Employee_RefID = empID;
                                                    dailyWorkScheduleQuery.WorkSheduleDate = date;
                                                    dailyWorkScheduleQuery.IsDeleted = false;
                                                    dailyWorkScheduleQuery.Tenant_RefID = securityTicket.TenantID;

                                                    var oldDailyWorkSchedule = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, dailyWorkScheduleQuery).FirstOrDefault();

                                                    if (oldDailyWorkSchedule != null)
                                                    {
                                                        ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query oldDailyWorkScheduleDetailQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query();
                                                        oldDailyWorkScheduleDetailQuery.DailyWorkSchedule_RefID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                                                        oldDailyWorkScheduleDetailQuery.IsDeleted = false;
                                                        oldDailyWorkScheduleDetailQuery.Tenant_RefID = securityTicket.TenantID;

                                                        var oldDailyWorkScheduleDetails = ORM_CMN_STR_PPS_DailyWorkSchedule_Detail.Query.Search(Connection, Transaction, oldDailyWorkScheduleDetailQuery);

                                                        List<P_L6DWS_DDWS_1126_Details> detailsList = new List<P_L6DWS_DDWS_1126_Details>();

                                                        foreach (var detail in oldDailyWorkScheduleDetails)
                                                        {
                                                            ORM_CMN_CAL_Event.Query eventQuery = new ORM_CMN_CAL_Event.Query();
                                                            eventQuery.CMN_CAL_EventID = detail.CMN_CAL_Event_RefID;
                                                            eventQuery.IsDeleted = false;
                                                            eventQuery.Tenant_RefID = securityTicket.TenantID;

                                                            var detailEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, eventQuery).FirstOrDefault();

                                                            if (detailEvent != null)
                                                            {
                                                                P_L6DWS_DDWS_1126_Details detailParam = new P_L6DWS_DDWS_1126_Details();
                                                                detailParam.DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;
                                                                detailParam.durationInDays = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), true);
                                                                detailParam.durationInHours = leaveRequestUtil.LeaveRequestDuration(detailEvent.StartTime, detailEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == empID), false);
                                                                detailsList.Add(detailParam);
                                                            }
                                                        }


                                                        P_L6DWS_DDWS_1126 deleteParam = new P_L6DWS_DDWS_1126();
                                                        deleteParam.CMN_STR_PPS_DailyWorkScheduleID = oldDailyWorkSchedule.CMN_STR_PPS_DailyWorkScheduleID;
                                                        deleteParam.Details = detailsList.ToArray();
                                                        cls_Delete_DailyWorkSchedule.Invoke(Connection, Transaction, deleteParam, securityTicket);
                                                    }
                                                    P_L5DWS_SDWSFST_1447 param = new P_L5DWS_SDWSFST_1447();
                                                    param.Employee_RefID = empID;
                                                    param.InstantiatedWithShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;
                                                    param.WorkSheduleDate = date;
                                                    param.R_ContractSpecified_WorkingTime_in_sec = empInfo.ContractInfo.FirstOrDefault(x => x.Date == date).ContractSpecified_WorkingTime_in_sec;
                                                    cls_Save_DailyWorkSchedule_For_ShiftTemplate.Invoke(Connection, Transaction, param, securityTicket);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
        public static FR_L6DWS_LPD_1451_Array Invoke(string ConnectionString, P_L6DWS_LPD_1451 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6DWS_LPD_1451_Array Invoke(DbConnection Connection, P_L6DWS_LPD_1451 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6DWS_LPD_1451_Array Invoke(DbConnection Connection, DbTransaction Transaction, P_L6DWS_LPD_1451 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6DWS_LPD_1451_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6DWS_LPD_1451 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6DWS_LPD_1451_Array functionReturn = new FR_L6DWS_LPD_1451_Array();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
                throw new Exception("Exception occured in method cls_Load_PlanningData", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6DWS_LPD_1451_Array : FR_Base
    {
        public L6DWS_LPD_1451[] Result { get; set; }
        public FR_L6DWS_LPD_1451_Array() : base() { }

        public FR_L6DWS_LPD_1451_Array(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes


    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DWS_LPD_1451_Array cls_Load_PlanningData(,P_L6DWS_LPD_1451 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DWS_LPD_1451_Array invocationResult = cls_Load_PlanningData.Invoke(connectionString,P_L6DWS_LPD_1451 Parameter,securityTicket);
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
var parameter = new CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation.P_L6DWS_LPD_1451();
parameter.EmployeeInformation = ...;

parameter.WorkSheduleDate = ...;
parameter.LoggedEmployeeID = ...;
parameter.LoadFor_Week = ...;
parameter.LoadFrom_LastWeek = ...;
parameter.LoadFrom_StandardTimes = ...;
parameter.LoadFrom_Specific_Date_Or_Week = ...;
parameter.IfLoadFrom_Specific_Date_Or_Week_DateTime = ...;
parameter.Events = ...;
parameter.Employees = ...;

*/
