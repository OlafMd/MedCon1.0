
	Select
	  cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID,
	  cmn_cal_calculationtimeframes.CalculationTimeframe_StartDate,
	  cmn_cal_calculationtimeframes.CalculationTimefrate_EndDate,
	  cmn_cal_calculationtimeframes.CalculationTimeframe_EstimatedEndDate,
	  cmn_cal_calculationtimeframes.IsCalculationTimeframe_Active,
	  cmn_bpt_emp_employmentrelationship_timeframes.CMN_BPT_EMP_EmploymentRelationship_TimeframeID,
	  cmn_bpt_emp_employmentrelationship_timeframes.CalculationTimeframe_RefID,
	  cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID,
	  cmn_bpt_emp_employmentrelationships.HasWorkRelationEnded,
	  cmn_bpt_emp_employmentrelationships.Work_StartDate,
	  cmn_bpt_emp_employmentrelationships.Work_EndDate,
	  cmn_bpt_emp_employmentrelationships.IsLockedFor_TemplateUpdates,
	  cmn_bpt_emp_employmentrelationships.InstanceOf_EmploymentRelationships_Template_RefID,
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
	  cmn_bpt_emp_employees.BusinessParticipant_RefID,
	  cmn_bpt_emp_employees.Staff_Number,
	  cmn_bpt_emp_employees.StandardFunction,
	  cmn_bpt_emp_employees.EmployeeDocument_Structure_RefID
	From
	  cmn_bpt_emp_employees Inner Join
	  cmn_bpt_emp_employmentrelationships
	    On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID =
	    cmn_bpt_emp_employmentrelationships.Employee_RefID Inner Join
	  cmn_bpt_emp_employmentrelationship_timeframes
	    On cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
	    = cmn_bpt_emp_employmentrelationship_timeframes.EmploymentRelationship_RefID
	  Inner Join
	  cmn_cal_calculationtimeframes
	    On cmn_bpt_emp_employmentrelationship_timeframes.CalculationTimeframe_RefID
	    = cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID
	Where
	  cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID =
	  @CalculationTimeframeID And
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID = @EmployeeID And
	  cmn_bpt_emp_employees.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
	  cmn_bpt_emp_employmentrelationship_timeframes.IsDeleted = 0 And
	  cmn_cal_calculationtimeframes.IsDeleted = 0 And
	  cmn_bpt_emp_employees.Tenant_RefID = @TenantID
  