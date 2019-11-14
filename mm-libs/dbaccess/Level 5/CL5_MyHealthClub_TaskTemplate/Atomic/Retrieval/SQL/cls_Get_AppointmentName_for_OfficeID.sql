
Select
  pps_tsk_tasks.DisplayName,
  pps_tsk_tasks.PlannedStartDate,
  pps_tsk_tasks.PlannedDuration_in_sec,
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID
From
  pps_tsk_task_templates Inner Join
  pps_tsk_tasks On pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID =
    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
    pps_tsk_tasks.Tenant_RefID = @TenantID And pps_tsk_tasks.IsDeleted = 0 Inner Join
  pps_tsk_task_officebookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_officebookings.PPS_TSK_Task_RefID And
    pps_tsk_task_officebookings.Tenant_RefID =
    @TenantID And
    pps_tsk_task_officebookings.IsDeleted = 0
Where
  pps_tsk_task_templates.Tenant_RefID = @TenantID And
  pps_tsk_task_templates.IsDeleted = 0 And
  pps_tsk_task_officebookings.CMN_STR_Office_RefID = @OfficeID
  