
Select
  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_InternalNumber As PracticeIDString,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID
From
  cmn_str_offices Left Join
  pps_tsk_task_template_organizationalunitavailabilities
    On cmn_str_offices.CMN_STR_OfficeID =
    pps_tsk_task_template_organizationalunitavailabilities.CMN_STR_Office_RefID
    And pps_tsk_task_template_organizationalunitavailabilities.IsDeleted = 0 And
    pps_tsk_task_template_organizationalunitavailabilities.Tenant_RefID =
    @TenantID Left Join
  pps_tsk_task_templates
    On
    pps_tsk_task_template_organizationalunitavailabilities.PPS_TSK_Task_Template_RefID = pps_tsk_task_templates.PPS_TSK_Task_TemplateID And pps_tsk_task_templates.Tenant_RefID = @TenantID And pps_tsk_task_templates.IsDeleted = 0
Where
  cmn_str_offices.Tenant_RefID = @TenantID And
  cmn_str_offices.IsDeleted = 0
  