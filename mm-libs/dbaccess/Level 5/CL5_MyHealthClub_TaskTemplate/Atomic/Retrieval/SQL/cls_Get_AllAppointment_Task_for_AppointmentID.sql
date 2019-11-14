
Select
  pps_tsk_tasks.PPS_TSK_TaskID,
  pps_tsk_task_staffbookings.PPS_TSK_Task_StaffBookingsID,
  pps_tsk_task_staffbookings.PPS_TSK_Task_RefID,
  pps_tsk_task_staffbookings.CMN_BPT_EMP_Employee_RefID,
  pps_tsk_task_officebookings.PPS_TSK_Task_OfficeBookingID,
  pps_tsk_task_officebookings.PPS_TSK_Task_RefID As PPS_TSK_Task_RefID_Office,
  pps_tsk_task_officebookings.CMN_STR_Office_RefID,
  pps_tsk_task_devicebookings.PPS_TSK_Task_DeviceBookingID,
  pps_tsk_task_devicebookings.PPS_TSK_Task_RefID As PPS_TSK_Task_RefID_Device,
  hec_app_appointments.HEC_APP_AppointmentID,
  hec_app_appointments.Ext_PPS_TSK_Task_RefID,
  pps_tsk_tasks.DisplayName,
  pps_tsk_tasks.PlannedStartDate,
  pps_tsk_tasks.PlannedDuration_in_sec,
  pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID,
  pps_tsk_task_staffbookings.CreatedFrom_TaskTemplate_RequiredStaff_RefID,
  pps_tsk_task_devicebookings.PPS_DEV_Device_Instance_RefID,
  hec_act_plannedactions.Patient_RefID,
  hec_act_plannedactions.HEC_ACT_PlannedActionID
From
  pps_tsk_tasks Left Join
  pps_tsk_task_staffbookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_staffbookings.PPS_TSK_Task_RefID And
    (pps_tsk_task_staffbookings.IsDeleted = 0 Or
      pps_tsk_task_staffbookings.IsDeleted Is Null) Inner Join
  pps_tsk_task_officebookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_officebookings.PPS_TSK_Task_RefID And
    pps_tsk_task_officebookings.IsDeleted = 0 Left Join
  pps_tsk_task_devicebookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_devicebookings.PPS_TSK_Task_RefID And
    (pps_tsk_task_devicebookings.IsDeleted = 0 Or
      pps_tsk_task_devicebookings.IsDeleted Is Null) Inner Join
  hec_app_appointments On pps_tsk_tasks.PPS_TSK_TaskID =
    hec_app_appointments.Ext_PPS_TSK_Task_RefID And
    hec_app_appointments.IsDeleted = 0 Inner Join
  hec_act_plannedactions On hec_app_appointments.HEC_APP_AppointmentID =
    hec_act_plannedactions.Appointment_RefID
Where
  pps_tsk_tasks.Tenant_RefID = @TenantID And
		  pps_tsk_tasks.IsDeleted = 0 and pps_tsk_tasks.PPS_TSK_TaskID = @AppointmentID
  