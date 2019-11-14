
Select
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  hec_doctors.IsTreatingChildren,
  cmn_per_communicationcontacts.PersonInfo_RefID,
  cmn_per_communicationcontacts.Content,
  cmn_per_communicationcontact_types.Type,
  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
  cmn_per_personinfo.Gender,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Office_InternalNumber,
  hec_doctors.DoctorIDNumber,
  cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employees.Staff_Number,
  Skills.Skill_Name_DictID,
  Skills.CMN_STR_SkillID,
  cmn_str_professions.CMN_STR_ProfessionID,
  cmn_str_professions.ProfessionName_DictID,
  cmn_bpt_businessparticipants.DisplayImage_RefID,
  pps_tsk_task_templates.PPS_TSK_Task_TemplateID,
  pps_tsk_task_templates.TaskTemplateName_DictID,
  (Case
    When
    cmn_bpt_businessparticipant_availabilities.CMN_BPT_BusinessParticipant_AvailabilityID Is Not Null Then true Else false End) As hasOpeningTime,
  cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID,
  cmn_bpt_emp_employee_2_profession.IsPrimary,
  hec_doctors.IsTreatingChildren,
  cmn_per_personinfo.Gender,
  cmn_languages.Name_DictID,
  cmn_languages.CMN_LanguageID,
  cmn_per_personinfo.Initials,
  hec_doctors.Account_RefID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_bpt_emp_employees On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  cmn_per_communicationcontacts
    On cmn_per_communicationcontacts.PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID =
    cmn_per_communicationcontacts.Contact_Type Inner Join
  cmn_bpt_emp_employee_2_office
    On cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
  cmn_str_offices On cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Left Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
  (Select
    cmn_bpt_emp_employee_2_skill.Employee_RefID,
    cmn_str_skills.Skill_Name_DictID,
    cmn_str_skills.CMN_STR_SkillID
  From
    cmn_str_skills Inner Join
    cmn_bpt_emp_employee_2_skill On cmn_bpt_emp_employee_2_skill.Skill_RefID =
      cmn_str_skills.CMN_STR_SkillID
  Where
    cmn_bpt_emp_employee_2_skill.IsDeleted = 0 And
    cmn_str_skills.IsDeleted = 0) Skills On Skills.Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
  cmn_bpt_emp_employee_2_profession
    On cmn_bpt_emp_employee_2_profession.Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID Inner Join
  cmn_str_professions On cmn_bpt_emp_employee_2_profession.Profession_RefID =
    cmn_str_professions.CMN_STR_ProfessionID Left Join
  cmn_bpt_businessparticipant_availabilities
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_availabilities.BusinessParticipant_RefID And
    cmn_bpt_businessparticipant_availabilities.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipant_availabilities.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipant_excludedavailabilitytypes
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_excludedavailabilitytypes.CMN_BPT_BusinessParticipant_RefID And cmn_bpt_businessparticipant_excludedavailabilitytypes.IsDeleted = 0 And cmn_bpt_businessparticipant_excludedavailabilitytypes.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipant_spokenlanguages
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_spokenlanguages.CMN_BPT_BusinessParticipant_RefID And cmn_bpt_businessparticipant_spokenlanguages.Tenant_RefID = @TenantID And cmn_bpt_businessparticipant_spokenlanguages.IsDeleted = 0 Left Join
  cmn_languages
    On cmn_bpt_businessparticipant_spokenlanguages.CMN_Language_RefID =
    cmn_languages.CMN_LanguageID And cmn_languages.IsDeleted = 0 And
    cmn_languages.Tenant_RefID = @TenantID Left Join
  hec_doctor_assignableappointmenttypes On hec_doctors.HEC_DoctorID =
    hec_doctor_assignableappointmenttypes.Doctor_RefID And
    hec_doctor_assignableappointmenttypes.IsDeleted = 0 And
    hec_doctor_assignableappointmenttypes.Tenant_RefID = @TenantID Left Join
  pps_tsk_task_templates
    On hec_doctor_assignableappointmenttypes.TaskTemplate_RefID =
    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
    pps_tsk_task_templates.IsDeleted = 0 And pps_tsk_task_templates.Tenant_RefID
    = @TenantID
Where
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_communicationcontacts.IsDeleted = 0 And
  cmn_per_communicationcontact_types.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_bpt_emp_employees.IsDeleted = 0 And
  cmn_bpt_emp_employee_2_profession.IsDeleted = 0 And
  cmn_str_professions.IsDeleted = 0 And
  cmn_str_offices.IsDeleted = 0 And
  cmn_bpt_emp_employee_2_office.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1
  