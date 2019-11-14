
Select
  pps_tsk_task_templates.TaskTemplateName_DictID,
  pps_tsk_tasks.DisplayName,
  pps_tsk_tasks.PPS_TSK_TaskID,
  cmn_per_personinfo.FirstName As DoctorFirstName,
  cmn_per_personinfo.LastName As DoctorLastName,
  cmn_str_offices.Office_Name_DictID,
  cmn_per_personinfo1.FirstName As PatientFirstName,
  cmn_per_personinfo1.LastName As PatientLastName,
  cmn_per_personinfo1.BirthDate As PatientBirthDay,
  cmn_per_personinfo2.FirstName As RequiredDoctorFirstName,
  cmn_per_personinfo2.LastName As RequiredDoctorLastName,
  pps_tsk_tasks.PlannedStartDate,
  pps_tsk_tasks.PlannedDuration_in_sec,
  cmn_per_personinfo2.Title As RequiredDoctorTitle,
  cmn_per_personinfo.Title As DoctorTitle,
  cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID As
  RequiredDoctorID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As DoctorID,
  hec_doctors1.HEC_DoctorID As RequiredDoctorFlag,
  hec_doctors.HEC_DoctorID As DoctorFlag,
  cmn_per_personinfo1.Salutation_General As AcademicTitle,
  cmn_per_communicationcontacts.Content,
  cmn_per_personinfo1.PrimaryEmail
From
  pps_tsk_task_templates Inner Join
  pps_tsk_tasks On pps_tsk_tasks.InstantiatedFrom_TaskTemplate_RefID =
    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And pps_tsk_tasks.IsDeleted =
    0 And pps_tsk_tasks.Tenant_RefID = @TenantID Left Join
  pps_tsk_task_staffbookings On pps_tsk_tasks.PPS_TSK_TaskID =
    pps_tsk_task_staffbookings.PPS_TSK_Task_RefID And
    pps_tsk_task_staffbookings.Tenant_RefID = @TenantID And
    pps_tsk_task_staffbookings.IsDeleted = 0 Left Join
  cmn_bpt_emp_employees On pps_tsk_task_staffbookings.CMN_BPT_EMP_Employee_RefID
    = cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
    cmn_bpt_emp_employees.IsDeleted = 0 And cmn_bpt_emp_employees.Tenant_RefID =
    @TenantID Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    hec_doctors.IsDeleted = 0 And hec_doctors.Tenant_RefID = @TenantID
  Inner Join
  pps_tsk_task_officebookings On pps_tsk_task_officebookings.PPS_TSK_Task_RefID
    = pps_tsk_tasks.PPS_TSK_TaskID And pps_tsk_task_officebookings.Tenant_RefID
    = @TenantID And pps_tsk_task_officebookings.IsDeleted = 0 Inner Join
  cmn_str_offices On pps_tsk_task_officebookings.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.Tenant_RefID =
    @TenantID And cmn_str_offices.IsDeleted = 0 Inner Join
  hec_app_appointments On hec_app_appointments.Ext_PPS_TSK_Task_RefID =
    pps_tsk_tasks.PPS_TSK_TaskID And hec_app_appointments.Tenant_RefID =
    @TenantID And hec_app_appointments.IsDeleted = 0 Inner Join
  hec_patients On hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID =
    @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.IsCompany = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_per_personinfo1.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID And
    cmn_per_personinfo1.IsDeleted = 0 And cmn_per_personinfo1.Tenant_RefID =
    @TenantID Left Join
  pps_tsk_task_requiredstaff On pps_tsk_task_requiredstaff.TaskTemplate_RefID =
    pps_tsk_task_templates.PPS_TSK_Task_TemplateID And
    pps_tsk_task_requiredstaff.IsDeleted = 0 And
    pps_tsk_task_requiredstaff.Tenant_RefID = @TenantID Left Join
  cmn_bpt_emp_employees cmn_bpt_emp_employees1
    On cmn_bpt_emp_employees1.CMN_BPT_EMP_EmployeeID =
    pps_tsk_task_requiredstaff.Required_Employee_RefID And
    cmn_bpt_emp_employees1.IsDeleted = 0 And cmn_bpt_emp_employees1.Tenant_RefID
    = @TenantID Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On cmn_bpt_emp_employees1.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants2.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants2.IsCompany = 0 And
    cmn_bpt_businessparticipants2.IsDeleted = 0 And
    cmn_bpt_businessparticipants2.Tenant_RefID = @TenantID Left Join
  cmn_per_personinfo cmn_per_personinfo2
    On cmn_bpt_businessparticipants2.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo2.CMN_PER_PersonInfoID And cmn_per_personinfo2.IsDeleted =
    0 And cmn_per_personinfo2.Tenant_RefID = @TenantID Left Join
  hec_doctors hec_doctors1 On hec_doctors1.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID And
    hec_doctors1.IsDeleted = 0 And hec_doctors1.Tenant_RefID = @TenantID
  Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo1.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID And
    cmn_per_communicationcontacts.IsDeleted = 0 And
    cmn_per_communicationcontacts.Tenant_RefID = @TenantID Inner Join
  cmn_per_communicationcontact_types
    On cmn_per_communicationcontacts.Contact_Type =
    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID And
    cmn_per_communicationcontact_types.Type = @Type And
    cmn_per_communicationcontact_types.IsDeleted = 0 And
    cmn_per_communicationcontact_types.Tenant_RefID = @TenantID Inner Join
  pprs_tsk_task_selectedavailabilitytypes On pps_tsk_tasks.PPS_TSK_TaskID =
    pprs_tsk_task_selectedavailabilitytypes.PPS_TSK_Task_RefID And
    pprs_tsk_task_selectedavailabilitytypes.Tenant_RefID = @TenantID And
    pprs_tsk_task_selectedavailabilitytypes.IsDeleted = 0 Inner Join
  hec_act_plannedactions On hec_act_plannedactions.Patient_RefID =
    hec_patients.HEC_PatientID And hec_act_plannedactions.Appointment_RefID =
    hec_app_appointments.HEC_APP_AppointmentID Inner Join
  pprs_tsk_task_selectedavailabilitytypes
  pprs_tsk_task_selectedavailabilitytypes1
    On pprs_tsk_task_selectedavailabilitytypes1.PPS_TSK_Task_RefID =
    pps_tsk_tasks.PPS_TSK_TaskID And
    pprs_tsk_task_selectedavailabilitytypes1.IsDeleted = 0 Inner Join
  cmn_cal_ava_availability_types
    On cmn_cal_ava_availability_types.CMN_CAL_AVA_Availability_TypeID =
    pprs_tsk_task_selectedavailabilitytypes1.CMN_CAL_AVA_Availability_Type_RefID
    And cmn_cal_ava_availability_types.IsDeleted = 0
Where
  pps_tsk_task_templates.Tenant_RefID = @TenantID And
  pps_tsk_task_templates.IsDeleted = 0 And
  cmn_cal_ava_availability_types.GlobalPropertyMatchingID = @TaskType
  