
    Select
      hec_cas_cases.CaseNumber,
      hec_cas_cases.Patient_RefID,
      hec_cas_cases.HEC_CAS_CaseID,
      hec_bil_billpositions.Ext_BIL_BillPosition_RefID
    From
      hec_cas_case_billcodes Inner Join
      hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID Inner Join
      hec_bil_billpositions
        On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
        hec_bil_billpositions.IsDeleted = 0 Inner Join
      hec_cas_cases
        On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID And hec_cas_cases.Tenant_RefID = @TenantID Inner Join
      bil_billposition_transmitionstatuses
        On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        bil_billposition_transmitionstatuses.TransmitionStatusKey = 'oct' And bil_billposition_transmitionstatuses.IsActive = 1 And
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billposition_transmitionstatuses.IsDeleted = 0
    Where
      hec_cas_case_billcodes.Tenant_RefID = @TenantID And
      hec_cas_case_billcodes.IsDeleted = 0
    Order By
      hec_cas_case_billcodes.Creation_Timestamp
	