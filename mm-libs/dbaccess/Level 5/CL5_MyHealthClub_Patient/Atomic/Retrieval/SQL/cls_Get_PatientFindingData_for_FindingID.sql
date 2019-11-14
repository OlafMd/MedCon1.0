
Select
  Concat_Ws(' ', cmn_per_personinfo.FirstName, cmn_per_personinfo.LastName) As
  patient_name,
  hec_patient_findings.Creation_Timestamp As CreationDate,
  Concat_Ws(' ', cmn_per_personinfo1.Title, cmn_per_personinfo1.FirstName,
  cmn_per_personinfo1.LastName) As doctor_name,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  cmn_str_offices.Office_Name_DictID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID
From
  hec_patient_findings Inner Join
  hec_patients
    On hec_patients.HEC_PatientID = hec_patient_findings.Patient_RefID
    And hec_patients.IsDeleted = 0 And hec_patients.Tenant_RefID = @TenantID
  Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_patients.CMN_BPT_BusinessParticipant_RefID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Left Join
  hec_doctors On hec_patient_findings.UndersigningDoctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.IsCompany = 0 And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Left Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo1.CMN_PER_PersonInfoID And cmn_per_personinfo1.IsDeleted =
    0 And cmn_per_personinfo1.Tenant_RefID = @TenantID Inner Join
  hec_act_performedaction_referrals
    On hec_patient_findings.IfFindingFromReferral_Referral_RefID =
    hec_act_performedaction_referrals.HEC_ACT_PerformedAction_ReferralID And
    hec_act_performedaction_referrals.Tenant_RefID = @TenantID And
    hec_act_performedaction_referrals.IsDeleted = 0 Inner Join
  hec_medicalpractice_types
    On hec_act_performedaction_referrals.ReferralTo_MedicalPracticeType_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    hec_medicalpractice_types.IsDeleted = 0 And
    hec_medicalpractice_types.Tenant_RefID = @TenantID Left Join
  cmn_str_offices On hec_patient_findings.MedicalPractice_RefID =
    cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID Left Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_act_performedaction_referrals.ReferralTo_MedicalPractice_RefID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0
Where
  hec_patient_findings.HEC_Patient_FindingID = @FindingID And
  hec_patient_findings.Patient_RefID = @PatientID And
  hec_patient_findings.Tenant_RefID = @TenantID And
  hec_patient_findings.IsDeleted = 0
  