
    Select
      hec_doctors.Account_RefID
    From
      hec_doctors
    Where
      hec_doctors.HEC_DoctorID = @AftercareDoctorID And
      hec_doctors.IsDeleted = 0 And
      hec_doctors.Tenant_RefID = @TenantID
	