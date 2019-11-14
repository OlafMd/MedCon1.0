
    Select
      bil_billposition_transmitionstatuses.Creation_Timestamp As StatusDate,
      bil_billposition_transmitionstatuses.IsActive,
      bil_billposition_transmitionstatuses.TransmitionStatusKey As StatusType,
      bil_billposition_transmitionstatuses.TransmitionCode as StatusCode,
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as StatusID,
      bil_billposition_transmitionstatuses.TransmittedOnDate,
      hec_cas_case_billcodes.HEC_CAS_Case_RefID as CaseID,
      hec_bil_billpositions.HEC_BIL_BillPositionID as BillPositionID
    From
      bil_billposition_transmitionstatuses
      Inner Join hec_bil_billpositions On bil_billposition_transmitionstatuses.BillPosition_RefID = hec_bil_billpositions.Ext_BIL_BillPosition_RefID And
        hec_bil_billpositions.Tenant_RefID = @TenantID And hec_bil_billpositions.IsDeleted = 0
      Inner Join hec_bil_billposition_billcodes On hec_bil_billpositions.HEC_BIL_BillPositionID = hec_bil_billposition_billcodes.BillPosition_RefID And
        hec_bil_billposition_billcodes.IsDeleted = 0 And hec_bil_billposition_billcodes.Tenant_RefID = @TenantID
      Inner Join hec_cas_case_billcodes On hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID = hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID And
        hec_cas_case_billcodes.Tenant_RefID = @TenantID And hec_cas_case_billcodes.IsDeleted = 0
    Where
      bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
      bil_billposition_transmitionstatuses.IsDeleted = 0 
	