
    Select
      hec_bil_potentialcodes.BillingCode 
    From
      hec_bil_potentialcode_catalogs Inner Join
      hec_bil_potentialcodes On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
        hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And
        hec_bil_potentialcodes.IsDeleted = 0
    Where
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GlobalPropertyMatchingID And
      hec_bil_potentialcode_catalogs.IsDeleted = 0 And
      hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID 
	