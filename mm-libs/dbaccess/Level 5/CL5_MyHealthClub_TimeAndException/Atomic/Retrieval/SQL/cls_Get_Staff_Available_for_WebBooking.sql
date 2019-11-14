
	Select
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID As OfficeID,
  cmn_bpt_emp_employee_2_skill.Skill_RefID As SkillID,
  cmn_bpt_emp_employee_2_profession.Profession_RefID,
  cmn_bpt_businessparticipant_availabilities.CMN_BPT_BusinessParticipant_AvailabilityID,
  cmn_cal_ava_availabilities.Office_RefID As OfficeID_WhereHeIsAvailable,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Mondays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Tuesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Wednesdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Thursdays,
  cmn_cal_repetitionpatterns_weekly.HasRepeatingOn_Fridays,
  cmn_bpt_emp_employee_2_profession.IsPrimary,
  cmn_bpt_emp_employees.BusinessParticipant_RefID as BusinessParticipantID
From
  cmn_bpt_emp_employees Left Join
  cmn_bpt_businessparticipant_excludedavailabilitytypes
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID And cmn_bpt_businessparticipant_excludedavailabilitytypes.Tenant_RefID = @TenantID And cmn_bpt_businessparticipant_excludedavailabilitytypes.IsDeleted = 0 Inner Join
  cmn_bpt_emp_employee_2_office
    On cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
    cmn_bpt_emp_employee_2_office.Tenant_RefID = @TenantID And
    cmn_bpt_emp_employee_2_office.IsDeleted = 0 Left Join
  cmn_bpt_emp_employee_2_skill On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
    cmn_bpt_emp_employee_2_skill.Employee_RefID And
    cmn_bpt_emp_employee_2_skill.IsDeleted = 0 And
    cmn_bpt_emp_employee_2_skill.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_emp_employee_2_profession
    On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
    cmn_bpt_emp_employee_2_profession.Employee_RefID And
    cmn_bpt_emp_employee_2_profession.IsDeleted = 0 And
    cmn_bpt_emp_employee_2_profession.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipant_availabilities
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID And
    cmn_bpt_businessparticipant_availabilities.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0 Inner Join
  cmn_cal_ava_availabilities
    On cmn_bpt_businessparticipant_availabilities.CMN_CAL_AVA_Availability_RefID
    = cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
    cmn_cal_ava_availabilities.IsDeleted = 0 And
    cmn_cal_ava_availabilities.Tenant_RefID = @TenantID And
    cmn_cal_ava_availabilities.IsAvailabilityExclusionItem = 0 Inner Join
  cmn_cal_ava_availability_types
    On cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID =
    cmn_cal_ava_availabilities.AvailabilityType_RefID And
    cmn_cal_ava_availability_types.GlobalPropertyMatchingID =
    @GlobalTypeMatching And cmn_cal_ava_availability_types.Tenant_RefID =
    @TenantID And cmn_cal_ava_availability_types.IsDeleted = 0 Left Join
  cmn_cal_ava_dates On cmn_cal_ava_dates.Availability_RefID =
    cmn_cal_ava_availabilities.CMN_CAL_AVA_AvailabilityID And
    cmn_cal_ava_dates.IsDeleted = 0 And cmn_cal_ava_dates.Tenant_RefID =
    @TenantID Inner Join
  cmn_cal_events On cmn_cal_ava_dates.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID And cmn_cal_events.IsDeleted = 0 And
    cmn_cal_events.Tenant_RefID = @TenantID And cmn_cal_events.IsRepetitive = 1
  Inner Join
  cmn_cal_repetitions On cmn_cal_events.Repetition_RefID =
    cmn_cal_repetitions.CMN_CAL_RepetitionID And cmn_cal_repetitions.IsWeekly =
    1 And cmn_cal_repetitions.IsDeleted = 0 And cmn_cal_repetitions.Tenant_RefID
    = @TenantID And cmn_cal_repetitions.IsMonthly = 0 And
    cmn_cal_repetitions.IsYearly = 0 And cmn_cal_repetitions.IsDaily = 0
  Inner Join
  cmn_cal_repetitionpatterns_weekly On cmn_cal_repetitions.CMN_CAL_RepetitionID
    = cmn_cal_repetitionpatterns_weekly.Repetition_RefID And
    cmn_cal_repetitionpatterns_weekly.IsDeleted = 0 And
    cmn_cal_repetitionpatterns_weekly.Tenant_RefID = @TenantID
Where
  cmn_bpt_emp_employees.IsDeleted = 0 And
  cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID Is Null
  