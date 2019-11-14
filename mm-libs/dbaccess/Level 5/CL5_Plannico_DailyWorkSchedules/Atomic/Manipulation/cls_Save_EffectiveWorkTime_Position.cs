/* 
 * Generated on 08-May-14 15:40:02
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
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using PlannicoModel.Models;
using CL1_CMN_BPT_EMP;
using CL1_CMN_CAL;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using VacationPlaner.Utils;
using CL1_CMN_STR_PPS;
using CL5_VacationPlanner_Tenant.Complex.Retrieval;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_EffectiveWorkTime_Position.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_EffectiveWorkTime_Position
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5DWS_SEWTP_1337 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here


            LeaveRequestUtils leaveRequestUtil = new LeaveRequestUtils();

            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position effectivePosition = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position();
            if (Parameter.CMN_BPT_EMP_EffectiveWorkTime_PositionID != Guid.Empty)
            {
                var result = effectivePosition.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_EffectiveWorkTime_PositionID);
                if (result.Status != FR_Status.Success || effectivePosition.CMN_BPT_EMP_EffectiveWorkTime_PositionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                effectivePosition.EffectiveWorkTime_Header_RefID = Parameter.EffectiveWorkTime_Header_RefID;
                effectivePosition.CMN_BPT_EMP_Employe_RefID = Parameter.Employee_RefID;
                effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Parameter.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                effectivePosition.Workplace_RefID = Parameter.Workplace_RefID;
                effectivePosition.Tenant_RefID = securityTicket.TenantID;
                effectivePosition.WorkTime_StartTime = Parameter.WorkTime_Start;
                effectivePosition.WorkTime_Duration_in_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                effectivePosition.SourceOfEntry = Parameter.SourceOfEntry;
                effectivePosition.Save(Connection, Transaction);

                if (Parameter.AbsenceReason_RefID != Guid.Empty)
                {
                    P_L5DWS_GDWSWDFPAE_1331 par = new P_L5DWS_GDWSWDFPAE_1331();
                    par.EmployeeID = Parameter.Employee_RefID;
                    par.PeriodStartDate = Parameter.WorkTime_Start.Date;
                    par.PeriodEndDate = Parameter.WorkTime_Start.Date;
                    var planningData = cls_Get_DailyWorkSchedules_WithDetails_For_Period_And_EmployeeID.Invoke(Connection, Transaction, par, securityTicket).Result;
                    if (planningData.DailyWorkSchedulesWithDetails.Length != 0)
                    {
                        var dailyWorkSchedule = planningData.DailyWorkSchedulesWithDetails[0];
                        foreach (var detail in dailyWorkSchedule.Details)
                        {
                            if (detail.LeaveRequest_RefID != Guid.Empty)
                            {
                                ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                                leaveRequest.Load(Connection, Transaction, detail.LeaveRequest_RefID);
                                leaveRequest.Remove(Connection, Transaction);

                                ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                                leaveRequestEvent.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);
                                leaveRequestEvent.Remove(Connection, Transaction);

                                var calQuery = new ORM_CMN_CAL_Event.Query();
                                calQuery.CMN_CAL_EventID = leaveRequest.CMN_CAL_Event_RefID;
                                var calendarRes = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calQuery);
                                ORM_CMN_CAL_Event calendarEvent = calendarRes[0];

                                P_L5TN_GCTFFTAY_1320 timeFrameParam = new P_L5TN_GCTFFTAY_1320();
                                timeFrameParam.Year = leaveRequestEvent.StartTime.Year;
                                var timeFrame = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result.CalculationTimeFrame;

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

                                    updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                                    updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                                    var durationInDays = leaveRequestUtil.LeaveRequestDuration(leaveRequestEvent.StartTime, leaveRequestEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == leaveRequest.RequestedFor_Employee_RefID), true);
                                    var durationInHours = leaveRequestUtil.LeaveRequestDuration(leaveRequestEvent.StartTime, leaveRequestEvent.EndTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == leaveRequest.RequestedFor_Employee_RefID), false);


                                    if (!isApprovedBefore){
                                        updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays - durationInDays ;
                                        updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours - durationInHours ;

                                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;

                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;
                                    }

                                    var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                                }

                                ORM_CMN_STR_PPS_DailyWorkSchedule_Detail scheduleDetail = new ORM_CMN_STR_PPS_DailyWorkSchedule_Detail();
                                result = scheduleDetail.Load(Connection, Transaction, detail.CMN_STR_PPS_DailyWorkSchedule_DetailID);
                                if (result.Status != FR_Status.Success || scheduleDetail.CMN_STR_PPS_DailyWorkSchedule_DetailID == Guid.Empty)
                                {
                                    var error = new FR_Guid();
                                    error.ErrorMessage = "No Such ID.";
                                    error.Status = FR_Status.Error_Internal;
                                    return error;
                                }

                                scheduleDetail.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Guid.Empty;
                                scheduleDetail.Save(Connection, Transaction);
                
                            }
                            
                        }
                    }

                    if (effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID == Guid.Empty)
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
                        approvalItem.IsApprovalProcessOpened = false;
                        approvalItem.IsApproved = true;
                        approvalItem.IsApprovalProcessCanceledByUser = false;
                        approvalItem.IsDeleted = false;
                        approvalItem.Creation_Timestamp = DateTime.Now;
                        approvalItem.Tenant_RefID = securityTicket.TenantID;
                        approvalItem.Save(Connection, Transaction);



                        var requestItem = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                        requestItem.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                        requestItem.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                        requestItem.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                        requestItem.IsDeleted = false;
                        requestItem.RequestedBy_Employee_RefID = Parameter.Employee_RefID;
                        requestItem.RequestedFor_Employee_RefID = Parameter.Employee_RefID;
                        requestItem.Tenant_RefID = securityTicket.TenantID;
                        requestItem.Creation_Timestamp = DateTime.Now;
                        requestItem.LeaveRequestCreationSource = "plannico.time";
                        requestItem.Save(Connection, Transaction);
                        effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = requestItem.CMN_BPT_EMP_Employee_LeaveRequestID;
                        effectivePosition.Save(Connection, Transaction);

                        P_L5TN_GCTFFTAY_1320 timeFrameParam = new P_L5TN_GCTFFTAY_1320();
                        timeFrameParam.Year = leaveRequestEvent.StartTime.Year;
                        var timeFrame = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result.CalculationTimeFrame;

                        P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                        statParam.absenceReasonID = requestItem.CMN_BPT_STA_AbsenceReason_RefID;
                        statParam.employeeID = requestItem.RequestedFor_Employee_RefID;
                        statParam.timeFrameID = timeFrame.CMN_CAL_CalculationTimeframeID;
                        var statistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statParam, securityTicket).Result;
                        if (statistics != null)
                        {
                            P_L5EM_SEARTFS_1356 updateStatisticsParam = new P_L5EM_SEARTFS_1356();
                            updateStatisticsParam.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                            updateStatisticsParam.Employee_RefID = statistics.Employee_RefID;
                            updateStatisticsParam.CalculationTimeframe_RefID = statistics.CalculationTimeframe_RefID;
                            updateStatisticsParam.AbsenceReason_RefID = statistics.AbsenceReason_RefID;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                            updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                            updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours ;


                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays ;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours;

                            var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                        }
                    }
                    else
                    {
                        ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                        leaveRequest.Load(Connection, Transaction, effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID);

                        ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                        leaveRequestEvent.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);
                        if (leaveRequest.CMN_BPT_STA_AbsenceReason_RefID != Parameter.AbsenceReason_RefID || Parameter.OldDurationInHours != Parameter.durationInHours || Parameter.OldDurationInDays != Parameter.durationInDays)
                        {
                            var calQuery = new ORM_CMN_CAL_Event.Query();
                            calQuery.CMN_CAL_EventID = leaveRequest.CMN_CAL_Event_RefID;
                            var calendarRes = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calQuery);
                            ORM_CMN_CAL_Event calendarEvent = calendarRes[0];

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

                                updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                                updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                                updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays + Parameter.OldDurationInDays-Parameter.durationInDays;
                                updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours + Parameter.OldDurationInHours-Parameter.durationInHours;

                                updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                                updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                                updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays - Parameter.OldDurationInDays+Parameter.durationInDays;
                                updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours - Parameter.OldDurationInHours+Parameter.durationInHours;

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
                else
                {
                    if (effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID != Guid.Empty)
                    {
                        ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                        leaveRequest.Load(Connection, Transaction, effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID);
                        leaveRequest.Remove(Connection, Transaction);

                        ORM_CMN_CAL_Event_Approval.Query calEventApprovalQuery = new ORM_CMN_CAL_Event_Approval.Query();
                        calEventApprovalQuery.Event_RefID = leaveRequest.CMN_CAL_Event_RefID;
                        calEventApprovalQuery.IsDeleted = false;
                        calEventApprovalQuery.Tenant_RefID = securityTicket.TenantID;
                        ORM_CMN_CAL_Event_Approval calEventApproval = ORM_CMN_CAL_Event_Approval.Query.Search(Connection, Transaction, calEventApprovalQuery).FirstOrDefault();
                        calEventApproval.Remove(Connection, Transaction);

                        ORM_CMN_CAL_Event leaveRequestEvent = new ORM_CMN_CAL_Event();
                        leaveRequestEvent.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);
                        leaveRequestEvent.Remove(Connection, Transaction);
                        effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Guid.Empty;
                        effectivePosition.Save(Connection, Transaction);

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

                            updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                            updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays + Parameter.OldDurationInDays;
                            updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours + Parameter.OldDurationInHours ;

                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                            updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays - Parameter.OldDurationInDays ;
                            updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours - Parameter.OldDurationInHours ;

                            var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                        }

                    }
                }
            }
            else
            {
                effectivePosition.EffectiveWorkTime_Header_RefID = Parameter.EffectiveWorkTime_Header_RefID;
                effectivePosition.CMN_BPT_EMP_Employe_RefID = Parameter.Employee_RefID;
                effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Parameter.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                effectivePosition.Workplace_RefID = Parameter.Workplace_RefID;
                effectivePosition.Tenant_RefID = securityTicket.TenantID;
                effectivePosition.WorkTime_StartTime = Parameter.WorkTime_Start;
                effectivePosition.WorkTime_Duration_in_sec = (int)Parameter.WorkTime_End.Subtract(Parameter.WorkTime_Start).TotalSeconds;
                effectivePosition.SourceOfEntry = Parameter.SourceOfEntry;
                effectivePosition.Save(Connection, Transaction);

                if (Parameter.AbsenceReason_RefID != Guid.Empty)
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
                    approvalItem.IsApprovalProcessOpened = false;
                    approvalItem.IsApproved = true;
                    approvalItem.IsApprovalProcessCanceledByUser = false;
                    approvalItem.IsDeleted = false;
                    approvalItem.Creation_Timestamp = DateTime.Now;
                    approvalItem.Tenant_RefID = securityTicket.TenantID;
                    approvalItem.Save(Connection, Transaction);

                    var requestItem = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
                    requestItem.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
                    requestItem.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
                    requestItem.CMN_CAL_Event_RefID = leaveRequestEvent.CMN_CAL_EventID;
                    requestItem.IsDeleted = false;
                    requestItem.RequestedBy_Employee_RefID = Parameter.RequestedBy_Employee_RefID;
                    requestItem.RequestedFor_Employee_RefID = Parameter.RequestedFor_Employee_RefID;
                    requestItem.Tenant_RefID = securityTicket.TenantID;
                    requestItem.Creation_Timestamp = DateTime.Now;
                    requestItem.LeaveRequestCreationSource = "plannico.time";
                    requestItem.Save(Connection, Transaction);
                    effectivePosition.CMN_BPT_EMP_Employee_LeaveRequest_RefID = requestItem.CMN_BPT_EMP_Employee_LeaveRequestID;
                    effectivePosition.Save(Connection, Transaction);


                    P_L5TN_GCTFFTAY_1320 timeFrameParam = new P_L5TN_GCTFFTAY_1320();
                    timeFrameParam.Year = leaveRequestEvent.StartTime.Year;
                    var timeFrame = cls_Get_CalculationTimeFramesForTenant_And_Year.Invoke(Connection, Transaction, timeFrameParam, securityTicket).Result.CalculationTimeFrame;

                    P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                    statParam.absenceReasonID = requestItem.CMN_BPT_STA_AbsenceReason_RefID;
                    statParam.employeeID = requestItem.RequestedFor_Employee_RefID;
                    statParam.timeFrameID = timeFrame.CMN_CAL_CalculationTimeframeID;
                    var statistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statParam, securityTicket).Result;
                    if (statistics != null)
                    {
                        P_L5EM_SEARTFS_1356 updateStatisticsParam = new P_L5EM_SEARTFS_1356();
                        updateStatisticsParam.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                        updateStatisticsParam.Employee_RefID = statistics.Employee_RefID;
                        updateStatisticsParam.CalculationTimeframe_RefID = statistics.CalculationTimeframe_RefID;
                        updateStatisticsParam.AbsenceReason_RefID = statistics.AbsenceReason_RefID;

                        updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                        updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays;
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours;


                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays ;
                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours ;

                        var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                    }
                }

            }



            returnValue.Result = effectivePosition.CMN_BPT_EMP_EffectiveWorkTime_PositionID;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L5DWS_SEWTP_1337 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5DWS_SEWTP_1337 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5DWS_SEWTP_1337 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5DWS_SEWTP_1337 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
                throw ex;
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes


    #endregion
}
