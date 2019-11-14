
Select
  hec_act_performedactions.HEC_ACT_PerformedActionID as action_id,
  hec_act_performedactions.IsPerformed_MedicalPractice_RefID as set_practice_id,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as real_practice_id
From
  hec_act_performedactions Inner Join
  hec_act_plannedactions
    On hec_act_plannedactions.IfPerformed_PerformedAction_RefID =
    hec_act_performedactions.HEC_ACT_PerformedActionID And
    hec_act_plannedactions.Tenant_RefID = @TenantID 
    Inner Join
  hec_cas_case_relevantplannedactions
    On hec_cas_case_relevantplannedactions.PlannedAction_RefID =
    hec_act_plannedactions.HEC_ACT_PlannedActionID And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunit_staff
    On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
    cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0
Where
  hec_cas_case_relevantplannedactions.Tenant_RefID =
  @TenantID And
  hec_cas_case_relevantplannedactions.IsDeleted = 0
	