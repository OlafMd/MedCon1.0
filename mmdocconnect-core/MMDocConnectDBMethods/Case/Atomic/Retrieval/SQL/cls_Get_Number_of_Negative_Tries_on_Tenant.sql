
    Select
      bil_billposition_transmitionstatuses.TransmitionStatusKey As CaseType,
      bil_billposition_transmitionstatuses.TransmitionCode,
      bil_billposition_transmitionstatuses.IsTransmitionStatusManuallySet,
      hec_bil_billpositions.HEC_BIL_BillPositionID As BillPositionID,
      hec_cas_case_billcodes.HEC_CAS_Case_RefID As CaseID,
      hec_bil_billposition_billcodes.PotentialCode_RefID As GposID,
      bil_billposition_transmitionstatuses.TransmittedOnDate
    From
      bil_billposition_transmitionstatuses
      Inner Join hec_bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        hec_bil_billpositions.Tenant_RefID = @TenantID And hec_bil_billpositions.IsDeleted = 0
      Inner Join hec_bil_billposition_billcodes On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
      Inner Join hec_cas_case_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_cas_case_billcodes.Tenant_RefID = @TenantID And hec_cas_case_billcodes.IsDeleted = 0
    Where
      bil_billposition_transmitionstatuses.IsDeleted = 0 And
      bil_billposition_transmitionstatuses.IsActive = 0 And
      bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID
	