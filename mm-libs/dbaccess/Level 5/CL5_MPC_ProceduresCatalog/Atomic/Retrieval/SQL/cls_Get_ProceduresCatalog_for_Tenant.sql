
Select
  hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID,
  hec_tre_potentialprocedure_catalogcodes.HEC_TRE_PotentialProcedure_CatalogCodeID,
  hec_tre_potentialprocedure_catalogcodes.Code,
  hec_tre_potentialprocedures.PotentialProcedureITL,
  hec_tre_potentialprocedures.PotentialProcedure_Name_DictID,
  hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID
From
  hec_tre_potentialprocedure_catalogs Inner Join
  hec_tre_potentialprocedure_catalogcodes
    On hec_tre_potentialprocedure_catalogcodes.PotentialProcedure_Catalog_RefID
    = hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID
  Inner Join
  hec_tre_potentialprocedures
    On hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID =
    hec_tre_potentialprocedure_catalogcodes.PotentialProcedure_RefID
Where
  hec_tre_potentialprocedure_catalogs.IsDeleted = 0 And
  hec_tre_potentialprocedure_catalogs.Tenant_RefID = @TenantID And
  hec_tre_potentialprocedure_catalogcodes.IsDeleted = 0 And
  hec_tre_potentialprocedures.IsDeleted = 0 and
  hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID = @CatalogID
  