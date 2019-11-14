
Select
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
  pps_tsk_task_template_requireddevices.PPS_TSK_Task_Template_RequiredDeviceID,
  pps_tsk_task_templates.Duration_EstimatedMax_in_sec,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_task_templates.Duration_Recommended_in_sec,
  pps_tsk_task_template_requireddevices.DEV_Device_RefID,
  pps_tsk_task_template_requireddevices.TaskTemplate_RefID As
  TaskTemplate_RefID_Device,
  pps_tsk_task_template_requireddevices.RequiredQuantity,
  pps_dev_devices.PPS_DEV_DeviceID,
  pps_dev_devices.DeviceName_DictID,
  pps_dev_devices.DeviceDisplayName,
  pps_tsk_task_requiredstaff_professions.CMN_STR_Profession_RefID,
  pps_tsk_task_requiredstaff_skills.CMN_STR_Skill_RefID,
  pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID,
  pps_tsk_task_requiredstaff.StaffQuantity,
  pps_tsk_task_requiredstaff.Required_Employee_RefID,
  pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_RefID As
  isNotWebBookable,
  cmn_str_skills.Skill_Name_DictID,
  cmn_str_professions.ProfessionName_DictID
From
  pps_tsk_task_templates Left Join
  pps_tsk_task_template_requireddevices
    On pps_tsk_task_template_requireddevices.TaskTemplate_RefID =
    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
    (pps_tsk_task_template_requireddevices.IsDeleted = 0 Or
      pps_tsk_task_template_requireddevices.IsDeleted Is Null) Left Join
  pps_dev_devices On pps_dev_devices.PPS_DEV_DeviceID =
    pps_tsk_task_template_requireddevices.DEV_Device_RefID And
    (pps_dev_devices.IsDeleted = 0 Or pps_dev_devices.IsDeleted Is Null)
  Left Join
  pps_tsk_task_requiredstaff On pps_tsk_task_templates.PPS_TSK_Task_TemplateID =
    pps_tsk_task_requiredstaff.TaskTemplate_RefID And
    pps_tsk_task_requiredstaff.Tenant_RefID = @TenantID And
    pps_tsk_task_requiredstaff.IsDeleted = 0 Left Join
  pps_tsk_task_requiredstaff_professions
    On pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID =
    pps_tsk_task_requiredstaff_professions.RequiredStaff_RefID And
    pps_tsk_task_requiredstaff_professions.Tenant_RefID = @TenantID And
    pps_tsk_task_requiredstaff_professions.IsDeleted = 0 Left Join
  pps_tsk_task_requiredstaff_skills
    On pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID =
    pps_tsk_task_requiredstaff_skills.RequiredStaff_RefID And
    pps_tsk_task_requiredstaff_skills.Tenant_RefID = @TenantID And
    pps_tsk_task_requiredstaff_skills.IsDeleted = 0 Left Join
  pps_tsk_task_template_excludedavailabilitytypes
    On pps_tsk_task_templates.PPS_TSK_Task_TemplateID =
    pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_RefID
    And pps_tsk_task_template_excludedavailabilitytypes.Tenant_RefID = @TenantID
    And pps_tsk_task_template_excludedavailabilitytypes.IsDeleted = 0 Left Join
  cmn_str_skills On pps_tsk_task_requiredstaff_skills.CMN_STR_Skill_RefID =
    cmn_str_skills.CMN_STR_SkillID And cmn_str_skills.IsDeleted = 0 And
    cmn_str_skills.Tenant_RefID = @TenantID Left Join
  cmn_str_professions
    On pps_tsk_task_requiredstaff_professions.CMN_STR_Profession_RefID =
    cmn_str_professions.CMN_STR_ProfessionID  And
  cmn_str_professions.IsDeleted = 0 And
  cmn_str_professions.Tenant_RefID = @TenantID
Where
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID = @TaskTemplateID And
  pps_tsk_task_templates.IsDeleted = 0 And
  pps_tsk_task_templates.Tenant_RefID = @TenantID
  