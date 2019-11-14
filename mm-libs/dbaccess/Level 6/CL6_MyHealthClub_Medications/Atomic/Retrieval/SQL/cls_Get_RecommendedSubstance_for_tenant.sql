
Select
  cmn_units.ISOCode,
  hec_dia_recommendedsubstances.HEC_DIA_RecommendedSubstanceID,
  hec_dia_recommendedsubstances.PotentialDiagnosis_RefID,
  hec_dia_recommendedsubstances.Substance_RefID,
  hec_dia_recommendedsubstances.SubstanceStrength,
  hec_dia_recommendedsubstances.Substance_Unit_RefID,
  hec_dia_recommendedsubstances.IsDefault,
  hec_dia_recommendedsubstances.Creation_Timestamp,
  hec_dia_recommendedsubstances.Tenant_RefID,
  hec_dia_recommendedsubstances.IsDeleted,
  hec_dia_recommendedsubstances.Modification_Timestamp As Modification_TimestampRecommendedSubstances,
  cmn_units.Modification_Timestamp As Modification_TimestampUnits
From
  hec_dia_recommendedsubstances Inner Join
  cmn_units
    On cmn_units.CMN_UnitID = hec_dia_recommendedsubstances.Substance_Unit_RefID
Where
  hec_dia_recommendedsubstances.Tenant_RefID = @Tenant And
  hec_dia_recommendedsubstances.IsDeleted = 0
  