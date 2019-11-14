
  Select
  hec_doctor_universalpropertyvalues.Value_String AS PeriodStartAt
From
  hec_doctor_universalproperties Inner Join
  hec_doctor_universalpropertyvalues
    On hec_doctor_universalproperties.HEC_Doctor_UniversalPropertyID =
    hec_doctor_universalpropertyvalues.UniversalProperty_RefID And
    hec_doctor_universalpropertyvalues.Tenant_RefID = @TenantID And
    hec_doctor_universalpropertyvalues.IsDeleted = 0 Inner Join
  hec_doctors
    On hec_doctor_universalpropertyvalues.HEC_Doctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.HEC_DoctorID = @DoctorID And
    hec_doctors.Tenant_RefID = @TenantiD And hec_doctors.IsDeleted = 0
Where
  hec_doctor_universalproperties.GlobalPropertyMatchingID =
  'mm.docconnect.doctor.pasword-grace-period' And
  hec_doctor_universalproperties.IsDeleted = 0 And
  hec_doctor_universalproperties.Tenant_RefID = @TenantID
	