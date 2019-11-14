
  Select
  hec_dia_potentialdiagnosis_catalogcodes.Code As DiagnoseCode,
  hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID As DiagnoseID,
  hec_dia_potentialdiagnoses_de.Content As DiagnoseName,
  hec_dia_potentialdiagnoses.ICD10_Code
From
  hec_dia_potentialdiagnoses Inner Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID And
    hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnosis_catalogs
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID
    = hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    And hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnoses_de
    On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
    hec_dia_potentialdiagnoses_de.DictID And
    hec_dia_potentialdiagnoses_de.IsDeleted = 0
Where
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnoses.IsDeleted = 0
Group By
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
    
	