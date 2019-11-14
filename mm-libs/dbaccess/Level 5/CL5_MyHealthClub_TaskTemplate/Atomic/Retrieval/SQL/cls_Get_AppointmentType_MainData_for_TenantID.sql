
	Select
	  pps_tsk_task_templates.Duration_EstimatedMax_in_sec,
	  pps_tsk_task_templates.TaskTemplateName_DictID,
	  pps_tsk_task_templates.Duration_Recommended_in_sec,
	  pps_tsk_task_template_requireddevices.RequiredQuantity As DeviceQuantity,
	  pps_dev_devices.DeviceDisplayName,
	  pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_RefID As
	  isNotWebBookable,
	  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
	  cmn_str_professions.ProfessionName_DictID,
	  cmn_str_skills.Skill_Name_DictID,
	  cmn_per_personinfo.FirstName As ReqEmployeeFirstName,
	  cmn_per_personinfo.LastName As ReqEmployeeLastName,
	  cmn_per_personinfo.Title As EmployeeTitle,
  pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID,
  pps_tsk_task_requiredstaff_skills.PPS_TSK_Task_RequiredStaff_SkillID,
  pps_tsk_task_template_requireddevices.PPS_TSK_Task_Template_RequiredDeviceID,
  pps_tsk_task_requiredstaff_professions.PPS_TSK_Task_RequiredStaff_ProfessionID,
  pps_tsk_task_requiredstaff.Required_Employee_RefID,
  pps_tsk_task_requiredstaff.StaffQuantity
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
	    pps_tsk_task_requiredstaff.Tenant_RefID =
	    @TenantID And
	    pps_tsk_task_requiredstaff.IsDeleted = 0 Left Join
	  pps_tsk_task_requiredstaff_professions
	    On pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID =
	    pps_tsk_task_requiredstaff_professions.RequiredStaff_RefID And
	    pps_tsk_task_requiredstaff_professions.Tenant_RefID =
	    @TenantID And
	    pps_tsk_task_requiredstaff_professions.IsDeleted = 0 Left Join
	  pps_tsk_task_requiredstaff_skills
	    On pps_tsk_task_requiredstaff.PPS_TSK_Task_RequiredStaffID =
	    pps_tsk_task_requiredstaff_skills.RequiredStaff_RefID And
	    pps_tsk_task_requiredstaff_skills.Tenant_RefID =
	    @TenantID And
	    pps_tsk_task_requiredstaff_skills.IsDeleted = 0 Left Join
	  pps_tsk_task_template_excludedavailabilitytypes
	    On pps_tsk_task_templates.PPS_TSK_Task_TemplateID =
	    pps_tsk_task_template_excludedavailabilitytypes.PPS_TSK_Task_Template_RefID
	    And pps_tsk_task_template_excludedavailabilitytypes.Tenant_RefID =
	    @TenantID And
	    pps_tsk_task_template_excludedavailabilitytypes.IsDeleted = 0 Left Join
	  cmn_str_professions On cmn_str_professions.CMN_STR_ProfessionID =
	    pps_tsk_task_requiredstaff_professions.CMN_STR_Profession_RefID And
	    cmn_str_professions.IsDeleted = 0 And cmn_str_professions.Tenant_RefID =
	    @TenantID Left Join
	  cmn_str_skills On pps_tsk_task_requiredstaff_skills.CMN_STR_Skill_RefID =
	    cmn_str_skills.CMN_STR_SkillID And cmn_str_skills.Tenant_RefID =
	    @TenantID And
	    cmn_str_skills.IsDeleted = 0 Left Join
	  cmn_bpt_emp_employees On pps_tsk_task_requiredstaff.Required_Employee_RefID =
	    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
	    cmn_bpt_emp_employees.IsDeleted = 0 And cmn_bpt_emp_employees.Tenant_RefID =
	    @TenantID Left Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID =
	    @TenantID Left Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And
	    cmn_per_personinfo.Tenant_RefID = @TenantID
	Where
	  pps_tsk_task_templates.IsDeleted = 0 And
	  pps_tsk_task_templates.Tenant_RefID = @TenantID
  