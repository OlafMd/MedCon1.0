
    Select
      Count(*) As CasesInStatus,
      Min(bil_billposition_transmitionstatuses.TransmittedOnDate) As TreatmentDate,
      Sum(bil_billpositions.PositionValue_IncludingTax) As NumberForPayment,
      bil_billposition_transmitionstatuses.TransmitionCode As FSStatus,
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType
    From
      bil_billpositions
      Inner Join bil_billposition_transmitionstatuses On bil_billposition_transmitionstatuses.BillPosition_RefID = bil_billpositions.BIL_BillPositionID And
        bil_billposition_transmitionstatuses.IsActive = 1 And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
        bil_billposition_transmitionstatuses.IsDeleted = 0
      Inner Join hec_bil_billpositions On bil_billpositions.BIL_BillPositionID = hec_bil_billpositions.Ext_BIL_BillPosition_RefID And
        hec_bil_billpositions.Tenant_RefID = @TenantID And hec_bil_billpositions.IsDeleted = 0
      Inner Join hec_bil_billposition_billcodes On hec_bil_billpositions.HEC_BIL_BillPositionID = hec_bil_billposition_billcodes.BillPosition_RefID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 
      Inner Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And
        hec_bil_potentialcodes.IsDeleted = 0 
      Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And hec_bil_potentialcode_catalogs.IsDeleted = 0
    Where
      bil_billpositions.Tenant_RefID = @TenantID And
      bil_billpositions.IsDeleted = 0
    Group By
      bil_billposition_transmitionstatuses.TransmitionCode, hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID
	