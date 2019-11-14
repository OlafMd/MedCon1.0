
	Select
	  pps_tsk_task_templates.TaskTemplateName_DictID,
	  pps_tsk_tasks.DisplayName,
	  pps_tsk_tasks.PlannedStartDate,
	  pps_tsk_tasks.PlannedDuration_in_sec,
	  cmn_str_offices.Office_Name_DictID,
	  cmn_addresses.Street_Name,
	  cmn_addresses.Street_Number,
	  cmn_addresses.City_Name
	From
	  pps_tsk_task_templates Inner Join
	  pps_tsk_tasks On pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID =
	    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
	    pps_tsk_task_templates.Tenant_RefID = @TenantID And
	    pps_tsk_task_templates.IsDeleted = 0 Inner Join
	  pps_tsk_task_officebookings On pps_tsk_tasks.PPS_TSK_TaskID =
	    pps_tsk_task_officebookings.PPS_TSK_Task_RefID And
	    pps_tsk_task_officebookings.Tenant_RefID = @TenantID And
	    pps_tsk_task_officebookings.IsDeleted = 0 Inner Join
	  cmn_str_offices On pps_tsk_task_officebookings.CMN_STR_Office_RefID =
	    cmn_str_offices.CMN_STR_OfficeID  And
	  cmn_str_offices.IsDeleted = 0 And
	  cmn_str_offices.Tenant_RefID = @TenantID Inner Join
	  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
	    cmn_str_office_addresses.Office_RefID And
	    cmn_str_office_addresses.Tenant_RefID = @TenantID And
	    cmn_str_office_addresses.IsDeleted = 0 And
	    cmn_str_office_addresses.IsDefault = 1 Inner Join
	  cmn_addresses On cmn_addresses.CMN_AddressID =
	    cmn_str_office_addresses.CMN_Address_RefID And cmn_addresses.IsDeleted = 0
	    And cmn_addresses.Tenant_RefID = @TenantID
	Where
	  pps_tsk_tasks.Tenant_RefID = @TenantID And
	  pps_tsk_tasks.IsDeleted = 0 And
	  pps_tsk_tasks.PPS_TSK_TaskID = @TaskID
  