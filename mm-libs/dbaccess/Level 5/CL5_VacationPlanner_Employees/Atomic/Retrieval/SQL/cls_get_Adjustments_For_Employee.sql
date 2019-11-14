
	Select
  cmn_bpt_emp_contractabsenceadjustment_groups.CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID,
  cmn_bpt_emp_contractabsenceadjustment_groups.AbsenceAdjustment_Comment,
  cmn_bpt_emp_contractabsenceadjustments.CMN_BPT_EMP_ContractAbsenceAdjustmentID,
  cmn_bpt_emp_contractabsenceadjustments.AbsenceTime_InMinutes,
  cmn_bpt_emp_contractabsenceadjustments.AdjustmentComment,
  cmn_bpt_emp_contractabsenceadjustments.TriggeringAccount_RefID,
  cmn_bpt_emp_contractabsenceadjustments.IsManual,
  cmn_bpt_emp_contractabsenceadjustments.InternalAdjustmentType,
  cmn_bpt_emp_contractabsenceadjustments.AdjustmentDate,
  cmn_bpt_sta_absencereasons.Name_DictID,
  cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID,
  cmn_bpt_emp_employmentrelationship_timeframes.CMN_BPT_EMP_EmploymentRelationship_TimeframeID,
  cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID,
  cmn_cal_calculationtimeframes.CalculationTimeframe_StartDate,
  cmn_cal_calculationtimeframes.CalculationTimefrate_EndDate,
  cmn_cal_calculationtimeframes.CalculationTimeframe_EstimatedEndDate,
  cmn_cal_calculationtimeframes.IsCalculationTimeframe_Active,
  cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID,
  cmn_bpt_emp_employmentrelationships.HasWorkRelationEnded,
  cmn_bpt_emp_employmentrelationships.Work_StartDate,
  cmn_bpt_emp_employmentrelationships.Work_EndDate,
  cmn_bpt_emp_employmentrelationships.IsLockedFor_TemplateUpdates,
  cmn_bpt_emp_employmentrelationships.InstanceOf_EmploymentRelationships_Template_RefID,
  cmn_bpt_emp_employees.StandardFunction,
  cmn_bpt_emp_employees.Staff_Number,
  cmn_bpt_emp_employees.BusinessParticipant_RefID,
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employees.EmployeeDocument_Structure_RefID,
  cmn_bpt_sta_absencereasons.IsDeleted,
  cmn_bpt_emp_employmentrelationship_timeframes.IsDeleted As IsDeleted1,
  cmn_bpt_emp_contractabsenceadjustments.IsDeleted As IsDeleted2,
  cmn_cal_calculationtimeframes.IsDeleted As IsDeleted3,
  cmn_bpt_emp_employmentrelationships.IsDeleted As IsDeleted4,
  cmn_bpt_emp_employees.IsDeleted As IsDeleted5,
  cmn_bpt_emp_contractabsenceadjustments.Creation_Timestamp
From
  cmn_bpt_emp_contractabsenceadjustment_groups Right Join
  cmn_bpt_emp_contractabsenceadjustments
    On
    cmn_bpt_emp_contractabsenceadjustments.ContractAbsenceAdjustment_Group_RefID
    =
    cmn_bpt_emp_contractabsenceadjustment_groups.CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID Inner Join
  cmn_bpt_sta_absencereasons
    On cmn_bpt_emp_contractabsenceadjustments.AbsenceReason_RefID =
    cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID Inner Join
  cmn_bpt_emp_employmentrelationship_timeframes
    On
    cmn_bpt_emp_employmentrelationship_timeframes.CMN_BPT_EMP_EmploymentRelationship_TimeframeID = cmn_bpt_emp_contractabsenceadjustments.EmploymentRelationship_Timeframe_RefID Inner Join
  cmn_cal_calculationtimeframes
    On cmn_bpt_emp_employmentrelationship_timeframes.CalculationTimeframe_RefID
    = cmn_cal_calculationtimeframes.CMN_CAL_CalculationTimeframeID Inner Join
  cmn_bpt_emp_employmentrelationships
    On
    cmn_bpt_emp_employmentrelationship_timeframes.EmploymentRelationship_RefID =
    cmn_bpt_emp_employmentrelationships.CMN_BPT_EMP_EmploymentRelationshipID
  Inner Join
  cmn_bpt_emp_employees On cmn_bpt_emp_employmentrelationships.Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID
Where
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID = @EmployeeID And
  cmn_bpt_sta_absencereasons.IsDeleted = 0 And
  cmn_bpt_emp_employmentrelationship_timeframes.IsDeleted = 0 And
  cmn_bpt_emp_contractabsenceadjustments.IsDeleted = 0 And
  cmn_cal_calculationtimeframes.IsDeleted = 0 And
  cmn_bpt_emp_employmentrelationships.IsDeleted = 0 And
  cmn_bpt_emp_employees.IsDeleted = 0 And
  (cmn_bpt_emp_contractabsenceadjustment_groups.IsDeleted = 0 Or
    cmn_bpt_emp_contractabsenceadjustment_groups.IsDeleted Is Null) And
  cmn_bpt_emp_employees.Tenant_RefID = @TenantID
  