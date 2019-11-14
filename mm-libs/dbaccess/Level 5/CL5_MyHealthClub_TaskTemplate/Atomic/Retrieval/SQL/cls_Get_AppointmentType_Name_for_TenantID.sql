
	Select
	  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
	  pps_tsk_task_templates.TaskTemplateName_DictID,
	  pps_tsk_task_templates.TaskTemplateNumber,
	  pps_tsk_task_templates.TaskTemplateDisplayName
	From
	  pps_tsk_task_templates
	Where
	  pps_tsk_task_templates.IsDeleted = 0 And  
	  pps_tsk_task_templates.Tenant_RefID = @TenantID
  