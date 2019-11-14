
	Select
  hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName,
  hec_dia_potentialdiagnosis_catalogs.GlobalPropertyMatchingID,
  hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
From
  hec_dia_potentialdiagnosis_catalogs
Where
  hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0
  