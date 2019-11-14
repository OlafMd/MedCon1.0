
	Select
	  cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID,
	  cmn_cal_weeklyofficehours_intervals.WeeklyOfficeHours_Template_RefID,
	  cmn_cal_weeklyofficehours_intervals.IsWholeDay,
	  cmn_cal_weeklyofficehours_intervals.TimeFrom_InMinutes,
	  cmn_cal_weeklyofficehours_intervals.TimeTo_InMinutes,
	  cmn_cal_weeklyofficehours_intervals.IsMonday,
	  cmn_cal_weeklyofficehours_intervals.IsTuesday,
	  cmn_cal_weeklyofficehours_intervals.IsWednesday,
	  cmn_cal_weeklyofficehours_intervals.IsThursday,
	  cmn_cal_weeklyofficehours_intervals.IsFriday,
	  cmn_cal_weeklyofficehours_intervals.IsSaturday,
	  cmn_cal_weeklyofficehours_intervals.IsSunday,
	  cmn_cal_weeklyofficehours_intervals.Creation_Timestamp,
	  cmn_cal_weeklyofficehours_intervals.Tenant_RefID,
	  cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID
	From
	  cmn_cal_weeklyofficehours_intervals Inner Join
	  cmn_bpt_emp_workingcontract_2_workingdays
	    On
	    cmn_bpt_emp_workingcontract_2_workingdays.CMN_CAL_WeeklyOfficeHours_Interval_RefID = cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID Inner Join
	  cmn_bpt_emp_workingcontracts
	    On cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID =
	    cmn_bpt_emp_workingcontract_2_workingdays.CMN_BPT_EMP_WorkingContract_RefID
	  Inner Join
	  cmn_bpt_emp_employmentrelationship_2_workingcontract
	    On
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID =
	    cmn_bpt_emp_workingcontracts.CMN_BPT_EMP_WorkingContractID Inner Join
	  cmn_bpt_emp_employmentrelationships
	    On cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
	    =
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.EmploymentRelationship_RefID Inner Join
	  cmn_bpt_emp_employees On cmn_bpt_emp_employmentrelationships.Employee_RefID =
	    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
	  usr_accounts On cmn_bpt_emp_employees.BusinessParticipant_RefID =
	    usr_accounts.BusinessParticipant_RefID
	Where
	  usr_accounts.USR_AccountID = @AccountID And
    usr_accounts.Tenant_RefID = @TenantID And
	  usr_accounts.IsDeleted = False And
	  cmn_bpt_emp_employees.IsDeleted = False And
	  cmn_bpt_emp_employmentrelationships.IsDeleted = False And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsDeleted = False And
	  cmn_bpt_emp_workingcontracts.IsDeleted = False And
	  cmn_bpt_emp_workingcontract_2_workingdays.IsDeleted = False And
	  cmn_cal_weeklyofficehours_intervals.IsDeleted = False And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsContract_Active = True
  