
Select
  hec_medicalpractice_types.HEC_MedicalPractice_TypeID,
  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
  hec_act_performedaction_referrals.HEC_ACT_PerformedAction_ReferralID,
  hec_act_performedaction_referrals.ReferralComment,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  hec_act_performedaction_referral_requestedpotentialprocedures.ProposedDate,
  hec_tre_potentialprocedures.PotentialProcedure_Name_DictID,
  hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID,
  hec_act_performedaction_referral_requestedpotentialprocedures.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID
From
  hec_act_performedaction_referrals Left Join
  hec_medicalpractice_types
    On hec_act_performedaction_referrals.ReferralTo_MedicalPracticeType_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
    (hec_medicalpractice_types.IsDeleted Is Null Or
      hec_medicalpractice_types.IsDeleted = 0) Left Join
  hec_medicalpractises
    On hec_act_performedaction_referrals.ReferralTo_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    (hec_medicalpractises.IsDeleted Is Null Or hec_medicalpractises.IsDeleted =
      0) Left Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And
    (cmn_bpt_ctm_organizationalunits.IsDeleted Is Null Or
      cmn_bpt_ctm_organizationalunits.IsDeleted = 0) Left Join
  hec_act_performedaction_referral_requestedpotentialprocedures
    On
    hec_act_performedaction_referral_requestedpotentialprocedures.Action_Referral_RefID = hec_act_performedaction_referrals.HEC_ACT_PerformedAction_ReferralID
    and (hec_act_performedaction_referral_requestedpotentialprocedures.IsDeleted is null or hec_act_performedaction_referral_requestedpotentialprocedures.IsDeleted = 0)
     Left Join
  hec_tre_potentialprocedures
    On hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID =
    hec_act_performedaction_referral_requestedpotentialprocedures.PotentialTreatment_RefID
    and ( hec_tre_potentialprocedures.IsDeleted is null or  hec_tre_potentialprocedures.IsDeleted = 0)
Where
  hec_act_performedaction_referrals.IsDeleted = 0 and 
  hec_act_performedaction_referrals.HEC_ACT_PerformedAction_RefID = @PerformedActionID
  and hec_act_performedaction_referrals.Tenant_RefID = @TenantID
   