/* 
 * Generated on 09-May-14 16:10:09
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
using CL5_Plannico_DailyWorkSchedules.Complex.Retrieval;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PPS;
using VacationPlannerCore.Utils;
using VacationPlaner.Utils;
using VacationPlaner;

namespace CL5_Plannico_DailyWorkSchedules.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Load_Employee_ActualData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Load_Employee_ActualData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5DWS_LAD_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            FR_Base returnValue = new FR_Base();


            var dayCount = 1;
            if (Parameter.LoadFor_Week)
                dayCount = 7;

            LeaveRequestUtils leaveRequestUtil = new LeaveRequestUtils();

            for (int i = 0; i < dayCount; i++)
            {
                var date = Parameter.WorkSheduleDate.Date.AddDays(i);
                if (Parameter.LoadFrom_LastWeek || Parameter.LoadFrom_Specific_Date_Or_Week)
                {
                    DateTime loadForDate;

                    if (Parameter.LoadFrom_Specific_Date_Or_Week)
                        loadForDate = Parameter.IfLoadFrom_Specific_Date_Or_Week_DateTime.AddDays(i);
                    else
                        loadForDate = Parameter.WorkSheduleDate.AddDays(-7).AddDays(i);



                    ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query actualsQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                    actualsQuery.EffectiveBusinessDay = loadForDate;
                    actualsQuery.Tenant_RefID = securityTicket.TenantID;
                    actualsQuery.IsDeleted = false;

                    var allEffectiveWorkTimeHeadersToLoadFrom = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, actualsQuery);

                    foreach (var effectiveWorkTimeHeader in allEffectiveWorkTimeHeadersToLoadFrom)
                    {
                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeToDeleteQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                        effectiveWorkTimeToDeleteQuery.EffectiveBusinessDay = date;
                        effectiveWorkTimeToDeleteQuery.Employee_RefID = effectiveWorkTimeHeader.Employee_RefID;
                        effectiveWorkTimeToDeleteQuery.Tenant_RefID = securityTicket.TenantID;
                        effectiveWorkTimeToDeleteQuery.IsDeleted = false;

                        var effectiveWorkTimeHeaderToDeleteQueryResult = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeToDeleteQuery);

                        if (effectiveWorkTimeHeaderToDeleteQueryResult.Count != 0)
                        {
                            var effectiveWorkTimeHeaderToDelete = effectiveWorkTimeHeaderToDeleteQueryResult.FirstOrDefault();
                            P_L5DWS_DEWTH_1126 deleteParam = new P_L5DWS_DEWTH_1126();
                            deleteParam.CMN_STR_PPS_EffectiveWorkTime_HeaderID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;

                            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionsQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
                            positionsQuery.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                            positionsQuery.Tenant_RefID = securityTicket.TenantID;
                            positionsQuery.IsDeleted = false;

                            var positions = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionsQuery);

                            List<P_L5DWS_DEWTH_1126_Positions> listOfPositions = new List<P_L5DWS_DEWTH_1126_Positions>();

                            foreach (var position in positions)
                            {
                                P_L5DWS_DEWTH_1126_Positions positionItem = new P_L5DWS_DEWTH_1126_Positions();
                                positionItem.CMN_BPT_EMP_EffectiveWorkTime_PositionID = position.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
                                positionItem.durationInDays = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), true);
                                positionItem.durationInHours = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), false);
                                listOfPositions.Add(positionItem);
                            }

                            deleteParam.Positions = listOfPositions.ToArray();
                            cls_Delete_EffectiveWorkTime_Header.Invoke(Connection, Transaction, deleteParam, securityTicket);
                        }

                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionsToLoadQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
                        positionsToLoadQuery.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                        positionsToLoadQuery.Tenant_RefID = securityTicket.TenantID;
                        positionsToLoadQuery.IsDeleted = false;

                        var positionsToLoad = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionsToLoadQuery);

                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Header newHeader = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();
                        newHeader.ContractWorkerText = effectiveWorkTimeHeader.ContractWorkerText;
                        newHeader.BreakDurationTime_in_sec = effectiveWorkTimeHeader.BreakDurationTime_in_sec;
                        newHeader.EffectiveBusinessDay = date;
                        newHeader.Employee_RefID = effectiveWorkTimeHeader.Employee_RefID;
                        newHeader.IsBreakTimeManualySpecified = effectiveWorkTimeHeader.IsBreakTimeManualySpecified;
                        newHeader.SheduleBreakTemplate_RefID = effectiveWorkTimeHeader.SheduleBreakTemplate_RefID;
                        newHeader.Tenant_RefID = securityTicket.TenantID;
                        newHeader.Save(Connection, Transaction);

                        foreach (var positionToLoad in positionsToLoad)
                        {
                            P_L5DWS_SEWTP_1337 positionSavePar = new P_L5DWS_SEWTP_1337();
                            if (positionToLoad.CMN_BPT_EMP_Employee_LeaveRequest_RefID != Guid.Empty)
                            {
                                ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query lrQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
                                lrQuery.CMN_BPT_EMP_Employee_LeaveRequestID = positionToLoad.CMN_BPT_EMP_Employee_LeaveRequest_RefID;
                                lrQuery.IsDeleted = false;
                                lrQuery.Tenant_RefID = securityTicket.TenantID;

                                var leaveRequest = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, lrQuery).FirstOrDefault();

                                positionSavePar.AbsenceReason_RefID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                                positionSavePar.durationInDays = leaveRequestUtil.LeaveRequestDuration(positionToLoad.WorkTime_StartTime, positionToLoad.WorkTime_StartTime.AddSeconds(positionToLoad.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == positionToLoad.CMN_BPT_EMP_Employe_RefID), true);
                                positionSavePar.durationInHours = leaveRequestUtil.LeaveRequestDuration(positionToLoad.WorkTime_StartTime, positionToLoad.WorkTime_StartTime.AddSeconds(positionToLoad.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == positionToLoad.CMN_BPT_EMP_Employe_RefID), false);
                                positionSavePar.RequestedBy_Employee_RefID = leaveRequest.RequestedBy_Employee_RefID;
                                positionSavePar.RequestedFor_Employee_RefID = leaveRequest.RequestedFor_Employee_RefID;
                            }
                            else
                            {
                                positionSavePar.AbsenceReason_RefID = Guid.Empty;
                                positionSavePar.durationInDays = 0;
                                positionSavePar.durationInHours = 0;
                                positionSavePar.RequestedBy_Employee_RefID = Guid.Empty;
                                positionSavePar.RequestedFor_Employee_RefID = Guid.Empty;
                            }

                            positionSavePar.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Guid.Empty;
                            positionSavePar.EffectiveWorkTime_Header_RefID = newHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                            positionSavePar.Employee_RefID = newHeader.Employee_RefID;
                            positionSavePar.OldDurationInDays = 0;
                            positionSavePar.OldDurationInHours = 0;
                            positionSavePar.Workplace_RefID = positionToLoad.Workplace_RefID;
                            positionSavePar.WorkTime_End = positionToLoad.WorkTime_StartTime.AddSeconds(positionToLoad.WorkTime_Duration_in_sec);
                            positionSavePar.WorkTime_Start = positionToLoad.WorkTime_StartTime;

                            cls_Save_EffectiveWorkTime_Position.Invoke(Connection, Transaction, positionSavePar, securityTicket);
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
                                                DateTime startTime = date;
                                                DateTime endTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);


                                                double startTimeInSec = startTime.TimeOfDay.TotalSeconds;
                                                double endTimeInSec = endTime.TimeOfDay.TotalSeconds;


                                                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeToDeleteQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                                                effectiveWorkTimeToDeleteQuery.EffectiveBusinessDay = date;
                                                effectiveWorkTimeToDeleteQuery.Employee_RefID = empID;
                                                effectiveWorkTimeToDeleteQuery.Tenant_RefID = securityTicket.TenantID;
                                                effectiveWorkTimeToDeleteQuery.IsDeleted = false;

                                                var allEffectiveWorkTimeHeadersToDelete = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeToDeleteQuery);

                                                foreach (var effectiveWorkTimeHeaderToDelete in allEffectiveWorkTimeHeadersToDelete)
                                                {
                                                    P_L5DWS_DEWTH_1126 deleteParam = new P_L5DWS_DEWTH_1126();
                                                    deleteParam.CMN_STR_PPS_EffectiveWorkTime_HeaderID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;

                                                    ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionsQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
                                                    positionsQuery.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                                                    positionsQuery.Tenant_RefID = securityTicket.TenantID;
                                                    positionsQuery.IsDeleted = false;

                                                    var positions = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionsQuery);

                                                    List<P_L5DWS_DEWTH_1126_Positions> listOfPositions = new List<P_L5DWS_DEWTH_1126_Positions>();

                                                    foreach (var position in positions)
                                                    {
                                                        P_L5DWS_DEWTH_1126_Positions positionItem = new P_L5DWS_DEWTH_1126_Positions();
                                                        positionItem.CMN_BPT_EMP_EffectiveWorkTime_PositionID = position.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
                                                        positionItem.durationInDays = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), true);
                                                        positionItem.durationInHours = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), false);
                                                        listOfPositions.Add(positionItem);
                                                    }

                                                    deleteParam.Positions = listOfPositions.ToArray();
                                                    cls_Delete_EffectiveWorkTime_Header.Invoke(Connection, Transaction, deleteParam, securityTicket);
                                                }

                                                ORM_CMN_BPT_EMP_EffectiveWorkTime_Header effectiveWorkTimeHeader = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();
                                                effectiveWorkTimeHeader.IsBreakTimeManualySpecified = false;
                                                effectiveWorkTimeHeader.ContractWorkerText = "";
                                                effectiveWorkTimeHeader.Employee_RefID = empID;
                                                effectiveWorkTimeHeader.Tenant_RefID = securityTicket.TenantID;
                                                effectiveWorkTimeHeader.EffectiveBusinessDay = date;
                                                effectiveWorkTimeHeader.Save(Connection, Transaction);

                                                P_L5DWS_SEWTP_1337 effectivePositionParam = new P_L5DWS_SEWTP_1337();
                                                effectivePositionParam.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                                                effectivePositionParam.WorkTime_Start = effectiveWorkTimeHeader.EffectiveBusinessDay.AddSeconds(0);
                                                effectivePositionParam.WorkTime_End = effectiveWorkTimeHeader.EffectiveBusinessDay.AddSeconds(86340);
                                                effectivePositionParam.Employee_RefID = empID;
                                                effectivePositionParam.AbsenceReason_RefID = pattern.CMN_BPT_STA_AbsenceReason_RefID;
                                                effectivePositionParam.RequestedFor_Employee_RefID = empID;
                                                cls_Save_EffectiveWorkTime_Position.Invoke(Connection, Transaction, effectivePositionParam, securityTicket);
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
                                                    ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeToDeleteQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                                                    effectiveWorkTimeToDeleteQuery.EffectiveBusinessDay = date;
                                                    effectiveWorkTimeToDeleteQuery.Employee_RefID = empID;
                                                    effectiveWorkTimeToDeleteQuery.Tenant_RefID = securityTicket.TenantID;
                                                    effectiveWorkTimeToDeleteQuery.IsDeleted = false;

                                                    var allEffectiveWorkTimeHeadersToDelete = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeToDeleteQuery);

                                                    foreach (var effectiveWorkTimeHeaderToDelete in allEffectiveWorkTimeHeadersToDelete)
                                                    {
                                                        P_L5DWS_DEWTH_1126 deleteParam = new P_L5DWS_DEWTH_1126();
                                                        deleteParam.CMN_STR_PPS_EffectiveWorkTime_HeaderID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;

                                                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionsQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
                                                        positionsQuery.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                                                        positionsQuery.Tenant_RefID = securityTicket.TenantID;
                                                        positionsQuery.IsDeleted = false;

                                                        var positions = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionsQuery);

                                                        List<P_L5DWS_DEWTH_1126_Positions> listOfPositions = new List<P_L5DWS_DEWTH_1126_Positions>();

                                                        foreach (var position in positions)
                                                        {
                                                            P_L5DWS_DEWTH_1126_Positions positionItem = new P_L5DWS_DEWTH_1126_Positions();
                                                            positionItem.CMN_BPT_EMP_EffectiveWorkTime_PositionID = position.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
                                                            positionItem.durationInDays = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), true);
                                                            positionItem.durationInHours = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), false);
                                                            listOfPositions.Add(positionItem);
                                                        }

                                                        deleteParam.Positions = listOfPositions.ToArray();
                                                        cls_Delete_EffectiveWorkTime_Header.Invoke(Connection, Transaction, deleteParam, securityTicket);
                                                    }

                                                    P_L5DWS_SEWTFST_1141 saveParam = new P_L5DWS_SEWTFST_1141();
                                                    saveParam.EffectiveBusinessDay = date;
                                                    saveParam.Employee_RefID = empID;
                                                    saveParam.ShiftTemplate_RefID = shiftTemplate.CMN_PPS_ShiftTemplateID;

                                                    cls_Save_EffectiveWorkTime_For_ShiftTemplate.Invoke(Connection, Transaction, saveParam, securityTicket);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Parameter.LoadFrom_PlanData)
                {
                    P_L5DWS_GDWSWDFT_0946 param = new P_L5DWS_GDWSWDFT_0946();
                    param.WorkSheduleDate = date;
                    var dailyWorkSchedules = cls_Get_DailyWorkSchedules_WithDetails_For_Date.Invoke(Connection, Transaction, param, securityTicket).Result;

                    foreach (var dailyWorkSchedule in dailyWorkSchedules)
                    {                        
                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query effectiveWorkTimeToDeleteQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query();
                        effectiveWorkTimeToDeleteQuery.EffectiveBusinessDay = date;
                        effectiveWorkTimeToDeleteQuery.Employee_RefID = dailyWorkSchedule.Employee_RefID;
                        effectiveWorkTimeToDeleteQuery.Tenant_RefID = securityTicket.TenantID;
                        effectiveWorkTimeToDeleteQuery.IsDeleted = false;

                        var effectiveWorkTimeHeaderToDeleteQueryResult = ORM_CMN_BPT_EMP_EffectiveWorkTime_Header.Query.Search(Connection, Transaction, effectiveWorkTimeToDeleteQuery);

                        if (effectiveWorkTimeHeaderToDeleteQueryResult.Count != 0)
                        {
                            var effectiveWorkTimeHeaderToDelete = effectiveWorkTimeHeaderToDeleteQueryResult.FirstOrDefault();
                            P_L5DWS_DEWTH_1126 deleteParam = new P_L5DWS_DEWTH_1126();
                            deleteParam.CMN_STR_PPS_EffectiveWorkTime_HeaderID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;

                            ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query positionsQuery = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query();
                            positionsQuery.EffectiveWorkTime_Header_RefID = effectiveWorkTimeHeaderToDelete.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                            positionsQuery.Tenant_RefID = securityTicket.TenantID;
                            positionsQuery.IsDeleted = false;

                            var positions = ORM_CMN_BPT_EMP_EffectiveWorkTime_Position.Query.Search(Connection, Transaction, positionsQuery);

                            List<P_L5DWS_DEWTH_1126_Positions> listOfPositions = new List<P_L5DWS_DEWTH_1126_Positions>();

                            foreach (var position in positions)
                            {
                                P_L5DWS_DEWTH_1126_Positions positionItem = new P_L5DWS_DEWTH_1126_Positions();
                                positionItem.CMN_BPT_EMP_EffectiveWorkTime_PositionID = position.CMN_BPT_EMP_EffectiveWorkTime_PositionID;
                                positionItem.durationInDays = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), true);
                                positionItem.durationInHours = leaveRequestUtil.LeaveRequestDuration(position.WorkTime_StartTime, position.WorkTime_StartTime.AddSeconds(position.WorkTime_Duration_in_sec), Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == position.CMN_BPT_EMP_Employe_RefID), false);
                                listOfPositions.Add(positionItem);
                            }

                            deleteParam.Positions = listOfPositions.ToArray();
                            cls_Delete_EffectiveWorkTime_Header.Invoke(Connection, Transaction, deleteParam, securityTicket);
                        }

                        ORM_CMN_BPT_EMP_EffectiveWorkTime_Header newHeader = new ORM_CMN_BPT_EMP_EffectiveWorkTime_Header();
                        newHeader.ContractWorkerText = dailyWorkSchedule.ContractWorkerText;
                        newHeader.BreakDurationTime_in_sec = dailyWorkSchedule.BreakDurationTime_in_sec;
                        newHeader.EffectiveBusinessDay = date;
                        newHeader.Employee_RefID = dailyWorkSchedule.Employee_RefID;
                        newHeader.IsBreakTimeManualySpecified = dailyWorkSchedule.IsBreakTimeManualySpecified;
                        newHeader.SheduleBreakTemplate_RefID = dailyWorkSchedule.SheduleBreakTemplate_RefID;
                        newHeader.Tenant_RefID = securityTicket.TenantID;
                        newHeader.Save(Connection, Transaction);

                        foreach (var dailyWorkDetail in dailyWorkSchedule.Details)
                        {
                            P_L5DWS_SEWTP_1337 positionSavePar = new P_L5DWS_SEWTP_1337();
                            if (dailyWorkDetail.LeaveRequest_RefID != Guid.Empty)
                            {
                                positionSavePar.AbsenceReason_RefID = dailyWorkDetail.AbsenceReason_RefID;
                                positionSavePar.durationInDays = leaveRequestUtil.LeaveRequestDuration(dailyWorkDetail.FromTime_as_DateTime, dailyWorkDetail.ToTime_as_DateTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == dailyWorkSchedule.Employee_RefID), true);
                                positionSavePar.durationInHours = leaveRequestUtil.LeaveRequestDuration(dailyWorkDetail.FromTime_as_DateTime, dailyWorkDetail.ToTime_as_DateTime, Parameter.Events, Parameter.Employees.FirstOrDefault(x => x.CMN_BPT_EMP_EmployeeID == dailyWorkSchedule.Employee_RefID), false);
                                positionSavePar.RequestedBy_Employee_RefID = Guid.Empty;
                                positionSavePar.RequestedFor_Employee_RefID = dailyWorkSchedule.Employee_RefID;
                            }
                            else
                            {
                                positionSavePar.AbsenceReason_RefID = Guid.Empty;
                                positionSavePar.durationInDays = 0;
                                positionSavePar.durationInHours = 0;
                                positionSavePar.RequestedBy_Employee_RefID = Guid.Empty;
                                positionSavePar.RequestedFor_Employee_RefID = Guid.Empty;
                            }

                            positionSavePar.CMN_BPT_EMP_Employee_LeaveRequest_RefID = Guid.Empty;
                            positionSavePar.EffectiveWorkTime_Header_RefID = newHeader.CMN_STR_PPS_EffectiveWorkTime_HeaderID;
                            positionSavePar.Employee_RefID = newHeader.Employee_RefID;
                            positionSavePar.OldDurationInDays = 0;
                            positionSavePar.OldDurationInHours = 0;
                            positionSavePar.Workplace_RefID = dailyWorkDetail.SheduleForWorkplace_RefID;
                            positionSavePar.WorkTime_End = dailyWorkDetail.ToTime_as_DateTime;
                            positionSavePar.WorkTime_Start = dailyWorkDetail.FromTime_as_DateTime;

                            cls_Save_EffectiveWorkTime_Position.Invoke(Connection, Transaction, positionSavePar, securityTicket);
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
		public static FR_Base Invoke(string ConnectionString,P_L5DWS_LAD_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5DWS_LAD_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DWS_LAD_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DWS_LAD_1001 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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
