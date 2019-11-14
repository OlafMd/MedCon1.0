
	Select
	  pps_tsk_tasks.DisplayName
	From
	  pps_tsk_tasks Inner Join
	  pprs_tsk_task_selectedavailabilitytypes
	    On pprs_tsk_task_selectedavailabilitytypes.PPS_TSK_Task_RefID =
	    pps_tsk_tasks.PPS_TSK_TaskID And
	    pprs_tsk_task_selectedavailabilitytypes.Tenant_RefID = @TenantID And
	    pprs_tsk_task_selectedavailabilitytypes.IsDeleted = 0 Inner Join
	  pps_tsk_task_templates On pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID =
	    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
	    pps_tsk_task_templates.IsDeleted = 0 And pps_tsk_task_templates.Tenant_RefID
	    = @TenantID
	Where
	  pps_tsk_tasks.IsDeleted = 0 And
	  pps_tsk_tasks.Tenant_RefID = @TenantID And
	  pps_tsk_task_templates.PPS_TSK_Task_TemplateID = @TaskTemplateID
  