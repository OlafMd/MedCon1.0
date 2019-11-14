
    Select
      hec_cas_cases.CaseNumber,
      hec_cas_case_billcodes.HEC_CAS_Case_RefID as CaseID,
      bil_billposition_transmitionstatuses.BillPosition_RefID As BillPositionID, 
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as StatusID
    From
      hec_bil_potentialcodes
      Inner Join hec_bil_billposition_billcodes On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID = hec_bil_billposition_billcodes.PotentialCode_RefID
      Inner Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID
      Inner Join bil_billposition_transmitionstatuses On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID
      Inner Join hec_cas_case_billcodes On hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID = hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID
      Inner Join hec_cas_cases On hec_cas_case_billcodes.HEC_CAS_Case_RefID = hec_cas_cases.HEC_CAS_CaseID
    Where
      hec_bil_potentialcodes.BillingCode = '36620059' And
      bil_billposition_transmitionstatuses.TransmitionStatusKey = 'aftercare' And
      bil_billposition_transmitionstatuses.IsDeleted = 1 And
      hec_cas_case_billcodes.IsDeleted = 0 And
      hec_cas_case_billcodes.Tenant_RefID = @TenantID
	