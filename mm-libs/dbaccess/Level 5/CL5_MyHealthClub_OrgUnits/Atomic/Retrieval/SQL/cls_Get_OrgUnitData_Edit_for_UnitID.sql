
Select
  cmn_str_offices.Parent_RefID,
  cmn_str_offices.DisplayImage_Document_RefID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Default_PhoneNumber As PhoneNumber,
  cmn_str_office_addresses.IsDefault As IsDefaultAddress,
  cmn_str_office_addresses.IsSpecialAddress,
  cmn_str_office_addresses.IsBillingAddress,
  cmn_str_office_addresses.IsShippingAddress,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode As ZIP,
  cmn_addresses.Country_ISOCode,
  cmn_per_personinfo.FirstName As ContactPersonFirstName,
  cmn_per_personinfo.LastName As ContactPersonLastName,
  cmn_per_personinfo.Title As ContactPersonTitle,
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Default_Email,
  cmn_str_offices.Default_Website,
  cmn_str_offices1.Office_Name_DictID As ParentNameDict,
  cmn_str_offices.Comment,
  cmn_addresses.Lattitude,
  cmn_addresses.Longitude,
  pps_tsk_task_template_organizationalunitavailabilities.PPS_TSK_Task_Template_RefID,
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  cmn_languages.CMN_LanguageID,
  cmn_languages.Name_DictID,
  cmn_languages.IsDeleted,
  cmn_addresses.Country_Name
From
  cmn_str_offices Left Join
  cmn_str_office_addresses On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_addresses.Office_RefID And
    cmn_str_office_addresses.Tenant_RefID = @TenantID And
    cmn_str_office_addresses.IsDeleted = 0 Left Join
  cmn_addresses On cmn_str_office_addresses.CMN_Address_RefID =
    cmn_addresses.CMN_AddressID And cmn_addresses.Tenant_RefID = @TenantID And
    cmn_addresses.IsDeleted = 0 Inner Join
  cmn_str_office_responsiblepersons
    On cmn_str_office_responsiblepersons.Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And
    cmn_str_office_responsiblepersons.Tenant_RefID = @TenantID And
    cmn_str_office_responsiblepersons.IsDeleted = 0 Inner Join
  cmn_bpt_emp_employees
    On cmn_str_office_responsiblepersons.CMN_BPT_EMP_Employee_RefID =
    cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID And
    cmn_bpt_emp_employees.Tenant_RefID = @TenantID And
    cmn_bpt_emp_employees.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  cmn_str_offices cmn_str_offices1 On cmn_str_offices.Parent_RefID =
    cmn_str_offices1.CMN_STR_OfficeID And cmn_str_offices1.IsDeleted = 0 And
    cmn_str_offices1.Tenant_RefID = @TenantID Left Join
  pps_tsk_task_template_organizationalunitavailabilities
    On
    pps_tsk_task_template_organizationalunitavailabilities.CMN_STR_Office_RefID
    = cmn_str_offices.CMN_STR_OfficeID And
    pps_tsk_task_template_organizationalunitavailabilities.IsDeleted = 0 And
    pps_tsk_task_template_organizationalunitavailabilities.Tenant_RefID =
    @TenantID Left Join
  ((hec_medicalpractice_2_practicetype Inner Join
  hec_medicalpractice_types
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    hec_medicalpractice_types.IsDeleted = 0 And
    hec_medicalpractice_types.Tenant_RefID = @TenantID) Inner Join
  hec_medicalpractises On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID And
    hec_medicalpractice_2_practicetype.IsDeleted = 0 And
    hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID)
    On cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Left Join
  (cmn_str_office_spokenlanguages Inner Join
  cmn_languages On cmn_str_office_spokenlanguages.Language_RefID =
    cmn_languages.CMN_LanguageID And cmn_str_office_spokenlanguages.IsDeleted =
    0 And cmn_str_office_spokenlanguages.Tenant_RefID = @TenantID)
    On cmn_str_offices.CMN_STR_OfficeID =
    cmn_str_office_spokenlanguages.Office_RefID
Where
  cmn_str_offices.CMN_STR_OfficeID = @OfficeID And
  cmn_str_offices.IsDeleted = 0 And
  cmn_str_offices.Tenant_RefID = @TenantID
  