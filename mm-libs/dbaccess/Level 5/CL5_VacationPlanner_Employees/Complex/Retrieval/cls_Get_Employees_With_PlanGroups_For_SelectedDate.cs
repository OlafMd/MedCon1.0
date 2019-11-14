/* 
 * Generated on 15/04/2014 14:19:45
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
using CL1_CMN_PER;
using CL1_CMN_BPT;
using PlannicoModel.Models;
using CL1_CMN_CAL;
using CL1_CMN_BPT_STA;
using CL1_CMN_STR;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees_With_PlanGroups_For_SelectedDate.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees_With_PlanGroups_For_SelectedDate
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEWPGFSD_1437_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEWPGFSD_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5EM_GEWPGFSD_1437_Array();
			//Put your code here

            ORM_CMN_BPT_EMP_Employee.Query empQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            empQuery.IsDeleted = false;
            empQuery.Tenant_RefID = securityTicket.TenantID;

            var allEmployees = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, empQuery);

            List<L5EM_GEWPGFSD_1437> resultList = new List<L5EM_GEWPGFSD_1437>();

            foreach(var employee in allEmployees)
            {
                L5EM_GEWPGFSD_1437 resultItem = new L5EM_GEWPGFSD_1437();
                resultItem.EmployeeID = employee.CMN_BPT_EMP_EmployeeID;

                ORM_CMN_BPT_BusinessParticipant.Query bptQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                bptQuery.CMN_BPT_BusinessParticipantID = employee.BusinessParticipant_RefID;
                bptQuery.IsDeleted = false;
                bptQuery.Tenant_RefID = securityTicket.TenantID;

                var bpt = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bptQuery).FirstOrDefault();

                ORM_CMN_PER_PersonInfo.Query infoQuery = new ORM_CMN_PER_PersonInfo.Query();
                infoQuery.CMN_PER_PersonInfoID = bpt.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                infoQuery.IsDeleted = false;
                infoQuery.Tenant_RefID = securityTicket.TenantID;

                var info = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, infoQuery).FirstOrDefault();

                int age = Parameter.SelectedDate.Year - info.BirthDate.Year;
                if (Parameter.SelectedDate < info.BirthDate.AddYears(age)) age--;

                resultItem.Age = age;
                resultItem.FirstName = info.FirstName;
                resultItem.LastName = info.LastName;
                

                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query wpaQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                wpaQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                wpaQuery.IsDeleted = false;
                wpaQuery.Tenant_RefID = securityTicket.TenantID;

                var allWorkPlaceAssignements = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, wpaQuery);

                var workPlaceAssignementsForSelectedDate = allWorkPlaceAssignements.Where(x => x.WorkplaceAssignment_StartDate.Date.CompareTo(Parameter.SelectedDate) <= 0).ToArray();
                if (workPlaceAssignementsForSelectedDate.Count() != 0)
                {
                    var resultingWorkPlaceAssignement = workPlaceAssignementsForSelectedDate.OrderByDescending(x => x.WorkplaceAssignment_StartDate.Ticks).FirstOrDefault();

                    if (resultingWorkPlaceAssignement.CMN_BPT_EMP_Employee_PlanGroup_RefID == Guid.Empty)
                    {
                        resultItem.PlanGroupID = Guid.Empty;
                        resultItem.PlanGroupName = new Dict();
                        resultItem.Position = -1;
                    }
                    else
                    {
                        ORM_CMN_BPT_EMP_Employee_PlanGroup.Query pgQuery = new ORM_CMN_BPT_EMP_Employee_PlanGroup.Query();
                        pgQuery.CMN_BPT_EMP_Employee_PlanGroupID = resultingWorkPlaceAssignement.CMN_BPT_EMP_Employee_PlanGroup_RefID;
                        pgQuery.IsDeleted = false;
                        pgQuery.Tenant_RefID = securityTicket.TenantID;

                        var selectedPlanGroup = ORM_CMN_BPT_EMP_Employee_PlanGroup.Query.Search(Connection, Transaction, pgQuery).FirstOrDefault();

                        if (selectedPlanGroup == null)
                        {
                            resultItem.PlanGroupID = Guid.Empty;
                            resultItem.PlanGroupName = new Dict();
                            resultItem.Position = -1;
                        }
                        else
                        {
                            resultItem.PlanGroupID = selectedPlanGroup.CMN_BPT_EMP_Employee_PlanGroupID;
                            resultItem.PlanGroupName = selectedPlanGroup.PlanGroup_Name;
                            resultItem.Position = resultingWorkPlaceAssignement.SequenceNumber;
                        }
                        
                        resultItem.IsBreakTimeCalculated_Planning = resultingWorkPlaceAssignement.IsBreakTimeCalculated_Planning;
                        resultItem.IsBreakTimeCalculated_Actual = resultingWorkPlaceAssignement.IsBreakTimeCalculated_Actual;
                        
                    }
                }
                else
                {
                    continue;
                }

                ORM_CMN_BPT_EMP_EmploymentRelationship.Query employmentRelationshipQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship.Query();
                employmentRelationshipQuery.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employmentRelationshipQuery.Tenant_RefID = securityTicket.TenantID;
                employmentRelationshipQuery.IsDeleted = false;

                ORM_CMN_BPT_EMP_EmploymentRelationship employmentRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship.Query.Search(Connection, Transaction, employmentRelationshipQuery).FirstOrDefault();

                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query er2wcQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                er2wcQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                er2wcQuery.Tenant_RefID = securityTicket.TenantID;
                er2wcQuery.IsContract_Active = true;
                er2wcQuery.IsDeleted = false;
                


                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract er2wc = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, er2wcQuery).FirstOrDefault();
                if (er2wc != null)
                {
                    ORM_CMN_BPT_EMP_WorkingContract.Query workingContractQuery = new ORM_CMN_BPT_EMP_WorkingContract.Query();
                    workingContractQuery.CMN_BPT_EMP_WorkingContractID = er2wc.WorkingContract_RefID;
                    workingContractQuery.IsDeleted = false;
                    workingContractQuery.Tenant_RefID = securityTicket.TenantID;

                    ORM_CMN_BPT_EMP_WorkingContract workingContract = ORM_CMN_BPT_EMP_WorkingContract.Query.Search(Connection, Transaction, workingContractQuery).FirstOrDefault();

                    resultItem.IsWorkTimeCalculated_InDays = workingContract.IsWorkTimeCalculated_InDays;
                    resultItem.IsWorkTimeCalculated_InHours = workingContract.IsWorkTimeCalculated_InHours;

                    ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query wc2wdQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
                    wc2wdQuery.CMN_BPT_EMP_WorkingContract_RefID = er2wc.WorkingContract_RefID;
                    wc2wdQuery.Tenant_RefID = securityTicket.TenantID;
                    wc2wdQuery.IsDeleted = false;

                    ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay[] workingContract2workingDays = ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, wc2wdQuery).ToArray();

                    resultItem.ContractSpecifiedWorkTime_InMinutes = 0;
                    List<WeeklyOfficeHours> listOfWeeklyOfficeHours = new List<WeeklyOfficeHours>();

                    foreach (var workingContract2workingDay in workingContract2workingDays)
                    {
                        ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query weeklyOfficeHoursQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query();
                        weeklyOfficeHoursQuery.CMN_CAL_WeeklyOfficeHours_IntervalID = workingContract2workingDay.CMN_CAL_WeeklyOfficeHours_Interval_RefID;
                        weeklyOfficeHoursQuery.Tenant_RefID = securityTicket.TenantID;
                        weeklyOfficeHoursQuery.IsDeleted = false;

                        ORM_CMN_CAL_WeeklyOfficeHours_Interval weeklyOfficeHours = ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query.Search(Connection, Transaction, weeklyOfficeHoursQuery).FirstOrDefault();

                        switch (Parameter.SelectedDate.DayOfWeek)
                        {
                            case DayOfWeek.Monday:
                                if (weeklyOfficeHours.IsMonday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Tuesday:
                                if (weeklyOfficeHours.IsTuesday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Wednesday:
                                if (weeklyOfficeHours.IsWednesday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Thursday:
                                if (weeklyOfficeHours.IsThursday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Friday:
                                if (weeklyOfficeHours.IsFriday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Saturday:
                                if (weeklyOfficeHours.IsSaturday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                            case DayOfWeek.Sunday:
                                if (weeklyOfficeHours.IsSunday)
                                    resultItem.ContractSpecifiedWorkTime_InMinutes = (int)(weeklyOfficeHours.TimeTo_InMinutes - weeklyOfficeHours.TimeFrom_InMinutes);
                                break;
                        }

                        WeeklyOfficeHours newWeeklyOfficeHour = new WeeklyOfficeHours();
                        newWeeklyOfficeHour.CMN_CAL_WeeklyOfficeHours_IntervalID = weeklyOfficeHours.CMN_CAL_WeeklyOfficeHours_IntervalID;
                        newWeeklyOfficeHour.IsFriday = weeklyOfficeHours.IsFriday;
                        newWeeklyOfficeHour.IsMonday = weeklyOfficeHours.IsMonday;
                        newWeeklyOfficeHour.IsSaturday = weeklyOfficeHours.IsSaturday;
                        newWeeklyOfficeHour.IsSunday = weeklyOfficeHours.IsSunday;
                        newWeeklyOfficeHour.IsThursday = weeklyOfficeHours.IsThursday;
                        newWeeklyOfficeHour.IsTuesday = weeklyOfficeHours.IsTuesday;
                        newWeeklyOfficeHour.IsWednesday = weeklyOfficeHours.IsWednesday;
                        newWeeklyOfficeHour.IsWholeDay = weeklyOfficeHours.IsWholeDay;
                        newWeeklyOfficeHour.TimeFrom_InMinutes = weeklyOfficeHours.TimeFrom_InMinutes;
                        newWeeklyOfficeHour.TimeTo_InMinutes = weeklyOfficeHours.TimeTo_InMinutes;

                        listOfWeeklyOfficeHours.Add(newWeeklyOfficeHour);

                    }


                    resultItem.WeeklyOfficeHours = listOfWeeklyOfficeHours.ToArray();
                }
                else
                {
                    continue;
                }

                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query relationShipToContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                relationShipToContractQuery.EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                relationShipToContractQuery.IsDeleted = false;
                relationShipToContractQuery.Tenant_RefID = securityTicket.TenantID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract> relationShipToContracts = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, relationShipToContractQuery);
                List<L5EM_GEFE_1150_WorkingContract> resultWorkingContracts = new List<L5EM_GEFE_1150_WorkingContract>();
                foreach (var relationShipToContract in relationShipToContracts)
                {
                    L5EM_GEFE_1150_WorkingContract resultWorkingContract = new L5EM_GEFE_1150_WorkingContract();

                    ORM_CMN_BPT_EMP_WorkingContract workingContractItem = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContractItem.Load(Connection, Transaction, relationShipToContract.WorkingContract_RefID);
                    resultWorkingContract.CMN_BPT_EMP_WorkingContractID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    resultWorkingContract.EmploymentRelationship_2_WorkingContractAssigmentID = relationShipToContract.AssignmentID;
                    resultWorkingContract.IsContract_Active = relationShipToContract.IsContract_Active;
                    resultWorkingContract.Contract_StartDate = workingContractItem.Contract_StartDate;
                    resultWorkingContract.Contract_EndDate = workingContractItem.Contract_EndDate;
                    resultWorkingContract.IsContractEndDateDefined = workingContractItem.IsContractEndDateDefined;
                    resultWorkingContract.IsWorkTimeCalculated_InDays = workingContractItem.IsWorkTimeCalculated_InDays;
                    resultWorkingContract.IsWorkTimeCalculated_InHours = workingContractItem.IsWorkTimeCalculated_InHours;
                    resultWorkingContract.R_WorkTime_DaysPerWeek = workingContractItem.R_WorkTime_DaysPerWeek;
                    resultWorkingContract.R_WorkTime_HoursPerWeek = workingContractItem.R_WorkTime_HoursPerWeek;
                    resultWorkingContract.WorkingContract_InCurrency_RefID = workingContractItem.WorkingContract_InCurrency_RefID;
                    resultWorkingContract.ExtraWorkCalculation_RefID = workingContractItem.ExtraWorkCalculation_RefID;
                    resultWorkingContract.IsWorktimeChecked_Weekly = workingContractItem.IsWorktimeChecked_Weekly;
                    resultWorkingContract.IsWorktimeChecked_Monthly = workingContractItem.IsWorktimeChecked_Monthly;
                    resultWorkingContract.SurchargeCalculation_UseMaximum = workingContractItem.SurchargeCalculation_UseMaximum;
                    resultWorkingContract.SurchargeCalculation_UseAccumulated = workingContractItem.SurchargeCalculation_UseAccumulated;
                    resultWorkingContract.IsMealAllowanceProvided = workingContractItem.IsMealAllowanceProvided;
                    resultWorkingContract.WorkingContract_Comment = workingContractItem.WorkingContract_Comment;

                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query contractToExtraWorkSurchargeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
                    contractToExtraWorkSurchargeQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    contractToExtraWorkSurchargeQuery.IsDeleted = false;
                    contractToExtraWorkSurchargeQuery.Tenant_RefID = securityTicket.TenantID;
                    var contractToExtraWorkSurchargeResult = ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.Search(Connection, Transaction, contractToExtraWorkSurchargeQuery);
                    if (contractToExtraWorkSurchargeResult.Count != 0)
                    {
                        var nightTimeSurcharge = contractToExtraWorkSurchargeResult.FirstOrDefault(x => x.R_IsNightTimeSurcharge && !x.R_IsSpecialEventSurcharge);
                        var specialEventSurcharge = contractToExtraWorkSurchargeResult.FirstOrDefault(x => x.R_IsSpecialEventSurcharge && !x.R_IsNightTimeSurcharge);

                        if (nightTimeSurcharge != null)
                        {
                            resultWorkingContract.NightTime_Surcharge_RefID = nightTimeSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                            resultWorkingContract.MaximumAllowedNightTimeSurchargeTime_in_mins = nightTimeSurcharge.MaximumAllowedSurchargeTime_in_mins;
                        }

                        if (specialEventSurcharge != null)
                        {
                            resultWorkingContract.SpecialEvent_Surcharge_RefID = specialEventSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                            resultWorkingContract.MaximumAllowedSpecialEventSurchargeTime_in_mins = specialEventSurcharge.MaximumAllowedSurchargeTime_in_mins;
                        }

                    }


                    //Office hours
                    ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query workingContractToWorkingDayQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
                    workingContractToWorkingDayQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    //workingContractToWorkingDayQuery.Tenant_RefID = securityTicket.TenantID;
                    workingContractToWorkingDayQuery.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay> workingDayAssigments = ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, workingContractToWorkingDayQuery);
                    List<L5EM_GEFE_1150_WeeklyOfficeHours> resultWeeklyOfficeHours = new List<L5EM_GEFE_1150_WeeklyOfficeHours>();
                    foreach (var workingDayAssigment in workingDayAssigments)
                    {

                        ORM_CMN_CAL_WeeklyOfficeHours_Interval interval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                        interval.Load(Connection, Transaction, workingDayAssigment.CMN_CAL_WeeklyOfficeHours_Interval_RefID);

                        L5EM_GEFE_1150_WeeklyOfficeHours resultOfficeHour = new L5EM_GEFE_1150_WeeklyOfficeHours();
                        resultOfficeHour.CMN_CAL_WeeklyOfficeHours_IntervalID = interval.CMN_CAL_WeeklyOfficeHours_IntervalID;
                        resultOfficeHour.IsFriday = interval.IsFriday;
                        resultOfficeHour.IsMonday = interval.IsMonday;
                        resultOfficeHour.IsSaturday = interval.IsSaturday;
                        resultOfficeHour.IsSunday = interval.IsSunday;
                        resultOfficeHour.IsThursday = interval.IsThursday;
                        resultOfficeHour.IsTuesday = interval.IsTuesday;
                        resultOfficeHour.IsWednesday = interval.IsWednesday;
                        resultOfficeHour.IsWholeDay = interval.IsWholeDay;
                        resultOfficeHour.TimeFrom_InMinutes = interval.TimeFrom_InMinutes;
                        resultOfficeHour.TimeTo_InMinutes = interval.TimeTo_InMinutes;
                        resultWeeklyOfficeHours.Add(resultOfficeHour);
                    }
                    resultWorkingContract.WeeklyOfficeHours = resultWeeklyOfficeHours.ToArray();



                    ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query workingContractTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query();
                    workingContractTypeQuery.CMN_BPT_EMP_Employee_WorkingContract_RefID = workingContractItem.CMN_BPT_EMP_WorkingContractID;
                    workingContractTypeQuery.Tenant_RefID = securityTicket.TenantID;
                    workingContractTypeQuery.IsDeleted = false;
                    ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType workingContract_2_ContractEmploymentType = ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query.Search(Connection, Transaction, workingContractTypeQuery).FirstOrDefault();
                    if (workingContract_2_ContractEmploymentType != null)
                    {
                        ORM_CMN_BPT_EMP_WorkingContract_EmploymentType EmploymentType = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType();
                        EmploymentType.Load(Connection, Transaction, workingContract_2_ContractEmploymentType.CMN_BPT_EMP_WorkingContract_EmploymentTypeID);
                        if (EmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID != Guid.Empty)
                        {
                            resultWorkingContract.TypeOfEmployment = int.Parse(EmploymentType.GlobalPropertyMatchingID);
                        }
                    }


                    //Allowed absence reasons
                    ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query AllowedAbsenceReasonQuery = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query();
                    AllowedAbsenceReasonQuery.WorkingContract_RefID = resultWorkingContract.CMN_BPT_EMP_WorkingContractID;
                    AllowedAbsenceReasonQuery.Tenant_RefID = securityTicket.TenantID;
                    AllowedAbsenceReasonQuery.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason> allowedAbsenceReasons = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, AllowedAbsenceReasonQuery);
                    List<L5EM_GEFE_1150_WorkingContractToLeaveRequest> resultAllowedAbsenceReasons = new List<L5EM_GEFE_1150_WorkingContractToLeaveRequest>();
                    foreach (var allowedAbsenceReason in allowedAbsenceReasons)
                    {
                        ORM_CMN_BPT_STA_AbsenceReason absenceReason = new ORM_CMN_BPT_STA_AbsenceReason();
                        absenceReason.Load(Connection, Transaction, allowedAbsenceReason.STA_AbsenceReason_RefID);

                        L5EM_GEFE_1150_WorkingContractToLeaveRequest resultReasonresultReason = new L5EM_GEFE_1150_WorkingContractToLeaveRequest();
                        resultReasonresultReason.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = allowedAbsenceReason.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID;
                        resultReasonresultReason.CMN_BPT_STA_AbsenceReasonID = absenceReason.CMN_BPT_STA_AbsenceReasonID;
                        resultReasonresultReason.IsAbsenceCalculated_InDays = allowedAbsenceReason.IsAbsenceCalculated_InDays;
                        resultReasonresultReason.IsAbsenceCalculated_InHours = allowedAbsenceReason.IsAbsenceCalculated_InHours;
                        resultReasonresultReason.ContractAllowedAbsence_per_Month = allowedAbsenceReason.ContractAllowedAbsence_per_Month;
                        resultReasonresultReason.AbsenceReasonName = absenceReason.Name;
                        resultReasonresultReason.CMN_BPT_EMP_EmploymentRelationship_RefID = employmentRelationship.CMN_BPT_EMP_EmploymentRelationshipID;
                        resultAllowedAbsenceReasons.Add(resultReasonresultReason);
                    }
                    resultWorkingContract.WorkingContractToLeaveRequest = resultAllowedAbsenceReasons.ToArray();

                    resultWorkingContracts.Add(resultWorkingContract);
                }
                resultItem.AllWorkingContracts = resultWorkingContracts.ToArray();

                //Employee workplace history
                ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query employeeWorkplaceAssignmentsQuery = new ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query();
                employeeWorkplaceAssignmentsQuery.CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                employeeWorkplaceAssignmentsQuery.Tenant_RefID = securityTicket.TenantID;
                employeeWorkplaceAssignmentsQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment> employeeWorkplaceAssignemntsList = ORM_CMN_BPT_EMP_Employee_WorkplaceAssignment.Query.Search(Connection, Transaction, employeeWorkplaceAssignmentsQuery);
                List<L5EM_GEFE_1150_EmployeeWorkplaceHistory> employeeWorkplaceAssignments = new List<L5EM_GEFE_1150_EmployeeWorkplaceHistory>();

                foreach (var workplaceAssignemns in employeeWorkplaceAssignemntsList)
                {
                    L5EM_GEFE_1150_EmployeeWorkplaceHistory item = new L5EM_GEFE_1150_EmployeeWorkplaceHistory();
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

                resultItem.AllWorkplaceHistories = employeeWorkplaceAssignments.ToArray();

                //employee qualifications
                ORM_CMN_BPT_EMP_Employee_2_Skill.Query qualificationQuary = new ORM_CMN_BPT_EMP_Employee_2_Skill.Query();
                qualificationQuary.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                qualificationQuary.Tenant_RefID = securityTicket.TenantID;
                qualificationQuary.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_2_Skill> qualificationList = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, qualificationQuary);
                List<L5EM_GEFE_1150_EmployeeQualification> employeeQualifications = new List<L5EM_GEFE_1150_EmployeeQualification>();

                L5EM_GEFE_1150_EmployeeQualification employeeQualification;
                ORM_CMN_STR_Skill skillORM;
                foreach (var qualification in qualificationList)
                {
                    employeeQualification = new L5EM_GEFE_1150_EmployeeQualification();
                    employeeQualification.QualificationAssignmentID = qualification.AssignmentID;
                    employeeQualification.ProfessionObtainedAtDate = qualification.QualificationObtainedAtDate;
                    employeeQualification.SkillName = new Dict();
                    if (qualification.Skill_RefID != Guid.Empty)
                    {
                        skillORM = new ORM_CMN_STR_Skill();
                        skillORM.Load(Connection, Transaction, qualification.Skill_RefID);
                        employeeQualification.Skill_RefID = skillORM.CMN_STR_SkillID;
                        employeeQualification.SkillName = skillORM.Skill_Name;
                    }

                    employeeQualifications.Add(employeeQualification);

                }

                resultItem.AllQualification = employeeQualifications.ToArray();


                resultList.Add(resultItem);
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
		public static FR_L5EM_GEWPGFSD_1437_Array Invoke(string ConnectionString,P_L5EM_GEWPGFSD_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWPGFSD_1437_Array Invoke(DbConnection Connection,P_L5EM_GEWPGFSD_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEWPGFSD_1437_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEWPGFSD_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEWPGFSD_1437_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEWPGFSD_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEWPGFSD_1437_Array functionReturn = new FR_L5EM_GEWPGFSD_1437_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employees_With_PlanGroups_For_SelectedDate",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEWPGFSD_1437_Array : FR_Base
	{
		public L5EM_GEWPGFSD_1437[] Result	{ get; set; } 
		public FR_L5EM_GEWPGFSD_1437_Array() : base() {}

		public FR_L5EM_GEWPGFSD_1437_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEWPGFSD_1437_Array cls_Get_Employees_With_PlanGroups_For_SelectedDate(,P_L5EM_GEWPGFSD_1437 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GEWPGFSD_1437_Array invocationResult = cls_Get_Employees_With_PlanGroups_For_SelectedDate.Invoke(connectionString,P_L5EM_GEWPGFSD_1437 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Complex.Retrieval.P_L5EM_GEWPGFSD_1437();
parameter.SelectedDate = ...;

*/
