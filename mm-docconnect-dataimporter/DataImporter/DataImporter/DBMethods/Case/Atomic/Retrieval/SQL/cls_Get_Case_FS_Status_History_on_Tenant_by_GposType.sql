
    Select
      bil_billposition_transmitionstatuses.IsActive,
      bil_billposition_transmitionstatuses.TransmitionCode,
      bil_billposition_transmitionstatuses.TransmitionStatusKey,
      bil_billposition_transmitionstatuses.TransmittedOnDate,
      hec_cas_cases.CaseNumber,
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
      hec_bil_billpositions.Ext_BIL_BillPosition_RefID,
      hec_cas_cases.HEC_CAS_CaseID
    From
      hec_cas_cases Inner Join
      hec_cas_case_billcodes
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
        hec_cas_case_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billpositions
        On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
        hec_bil_billpositions.IsDeleted = 0 Inner Join
      hec_bil_potentialcodes
        On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.PotentialCode_Catalog_RefID = @GposCatalogID And hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted
        = 0 Left Join
      bil_billposition_transmitionstatuses
        On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billposition_transmitionstatuses.IsDeleted = 0
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
	