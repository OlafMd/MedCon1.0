
Select
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_task_templates.IsDeleted,
  pps_tsk_task_templates.TaskTemplateITL
From
  pps_tsk_task_templates
Where
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID = @TaskTemplateID And
  pps_tsk_task_templates.Tenant_RefID = @TenantID
  