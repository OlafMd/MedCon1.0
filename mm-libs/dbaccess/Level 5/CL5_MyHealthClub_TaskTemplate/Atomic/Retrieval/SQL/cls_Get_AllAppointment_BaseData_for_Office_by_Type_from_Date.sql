
Select
  pps_tsk_tasks.PPS_TSK_TaskID,
  pps_tsk_tasks.PlannedDuration_in_sec,
  pps_tsk_task_staffbookings.CMN_BPT_EMP_Employee_RefID,
  pps_tsk_tasks.PlannedStartDate,
  pps_tsk_task_devicebookings.PPS_DEV_Device_Instance_RefID
From
  pps_tsk_tasks Left Join
  pps_tsk_task_staffbookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_staffbookings.PPS_TSK_Task_RefID And
    pps_tsk_task_staffbookings.Tenant_RefID = @TenantID And
    pps_tsk_task_staffbookings.IsDeleted = 0 Inner Join
  pps_tsk_task_officebookings On pps_tsk_task_officebookings.PPS_TSK_Task_RefID
    = pps_tsk_tasks.PPS_TSK_TaskID And pps_tsk_task_officebookings.Tenant_RefID
    = @TenantID And pps_tsk_task_officebookings.IsDeleted = 0 And
    pps_tsk_task_officebookings.CMN_STR_Office_RefID = @OfficeID And
    pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID = @TaskTemplateID And
    pps_tsk_tasks.PlannedStartDate >= @FromDate Left Join
  pps_tsk_task_devicebookings On pps_tsk_task_devicebookings.PPS_TSK_Task_RefID
    = pps_tsk_tasks.PPS_TSK_TaskID And pps_tsk_task_devicebookings.IsDeleted = 0
  