
Select
  hec_act_performedaction_referrals.HEC_ACT_PerformedAction_ReferralID As id,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID
  
From
  hec_act_performedaction_referrals Left Join
  hec_medicalpractises
    On hec_act_performedaction_referrals.ReferralTo_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID = @TenantID
  Left Join
  hec_medicalpractice_types
    On hec_act_performedaction_referrals.ReferralTo_MedicalPracticeType_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    hec_medicalpractice_types.IsDeleted = 0 And
    hec_medicalpractice_types.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID
Where
  cmn_bpt_ctm_organizationalunits.IsDeleted = 0 And
  hec_act_performedaction_referrals.Tenant_RefID = @TenantID And
  hec_act_performedaction_referrals.IsDeleted = 0 And
  hec_act_performedaction_referrals.HEC_ACT_PerformedAction_RefID =
  @ExaminationID And
  cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID
  