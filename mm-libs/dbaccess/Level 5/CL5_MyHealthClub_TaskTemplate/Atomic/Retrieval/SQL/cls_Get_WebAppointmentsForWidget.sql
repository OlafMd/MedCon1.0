
	Select
	  pps_tsk_tasks.PPS_TSK_TaskID,
	  cmn_str_offices.Office_Name_DictID,
	  pps_tsk_tasks.PlannedStartDate,
	  pps_tsk_tasks.PlannedDuration_in_sec,
	  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID As EmployeeID,
	  cmn_bpt_emp_employees1.CMN_BPT_EMP_EmployeeID As RequiredEmployeeID
	From
	  pps_tsk_task_templates Inner Join
	  pps_tsk_tasks On pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID =
	    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And pps_tsk_tasks.IsDeleted =
	    0 And pps_tsk_tasks.Tenant_RefID = @TenantID And 
	    pps_tsk_tasks.PlannedStartDate >= @Date
	  Left Join
	  pps_tsk_task_staffbookings On pps_tsk_tasks.PPS_TSK_TaskID =
	    pps_tsk_task_staffbookings.PPS_TSK_Task_RefID And
	    pps_tsk_task_staffbookings.Tenant_RefID = @TenantID
	    And pps_tsk_task_staffbookings.IsDeleted = 0 Left Join
	  cmn_bpt_emp_employees On pps_tsk_task_staffbookings.CMN_BPT_EMP_Employee_RefID
	    = cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
	    cmn_bpt_emp_employees.IsDeleted = 0 And cmn_bpt_emp_employees.Tenant_RefID =
	    @TenantID Inner Join
	  pps_tsk_task_officebookings On pps_tsk_task_officebookings.PPS_TSK_Task_RefID
	    = pps_tsk_tasks.PPS_TSK_TaskID And pps_tsk_task_officebookings.Tenant_RefID
	    = @TenantID And
	    pps_tsk_task_officebookings.IsDeleted = 0 Inner Join
	  cmn_str_offices On pps_tsk_task_officebookings.CMN_STR_Office_RefID =
	    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.Tenant_RefID =
	    @TenantID And cmn_str_offices.IsDeleted = 0
	  Inner Join
	  hec_app_appointments On hec_app_appointments.Ext_PPS_TSK_Task_RefID =
	    pps_tsk_tasks.PPS_TSK_TaskID And hec_app_appointments.Tenant_RefID =
	    @TenantID And hec_app_appointments.IsDeleted = 0
	  Left Join
	  pps_tsk_task_requiredstaff On pps_tsk_task_requiredstaff.TaskTemplate_RefID =
	    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
	    pps_tsk_task_requiredstaff.IsDeleted = 0 And
	    pps_tsk_task_requiredstaff.Tenant_RefID = @TenantID
	  Left Join
	  cmn_bpt_emp_employees cmn_bpt_emp_employees1
	    On cmn_bpt_emp_employees1.CMN_BPT_EMP_EmployeeID =
	    pps_tsk_task_requiredstaff.Required_Employee_RefID And
	    cmn_bpt_emp_employees1.IsDeleted = 0 And cmn_bpt_emp_employees1.Tenant_RefID
	    = @TenantID Inner Join
	  pprs_tsk_task_selectedavailabilitytypes On pps_tsk_tasks.PPS_TSK_TaskID =
	    pprs_tsk_task_selectedavailabilitytypes.PPS_TSK_Task_RefID And
	    pprs_tsk_task_selectedavailabilitytypes.Tenant_RefID =
	    @TenantID And
	    pprs_tsk_task_selectedavailabilitytypes.IsDeleted = 0
	Where
	  pps_tsk_task_templates.Tenant_RefID = @TenantID And
	  pps_tsk_task_templates.IsDeleted = 0
  