
Select
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  hec_cas_cases.Patient_RefID As PatientID,
  hec_cas_cases.CaseNumber,
  hec_bil_billpositions.Ext_BIL_BillPosition_RefID As BillPositionID
From
  hec_cas_cases Inner Join
  hec_cas_case_billcodes
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And
    	 hec_cas_case_billcodes.Tenant_RefID = @TenantID And
  		 hec_cas_case_billcodes.IsDeleted = 0
  Inner Join
  hec_bil_billposition_billcodes
    On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID =
    hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
    hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And
    hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
  hec_bil_billpositions
    On hec_bil_billposition_billcodes.BillPosition_RefID =
    hec_bil_billpositions.HEC_BIL_BillPositionID And
    hec_bil_billpositions.Tenant_RefID = @TenantID And
    hec_bil_billpositions.IsDeleted = 0
Where
	hec_cas_cases.Tenant_RefID = @TenantID And
	hec_cas_cases.IsDeleted = 0
	