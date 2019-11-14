
	Select
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
	  cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID,
	  cmn_bpt_emp_employmentrelationships.HasWorkRelationEnded,
	  cmn_bpt_emp_employmentrelationships.Work_StartDate,
	  cmn_bpt_emp_employmentrelationships.Work_EndDate,
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.AssignmentID,
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsContract_Active,
	  cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID,
	  cmn_bpt_emp_workingcontracts.Contract_StartDate,
	  cmn_bpt_emp_workingcontracts.Contract_EndDate,
	  cmn_bpt_emp_workingcontracts.IsContractEndDateDefined,
	  cmn_bpt_emp_workingcontracts.IsWorkTimeCalculated_InHours,
	  cmn_bpt_emp_workingcontracts.IsWorkTimeCalculated_InDays,
	  cmn_bpt_emp_workingcontracts.R_WorkTime_DaysPerWeek,
	  cmn_bpt_emp_workingcontracts.R_WorkTime_HoursPerWeek,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.STA_AbsenceReason_RefID,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsAbsenceCalculated_InHours,
    cmn_bpt_emp_workingcontract_allowedabsencereasons.IsAbsenceCalculated_InDays,
    cmn_bpt_emp_workingcontract_allowedabsencereasons.ContractAllowedAbsence_per_Month
	  From
	  cmn_bpt_emp_employees Inner Join
	  cmn_bpt_emp_employmentrelationships
	  On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
	  cmn_bpt_emp_employmentrelationships.Employee_RefID Inner Join
	  cmn_bpt_emp_employmentrelationship_2_workingcontract
	  On cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
	  =
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.EmploymentRelationship_RefID Inner Join
	  cmn_bpt_emp_workingcontracts
	  On
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID =
	  cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID Inner Join
	  cmn_bpt_emp_workingcontract_allowedabsencereasons
	  On cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID =
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.WorkingContract_RefID
	  Where
	  cmn_bpt_emp_employmentrelationships.HasWorkRelationEnded =
	  '( = 0 And Year(cmn_bpt_emp_employmentrelationships.Work_StartDate) <= @ForYear) Or ( = 1 And cmn_bpt_emp_employmentrelationships.Work_EndDate  > cmn_bpt_emp_employmentrelationships.Work_StartDate And Year(cmn_bpt_emp_employmentrelationships.Work_StartDate)  <= @ForYear And Year(cmn_bpt_emp_employmentrelationships.Work_EndDate) >= @ForYear)' And
	  cmn_bpt_emp_workingcontracts.IsContractEndDateDefined =
	  '( = 0 And Year(cmn_bpt_emp_workingcontracts.Contract_StartDate)  <= @ForYear) Or ( = 1 And cmn_bpt_emp_workingcontracts.Contract_EndDate > cmn_bpt_emp_workingcontracts.Contract_StartDate And Year(cmn_bpt_emp_workingcontracts.Contract_StartDate)  <= @ForYear And Year(cmn_bpt_emp_workingcontracts.Contract_EndDate) >= @ForYear)' And
	  cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_employees.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsDeleted = 0 And
	  cmn_bpt_emp_workingcontracts.IsDeleted = 0 And
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsDeleted = 0

  