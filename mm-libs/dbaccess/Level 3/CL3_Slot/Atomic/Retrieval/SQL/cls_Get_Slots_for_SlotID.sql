
Select
  pps_tsk_freeslotsfortasktemplates.FreeInterval_End,
  pps_tsk_freeslotsfortasktemplates.FreeInterval_Start,
  pps_tsk_freeslotsfortasktemplates.TaskTemplate_RefID,
  pps_tsk_freeslotsfortasktemplates.FreeSlotsForTaskTemplateITPL,
  pps_tsk_freeslotsfortasktemplates.PPS_TSK_FreeSlotsForTaskTemplateID,
  pps_tsk_freeslotsfortasktemplates.Office_RefID
From
  pps_tsk_freeslotsfortasktemplates
Where
  pps_tsk_freeslotsfortasktemplates.IsDeleted = 0 And
  pps_tsk_freeslotsfortasktemplates.PPS_TSK_FreeSlotsForTaskTemplateID = @SlotID And
  pps_tsk_freeslotsfortasktemplates.Tenant_RefID = @TenantID
  