
Select
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  hec_act_performedactions.IfPerfomed_DateOfAction,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
  hec_act_performedaction_doctors.HEC_Doctor_RefID,
  cmn_per_personinfo.FirstName As PatientFirstName,
  cmn_per_personinfo.LastName As PatientLastName,
  hec_patients.HEC_PatientID,
  hec_act_performedactions.HEC_ACT_PerformedActionID,
  cmn_per_personinfo1.Title As DoctorTitle,
  cmn_per_personinfo1.FirstName As DoctorFirstName,
  cmn_per_personinfo1.LastName As DoctorLastName,
  hec_medicalpractises.HEC_MedicalPractiseID
From
  hec_act_performedaction_referrals Inner Join
  hec_act_performedactions On hec_act_performedactions.HEC_ACT_PerformedActionID
    = hec_act_performedaction_referrals.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_referrals.IsDeleted = 0 And
    hec_act_performedaction_referrals.Tenant_RefID = @TenantID Inner Join
  hec_act_performedaction_doctors
    On hec_act_performedaction_doctors.HEC_ACT_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_performedactions.IsDeleted = 0 And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsPerformed_Externally = 0 Left Join
  hec_medicalpractises
    On
    hec_act_performedaction_referrals.PatientEffectivelyWentTo_MedicalPractice_RefID = hec_medicalpractises.HEC_MedicalPractiseID And hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID = @TenantID And hec_act_performedaction_referrals.IsReferral_ForFollowup = 0 Left Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
    cmn_bpt_ctm_organizationalunits.IsMedicalPractice = 1 Inner Join
  hec_medicalpractice_types
    On hec_act_performedaction_referrals.ReferralTo_MedicalPracticeType_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    hec_medicalpractice_types.IsDeleted = 0 And
    hec_medicalpractice_types.Tenant_RefID = @TenantID Inner Join
  hec_patients On hec_act_performedactions.Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  hec_doctors On hec_act_performedaction_doctors.HEC_Doctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants1.IsDeleted = 0 Inner Join
  cmn_per_personinfo cmn_per_personinfo1
    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo1.CMN_PER_PersonInfoID And cmn_per_personinfo1.IsDeleted =
    0 And cmn_per_personinfo1.Tenant_RefID = @TenantID
Where
  hec_act_performedaction_doctors.HEC_Doctor_RefID = @ListDoctorID And
  hec_act_performedaction_doctors.Tenant_RefID = @TenantID And
  hec_act_performedaction_doctors.IsDeleted = 0
  