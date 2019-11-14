
	Select
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.STA_AbsenceReason_RefID,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsAbsenceCalculated_InHours,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsAbsenceCalculated_InDays,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.ContractAllowedAbsence_per_Month,
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID,
	  cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID,
	  cmn_cal_weeklyofficehours_intervals.IsWholeDay,
	  cmn_cal_weeklyofficehours_intervals.IsSunday,
	  cmn_cal_weeklyofficehours_intervals.IsSaturday,
	  cmn_cal_weeklyofficehours_intervals.IsFriday,
	  cmn_cal_weeklyofficehours_intervals.IsThursday,
	  cmn_cal_weeklyofficehours_intervals.IsWednesday,
	  cmn_cal_weeklyofficehours_intervals.IsTuesday,
	  cmn_cal_weeklyofficehours_intervals.IsMonday,
	  cmn_cal_weeklyofficehours_intervals.TimeTo_InMinutes,
	  cmn_cal_weeklyofficehours_intervals.TimeFrom_InMinutes
	From
	  cmn_bpt_emp_workingcontract_allowedabsencereasons Inner Join
	  cmn_bpt_emp_employmentrelationship_2_workingcontract
	    On cmn_bpt_emp_workingcontract_allowedabsencereasons.WorkingContract_RefID =
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID
	  Inner Join
	  cmn_bpt_emp_employmentrelationships
	    On
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.EmploymentRelationship_RefID = cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID Inner Join
	  cmn_bpt_emp_workingcontract_2_workingdays
	    On
	    cmn_bpt_emp_employmentrelationship_2_workingcontract.WorkingContract_RefID =
	    cmn_bpt_emp_workingcontract_2_workingdays.CMN_BPT_EMP_WorkingContract_RefID
	  Inner Join
	  cmn_cal_weeklyofficehours_intervals
	    On
	    cmn_bpt_emp_workingcontract_2_workingdays.CMN_CAL_WeeklyOfficeHours_Interval_RefID = cmn_cal_weeklyofficehours_intervals.CMN_CAL_WeeklyOfficeHours_IntervalID
	Where
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.Tenant_RefID = @TenantID And
	  cmn_bpt_emp_workingcontract_allowedabsencereasons.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
	  cmn_bpt_emp_workingcontract_2_workingdays.IsDeleted = 0 And
	  cmn_cal_weeklyofficehours_intervals.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationship_2_workingcontract.IsContract_Active = 1
	  And
	  cmn_bpt_emp_employmentrelationships.Employee_RefID = @ForEmployeeID
  