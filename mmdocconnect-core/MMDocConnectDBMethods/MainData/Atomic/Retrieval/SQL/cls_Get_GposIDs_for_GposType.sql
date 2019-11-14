
    Select
      hec_bil_potentialcodes.HEC_BIL_PotentialCodeID As GposID
    From
      hec_bil_potentialcode_catalogs Inner Join
      hec_bil_potentialcodes
        On hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID = hec_bil_potentialcodes.PotentialCode_Catalog_RefID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And
        hec_bil_potentialcodes.IsDeleted = 0
    Where
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposType And
      hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
      hec_bil_potentialcode_catalogs.IsDeleted = 0
  