
    Select
      hec_doctors.HEC_DoctorID as DoctorID
    From
      usr_accounts Inner Join
      hec_doctors On usr_accounts.BusinessParticipant_RefID =
        hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
        @TenantID And hec_doctors.IsDeleted = 0
    Where
      usr_accounts.USR_AccountID = @AccountID And
      usr_accounts.IsDeleted = 0 And
      usr_accounts.Tenant_RefID = @TenantID
	