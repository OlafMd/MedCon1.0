
    
    Select
  usr_accounts.USR_AccountID As accountID,
  usr_accounts.AccountSignInEmailAddress As accountMail,
  cmn_bpt_businessparticipants.DisplayName
From
  hec_doctors Inner Join
  usr_accounts On hec_doctors.BusinessParticipant_RefID =
    usr_accounts.BusinessParticipant_RefID And  usr_accounts.Tenant_RefID =
        @TenantID And usr_accounts.IsDeleted = 0
  Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    usr_accounts.BusinessParticipant_RefID And  cmn_bpt_businessparticipants.Tenant_RefID =
        @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 
    Where
      hec_doctors.Tenant_RefID = @TenantID And
      hec_doctors.IsDeleted = 0 And
      hec_doctors.HEC_DoctorID = @DoctorID
  