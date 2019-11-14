
    Select
      min(hec_doctors.Creation_Timestamp)as dateofOldestACDoctorChange,
      count(hec_doctors.HEC_DoctorID) as numberOfAcDocs
    From
      hec_doctors
    Where
      hec_doctors.IsDeleted = 0 And
      hec_doctors.Tenant_RefID = @TenantID And
      hec_doctors.Account_RefID = x'00000000000000000000000000000000'
	