
Select
  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
  cmn_str_offices.Office_Name_DictID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_addresses.Country_ISOCode,
  cmn_str_offices.Office_InternalNumber As PracticeIDString,
  cmn_per_personinfo.FirstName As ContactPersonFirstName,
  cmn_per_personinfo.LastName As ContactPersonLastName,
  cmn_per_personinfo.Title As ContactPersonTitle,
  cmn_str_office_worktimetemplateexceptions.CMN_STR_Office_WorktimeTemplateExceptionID,
  cmn_str_office_weekly_worktimetemplates.CMN_STR_Office_Weekly_WorkTimeTemplateID,
  (Case
    When
    cmn_str_office_worktimetemplateexceptions.CMN_STR_Office_WorktimeTemplateExceptionID Is Not Null Or cmn_str_office_weekly_worktimetemplates.CMN_STR_Office_Weekly_WorkTimeTemplateID Is Not Null Then true Else false End) As hasOpeningTime,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
  cmn_str_offices1.Office_Name_DictID As Parent_Office_Name_DictID,
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID
From
  cmn_str_offices Inner Join
  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_addresses.Office_RefID And
    cmn_str_office_addresses.IsDeleted = 0 And  cmn_str_office_addresses.Tenant_RefID = @TenantID And
    cmn_str_office_addresses.IsDefault = 1 Left Join
  cmn_addresses On cmn_addresses.CMN_AddressID =
    cmn_str_office_addresses.CMN_Address_RefID And cmn_addresses.IsDeleted = 0 And cmn_addresses.Tenant_RefID = @TenantID
    Inner Join  cmn_str_office_responsiblepersons On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_responsiblepersons.Office_RefID And
    cmn_str_office_responsiblepersons.IsDeleted = 0 And cmn_str_office_responsiblepersons.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_emp_employees
    On cmn_str_office_responsiblepersons.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
    cmn_bpt_emp_employees.IsDeleted = 0 And cmn_bpt_emp_employees.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And      
    cmn_bpt_businessparticipants.IsDeleted = 0 And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID 
    Inner Join cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0 And cmn_per_personinfo.Tenant_RefID = @TenantID 
    Left Join
  cmn_str_office_weekly_worktimetemplates On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_weekly_worktimetemplates.Office_RefID And
    cmn_str_office_weekly_worktimetemplates.IsDeleted = 0 And cmn_str_office_weekly_worktimetemplates.Tenant_RefID = @TenantID
    Left Join 
    cmn_str_office_worktimetemplateexceptions On cmn_str_offices.CMN_STR_OfficeID
    = cmn_str_office_worktimetemplateexceptions.Office_RefID And
    cmn_str_office_worktimetemplateexceptions.Tenant_RefID = @TenantID
    And cmn_str_office_worktimetemplateexceptions.IsDeleted = 0 
    Left Join pps_tsk_task_template_organizationalunitavailabilities
    On cmn_str_offices.CMN_STR_OfficeID =
    pps_tsk_task_template_organizationalunitavailabilities.CMN_STR_Office_RefID
    And pps_tsk_task_template_organizationalunitavailabilities.IsDeleted = 0 
    And pps_tsk_task_template_organizationalunitavailabilities.Tenant_RefID = @TenantID
  Left Join
  pps_tsk_task_templates
    On
    pps_tsk_task_template_organizationalunitavailabilities.PPS_TSK_Task_Template_RefID = pps_tsk_task_templates.PPS_TSK_Task_TemplateID And pps_tsk_task_templates.Tenant_RefID = @TenantID And pps_tsk_task_templates.IsDeleted = 0 Left Join
  cmn_str_offices cmn_str_offices1 On cmn_str_offices1.CMN_STR_OfficeID =
    cmn_str_offices.Parent_RefID And cmn_str_offices1.IsDeleted = 0 And cmn_str_offices1.Tenant_RefID = @TenantID
    Left Join ((hec_medicalpractice_2_practicetype Inner Join
  hec_medicalpractice_types
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And hec_medicalpractice_types.IsDeleted = 0 And hec_medicalpractice_types.Tenant_RefID = @TenantID ) Inner Join
  hec_medicalpractises On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID And hec_medicalpractice_2_practicetype.IsDeleted = 0 And hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID) On cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID
Where
  cmn_str_offices.Tenant_RefID = @TenantID And
  cmn_str_offices.IsDeleted = 0
  