
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID
From
  tms_pro_projectmembers Inner Join
  usr_accounts
    On usr_accounts.USR_AccountID = tms_pro_projectmembers.USR_Account_RefID
  Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID = @ProjectMemberID And
  tms_pro_projectmembers.IsDeleted = 0 And
  usr_accounts.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  tms_pro_projectmembers.Tenant_RefID = @TenantID 
  
  