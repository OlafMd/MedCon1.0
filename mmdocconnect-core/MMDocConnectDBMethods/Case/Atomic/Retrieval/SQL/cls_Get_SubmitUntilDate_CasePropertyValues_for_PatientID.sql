    
    SELECT
      hec_cas_case_universalpropertyvalue.Value_String AS property_string_value,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalPropertyValueID AS property_value_id,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID AS case_id
    FROM
      hec_cas_cases
      INNER JOIN hec_cas_case_universalpropertyvalue ON
        hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID AND
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID AND hec_cas_case_universalpropertyvalue.IsDeleted = 0
      INNER JOIN hec_cas_case_universalproperties ON
        hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID =
        hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID AND
        hec_cas_case_universalproperties.GlobalPropertyMatchingID = 'mm.doc.connect.case.submit.oct.until.date' AND
        hec_cas_case_universalproperties.Tenant_RefID = @TenantID AND hec_cas_case_universalproperties.IsDeleted = 0
    WHERE
      hec_cas_cases.Patient_RefID = @PatientID AND
      hec_cas_cases.Tenant_RefID = @TenantID
	