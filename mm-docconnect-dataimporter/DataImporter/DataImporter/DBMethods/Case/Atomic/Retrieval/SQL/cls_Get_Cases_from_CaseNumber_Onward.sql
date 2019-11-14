
Select
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  hec_cas_cases.Patient_RefID As PatientID,
  hec_cas_cases.CaseNumber As CaseNumber
From
  hec_cas_cases
  Inner Join hec_cas_case_relevantplannedactions
    On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID And
    hec_cas_case_relevantplannedactions.IsDeleted = 0 And
    hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID
Where
  hec_cas_cases.IsDeleted = 0 And
  hec_cas_cases.Tenant_RefID = @TenantID And
  Cast(hec_cas_cases.CaseNumber As Unsigned) >= @CaseNumber
	