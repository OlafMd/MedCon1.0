
    
Select Distinct
  usr_accounts.USR_AccountID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  ProfileImage.File_ServerLocation
From
  cmn_per_personinfo_2_account Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    doc_documentrevisions.Document_RefID,
    doc_documentrevisions.File_ServerLocation
  From
    doc_documentrevisions
  Where
    doc_documentrevisions.IsLastRevision = 1 And
    doc_documentrevisions.IsDeleted = 0 And
    doc_documentrevisions.Tenant_RefID = @TenantID) ProfileImage On cmn_per_personinfo.ProfileImage_Document_RefID =
    ProfileImage.Document_RefID Inner Join
  usr_accounts On cmn_per_personinfo_2_account.USR_Account_RefID =
    usr_accounts.USR_AccountID
Where
  usr_accounts.Tenant_RefID = @TenantID And
  usr_accounts.IsDeleted = '0' And
  cmn_per_personinfo_2_account.IsDeleted = '0' And
  cmn_per_personinfo.IsDeleted = '0'
  