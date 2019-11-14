
Select
  cmn_per_personinfo.Title As ContactPersonTitle,
  cmn_per_personinfo.FirstName As ContactPersonFirstName,
  cmn_per_personinfo.LastName As ContactPersonLastName,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Town,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  hec_medicalpractises.HEC_MedicalPractiseID,
  hec_medicalservices.ServiceName_DictID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  cmn_bpt_ctm_organizationalunits.Default_PhoneNumber,
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
  cmn_universalcontactdetails.Contact_Website_URL,
  hec_medicalservices.HEC_MedicalServiceID
From
  hec_medicalpractises Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.IsCompany = 1 And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_medicalpractises.ContactPerson_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  hec_medicalpractice_2_practicetype
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID And
    hec_medicalpractice_2_practicetype.IsDeleted = 0 And
    hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID Left Join
  hec_medicalpractice_types
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    hec_medicalpractice_types.IsDeleted = 0 And
    hec_medicalpractice_types.Tenant_RefID = @TenantID Inner Join
  hec_medicalpractice_offeredservices
    On hec_medicalpractises.HEC_MedicalPractiseID =
    hec_medicalpractice_offeredservices.MedicalPractice_RefID And
    hec_medicalpractice_offeredservices.Tenant_RefID = @TenantID And
    hec_medicalpractice_offeredservices.IsDeleted = 0 Inner Join
  hec_medicalservices On hec_medicalservices.HEC_MedicalServiceID =
    hec_medicalpractice_offeredservices.MedicalService_RefID And
    hec_medicalservices.Tenant_RefID = @TenantID And
    hec_medicalservices.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits On hec_medicalpractises.HEC_MedicalPractiseID
    =
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    And cmn_bpt_ctm_organizationalunits.IsMedicalPractice = 1 And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0
Where
  hec_medicalpractises.HEC_MedicalPractiseID = @MedicalPractiseID And
  hec_medicalpractises.IsDeleted = 0 And
  hec_medicalpractises.Tenant_RefID = @TenantID And
  hec_medicalpractises.IsHospital = 1
  