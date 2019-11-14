
Select
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_dia_potentialdiagnoses.IsDeleted,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Description_DictID,
  hec_dia_potentialdiagnoses.PotentialDiagnosisITL,
  hec_dia_potentialdiagnoses.Tenant_RefID,
  hec_dia_potentialdiagnoses.Creation_Timestamp,
  hec_dia_potentialdiagnoses.IsAllergy,
  hec_dia_potentialdiagnoses.DefaultTimeUntillDeactivation_InDays
From
  hec_dia_potentialdiagnosis_catalogs Inner Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    = hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID
  Inner Join
  hec_dia_potentialdiagnoses
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
Where
  hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 And
  hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID =
  @CatalogID And
  hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 And
  hec_dia_potentialdiagnoses.IsDeleted = 0
  