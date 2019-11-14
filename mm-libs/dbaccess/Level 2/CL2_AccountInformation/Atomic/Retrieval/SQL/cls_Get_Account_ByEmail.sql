
Select
  usr_accounts.USR_AccountID,
  usr_accounts.Username,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  usr_accounts.AccountType
From
  usr_accounts Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  usr_accounts.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  UPPER(cmn_per_personinfo.PrimaryEmail) = UPPER(@Email) And
    cmn_per_personinfo.Tenant_RefID = @TenantID 
  