
DELETE from
  pps_tsk_freeslotsfortasktemplates
From
  pps_tsk_freeslotsfortasktemplates
Where
  pps_tsk_freeslotsfortasktemplates.IsDeleted = 0 And
  pps_tsk_freeslotsfortasktemplates.Tenant_RefID = @TenantID And
  pps_tsk_freeslotsfortasktemplates.PPS_TSK_FreeSlotsForTaskTemplateID = @SlotIDList
  