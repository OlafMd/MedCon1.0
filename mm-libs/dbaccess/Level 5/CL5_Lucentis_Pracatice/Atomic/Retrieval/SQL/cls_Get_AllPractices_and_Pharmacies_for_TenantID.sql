
Select
  Pharmacies.HEC_PharmacyID As PharmacyID,
  Pharmacies.DisplayName As PharmacyName,
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  hec_medicalpractises.HEC_MedicalPractiseID As PracticeID,
  Pharmacies.IsDefault As IsDefaultPharmacy,
  hec_doctors.HEC_DoctorID As My_HEC_DoctorID,
  Doctors.HEC_DoctorID,
  Doctors.FirstName,
  Doctors.LastName,
  Doctors.Title,
  Doctors.Account_RefID,
  cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID As
  CooperatinbussinessParticnID,
  cmn_bpt_businessparticipants2.DisplayName As CooperatingPracticeName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  Doctors.CMN_BPT_BusinessParticipantID As Doctors_CMN_BPT_BusinessParticipantID
From
  cmn_com_companyinfo Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  hec_medicalpractises On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  (Select
    cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID,
    hec_pharmacies.HEC_PharmacyID,
    cmn_bpt_businessparticipants.DisplayName,
    hec_medicalpractise_availablepharmaciesforordering.HEC_MedicalPractise_RefID,
    hec_medicalpractise_availablepharmaciesforordering.IsDefault,
    hec_medicalpractise_availablepharmaciesforordering.Tenant_RefID
  From
    hec_pharmacies Inner Join
    cmn_com_companyinfo On hec_pharmacies.Ext_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
    hec_medicalpractise_availablepharmaciesforordering
      On hec_pharmacies.HEC_PharmacyID =
      hec_medicalpractise_availablepharmaciesforordering.HEC_Pharmacy_RefID
  Where
    hec_medicalpractise_availablepharmaciesforordering.Tenant_RefID = @TenantID
    And
    hec_medicalpractise_availablepharmaciesforordering.IsDeleted = 0 And
    hec_pharmacies.IsDeleted = 0 And
    cmn_com_companyinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0) Pharmacies
    On hec_medicalpractises.HEC_MedicalPractiseID =
    Pharmacies.HEC_MedicalPractise_RefID Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Left Join
  (Select
    hec_doctors.HEC_DoctorID,
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    cmn_per_personinfo.Title,
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID,
    hec_doctors.Tenant_RefID,
    hec_doctors.Account_RefID,
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID
  From
    hec_doctors Inner Join
    cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
      On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Inner Join
    cmn_per_personinfo
      On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID
      = cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
    cmn_bpt_businessparticipant_associatedbusinessparticipants
      On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
      cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID
  Where
    hec_doctors.Tenant_RefID = @TenantID And
    hec_doctors.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted =
    0) Doctors On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    Doctors.AssociatedBusinessParticipant_RefID Left Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
  cmn_bpt_businessparticipant_associatedbusinessparticipants1
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants1.BusinessParticipant_RefID And cmn_bpt_businessparticipant_associatedbusinessparticipants1.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants2
    On cmn_bpt_businessparticipants2.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants1.AssociatedBusinessParticipant_RefID And cmn_bpt_businessparticipants2.IsDeleted = 0
Where
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0 And
  cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
  hec_doctors.Tenant_RefID = @TenantID
  