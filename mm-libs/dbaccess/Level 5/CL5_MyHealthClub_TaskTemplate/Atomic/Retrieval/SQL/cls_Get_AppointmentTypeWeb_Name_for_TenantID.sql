
Select
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID,
  pps_tsk_task_requiredstaff.Required_Employee_RefID,
  pps_tsk_task_requiredstaff_skills.CMN_STR_Skill_RefID,
  pps_tsk_task_requiredstaff_professions.CMN_STR_Profession_RefID,
  pps_tsk_task_template_requireddevices.DEV_Device_RefID,
  pps_tsk_task_templates.Duration_EstimatedMax_in_sec,
  pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID,
  pps_tsk_task_requiredstaff.StaffQuantity,
  pps_tsk_task_template_requireddevices.RequiredQuantity
From
  pps_tsk_task_templates Left Join
  pps_tsk_task_template_excludedavailabilitytypes
    On
    pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_RefID
    = pps_tsk_task_templates.PPS_TSK_Task_TemplateID and pps_tsk_task_template_excludedavailabilitytypes.IsDeleted = 0 Left Join
  pps_tsk_task_requiredstaff On pps_tsk_task_templates.PPS_TSK_Task_TemplateID =
    pps_tsk_task_requiredstaff.TaskTemplate_RefID And
    pps_tsk_task_requiredstaff.IsDeleted = 0 And
    pps_tsk_task_requiredstaff.Tenant_RefID = @TenantID Left Join
  pps_tsk_task_requiredstaff_skills
    On pps_tsk_task_requiredstaff_skills.RequiredStaff_RefID =
    pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID And
    pps_tsk_task_requiredstaff_skills.Tenant_RefID = @TenantID And
    pps_tsk_task_requiredstaff_skills.IsDeleted = 0 Left Join
  pps_tsk_task_requiredstaff_professions
    On pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID =
    pps_tsk_task_requiredstaff_professions.RequiredStaff_RefID And
    pps_tsk_task_requiredstaff_professions.Tenant_RefID = @TenantID And
    pps_tsk_task_requiredstaff_professions.IsDeleted = 0 Left Join
  pps_tsk_task_template_requireddevices
    On pps_tsk_task_templates.PPS_TSK_Task_TemplateID =
    pps_tsk_task_template_requireddevices.TaskTemplate_RefID And
    pps_tsk_task_template_requireddevices.IsDeleted = 0 And
    pps_tsk_task_template_requireddevices.Tenant_RefID = @TenantID
Where
  pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_ExcludedAvailabilityTypeID is null
  And
  pps_tsk_task_templates.Tenant_RefID = @TenantID And
  pps_tsk_task_templates.IsDeleted = 0
  