
    Select
      hec_bil_billpositions.Ext_BIL_BillPosition_RefID As bill_position_id,
      hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID As hec_case_bill_code_id,
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As gpos_type,
      hec_bil_billposition_billcodes.PotentialCode_RefID As gpos_id
    From
      hec_cas_case_billcodes
      Inner Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
        And hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
      Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID =
        @TenantID And hec_bil_billpositions.IsDeleted = 0
      Inner Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID =
        @TenantID And hec_bil_potentialcodes.IsDeleted = 0
      Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcode_catalogs.IsDeleted = 0 And hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID
    Where
      hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID And
      hec_cas_case_billcodes.Tenant_RefID = @TenantID And
      hec_cas_case_billcodes.IsDeleted = 0
    Order By
      hec_cas_case_billcodes.Creation_Timestamp
	