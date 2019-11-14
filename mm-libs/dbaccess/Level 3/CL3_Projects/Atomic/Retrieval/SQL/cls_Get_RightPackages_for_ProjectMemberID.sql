
    Select
  tms_pro_members_2_rightpackage.AssignmentID,
  tms_pro_acc_rightspackages.Name_DictID,
  tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID,
  usr_accounts.USR_AccountID
From
  usr_accounts Inner Join
  tms_pro_projectmembers On tms_pro_projectmembers.USR_Account_RefID =
    usr_accounts.USR_AccountID Inner Join
  tms_pro_members_2_rightpackage
    On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
    tms_pro_members_2_rightpackage.ProjectMember_RefID Inner Join
  tms_pro_acc_rightspackages
    On tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID =
    tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID
Where
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID = @ProjectMemberID And
  usr_accounts.IsDeleted = 0 And
  tms_pro_projectmembers.IsDeleted = 0 And
  tms_pro_members_2_rightpackage.IsDeleted = 0 And
  tms_pro_acc_rightspackages.IsDeleted = 0 And
  tms_pro_projectmembers.Tenant_RefID = @TenantID
  