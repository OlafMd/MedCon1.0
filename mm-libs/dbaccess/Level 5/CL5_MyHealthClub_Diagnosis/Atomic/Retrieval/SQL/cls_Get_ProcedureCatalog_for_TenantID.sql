
	Select
	  hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID,
	  hec_tre_potentialprocedure_catalogs.GlobalPropertyMatchingID,
	  hec_tre_potentialprocedure_catalogs.Catalog_DisplayName
	From
	  hec_tre_potentialprocedure_catalogs
	Where
	  hec_tre_potentialprocedure_catalogs.IsDeleted = 0 And
	  hec_tre_potentialprocedure_catalogs.Tenant_RefID = @TenantID
  