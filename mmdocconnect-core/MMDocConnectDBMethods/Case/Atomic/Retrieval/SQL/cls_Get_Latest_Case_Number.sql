
     Select
      MAX(CONVERT(hec_cas_cases.CaseNumber, SIGNED)) As latest_case_number
    From
      hec_cas_cases
    Where
      CAST(hec_cas_cases.CaseNumber AS UNSIGNED) >= 10000 And
      hec_cas_cases.Tenant_RefID = @TenantID      
	