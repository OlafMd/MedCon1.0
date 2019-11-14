
Select
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Gender,
  cmn_bpt_businessparticipants.DefaultLanguage_RefID,
  hec_doctors.HEC_DoctorID,
  hec_doctors.Tenant_RefID,
  hec_doctors.IsDeleted,
  hec_doctors.Creation_Timestamp,
  hec_doctors.Account_RefID,
  hec_doctors.Modification_Timestamp As Modification_TimestampDoctors,
  cmn_bpt_businessparticipants.Modification_Timestamp As
  Modification_TimestampBpart,
  cmn_per_personinfo.Modification_Timestamp As Modification_TimestampPersonInfo,
  cmn_per_personinfo.AgeCalculation_YearOfBirth,
  cmn_per_personinfo.Initials,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Default_PhoneNumber,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Country_Name,
  cmn_addresses.Modification_Timestamp As Modification_TimestampAdress,
  cmn_per_personinfo.Title,
  cmn_str_offices.Default_Email,
  cmn_str_offices.Default_Website,
  hec_doctors.DoctorIDNumber,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
  cmn_bpt_emp_employees On cmn_bpt_emp_employees.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Left Join
  cmn_bpt_emp_employee_2_office On cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID
    = cmn_bpt_emp_employee_2_office.CMN_BPT_EMP_Employee_RefID Left Join
  cmn_str_offices On cmn_bpt_emp_employee_2_office.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Left Join
  cmn_str_office_addresses On cmn_str_office_addresses.Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID Left Join
  cmn_addresses On cmn_str_office_addresses.CMN_Address_RefID =
    cmn_addresses.CMN_AddressID Left Join
  hec_medicalpractice_2_practicetype
    On cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID =
    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID Left Join
  hec_medicalpractice_types
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID
Where
  hec_doctors.Tenant_RefID = @Tenant And
  (cmn_bpt_emp_employees.IsDeleted = 0 Or
    isnull(cmn_bpt_emp_employees.IsDeleted)) And
  (cmn_addresses.IsDeleted = 0 Or
    isnull(cmn_addresses.IsDeleted)) And
  (cmn_str_office_addresses.IsDeleted = 0 Or
    isnull(cmn_str_office_addresses.IsDeleted)) And
  (hec_medicalpractice_2_practicetype.IsDeleted = 0 Or
    isnull(hec_medicalpractice_2_practicetype.IsDeleted)) And
  (hec_medicalpractice_types.IsDeleted = 0 Or
    isnull(hec_medicalpractice_types.IsDeleted))
Group By
  hec_doctors.HEC_DoctorID
  