
    Select
      hec_cas_case_billcodes.HEC_CAS_Case_RefID As CaseID,
      Count(Distinct hec_cas_case_billcodes.HEC_CAS_Case_BillCodeID) As NumberOfTreatmentGposes
    From
      hec_cas_case_billcodes
      Inner Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID
        And hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
      Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID =
        @TenantID And hec_bil_billpositions.IsDeleted = 0
      Inner Join bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billposition_transmitionstatuses.IsDeleted = 0
      Inner Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID =
        @TenantID And hec_bil_potentialcodes.IsDeleted = 0
      Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
        hec_bil_potentialcode_catalogs.IsDeleted = 0 And hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
        hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposType
      Inner Join hec_bil_potentialcode_2_healthcareproduct On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID
        And hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID And hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0
      Inner Join hec_bil_potentialcode_2_potentialdiagnosis
        On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID And
        hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID = @TenantID And hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0
    Where
      hec_cas_case_billcodes.Tenant_RefID = @TenantID And
      hec_cas_case_billcodes.IsDeleted = 0
    Group By
      hec_cas_case_billcodes.HEC_CAS_Case_RefID
      
	