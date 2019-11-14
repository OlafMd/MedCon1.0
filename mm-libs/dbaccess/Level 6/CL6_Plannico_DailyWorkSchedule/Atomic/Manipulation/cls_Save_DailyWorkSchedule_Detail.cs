/* 
 * Generated on 08/05/2014 13:55:57
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
using CL1_CMN_CAL;
using CL1_CMN_STR_PPS;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using CL5_VacationPlanner_LeaveRequest.Atomic.Manipulation;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlannerCore.CustomClasses;
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using CL5_VacationPlanner_Tenant.Complex.Retrieval;
using CL5_VacationPlanner_Absence.Atomic.Retrieval;
using VacationPlaner;

namespace CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_DailyWorkSchedule_Detail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_DailyWorkSchedule_Detail
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L6DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            L6TN_GSFT_1017 settings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            var authRequired = true;

            var absenceReasons = cls_get_Active_AbsenceReason_For_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            if (absenceReasons != null)
            {
                if (absenceReasons.Any(r => r.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceReason_RefID))
                {
                    var reason = absenceReasons.FirstOrDefault(r => r.CMN_BPT_STA_AbsenceReasonID == Parameter.AbsenceReason_RefID);
                    if (reason != null)
                    {
                        authRequired = reason.IsAuthorizationRequired;
                    }
                }
            }

            P_L5DWS_SDWSD_1130 param = new P_L5DWS_SDWSD_1130();
            param.AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
            param.CMN_CAL_Event_RefID = Parameter.CMN_CAL_Event_RefID;
            param.CMN_STR_PPS_DailyWorkSchedule_DetailID = Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID;
            param.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Parameter.LeaveRequest_RefID;
            param.DailyWorkSchedule_RefID = Parameter.DailyWorkSchedule_RefID;
            param.durationInDays = Parameter.durationInDays;
            param.durationInHours = Parameter.durationInHours;
            param.IsWorkBreak = Parameter.IsWorkBreak;
            param.OldDurationInDays = Parameter.OldDurationInDays;
            param.OldDurationInHours = Parameter.OldDurationInHours;
            param.RequestedBy_Employee_RefID = Parameter.RequestedBy_Employee_RefID;
            param.RequestedFor_Employee_RefID = Parameter.RequestedFor_Employee_RefID;
            param.SheduleForWorkplace_RefID = Parameter.SheduleForWorkplace_RefID;
            param.WorkTime_End = Parameter.WorkTime_End;
            param.WorkTime_Start = Parameter.WorkTime_Start;

            var scheduleID = cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, param, securityTicket).Result;

            returnValue = new FR_Guid(scheduleID);


            if (Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID != Guid.Empty && Parameter.AbsenceReason_RefID != Guid.Empty)
            {

                ORM_CMN_CAL_Event.Query calEventQuery = new ORM_CMN_CAL_Event.Query();
                calEventQuery.CMN_CAL_EventID = Parameter.CMN_CAL_Event_RefID;
                calEventQuery.IsDeleted = false;
                calEventQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_CAL_Event calEvent = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calEventQuery).FirstOrDefault();

                ORM_CMN_STR_PPS_DailyWorkSchedule_Detail scheduleDetail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                var result = scheduleDetail.Load(Connection, Transaction, Parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                if (result.Status != FR_Status.Success || scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                if (scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID == Guid.Empty)
                {
                  

                    ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                    leaveRequestEvent.StartTime = Parameter.WorkTime_Start;
                    leaveRequestEvent.EndTime = Parameter.WorkTime_End;
                    leaveRequestEvent.R_EventDuration_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                    leaveRequestEvent.IsRepetitive = false;
                    leaveRequestEvent.IsWholeDayEvent = false;
                    leaveRequestEvent.IsCalendarEvent_Editable = true;
                    leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                    leaveRequestEvent.Save(Connection, Transaction);

                    var approvalItem = new ORM_CMN_CAL_Event_Approval();
                    approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                    approvalItem.IsApprovalProcessDenied = false;
                  
                    if (settings.NumberOfResponsiblePersonsRequiredToApprove == 0 || !authRequired)
                    {
                        approvalItem.IsApproved = true;
                        approvalItem.IsApprovalProcessOpened = false;
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
                    leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                    leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                    leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                    leaveRequest.IsDeleted = false;
                    leaveRequest.RequestedBy_Employee_RefID = Parameter.RequestedBy_Employee_RefID;
                    leaveRequest.RequestedFor_Employee_RefID = Parameter.RequestedFor_Employee_RefID;
                    leaveRequest.Tenant_RefID = securityTicket.TenantID;
                    leaveRequest.Creation_Timestamp = DateTime.Now;
                    leaveRequest.LeaveRequestCreationSource = "plannico.time";
                    leaveRequest.Save(Connection, Transaction);
                    scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    scheduleDetail.Save(Connection, Transaction);



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

                        if (approvalItem.IsApproved)
                        {
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays + Parameter.OldDurationInDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours + Parameter.OldDurationInHours;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;
                        }
                        else
                        {
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;

                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;
                        }

                        var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                    }
                    #endregion


                }
                else
                {
                    ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                    leaveRequest.Load(Connection, Transaction, scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID);

                    Guid oldLeaveRequestID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;

                    ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                    leaveRequestEvent.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);
             
                        var calQuery = new ORM_CMN_CAL_Event.Query();
                        calQuery.CMN_CAL_EventID = leaveRequest.CMN_CAL_Event_RefID;
                        var calendarRes = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calQuery);
                        ORM_CMN_CAL_Event calendarEvent = calendarRes[0];

                        P_L5TN_GCTFFTAY_1320 timeFrameParam = new P_L5TN_GCTFFTAY_1320();
                        timeFrameParam.Year = leaveRequestEvent.StartTime.Year;
                        var timeFrame = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result.CalculationTimeFrame;


                        if (leaveRequestEvent.StartTime.Date != leaveRequestEvent.EndTime.Date)
                        {
                            DateTimeRange firstRange = null;
                            DateTimeRange secondRange = null;
                            DateTimeRange thirdRange = null;

                            ORM_CMN_STR_PPS_DailyWorkSchedule dailySchedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                            dailySchedule.Load(Connection, Transaction, Parameter.DailyWorkSchedule_RefID);

                            if (leaveRequestEvent.StartTime.Date == dailySchedule.WorkSheduleDate)
                            {
                                firstRange = new DateTimeRange();
                                firstRange.Start = Parameter.WorkTime_Start;
                                firstRange.End = Parameter.WorkTime_End;

                                P_L5DWS_GDWSWDFT_0946 dailyScheduleDetailsPar = new P_L5DWS_GDWSWDFT_0946();
                                dailyScheduleDetailsPar.WorkSheduleDate = dailySchedule.WorkSheduleDate.AddDays(1).Date;
                                var schedule = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, dailyScheduleDetailsPar, securityTicket).Result.FirstOrDefault(i => i.Employee_RefID == Parameter.RequestedFor_Employee_RefID);
                                secondRange = new DateTimeRange();
                                if (schedule != null && schedule.Details.Any(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID))
                                {
                                    secondRange.Start = schedule.Details.FirstOrDefault(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID).FromTime_as_DateTime;
                                    secondRange.End = leaveRequestEvent.EndTime;
                                }
                                else
                                    secondRange = null;

                            }
                            else if (leaveRequestEvent.EndTime.Date == dailySchedule.WorkSheduleDate)
                            {
                                firstRange = new DateTimeRange();
                                firstRange.Start = leaveRequestEvent.StartTime;

                                P_L5DWS_GDWSWDFT_0946 dailyScheduleDetailsPar = new P_L5DWS_GDWSWDFT_0946();
                                dailyScheduleDetailsPar.WorkSheduleDate = dailySchedule.WorkSheduleDate.AddDays(-1).Date;
                                var schedule = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, dailyScheduleDetailsPar, securityTicket).Result.FirstOrDefault(i => i.Employee_RefID == Parameter.RequestedFor_Employee_RefID);

                                if (schedule!=null&&schedule.Details.Any(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID))
                                    firstRange.End = schedule.Details.FirstOrDefault(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID).ToTime_as_DateTime;
                                else
                                    firstRange = null;

                                secondRange = new DateTimeRange();
                                secondRange.Start = Parameter.WorkTime_Start;
                                secondRange.End = Parameter.WorkTime_End;
                            }
                            else
                            {
                                firstRange = new DateTimeRange();
                                firstRange.Start = leaveRequestEvent.StartTime;

                                P_L5DWS_GDWSWDFT_0946 dailyScheduleDetailsPar = new P_L5DWS_GDWSWDFT_0946();
                                dailyScheduleDetailsPar.WorkSheduleDate = dailySchedule.WorkSheduleDate.AddDays(-1).Date;
                                var schedule = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, dailyScheduleDetailsPar, securityTicket).Result.FirstOrDefault(i => i.Employee_RefID == Parameter.RequestedFor_Employee_RefID);

                                if (schedule != null && schedule.Details.Any(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID))
                                    firstRange.End = schedule.Details.FirstOrDefault(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID).ToTime_as_DateTime;
                                else
                                    firstRange = null;

                                P_L5DWS_GDWSWDFT_0946 dailyScheduleDetailsParSecond = new P_L5DWS_GDWSWDFT_0946();
                                dailyScheduleDetailsParSecond.WorkSheduleDate = dailySchedule.WorkSheduleDate.AddDays(1).Date;
                                var scheduleSecond = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, dailyScheduleDetailsParSecond, securityTicket).Result.FirstOrDefault(i => i.Employee_RefID == Parameter.RequestedFor_Employee_RefID);
                                secondRange = new DateTimeRange();
                                if (scheduleSecond != null && scheduleSecond.Details.Any(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID))
                                {
                                    secondRange.End = leaveRequestEvent.EndTime;
                                    secondRange.Start = scheduleSecond.Details.FirstOrDefault(i => i.LeaveRequest_RefID == leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID).FromTime_as_DateTime;
                                }
                                else
                                    secondRange = null;

                                thirdRange = new DateTimeRange();

                                thirdRange.Start = Parameter.WorkTime_Start;
                                thirdRange.End = Parameter.WorkTime_End;
                            }

                            #region cancelLeaveRequest

                            P_L5LR_SEAA_1351 ApprovalActionParam = new P_L5LR_SEAA_1351();
                            ApprovalActionParam.Approval_Action_Commnet = "";
                            ApprovalActionParam.CMN_CAL_Event_Approval_ActionID = Guid.Empty;
                            ApprovalActionParam.EventApproval_RefID = leaveRequest.CMN_CAL_Event_Approval_RefID;
                            ApprovalActionParam.IsApproval = false;
                            ApprovalActionParam.IsDenial = false;
                            ApprovalActionParam.IsRevocation = true;
                            cls_Save_Employee_ApprovalAction.Invoke(Connection, Transaction, ApprovalActionParam, securityTicket);



                            var approvalItem = new ORM_CMN_CAL_Event_Approval();
                            if (leaveRequest.CMN_CAL_Event_Approval_RefID != Guid.Empty)
                            {
                                var approvalResult = approvalItem.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_Approval_RefID);
                                if (approvalResult.Status != FR_Status.Success || approvalItem.CMN_CAL_Event_ApprovalID == Guid.Empty)
                                {
                                    var error = new FR_Guid();
                                    error.ErrorMessage = "No Such ID";
                                    error.Status = FR_Status.Error_Internal;
                                    return error;
                                }
                            }

                            bool isApprovedBefore = approvalItem.IsApproved;

                            approvalItem.IsApprovalProcessDenied = false;
                            approvalItem.IsApprovalProcessOpened = false;
                            approvalItem.IsApprovalProcessCanceledByUser = true;
                            approvalItem.IsApproved = false;

                            approvalItem.Save(Connection, Transaction);


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

                                if (isApprovedBefore)
                                {
                                    updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                                    updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                                    updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays  - Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours-  Parameter.OldDurationInHours;

                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays + Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours+Parameter.OldDurationInHours;
                                }
                                else
                                {
                                    updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays - Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours - Parameter.OldDurationInHours;

                                    updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                                    updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;

                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;
                                }
                                var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                            }
                                leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                                leaveRequest.Save(Connection, Transaction);
                            
                            #endregion

                            Guid absenceReasonID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;

                            #region FirstRange

                            if (firstRange != null)
                            {
                                leaveRequestEvent = new ORM_CMN_CAL_Event();
                                leaveRequestEvent.CMN_CAL_EventID = Guid.NewGuid();
                                leaveRequestEvent.StartTime = firstRange.Start;
                                leaveRequestEvent.EndTime = firstRange.End;
                                leaveRequestEvent.R_EventDuration_sec = (int)firstRange.End.Subtract(firstRange.Start).TotalSeconds;
                                leaveRequestEvent.IsRepetitive = false;
                                leaveRequestEvent.IsWholeDayEvent = false;
                                leaveRequestEvent.IsCalendarEvent_Editable = true;
                                leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                                leaveRequestEvent.Save(Connection, Transaction);

                                approvalItem = new ORM_CMN_CAL_Event_Approval();
                                approvalItem.CMN_CAL_Event_ApprovalID = Guid.NewGuid();
                                approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                approvalItem.IsApprovalProcessDenied = false;
                                approvalItem.IsApprovalProcessOpened = false;
                                if (settings.NumberOfResponsiblePersonsRequiredToApprove == 0 || !authRequired)
                                {
                                    approvalItem.IsApproved = true;
                                    approvalItem.IsApprovalProcessOpened = false;
                                }
                                else
                                {
                                    approvalItem.IsApproved = false;
                                    approvalItem.IsApprovalProcessOpened = true;
                                }
                                approvalItem.IsApprovalProcessCanceledByUser = false;
                                approvalItem.IsDeleted = false;
                                approvalItem.Creation_Timestamp = DateTime.Now;
                                approvalItem.Tenant_RefID = securityTicket.TenantID;
                                approvalItem.Save(Connection, Transaction);



                                leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                                leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID = Guid.NewGuid();
                                leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = absenceReasonID;
                                leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                                leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                leaveRequest.IsDeleted = false;
                                leaveRequest.RequestedFor_Employee_RefID = dailySchedule.Employee_RefID;
                                leaveRequest.Tenant_RefID = securityTicket.TenantID;
                                leaveRequest.Creation_Timestamp = DateTime.Now;
                                leaveRequest.LeaveRequestCreationSource = "plannico.time";
                                leaveRequest.Save(Connection, Transaction);


                                P_L5DWS_GDWSWDFP_1225 par = new P_L5DWS_GDWSWDFP_1225();
                                par.StartDate = firstRange.Start;
                                par.EndDate = firstRange.End;
                                var schedulesWithDetails = cls_Get_DailyWorkSchedules_WithDetails_For_Period.Invoke(Connection, Transaction, par, securityTicket).Result.DailyWorkSchedulesWithDetails;

                                foreach (var schedule in schedulesWithDetails)
                                {
                                    if (schedule.Details.Any(i => i.LeaveRequest_RefID == oldLeaveRequestID))
                                    {

                                        foreach (var detailItem in schedule.Details.Where(i => i.LeaveRequest_RefID == oldLeaveRequestID).ToArray())
                                        {
                                            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail detail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                                            detail.Load(Connection, Transaction, detailItem.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                                            detail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                                            detail.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region secondRange
                            if (secondRange != null)
                            {
                                leaveRequestEvent = new ORM_CMN_CAL_Event();
                                leaveRequestEvent.CMN_CAL_EventID = Guid.NewGuid();
                                leaveRequestEvent.StartTime = secondRange.Start;
                                leaveRequestEvent.EndTime = secondRange.End;
                                leaveRequestEvent.R_EventDuration_sec = (int)secondRange.End.Subtract(secondRange.Start).TotalSeconds;
                                leaveRequestEvent.IsRepetitive = false;
                                leaveRequestEvent.IsWholeDayEvent = false;
                                leaveRequestEvent.IsCalendarEvent_Editable = true;
                                leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                                leaveRequestEvent.Save(Connection, Transaction);

                                approvalItem = new ORM_CMN_CAL_Event_Approval();
                                approvalItem.CMN_CAL_Event_ApprovalID = Guid.NewGuid();
                                approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                approvalItem.IsApprovalProcessDenied = false;
                                approvalItem.IsApprovalProcessOpened = false;
                                if (settings.NumberOfResponsiblePersonsRequiredToApprove == 0 || !authRequired)
                                {
                                    approvalItem.IsApproved = true;
                                    approvalItem.IsApprovalProcessOpened = false;
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



                                leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                                leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID = Guid.NewGuid();
                                leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = absenceReasonID;
                                leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                                leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                leaveRequest.IsDeleted = false;
                                leaveRequest.RequestedFor_Employee_RefID = dailySchedule.Employee_RefID;
                                leaveRequest.Tenant_RefID = securityTicket.TenantID;
                                leaveRequest.Creation_Timestamp = DateTime.Now;
                                leaveRequest.LeaveRequestCreationSource = "plannico.time";
                                leaveRequest.Save(Connection, Transaction);
                                
                                P_L5DWS_GDWSWDFP_1225 par = new P_L5DWS_GDWSWDFP_1225();
                                par.StartDate = secondRange.Start;
                                par.EndDate = secondRange.End;
                                var schedulesWithDetails = cls_Get_DailyWorkSchedules_WithDetails_For_Period.Invoke(Connection, Transaction, par, securityTicket).Result.DailyWorkSchedulesWithDetails;

                                foreach (var schedule in schedulesWithDetails)
                                {
                                    if (schedule.Details.Any(i => i.LeaveRequest_RefID == oldLeaveRequestID))
                                    {

                                        foreach (var detailItem in schedule.Details.Where(i => i.LeaveRequest_RefID == oldLeaveRequestID).ToArray())
                                        {
                                            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail detail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                                            detail.Load(Connection, Transaction, detailItem.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                                            detail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                                            detail.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }

                            #endregion

                            #region thirdRange
                            if (thirdRange != null)
                            {
                                leaveRequestEvent = new ORM_CMN_CAL_Event();
                                leaveRequestEvent.CMN_CAL_EventID = Guid.NewGuid();
                                leaveRequestEvent.StartTime = thirdRange.Start;
                                leaveRequestEvent.EndTime = thirdRange.End;
                                leaveRequestEvent.R_EventDuration_sec = (int)thirdRange.End.Subtract(thirdRange.Start).TotalSeconds;
                                leaveRequestEvent.IsRepetitive = false;
                                leaveRequestEvent.IsWholeDayEvent = false;
                                leaveRequestEvent.IsCalendarEvent_Editable = true;
                                leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                                leaveRequestEvent.Save(Connection, Transaction);

                                approvalItem = new ORM_CMN_CAL_Event_Approval();
                                approvalItem.CMN_CAL_Event_ApprovalID = Guid.NewGuid();
                                approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                approvalItem.IsApprovalProcessDenied = false;
                                approvalItem.IsApprovalProcessOpened = false;
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



                                leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                                leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID = Guid.NewGuid();
                                leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = absenceReasonID;
                                leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                                leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                                leaveRequest.IsDeleted = false;
                                leaveRequest.RequestedFor_Employee_RefID = dailySchedule.Employee_RefID;
                                leaveRequest.Tenant_RefID = securityTicket.TenantID;
                                leaveRequest.Creation_Timestamp = DateTime.Now;
                                leaveRequest.LeaveRequestCreationSource = "plannico.time";
                                leaveRequest.Save(Connection, Transaction);


                                P_L5DWS_GDWSWDFP_1225 par = new P_L5DWS_GDWSWDFP_1225();
                                par.StartDate = thirdRange.Start;
                                par.EndDate = thirdRange.End;
                                var schedulesWithDetails = cls_Get_DailyWorkSchedules_WithDetails_For_Period.Invoke(Connection, Transaction, par, securityTicket).Result.DailyWorkSchedulesWithDetails;

                                foreach (var schedule in schedulesWithDetails)
                                {
                                    if (schedule.Details.Any(i => i.LeaveRequest_RefID == oldLeaveRequestID))
                                    {

                                        foreach (var detailItem in schedule.Details.Where(i => i.LeaveRequest_RefID == oldLeaveRequestID).ToArray())
                                        {
                                            ORM_CMN_STR_PPS_DailyWorkSchedule_Detail detail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                                            detail.Load(Connection, Transaction, detailItem.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                                            detail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                                            detail.Save(Connection, Transaction);
                                        }
                                    }
                                }
                            }

                            #endregion     

                            

                        }
                        else
                        {

  
                            leaveRequestEvent.StartTime = Parameter.WorkTime_Start;
                            leaveRequestEvent.EndTime = Parameter.WorkTime_End;
                            leaveRequestEvent.R_EventDuration_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                            leaveRequestEvent.IsRepetitive = false;
                            leaveRequestEvent.IsWholeDayEvent = false;
                            leaveRequestEvent.IsCalendarEvent_Editable = true;
                            leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                            leaveRequestEvent.Save(Connection, Transaction);

                            var approvalItem=new ORM_CMN_CAL_Event_Approval();
                            var approvalItemQuery = new ORM_CMN_CAL_Event_Approval.Query();
                            approvalItemQuery.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                            approvalItemQuery.Tenant_RefID = securityTicket.TenantID;
                            approvalItemQuery.IsDeleted = false;
                            var approvalItems = ORM_CMN_CAL_Event_Approval.Query.Search(Connection, Transaction, approvalItemQuery);
                            if (approvalItems.Count > 0)
                                approvalItem = approvalItems[0];

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

                                if (approvalItem.IsApproved)
                                {
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays + Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours + Parameter.OldDurationInHours;

                                    updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                                    updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                                    updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;
                                }
                                else
                                {
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                                    updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;

                                    updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                                    updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;

                                    updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                                    updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;
                                }
                                var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                            }
                            leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                            leaveRequest.Save(Connection, Transaction);
                        }
                    
                    leaveRequestEvent.StartTime = Parameter.WorkTime_Start;
                    leaveRequestEvent.EndTime = Parameter.WorkTime_End;
                    leaveRequestEvent.R_EventDuration_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                    leaveRequestEvent.Save(Connection, Transaction);
                }
            }
            else if (Parameter.AbsenceReason_RefID != Guid.Empty)
            {
                    ORM_CMN_STR_PPS_DailyWorkSchedule_Detail scheduleDetail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                    if (scheduleID != Guid.Empty)
                    {
                        var result = scheduleDetail.Load(Connection, Transaction, scheduleID);
                        if (result.Status != FR_Status.Success || scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID.";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                    leaveRequestEvent.StartTime = Parameter.WorkTime_Start;
                    leaveRequestEvent.EndTime = Parameter.WorkTime_End;
                    leaveRequestEvent.R_EventDuration_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                    leaveRequestEvent.IsRepetitive = false;
                    leaveRequestEvent.IsWholeDayEvent = false;
                    leaveRequestEvent.IsCalendarEvent_Editable = true;
                    leaveRequestEvent.Tenant_RefID = securityTicket.TenantID;
                    leaveRequestEvent.Save(Connection, Transaction);

                    var approvalItem = new ORM_CMN_CAL_Event_Approval();
                    approvalItem.Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                    approvalItem.IsApprovalProcessDenied = false;
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
                    leaveRequest.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                    leaveRequest.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                    leaveRequest.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                    leaveRequest.IsDeleted = false;
                    leaveRequest.RequestedBy_Employee_RefID = Parameter.RequestedBy_Employee_RefID;
                    leaveRequest.RequestedFor_Employee_RefID = Parameter.RequestedFor_Employee_RefID;
                    leaveRequest.Tenant_RefID = securityTicket.TenantID;
                    leaveRequest.Creation_Timestamp = DateTime.Now;
                    leaveRequest.LeaveRequestCreationSource = "plannico.time";
                    leaveRequest.Save(Connection, Transaction);
                    scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    scheduleDetail.Save(Connection, Transaction);

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

                        if (approvalItem.IsApproved)
                        {
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays + Parameter.OldDurationInDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours + Parameter.OldDurationInHours;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;
                        }
                        else
                        {
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays + Parameter.durationInDays - Parameter.OldDurationInDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours + Parameter.durationInHours - Parameter.OldDurationInHours;

                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;
                        }
                        var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                    #endregion
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
        public static FR_Guid Invoke(string ConnectionString, P_L6DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L6DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L6DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6DWS_SDWSD_1130 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
                throw new Exception("Exception occured in method cls_Save_DailyWorkSchedule_Detail", ex);
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
FR_Guid cls_Save_DailyWorkSchedule_Detail(,P_L6DWS_SDWSD_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DailyWorkSchedule_Detail.Invoke(connectionString,P_L6DWS_SDWSD_1130 Parameter,securityTicket);
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
var parameter = new CL6_Plannico_DailyWorkSchedule.Atomic.Manipulation.P_L6DWS_SDWSD_1130();
parameter.CMN_STR_PPS_DailyWorkSchedule_DetailID = ...;
parameter.DailyWorkSchedule_RefID = ...;
parameter.CMN_CAL_Event_RefID = ...;
parameter.WorkTime_Start = ...;
parameter.WorkTime_End = ...;
parameter.AbsenceReason_RefID = ...;
parameter.SheduleForWorkplace_RefID = ...;
parameter.IsWorkBreak = ...;
parameter.RequestedBy_Employee_RefID = ...;
parameter.RequestedFor_Employee_RefID = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;
parameter.OldDurationInDays = ...;
parameter.OldDurationInHours = ...;

*/
