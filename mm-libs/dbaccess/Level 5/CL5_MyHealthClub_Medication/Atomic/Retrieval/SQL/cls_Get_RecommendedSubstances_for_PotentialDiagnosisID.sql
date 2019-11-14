
Select
  hec_dia_recommendedsubstances.HEC_DIA_RecommendedSubstanceID,
  hec_dia_recommendedsubstances.SubstanceStrength,
  hec_sub_substance_names.SubstanceName_Label_DictID,
  hec_dia_recommendedsubstances.Substance_RefID,
  hec_dia_recommendedsubstances.Substance_Unit_RefID,
  cmn_units.ISOCode As SubstanceUnitName,
  hec_dosages.DosageText,
  hec_dia_recommendedsubstance_dosages.HEC_DIA_RecommendedSubstance_DosageID,
  hec_dosages.HEC_DosageID,
  hec_dia_recommendedsubstance_dosages.IsDefault
From
  hec_dia_recommendedsubstances Inner Join
  hec_sub_substances On hec_sub_substances.HEC_SUB_SubstanceID =
    hec_dia_recommendedsubstances.Substance_RefID And
    hec_sub_substances.Tenant_RefID = @TenantID And
    hec_sub_substances.IsDeleted = 0 Inner Join
  hec_sub_substance_names On hec_sub_substances.HEC_SUB_SubstanceID =
    hec_sub_substance_names.HEC_SUB_Substance_RefID And
    hec_sub_substance_names.Tenant_RefID = @TenantID And
    hec_sub_substance_names.IsDeleted = 0 Inner Join
  cmn_units On hec_dia_recommendedsubstances.Substance_Unit_RefID =
    cmn_units.CMN_UnitID And cmn_units.IsDeleted = 0 And
    cmn_units.Tenant_RefID = @TenantID Inner Join
  hec_dia_recommendedsubstance_dosages
    On hec_dia_recommendedsubstance_dosages.RecommendedSubstance_RefID =
    hec_dia_recommendedsubstances.HEC_DIA_RecommendedSubstanceID And
    hec_dia_recommendedsubstance_dosages.Tenant_RefID = @TenantID And
    hec_dia_recommendedsubstance_dosages.IsDeleted = 0 Inner Join
  hec_dosages On hec_dia_recommendedsubstance_dosages.Dosage_RefID =
    hec_dosages.HEC_DosageID And hec_dosages.Tenant_RefID = @TenantID And
    hec_dosages.IsDeleted = 0
Where
  hec_dia_recommendedsubstances.Tenant_RefID = @TenantID And
  hec_dia_recommendedsubstances.IsDeleted = 0 And
  hec_dia_recommendedsubstances.PotentialDiagnosis_RefID = @PotentialDiagnosisID
  