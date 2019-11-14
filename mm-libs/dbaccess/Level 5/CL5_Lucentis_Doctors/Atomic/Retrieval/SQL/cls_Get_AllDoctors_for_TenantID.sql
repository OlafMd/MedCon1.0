
Select
  hec_doctors.HEC_DoctorID,
  hec_doctors.DoctorIDNumber As LANR,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  Practices.PracticeName,
  Practices.PracticeID,
  hec_doctors.Account_RefID,
  cmn_per_personinfo.PrimaryEmail,
  Practices.HEC_MedicalPractiseID
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID,
    cmn_bpt_businessparticipants.DisplayName As PracticeName,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As PracticeID,
    hec_medicalpractises.HEC_MedicalPractiseID
  From
    cmn_bpt_businessparticipant_associatedbusinessparticipants Inner Join
    cmn_bpt_businessparticipants
      On
      cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    hec_medicalpractises
      On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
      hec_medicalpractises.Ext_CompanyInfo_RefID
  Where
    cmn_bpt_businessparticipants.IsCompany = 1 And
    cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0) Practices
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    Practices.BusinessParticipant_RefID
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_doctors.Tenant_RefID = @TenantID
  