/* 
 * Generated on 31-Jan-14 11:10:08
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
using CL1_CMN_CAL;
using PlannicoModel.Models;
using CL2_Language.Atomic.Retrieval;

namespace CL5_VacationPlanner_Contract.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_WorkingContract.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_WorkingContract
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CT_SECT_1810 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
            if (Parameter.CMN_BPT_EMP_WorkingContractID != Guid.Empty)
            {
                var result = workingContract.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_WorkingContractID);
                if (result.Status != FR_Status.Success || workingContract.CMN_BPT_EMP_WorkingContractID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            workingContract.Contract_EndDate = Parameter.Contract_EndDate;
            workingContract.Contract_StartDate = Parameter.Contract_StartDate;
            workingContract.IsContractEndDateDefined = Parameter.IsContractEndDateDefined;
            workingContract.IsWorkTimeCalculated_InDays = Parameter.IsWorkTimeCalculated_InDays;
            workingContract.IsWorkTimeCalculated_InHours = Parameter.IsWorkTimeCalculated_InHours;
            workingContract.R_WorkTime_DaysPerWeek = Parameter.R_WorkTime_DaysPerWeek;
            workingContract.R_WorkTime_HoursPerWeek = Parameter.R_WorkTime_HoursPerWeek;
            workingContract.ExtraWorkCalculation_RefID = Parameter.ExtraWorkCalculation_RefID;
            workingContract.WorkingContract_InCurrency_RefID = Parameter.WorkingContract_InCurrency_RefID;
            workingContract.IsWorktimeChecked_Monthly = Parameter.IsWorktimeChecked_Monthly;
            workingContract.IsWorktimeChecked_Weekly = Parameter.IsWorktimeChecked_Weekly;
            workingContract.IsMealAllowanceProvided = Parameter.IsMealAllowanceProvided;
            workingContract.SurchargeCalculation_UseAccumulated = Parameter.SurchargeCalculation_UseAccumulated;
            workingContract.SurchargeCalculation_UseMaximum = Parameter.SurchargeCalculation_UseMaximum;
            workingContract.WorkingContract_Comment = Parameter.WorkingContract_Comment;
            workingContract.Tenant_RefID = securityTicket.TenantID;
            
            workingContract.Save(Connection, Transaction);

            returnValue.Result = workingContract.CMN_BPT_EMP_WorkingContractID;

            //Night time surcharges

            ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query contractToNightTimeSurchargeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
            contractToNightTimeSurchargeQuery.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = Parameter.NightTime_Surcharge_RefID;
            contractToNightTimeSurchargeQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
            contractToNightTimeSurchargeQuery.R_IsNightTimeSurcharge = true;
            contractToNightTimeSurchargeQuery.R_IsSpecialEventSurcharge = false;
            contractToNightTimeSurchargeQuery.IsDeleted = false;
            contractToNightTimeSurchargeQuery.Tenant_RefID = securityTicket.TenantID;

            var nightTimeSurchargeQueryResult = ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.Search(Connection, Transaction, contractToNightTimeSurchargeQuery);
            if (nightTimeSurchargeQueryResult.Count != 0)
            {
                ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge contractToNightTimeSurcharge = nightTimeSurchargeQueryResult.FirstOrDefault();
                contractToNightTimeSurcharge.MaximumAllowedSurchargeTime_in_mins = Parameter.MaximumAllowedNightTimeSurchargeTime_in_mins;
                contractToNightTimeSurcharge.Save(Connection, Transaction);
            }
            else
            {
                ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge contractToNightTimeSurcharge = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge();
                contractToNightTimeSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = Parameter.NightTime_Surcharge_RefID;
                contractToNightTimeSurcharge.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                contractToNightTimeSurcharge.R_IsNightTimeSurcharge = true;
                contractToNightTimeSurcharge.R_IsSpecialEventSurcharge = false;
                contractToNightTimeSurcharge.MaximumAllowedSurchargeTime_in_mins = Parameter.MaximumAllowedNightTimeSurchargeTime_in_mins;
                contractToNightTimeSurcharge.Tenant_RefID = securityTicket.TenantID;
                contractToNightTimeSurcharge.Save(Connection, Transaction);
            }

            //Special event surcharges

            ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query contractToSpecialEventSurchargeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
            contractToSpecialEventSurchargeQuery.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = Parameter.SpecialEvent_Surcharge_RefID;
            contractToSpecialEventSurchargeQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
            contractToSpecialEventSurchargeQuery.R_IsNightTimeSurcharge = false;
            contractToSpecialEventSurchargeQuery.R_IsSpecialEventSurcharge = true;
            contractToSpecialEventSurchargeQuery.IsDeleted = false;
            contractToSpecialEventSurchargeQuery.Tenant_RefID = securityTicket.TenantID;

            var specialEventSurchargeQueryResult = ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.Search(Connection, Transaction, contractToSpecialEventSurchargeQuery);
            if (specialEventSurchargeQueryResult.Count != 0)
            {
                ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge contractToSpecialEventSurcharge = specialEventSurchargeQueryResult.FirstOrDefault();
                contractToSpecialEventSurcharge.MaximumAllowedSurchargeTime_in_mins = Parameter.MaximumAllowedSpecialEventSurchargeTime_in_mins;
                contractToSpecialEventSurcharge.Save(Connection, Transaction);
            }
            else
            {
                ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge contractToSpecialEventSurcharge = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge();
                contractToSpecialEventSurcharge.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = Parameter.SpecialEvent_Surcharge_RefID;
                contractToSpecialEventSurcharge.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                contractToSpecialEventSurcharge.R_IsNightTimeSurcharge = false;
                contractToSpecialEventSurcharge.R_IsSpecialEventSurcharge = true;
                contractToSpecialEventSurcharge.MaximumAllowedSurchargeTime_in_mins = Parameter.MaximumAllowedSpecialEventSurchargeTime_in_mins;
                contractToSpecialEventSurcharge.Tenant_RefID = securityTicket.TenantID;
                contractToSpecialEventSurcharge.Save(Connection, Transaction);
            }           

            ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract contractToEmployeeRelationship = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract();

            if (Parameter.EmployeeRelationshipToWorkingContractAssignmentID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query contractToEmployeeRelationshipQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                contractToEmployeeRelationshipQuery.AssignmentID = Parameter.EmployeeRelationshipToWorkingContractAssignmentID;
                contractToEmployeeRelationshipQuery.IsDeleted = false;
                contractToEmployeeRelationshipQuery.Tenant_RefID = securityTicket.TenantID;

                contractToEmployeeRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, contractToEmployeeRelationshipQuery).FirstOrDefault();
            }
            contractToEmployeeRelationship.WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
            contractToEmployeeRelationship.EmploymentRelationship_RefID = Parameter.EmploymentRelationship_RefID;
            contractToEmployeeRelationship.IsContract_Active = Parameter.IsActive_WorkingContract;
            contractToEmployeeRelationship.Tenant_RefID = securityTicket.TenantID;
            contractToEmployeeRelationship.Save(Connection,Transaction);

            if (Parameter.LastActive_WorkingContractID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query lastActiveContractToEmployeeRelationshipQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query();
                lastActiveContractToEmployeeRelationshipQuery.WorkingContract_RefID = Parameter.LastActive_WorkingContractID;
                lastActiveContractToEmployeeRelationshipQuery.IsDeleted = false;
                lastActiveContractToEmployeeRelationshipQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract lastActiveContractToEmployeeRelationship = ORM_CMN_BPT_EMP_EmploymentRelationship_2_WorkingContract.Query.Search(Connection, Transaction, lastActiveContractToEmployeeRelationshipQuery).FirstOrDefault();
                lastActiveContractToEmployeeRelationship.IsContract_Active = false;
                lastActiveContractToEmployeeRelationship.Save(Connection, Transaction);

                ORM_CMN_BPT_EMP_WorkingContract.Query lastActiveContractQuery = new ORM_CMN_BPT_EMP_WorkingContract.Query();
                lastActiveContractQuery.CMN_BPT_EMP_WorkingContractID = Parameter.LastActive_WorkingContractID;
                lastActiveContractQuery.IsDeleted = false;
                lastActiveContractQuery.Tenant_RefID = securityTicket.TenantID;

                var lastActiveContract = ORM_CMN_BPT_EMP_WorkingContract.Query.Search(Connection, Transaction, lastActiveContractQuery).FirstOrDefault();

                if (!lastActiveContract.IsContractEndDateDefined)
                {
                    lastActiveContract.Contract_EndDate = Parameter.Contract_StartDate;
                    lastActiveContract.IsContractEndDateDefined = true;
                    lastActiveContract.Save(Connection, Transaction);
                }
            }

            foreach (P_L5CT_SECT_1810_WorkingContractAllowedAbsenceReason obj in Parameter.WorkingContractAllowedAbsenceReason)
            {
                ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason contractToabsenceReason = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason();
                if (obj.WorkingContractAllowedAbsenceReasonID != Guid.Empty)
                {
                    ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query contractToabsenceReasonQuery = new ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query();
                    contractToabsenceReasonQuery.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = obj.WorkingContractAllowedAbsenceReasonID;
                    contractToabsenceReasonQuery.IsDeleted = false;
                    contractToabsenceReasonQuery.Tenant_RefID = securityTicket.TenantID;

                    contractToabsenceReason = ORM_CMN_BPT_EMP_WorkingContract_AllowedAbsenceReason.Query.Search(Connection, Transaction, contractToabsenceReasonQuery).FirstOrDefault();
                }
                contractToabsenceReason.ContractAllowedAbsence_per_Month = obj.ContractAllowedAbsence;
                contractToabsenceReason.WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                contractToabsenceReason.IsAbsenceCalculated_InDays = Parameter.IsWorkTimeCalculated_InDays;
                contractToabsenceReason.IsAbsenceCalculated_InHours = Parameter.IsWorkTimeCalculated_InHours;
                contractToabsenceReason.STA_AbsenceReason_RefID = obj.AbsenceReasonRefID;
                contractToabsenceReason.Tenant_RefID = securityTicket.TenantID;
                contractToabsenceReason.Save(Connection, Transaction);
            }

            ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query query = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query();
            query.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;

            foreach (ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay obj in ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.Search(Connection, Transaction, query))
            {
                ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query intervalQuery = new ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query();
                intervalQuery.CMN_CAL_WeeklyOfficeHours_IntervalID = obj.CMN_CAL_WeeklyOfficeHours_Interval_RefID;
                ORM_CMN_CAL_WeeklyOfficeHours_Interval.Query.SoftDelete(Connection, Transaction, intervalQuery);
            }
            ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay.Query.SoftDelete(Connection, Transaction, query);
            foreach (P_L5CT_SECT_1810_WeeklyOfficeHours obj in Parameter.WeeklyOfficeHours)
            {
                ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay workingContractToWorkingDay = new ORM_CMN_BPT_EMP_WorkingContract_2_WorkingDay();
                workingContractToWorkingDay.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                ORM_CMN_CAL_WeeklyOfficeHours_Interval weeklyOfficeHoursInterval = new ORM_CMN_CAL_WeeklyOfficeHours_Interval();
                weeklyOfficeHoursInterval.IsMonday = obj.IsMonday;
                weeklyOfficeHoursInterval.IsTuesday = obj.IsTuesday;
                weeklyOfficeHoursInterval.IsWednesday = obj.IsWednesday;
                weeklyOfficeHoursInterval.IsThursday = obj.IsThursday;
                weeklyOfficeHoursInterval.IsFriday = obj.IsFriday;
                weeklyOfficeHoursInterval.IsSaturday = obj.IsSaturday;
                weeklyOfficeHoursInterval.IsSunday = obj.IsSunday;
                weeklyOfficeHoursInterval.TimeFrom_InMinutes = obj.TimeFrom_InMinutes;
                weeklyOfficeHoursInterval.TimeTo_InMinutes = obj.TimeTo_InMinutes;
                weeklyOfficeHoursInterval.Tenant_RefID = securityTicket.TenantID;
                weeklyOfficeHoursInterval.IsWholeDay = obj.IsWholeDay;
                weeklyOfficeHoursInterval.Save(Connection, Transaction);     
                workingContractToWorkingDay.CMN_CAL_WeeklyOfficeHours_Interval_RefID = weeklyOfficeHoursInterval.CMN_CAL_WeeklyOfficeHours_IntervalID;
                workingContractToWorkingDay.Tenant_RefID = securityTicket.TenantID;
                workingContractToWorkingDay.Save(Connection, Transaction);
            }


            ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query workingContractTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query();
            workingContractTypeQuery.CMN_BPT_EMP_Employee_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
            workingContractTypeQuery.Tenant_RefID = securityTicket.TenantID;
            workingContractTypeQuery.IsDeleted = false;
            ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType workingContract_2_ContractEmploymentType = ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType.Query.Search(Connection, Transaction, workingContractTypeQuery).FirstOrDefault();
            if (workingContract_2_ContractEmploymentType != null)
            {


                ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query employmentTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query();
                employmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
                employmentTypeQuery.IsDeleted = false;
                employmentTypeQuery.GlobalPropertyMatchingID = Parameter.TypeOfEmployment.ToString();
                ORM_CMN_BPT_EMP_WorkingContract_EmploymentType newEmploymentType = ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query.Search(Connection, Transaction, employmentTypeQuery).FirstOrDefault();
                if (newEmploymentType != null)
                {
                    workingContract_2_ContractEmploymentType.CMN_BPT_EMP_WorkingContract_EmploymentTypeID = newEmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID;
                    workingContract_2_ContractEmploymentType.Save(Connection, Transaction);
                }
            }
            else
            {
                ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query employmentTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query();
                employmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
                employmentTypeQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_WorkingContract_EmploymentType> employmentTypes = ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query.Search(Connection, Transaction, employmentTypeQuery);
                ORM_CMN_BPT_EMP_WorkingContract_EmploymentType newEmploymentType = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType();
                if (employmentTypes.Count == 0)
                {
                    Guid german = Guid.Empty;
                    Guid english = Guid.Empty;
                    L2LN_GAL_1526[] AllLanguages = cls_Get_All_Languages.Invoke(Connection,Transaction,securityTicket).Result;
                    foreach (var language in AllLanguages)
                    {
                        if (language.ISO_639_1.ToUpper() == "DE")
                        {
                            german = language.CMN_LanguageID;
                        }
                        else if (language.ISO_639_1.ToUpper() == "EN")
                        {
                            english = language.CMN_LanguageID;
                        }
                    }
                    

                   
                    newEmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Description.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description.AddEntry(german, "Festangestellte");
                    newEmploymentType.EmploymentType_Description.AddEntry(english, "permanent worker");
                    newEmploymentType.EmploymentType_Name = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Name.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Name.AddEntry(german, "Festangestellte");
                    newEmploymentType.EmploymentType_Name.AddEntry(english, "permanent worker");
                    newEmploymentType.GlobalPropertyMatchingID = "0";
                    newEmploymentType.Tenant_RefID = securityTicket.TenantID;
                    newEmploymentType.Save(Connection, Transaction);

                    newEmploymentType = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType();
                    newEmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Description.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description.AddEntry(german, "Aushilfe");
                    newEmploymentType.EmploymentType_Description.AddEntry(english, "temporary worker");
                    newEmploymentType.EmploymentType_Name = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Name.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Name.AddEntry(german, "Aushilfe");
                    newEmploymentType.EmploymentType_Name.AddEntry(english, "temporary worker");
                    newEmploymentType.GlobalPropertyMatchingID = "1";
                    newEmploymentType.Tenant_RefID = securityTicket.TenantID;
                    newEmploymentType.Save(Connection, Transaction);

                    newEmploymentType = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType();
                    newEmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Description.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Description.AddEntry(german, "Contract worker");
                    newEmploymentType.EmploymentType_Description.AddEntry(english, "Leiharbeiter");
                    newEmploymentType.EmploymentType_Name = new Dict("CMN_BPT_EMP_WorkingContract_EmploymentType");
                    newEmploymentType.EmploymentType_Name.DictionaryID = Guid.NewGuid();
                    newEmploymentType.EmploymentType_Name.AddEntry(german, "Contract worker");
                    newEmploymentType.EmploymentType_Name.AddEntry(english, "Leiharbeiter");
                    newEmploymentType.GlobalPropertyMatchingID = "2";
                    newEmploymentType.Tenant_RefID = securityTicket.TenantID;
                    newEmploymentType.Save(Connection, Transaction);
                }

                ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType employmentType2Contract = new ORM_CMN_BPT_EMP_WorkingContract_2_ContractEmploymentType();
                employmentType2Contract.Tenant_RefID = securityTicket.TenantID;
                employmentType2Contract.IsDeleted = false;
                employmentType2Contract.CMN_BPT_EMP_Employee_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                
                ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query newEmploymentTypeQuery = new ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query();
                newEmploymentTypeQuery.Tenant_RefID = securityTicket.TenantID;
                newEmploymentTypeQuery.IsDeleted = false;
                newEmploymentTypeQuery.GlobalPropertyMatchingID = Parameter.TypeOfEmployment.ToString();
                newEmploymentType = ORM_CMN_BPT_EMP_WorkingContract_EmploymentType.Query.Search(Connection, Transaction, newEmploymentTypeQuery).FirstOrDefault();
                if (newEmploymentType != null)
                {
                    employmentType2Contract.CMN_BPT_EMP_WorkingContract_EmploymentTypeID = newEmploymentType.CMN_BPT_EMP_Employee_WorkingContract_EmploymentTypeID;
                    employmentType2Contract.Save(Connection, Transaction);
                }
              
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CT_SECT_1810 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CT_SECT_1810 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CT_SECT_1810 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CT_SECT_1810 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		

	#endregion
}
