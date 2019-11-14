
    Select
      hec_doctor_universalpropertyvalues.Value_Boolean As IsDoctorCertificated
    From
      hec_doctor_universalproperties
      Inner Join hec_doctor_universalpropertyvalues On hec_doctor_universalproperties.HEC_Doctor_UniversalPropertyID = hec_doctor_universalpropertyvalues.UniversalProperty_RefID And
        hec_doctor_universalpropertyvalues.HEC_Doctor_RefID = @DoctorID And hec_doctor_universalpropertyvalues.Tenant_RefID = @TenantID And hec_doctor_universalpropertyvalues.IsDeleted
        = 0
    Where
      hec_doctor_universalproperties.Tenant_RefID = @TenantID And
      hec_doctor_universalproperties.IsDeleted = 0 And
      hec_doctor_universalproperties.GlobalPropertyMatchingID = 'mm.docconnect.doctor.oct.certificated'
  