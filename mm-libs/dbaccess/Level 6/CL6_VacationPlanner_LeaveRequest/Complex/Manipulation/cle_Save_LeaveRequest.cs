/* 
 * Generated on 09/05/2014 13:39:31
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation;
using CL1_CMN_STR_PPS;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;
using CL1_CMN_BPT_EMP;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using VacationPlannerCore.Utils;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using CL1_CMN_CAL;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_LeaveRequest.Atomic.Manipulation;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using VacationPlaner.Utils;
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using VacationPlannerCore.CustomClasses;
using CL1_CMN_BPT_STA;

namespace CL6_VacationPlanner_LeaveRequest.Complex.Manipulation
{
    /// <summary>
    /// No description found in <meta/> tag
    /// <example>
    /// string connectionString = ...;
    /// var result = cle_Save_LeaveRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cle_Save_LeaveRequest
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L6LR_SLR_1142 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            ORM_CMN_BPT_STA_AbsenceReason.Query selectedLeaveTypeQuery = new ORM_CMN_BPT_STA_AbsenceReason.Query();
            selectedLeaveTypeQuery.Tenant_RefID = securityTicket.TenantID;
            selectedLeaveTypeQuery.CMN_BPT_STA_AbsenceReasonID = Parameter.LeaveRequest.AbsenceReason_RefID;
            selectedLeaveTypeQuery.IsDeleted = false;

            var selectedLeaveType = ORM_CMN_BPT_STA_AbsenceReason.Query.Search(Connection, Transaction, selectedLeaveTypeQuery).FirstOrDefault();

            LeaveRequestUtils leaveRequestUtils = new LeaveRequestUtils();

            P_L5LR_SELR_255 par = Parameter.LeaveRequest;
            L6TN_GSFT_1017 settings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            par.NumberOfResponsiblePersonsRequiredToApprove = settings.NumberOfResponsiblePersonsRequiredToApprove;
            if (settings.NumberOfResponsiblePersonsRequiredToApprove == 0 || !Parameter.IsAuthRequired)
            {
                par.IsApprovalProcessOpened = false;
                par.IsApproved = true;
            }
            Guid leaveRequestID = cls_Save_Employee_LeaveRequest.Invoke(Connection, Transaction, par, securityTicket).Result;
            returnValue.Result = leaveRequestID;
            P_L5CT_GER2AAR_1258 getParam = new P_L5CT_GER2AAR_1258();
            getParam.AbsenceReasonID = Parameter.LeaveRequest.AbsenceReason_RefID;
            getParam.ForEmployeeID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
            L5CT_GER2AAR_1258 wc2aar = cls_Get_EmploymentRelationships_2_AllowedAbsenceReasons.Invoke(Connection, Transaction, getParam, securityTicket).Result;
            L5EM_GEFE_1150_WorkingContract activeWorkingContract = new L5EM_GEFE_1150_WorkingContract();
            P_L5EM_GEFE_1150 param = new P_L5EM_GEFE_1150();
            param.EmployeeID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
            var employeeData = cls_Get_Employee_For_EmployeeID.Invoke(Connection, Transaction, param, securityTicket).Result;
            if (employeeData != null && employeeData.WorkingContracts != null)
            {
                activeWorkingContract = employeeData.WorkingContracts.FirstOrDefault(t => t.IsContract_Active == true);
                if (wc2aar == null)
                {
                    if (activeWorkingContract != null)
                    {
                        ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason workingContractToabsenceReason = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason();
                        workingContractToabsenceReason.ContractAllowedAbsence_per_Month = 0;
                        workingContractToabsenceReason.WorkingContract_RefID = activeWorkingContract.CMN_BPT_EMP_WorkingContractID;
                        workingContractToabsenceReason.IsAbsenceCalculated_InDays = activeWorkingContract.IsWorkTimeCalculated_InDays;
                        workingContractToabsenceReason.IsAbsenceCalculated_InHours = activeWorkingContract.IsWorkTimeCalculated_InHours;
                        workingContractToabsenceReason.ContractAllowedAbsence_per_Month = 0;
                        workingContractToabsenceReason.STA_AbsenceReason_RefID = Parameter.LeaveRequest.AbsenceReason_RefID;
                        workingContractToabsenceReason.Tenant_RefID = securityTicket.TenantID;
                        workingContractToabsenceReason.Save(Connection, Transaction);
                    }
                }
            }


            // update statistics ************************************************
            var timeFrame = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.CalculationTimeframe_StartDate.Year == par.StartTime.Year).FirstOrDefault();
            if (timeFrame == null)
            {
                ORM_CMN_CAL_CalculationTimeframe timeFramePar = new ORM_CMN_CAL_CalculationTimeframe();
                timeFramePar.CalculationTimeframe_StartDate = new DateTime(par.StartTime.Year, 1, 1);
                timeFramePar.CalculationTimefrate_EndDate = new DateTime(0);
                timeFramePar.CalculationTimeframe_EstimatedEndDate = new DateTime(par.StartTime.Year, 12, 31);
                timeFramePar.IsCalculationTimeframe_Active = false;
                timeFramePar.Tenant_RefID = securityTicket.TenantID;
                timeFramePar.Save(Connection, Transaction);
                L5EM_GEFT_0959[] employees = cls_Get_Employees_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
                foreach (var emp in employees)
                {
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe workingContactTimeFrame = new ORM_CMN_BPT_EMP_EmploymentRelationship_Timeframe();
                    workingContactTimeFrame.CalculationTimeframe_RefID = timeFramePar.CMN_CAL_CalculationTimeframeID;
                    workingContactTimeFrame.CMN_BPT_EMP_EmploymentRelationship_TimeframeID = emp.CMN_BPT_EMP_EmploymentRelationshipID;
                    workingContactTimeFrame.Tenant_RefID = securityTicket.TenantID;
                    workingContactTimeFrame.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic timeFrameStatisticsPar = new ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic();
                timeFrameStatisticsPar.AbsenceReason_RefID = par.AbsenceReason_RefID;
                timeFrameStatisticsPar.CalculationTimeframe_RefID = timeFramePar.CMN_CAL_CalculationTimeframeID;
                timeFrameStatisticsPar.Employee_RefID = par.RequestedFor_Employee_RefID;
                timeFrameStatisticsPar.R_AbsenceCarryOver_InDays = 0;
                timeFrameStatisticsPar.R_AbsenceCarryOver_InHours = 0;
                double timeToSubtractDays = 0;
                double timeToSubtractHours = 0;

                if (par.IsApproved)
                {
                    timeToSubtractDays = Parameter.durationInDays;
                    timeToSubtractHours = Parameter.durationInHours;
                    timeFrameStatisticsPar.R_RequestReservedAbsence_InDays = 0;
                    timeFrameStatisticsPar.R_RequestReservedAbsence_InHours = 0;
                    timeFrameStatisticsPar.R_AbsenceTimeUsed_InDays = Parameter.durationInDays;
                    timeFrameStatisticsPar.R_AbsenceTimeUsed_InHours = Parameter.durationInHours;
                }
                else
                {
                    timeFrameStatisticsPar.R_RequestReservedAbsence_InDays = Parameter.durationInDays;
                    timeFrameStatisticsPar.R_RequestReservedAbsence_InHours = Parameter.durationInDays;
                    timeFrameStatisticsPar.R_AbsenceTimeUsed_InDays = 0;
                    timeFrameStatisticsPar.R_AbsenceTimeUsed_InHours = 0;
                }
                if (wc2aar != null && activeWorkingContract != null)
                {
                    if (wc2aar.IsAbsenceCalculated_InDays)
                    {

                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = wc2aar.ContractAllowedAbsence_per_Month - timeToSubtractDays;
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = WeeklyOfficeHoursUtils.DaysToHoursPeriod(leaveRequestUtils.PresiPatch(activeWorkingContract.WeeklyOfficeHours), wc2aar.ContractAllowedAbsence_per_Month - timeToSubtractHours);
                    }
                    else
                    {
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = WeeklyOfficeHoursUtils.HoursToDaysPeriod(leaveRequestUtils.PresiPatch(activeWorkingContract.WeeklyOfficeHours), wc2aar.ContractAllowedAbsence_per_Month - timeToSubtractDays);
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = wc2aar.ContractAllowedAbsence_per_Month - timeToSubtractHours;
                    }
                }
                else
                {
                    timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = 0;
                    timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = 0;
                }
                timeFrameStatisticsPar.Tenant_RefID = securityTicket.TenantID;
                timeFrameStatisticsPar.Save(Connection, Transaction);
            }
            else
            {

                P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                statParam.absenceReasonID = Parameter.LeaveRequest.AbsenceReason_RefID;
                statParam.employeeID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
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

                    if (par.IsApproved)
                    {
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays;
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours;

                        updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays;
                        updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours;

                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays;
                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours;
                    }
                    else
                    {
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays;
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours;

                        updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays + Parameter.durationInDays;
                        updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours + Parameter.durationInHours;

                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays;
                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours;
                    }
                    var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                }
                else
                {
                    ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic timeFrameStatisticsPar = new ORM_CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatistic();
                    timeFrameStatisticsPar.AbsenceReason_RefID = par.AbsenceReason_RefID;
                    timeFrameStatisticsPar.CalculationTimeframe_RefID = timeFrame.CMN_CAL_CalculationTimeframeID;
                    timeFrameStatisticsPar.Employee_RefID = par.RequestedFor_Employee_RefID;
                    timeFrameStatisticsPar.R_AbsenceCarryOver_InDays = 0;
                    timeFrameStatisticsPar.R_AbsenceCarryOver_InHours = 0;
                    double timeToSubtractDays = 0;
                    double timeToSubtractHours = 0;

                    if (par.IsApproved)
                    {
                        timeToSubtractDays = Parameter.durationInDays;
                        timeToSubtractHours = Parameter.durationInHours;
                        timeFrameStatisticsPar.R_RequestReservedAbsence_InDays = 0;
                        timeFrameStatisticsPar.R_RequestReservedAbsence_InHours = 0;
                        timeFrameStatisticsPar.R_AbsenceTimeUsed_InDays = Parameter.durationInDays;
                        timeFrameStatisticsPar.R_AbsenceTimeUsed_InHours = Parameter.durationInHours;
                    }
                    else
                    {
                        timeFrameStatisticsPar.R_RequestReservedAbsence_InDays = Parameter.durationInDays;
                        timeFrameStatisticsPar.R_RequestReservedAbsence_InHours = Parameter.durationInDays;
                        timeFrameStatisticsPar.R_AbsenceTimeUsed_InDays = 0;
                        timeFrameStatisticsPar.R_AbsenceTimeUsed_InHours = 0;
                    }
                    if (wc2aar != null && activeWorkingContract != null)
                    {


                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = 0;
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = 0;

                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = 0;
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = 0;

                    }
                    else
                    {
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InDays = 0;
                        timeFrameStatisticsPar.R_TotalAllowedAbsenceTime_InHours = 0;
                    }
                    timeFrameStatisticsPar.Tenant_RefID = securityTicket.TenantID;
                    timeFrameStatisticsPar.Save(Connection, Transaction);
                }
            }

            //cls_get

            // statistics update end :)

            //Create daily work schedule
            DateTime startTime = Parameter.LeaveRequest.StartTime;
            while (startTime.Date <= Parameter.LeaveRequest.EndTime.Date)
            {
                ORM_CMN_STR_PPS_DailyWorkSchedule.Query scheduleQuery = new ORM_CMN_STR_PPS_DailyWorkSchedule.Query();
                scheduleQuery.Tenant_RefID = securityTicket.TenantID;
                scheduleQuery.IsDeleted = false;
                scheduleQuery.WorkSheduleDate = startTime.Date;
                scheduleQuery.Employee_RefID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
                List<ORM_CMN_STR_PPS_DailyWorkSchedule> workSechedules = ORM_CMN_STR_PPS_DailyWorkSchedule.Query.Search(Connection, Transaction, scheduleQuery);

                if (workSechedules.Count == 0)
                {
                    ORM_CMN_STR_PPS_DailyWorkSchedule schedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                    var workingTimeInHours = 0.0;
                    var daysFromContractTerm = WeeklyOfficeHoursUtils.DaysFromContractTerm(leaveRequestUtils.PresiPatch(activeWorkingContract.WeeklyOfficeHours));
                    var dayFromContractTerm = daysFromContractTerm.FirstOrDefault(x => x.dayOfWeek == startTime.DayOfWeek);

                    if (dayFromContractTerm != null)
                        workingTimeInHours = (double)dayFromContractTerm.hours;

                    TimeSpan workingTimeSpan = TimeSpan.FromHours(workingTimeInHours);
                    var workingHours = workingTimeSpan.Hours;
                    var workingMinutes = workingTimeSpan.Minutes;
                    var workingSeconds = workingTimeSpan.Seconds;


                    DateTime detailStartTime; ;
                    DateTime detailEndTime;

                    if (startTime.Date == Parameter.LeaveRequest.StartTime.Date)
                    {
                        detailStartTime = startTime;
                        if (startTime.Hour + workingTimeInHours < 24)
                        {
                            var newEndTime = startTime.TimeOfDay + workingTimeSpan;
                            detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, newEndTime.Hours, newEndTime.Minutes, newEndTime.Seconds);
                        }
                        else
                        {
                            detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59);
                        }
                    }
                    else if (startTime.Date == Parameter.LeaveRequest.EndTime.Date)
                    {
                        if (Parameter.LeaveRequest.EndTime.TimeOfDay > workingTimeSpan)
                        {
                            var newStartTime = Parameter.LeaveRequest.EndTime.TimeOfDay - workingTimeSpan;
                            detailStartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, newStartTime.Hours, newStartTime.Minutes, newStartTime.Seconds);
                        }
                        else
                        {
                            detailStartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
                        }
                        detailEndTime = Parameter.LeaveRequest.EndTime;
                    }
                    else
                    {
                        int hours = (int)Parameter.WorkTimeStart / (int)60;
                        int mintues = Parameter.WorkTimeStart - hours * 60;
                        detailStartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours, mintues, 0);
                        if (hours + workingTimeSpan.Hours >= 24)
                        {
                            if (mintues + workingTimeSpan.Minutes >= 60)
                            {
                                detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours + workingTimeSpan.Hours - 24, workingTimeSpan.Minutes, workingTimeSpan.Seconds);
                            }
                            else
                            {
                                detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours + workingTimeSpan.Hours - 24, workingTimeSpan.Minutes - 60, workingTimeSpan.Seconds);
                            }

                        }
                        else
                        {
                            if (mintues + workingTimeSpan.Minutes >= 60)
                            {
                                detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours + workingTimeSpan.Hours, workingTimeSpan.Minutes - 60, workingTimeSpan.Seconds);
                            }
                            else
                            {
                                detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, hours + workingTimeSpan.Hours, workingTimeSpan.Minutes, workingTimeSpan.Seconds);
                            }
                        }
                    }

                    schedule.Employee_RefID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
                    schedule.ContractWorkerText = "";
                    schedule.BreakDurationTime_in_sec = 0;
                    schedule.IsBreakTimeManualySpecified = false;
                    schedule.IsWorkShedule_Confirmed = false;
                    schedule.R_ContractSpecified_WorkingTime_in_sec = (int)workingTimeSpan.TotalSeconds;
                    if (selectedLeaveType.IsLeaveTimeReducing_WorkingHours)
                        schedule.R_WorkDay_Duration_in_sec = (int)detailEndTime.Subtract(detailStartTime).TotalSeconds;
                    else
                        schedule.R_WorkDay_Duration_in_sec = 0;
                    schedule.R_WorkDay_Start_in_sec = (int)new TimeSpan(detailStartTime.Hour, detailStartTime.Minute, detailStartTime.Second).TotalSeconds;
                    schedule.R_WorkDay_End_in_sec = (int)detailEndTime.Subtract(detailStartTime).TotalSeconds;
                    schedule.SheduleBreakTemplate_RefID = Guid.Empty;
                    schedule.Tenant_RefID = securityTicket.TenantID;
                    schedule.WorkingSheduleComment = "";
                    schedule.WorkShedule_ConfirmedBy_Account_RefID = Guid.Empty;
                    schedule.WorkSheduleDate = startTime.Date;
                    schedule.InstantiatedWithShiftTemplate_RefID = Guid.Empty;
                    schedule.Save(Connection, Transaction);




                    P_L5DWS_SDWSD_1130 detailParam = new P_L5DWS_SDWSD_1130();
                    detailParam.WorkTime_Start = detailStartTime;
                    detailParam.WorkTime_End = detailEndTime;
                    detailParam.DailyWorkSchedule_RefID = schedule.CMN_STR_PPS_DailyWorkScheduleID;
                    detailParam.IsWorkBreak = false;
                    detailParam.SheduleForWorkplace_RefID = Guid.Empty;
                    detailParam.AbsenceReason_RefID = Parameter.LeaveRequest.AbsenceReason_RefID;
                    detailParam.RequestedBy_Employee_RefID = Parameter.LeaveRequest.RequestedBy_Employee_RefID;
                    detailParam.RequestedFor_Employee_RefID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
                    detailParam.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequestID;
                    detailParam.createRequest = false;
                    cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, detailParam, securityTicket);


                }
                else
                {
                    var dwsParam = new P_L5DWS_GDWSWDFT_0946();
                    dwsParam.WorkSheduleDate = startTime.Date;
                    var resultDailyWorkSchedule = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, dwsParam, securityTicket);
                    LeaveRequestUtils leaveRequestUtil = new LeaveRequestUtils();
                    var dailySchedule = resultDailyWorkSchedule.Result.FirstOrDefault(i => i.Employee_RefID == Parameter.LeaveRequest.RequestedFor_Employee_RefID);
                    foreach (var detail in dailySchedule.Details)
                    {

                        var durationInDays = leaveRequestUtil.LeaveRequestDuration(detail.FromTime_as_DateTime, detail.ToTime_as_DateTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == Parameter.LeaveRequest.RequestedFor_Employee_RefID), true);
                        var durationInHours = leaveRequestUtil.LeaveRequestDuration(detail.FromTime_as_DateTime, detail.ToTime_as_DateTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == Parameter.LeaveRequest.RequestedFor_Employee_RefID), false);
                        P_L5DWS_DDWSDFIDL_1014 deleteParam = new P_L5DWS_DDWSDFIDL_1014();
                        deleteParam.DailyWorkSchedule_DetailID = detail.CMN_STR_PPS_DailyWorkSchedule_DetailID;

                        var scheduleID = cls_Delete_Employee_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, deleteParam, securityTicket);

                    }
                    ORM_CMN_STR_PPS_DailyWorkSchedule schedule = new ORM_CMN_STR_PPS_DailyWorkSchedule();
                    schedule.Load(Connection, Transaction, dailySchedule.CMN_STR_PPS_DailyWorkScheduleID);

                    var workingTimeInHours = 0;
                    var daysFromContractTerm = WeeklyOfficeHoursUtils.DaysFromContractTerm(leaveRequestUtils.PresiPatch(activeWorkingContract.WeeklyOfficeHours));
                    var dayFromContractTerm = daysFromContractTerm.FirstOrDefault(x => x.dayOfWeek == startTime.DayOfWeek);

                    if (dayFromContractTerm != null)
                        workingTimeInHours = (int)dayFromContractTerm.hours;


                    DateTime detailStartTime; ;
                    DateTime detailEndTime;

                    if (startTime.Date == Parameter.LeaveRequest.StartTime.Date)
                    {
                        detailStartTime = startTime;
                        detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59);
                    }
                    else if (startTime.Date == Parameter.LeaveRequest.EndTime.Date)
                    {
                        detailStartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
                        detailEndTime = Parameter.LeaveRequest.EndTime;
                    }
                    else
                    {
                        detailStartTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 0, 0, 0);
                        detailEndTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, 23, 59, 59);
                    }

                    schedule.Employee_RefID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
                    schedule.ContractWorkerText = "";
                    schedule.BreakDurationTime_in_sec = 0;
                    schedule.IsBreakTimeManualySpecified = false;
                    schedule.IsWorkShedule_Confirmed = false;
                    schedule.R_ContractSpecified_WorkingTime_in_sec = workingTimeInHours * 360;
                    if (selectedLeaveType.IsLeaveTimeReducing_WorkingHours)
                        schedule.R_WorkDay_Duration_in_sec = (int)detailEndTime.Subtract(detailStartTime).TotalSeconds;
                    else
                        schedule.R_WorkDay_Duration_in_sec = 0;
                    schedule.R_WorkDay_Start_in_sec = (int)new TimeSpan(detailStartTime.Hour, detailStartTime.Minute, detailStartTime.Second).TotalSeconds;
                    schedule.R_WorkDay_End_in_sec = schedule.R_WorkDay_Start_in_sec + (int)detailEndTime.Subtract(detailStartTime).TotalSeconds;
                    schedule.SheduleBreakTemplate_RefID = Guid.Empty;
                    schedule.Tenant_RefID = securityTicket.TenantID;
                    schedule.WorkingSheduleComment = "";
                    schedule.WorkShedule_ConfirmedBy_Account_RefID = Guid.Empty;
                    schedule.WorkSheduleDate = startTime.Date;
                    schedule.InstantiatedWithShiftTemplate_RefID = Guid.Empty;
                    schedule.Save(Connection, Transaction);




                    P_L5DWS_SDWSD_1130 detailParam = new P_L5DWS_SDWSD_1130();
                    detailParam.WorkTime_Start = detailStartTime;
                    detailParam.WorkTime_End = detailEndTime;
                    detailParam.DailyWorkSchedule_RefID = schedule.CMN_STR_PPS_DailyWorkScheduleID;
                    detailParam.IsWorkBreak = false;
                    detailParam.SheduleForWorkplace_RefID = Guid.Empty;
                    detailParam.AbsenceReason_RefID = Parameter.LeaveRequest.AbsenceReason_RefID;
                    detailParam.RequestedBy_Employee_RefID = Parameter.LeaveRequest.RequestedBy_Employee_RefID;
                    detailParam.RequestedFor_Employee_RefID = Parameter.LeaveRequest.RequestedFor_Employee_RefID;
                    detailParam.CMN_BPT_EMP_Employee_LeaveRequest_RefID = leaveRequestID;
                    detailParam.createRequest = false;
                    cls_Save_Employee_DailyWorkSchedule_Detail.Invoke(Connection, Transaction, detailParam, securityTicket);

                }
                startTime = startTime.AddDays(1);
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L6LR_SLR_1142 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L6LR_SLR_1142 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L6LR_SLR_1142 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6LR_SLR_1142 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cle_Save_LeaveRequest", ex);
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
FR_Guid cle_Save_LeaveRequest(,P_L6LR_SLR_1142 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cle_Save_LeaveRequest.Invoke(connectionString,P_L6LR_SLR_1142 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_LeaveRequest.Complex.Manipulation.P_L6LR_SLR_1142();
parameter.LeaveRequest = ...;
parameter.WorkingContractToLeaveRequestID = ...;
parameter.IsAuthRequired = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;
parameter.Events = ...;
parameter.Employees = ...;

*/
