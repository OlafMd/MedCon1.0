
    Select
      hec_bil_billpositions.Ext_BIL_BillPosition_RefID As bill_position_id
    From
      hec_cas_case_billcodes
      Inner Join hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
        hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_bil_billposition_billcodes.IsDeleted = 0 And
        hec_bil_billposition_billcodes.Tenant_RefID =
        @TenantID
      Inner Join hec_bil_billpositions
        On hec_bil_billposition_billcodes.BillPosition_RefID =
        hec_bil_billpositions.HEC_BIL_BillPositionID And
        hec_bil_billpositions.Tenant_RefID = @TenantID And
        hec_bil_billpositions.IsDeleted = 0
      Inner Join hec_cas_cases On hec_cas_case_billcodes.HEC_CAS_Case_RefID =
        hec_cas_cases.HEC_CAS_CaseID And
        hec_cas_cases.IsDeleted = 0 And
        hec_cas_cases.Tenant_RefID = @TenantID And
        Cast(hec_cas_cases.CaseNumber as unsigned) >= 10000
      Inner Join hec_bil_potentialcodes
        On hec_bil_billposition_billcodes.PotentialCode_RefID =
        hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
      Inner Join hec_bil_potentialcode_catalogs
        On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
        hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID
    Where
      hec_cas_case_billcodes.HEC_CAS_Case_RefID = @CaseID And  
      hec_cas_case_billcodes.IsDeleted = 0 And
      hec_cas_case_billcodes.Tenant_RefID = @TenantID And
      hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID =
      'mm.docconnect.gpos.catalog.nachsorge'
	