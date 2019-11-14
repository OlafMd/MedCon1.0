
	Select
  cmn_per_personinfo_2_account.AssignmentID,
  cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID,
  cmn_per_personinfo_2_account.Creation_Timestamp,
  cmn_per_personinfo_2_account.USR_Account_RefID,
  cmn_per_personinfo_2_account.IsDeleted,
  cmn_per_personinfo_2_account.Tenant_RefID
From
  cmn_per_personinfo_2_account
Where
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo_2_account.Tenant_RefID = @TenantID
  