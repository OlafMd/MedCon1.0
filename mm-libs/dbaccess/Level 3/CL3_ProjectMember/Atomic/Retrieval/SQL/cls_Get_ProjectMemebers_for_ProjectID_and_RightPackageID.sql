
Select distinct
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID AS ProjectMember_ID,
  usr_accounts.USR_AccountID AS ProjectMember_AccountID,
  cmn_per_personinfo.FirstName AS ProjectMember_FirstName,
  cmn_per_personinfo.LastName AS ProjectMember_LastName,
  ProfileImage.File_ServerLocation AS ProjectMember_ProfilePic_ServerLocation
From
  tms_pro_projectmembers Inner Join
  tms_pro_members_2_rightpackage
    On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
    tms_pro_members_2_rightpackage.ProjectMember_RefID Inner Join
  usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
    usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  (Select
    doc_documentrevisions.Document_RefID,
    doc_documentrevisions.File_ServerLocation
  From
    doc_documentrevisions
  Where
    doc_documentrevisions.IsLastRevision = 1) ProfileImage
    On cmn_per_personinfo.ProfileImage_Document_RefID =
    ProfileImage.Document_RefID
Where
  tms_pro_projectmembers.Project_RefID = @ProjectID And
  tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID = @RightPackageID And
  tms_pro_members_2_rightpackage.IsDeleted = 0 And
  tms_pro_projectmembers.IsDeleted = 0 And
  usr_accounts.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0
  