
Select
  hec_act_performedaction_medicationupdates.DosageText,
  hec_act_performedaction_medicationupdates.IfSubstance_Strength,
  cmn_units.ISOCode,
  hec_sub_substance_names.SubstanceName_Label_DictID,
  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_MedicationUpdateID,
  hec_act_performedaction_medicationupdates.IsMedicationDeactivated,
  hec_act_performedaction_medicationupdates.IsSubstance,
  hec_act_performedaction_medicationupdates.Creation_Timestamp,
  hec_sub_substances.HEC_SUB_SubstanceID,
  hec_sub_substances.GlobalPropertyMatchingID,
  hec_act_performedaction_medicationupdates.IntendedApplicationDuration_in_days,
  cmn_units.CMN_UnitID
From
  hec_sub_substances Inner Join
  hec_sub_substance_names On hec_sub_substance_names.HEC_SUB_Substance_RefID =
    hec_sub_substances.HEC_SUB_SubstanceID And hec_sub_substance_names.IsDeleted
    = 0 And hec_sub_substance_names.Tenant_RefID = @TenantID And
    hec_sub_substances.IsDeleted = 0 And hec_sub_substances.Tenant_RefID =
    @TenantID Inner Join
  hec_act_performedaction_medicationupdates
    On hec_act_performedaction_medicationupdates.IfSubstance_Substance_RefiD =
    hec_sub_substances.HEC_SUB_SubstanceID Left Join
  cmn_units
    On cmn_units.CMN_UnitID =
    hec_act_performedaction_medicationupdates.IfSubstance_Unit_RefID And
    cmn_units.IsDeleted = 0 And cmn_units.Tenant_RefID = @TenantID
Where
  hec_act_performedaction_medicationupdates.IsMedicationDeactivated = 0 And
  hec_act_performedaction_medicationupdates.IsSubstance = 1 And
  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID And
  hec_act_performedaction_medicationupdates.Tenant_RefID = @TenantID And
  hec_act_performedaction_medicationupdates.IsDeleted = 0
  