
      Select
        hec_doctor_universalpropertyvalues.Value_String as Comment
      From
        hec_doctors Inner Join
        hec_doctor_universalpropertyvalues On hec_doctors.HEC_DoctorID =
          hec_doctor_universalpropertyvalues.HEC_Doctor_RefID And
          hec_doctor_universalpropertyvalues.Tenant_RefID = @TenantID And
          hec_doctor_universalpropertyvalues.IsDeleted = 0 Inner Join
        hec_doctor_universalproperties
          On hec_doctor_universalpropertyvalues.UniversalProperty_RefID =
          hec_doctor_universalproperties.HEC_Doctor_UniversalPropertyID And
          hec_doctor_universalproperties.Tenant_RefID = @TenantID And
          hec_doctor_universalproperties.IsDeleted = 0 And
          hec_doctor_universalproperties.GlobalPropertyMatchingID = 'mm.docconnect.temporary.aftercare.doctor.comment'
      Where
        hec_doctors.HEC_DoctorID = @DoctorID And
        hec_doctors.IsDeleted = 0 And
        hec_doctors.Tenant_RefID = @TenantID
	