
	Select
  cmn_bpt_emp_workingcontract_allowedabsencereasons.ContractAllowedAbsence_per_Month,
  cmn_bpt_sta_absencereasons.IsAllowedAbsence,
  cmn_bpt_emp_contractabsenceadjustments.AbsenceTime_InMinutes,
  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID,
  cmn_bpt_emp_workingcontracts.IsWorkTimeCalculated_InHours,
  cmn_bpt_emp_workingcontracts.IsWorkTimeCalculated_InDays
From
  cmn_bpt_emp_employees Inner Join
  cmn_bpt_emp_employmentrelationships
    On cmn_bpt_emp_employmentrelationships.Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
  cmn_bpt_emp_employmentrelationship_2_workingcontract
    On cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
    =
    cmn_bpt_emp_employmentrelationship_2_workingcontract.EmploymentRelationship_RefID Inner Join
  cmn_bpt_emp_workingcontracts
    On cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID =
    cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID
  Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_emp_employees.BusinessParticipant_RefID Inner Join
  cmn_bpt_emp_workingcontract_allowedabsencereasons
    On cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID =
    cmn_bpt_emp_workingcontract_allowedabsencereasons.WorkingContract_RefID
  Inner Join
  cmn_bpt_sta_absencereasons
    On cmn_bpt_emp_workingcontract_allowedabsencereasons.STA_AbsenceReason_RefID
    = cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID Inner Join
  cmn_bpt_emp_contractabsenceadjustments
    On cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID =
    cmn_bpt_emp_contractabsenceadjustments.AbsenceReason_RefID
Where
  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID = @AbsenceReason_ID And
  cmn_bpt_emp_employees.IsDeleted = False And
  cmn_bpt_emp_employmentrelationships.IsDeleted = False And
  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsDeleted = False And
  cmn_bpt_emp_workingcontracts.IsDeleted = False And
  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsContract_Active = True
  And
  usr_accounts.USR_AccountID = @AccountID And
  usr_accounts.Tenant_RefID = @TenantID And
  cmn_bpt_emp_contractabsenceadjustments.IsDeleted = False And
  cmn_bpt_sta_absencereasons.IsDeleted = False And
  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsDeleted = False
  