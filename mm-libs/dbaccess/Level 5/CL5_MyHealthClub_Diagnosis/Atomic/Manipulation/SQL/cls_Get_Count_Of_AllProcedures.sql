
	Select
	  Count(Distinct hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID) As
	  NumberOfElements
	From
	  hec_tre_potentialprocedures Left Join
	  hec_tre_potentialprocedures_de
	    On hec_tre_potentialprocedures.PotentialProcedure_Name_DictID =
	    hec_tre_potentialprocedures_de.DictID Inner Join
	  hec_tre_potentialprocedure_catalogcodes
	    On hec_tre_potentialprocedures.HEC_TRE_PotentialProcedureID =
	    hec_tre_potentialprocedure_catalogcodes.PotentialProcedure_RefID And
	    hec_tre_potentialprocedure_catalogcodes.Tenant_RefID = @TenantID And
	    hec_tre_potentialprocedure_catalogcodes.IsDeleted = 0 Inner Join
	  hec_tre_potentialprocedure_catalogs
	    On hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID
	    = hec_tre_potentialprocedure_catalogcodes.PotentialProcedure_Catalog_RefID
	    And hec_tre_potentialprocedure_catalogs.Tenant_RefID = @TenantID And
	    hec_tre_potentialprocedure_catalogs.IsDeleted = 0 And
	    hec_tre_potentialprocedure_catalogs.HEC_TRE_PotentialProcedure_CatalogID =
	    @CatalogID Left Join
	  hec_tre_potentialprocedures_de hec_tre_potentialprocedures_de1
	    On hec_tre_potentialprocedures.PotentialProcedure_Description_DictID =
	    hec_tre_potentialprocedures_de1.DictID And
	    hec_tre_potentialprocedures_de1.IsDeleted = 0
	Where
	  hec_tre_potentialprocedures.IsDeleted = 0 And
	  hec_tre_potentialprocedures.Tenant_RefID = @TenantID @SearchCriterium
  