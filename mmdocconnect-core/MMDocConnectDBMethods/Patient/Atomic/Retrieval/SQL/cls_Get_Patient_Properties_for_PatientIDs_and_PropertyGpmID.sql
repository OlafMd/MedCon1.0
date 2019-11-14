
    Select
      hec_patient_universalpropertyvalues.Value_String As string_value,
      hec_patient_universalpropertyvalues.Value_Number As numeric_value,
      hec_patient_universalpropertyvalues.Value_Boolean As boolean_value,
      hec_patient_universalpropertyvalues.HEC_Patient_UniversalPropertyValueID as id,
      hec_patient_universalpropertyvalues.HEC_Patient_RefID as patient_id
    From
      hec_patient_universalpropertyvalues Inner Join
      hec_patient_universalproperties
        On hec_patient_universalpropertyvalues.HEC_Patient_UniversalProperty_RefID = hec_patient_universalproperties.HEC_Patient_UniversalPropertyID And
  	    hec_patient_universalproperties.GlobalPropertyMatchingID = @PropertyGpmID And
        hec_patient_universalproperties.Tenant_RefID = @TenantID And hec_patient_universalproperties.IsDeleted = 0
    Where
      hec_patient_universalpropertyvalues.HEC_Patient_RefID = @PatientIDs And
      hec_patient_universalpropertyvalues.Tenant_RefID = @TenantID And
      hec_patient_universalpropertyvalues.IsDeleted = 0
  