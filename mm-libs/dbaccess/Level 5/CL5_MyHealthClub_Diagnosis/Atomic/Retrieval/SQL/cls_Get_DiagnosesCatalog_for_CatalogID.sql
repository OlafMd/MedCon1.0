
	Select
	  hec_dia_potentialdiagnosis_catalogs.Catalog_Name_DictID,
	  hec_dia_potentialdiagnosis_catalog_access.IsContributor,
	  hec_dia_potentialdiagnosis_catalogs.IsPrivateCatalog,
	  hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID,
	  hec_dia_potentialdiagnosis_catalog_access.HEC_DIA_PotentialDiagnosis_Catalog_AccessID,
	  hec_dia_potentialdiagnosis_catalog_access.BusinessParticipant_RefID
	From
	  hec_dia_potentialdiagnosis_catalogs Left Join
	  hec_dia_potentialdiagnosis_catalog_access
	    On hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
	    = hec_dia_potentialdiagnosis_catalog_access.PotentialDiagnosis_Catalog_RefID
	    And hec_dia_potentialdiagnosis_catalog_access.Tenant_RefID = @TenantID And
	    hec_dia_potentialdiagnosis_catalog_access.IsDeleted = 0
	Where
	  hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
	  hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 And
	  HEC_DIA_PotentialDiagnosis_CatalogID = @CatalogID
  