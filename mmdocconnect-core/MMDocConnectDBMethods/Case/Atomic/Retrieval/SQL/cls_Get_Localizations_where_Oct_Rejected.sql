
    Select
      hec_cas_case_universalpropertyvalue.Value_String as localization,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalPropertyValueID as property_id
    From
      hec_cas_cases Inner Join
      hec_cas_case_universalpropertyvalue
        On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
        hec_cas_case_universalpropertyvalue.IsDeleted = 0 Inner Join
      hec_cas_case_universalproperties
        On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
  	    hec_cas_case_universalproperties.GlobalPropertyMatchingID = @RejectedOctPropertyID And
  	    hec_cas_case_universalproperties.Tenant_RefID = @TenantID And
  	    hec_cas_case_universalproperties.IsDeleted = 0
    Where
      hec_cas_cases.Patient_RefID = @PatientID And
      hec_cas_cases.Tenant_RefID = @TenantID 
	