
Select
  tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID,
  tms_pro_acc_rightspackages.Name_DictID,
  tms_pro_acc_rightspackages.Description_DictID,
  tms_pro_acc_rightspackages.HierarchyLevel,
  tms_pro_acc_rightspackages.Creation_Timestamp,
  tms_pro_acc_rightspackages.IsDeleted,
  tms_pro_acc_rightspackages.Tenant_RefID,
  tms_pro_acc_rightspackages.GlobalPropertyMatchingID
From
  tms_pro_projectmembers Left Join
  tms_pro_projectmembers tms_pro_projectmembers1
    On tms_pro_projectmembers.Project_RefID =
    tms_pro_projectmembers1.Project_RefID Inner Join
  tms_pro_members_2_rightpackage
    On tms_pro_projectmembers1.TMS_PRO_ProjectMemberID =
    tms_pro_members_2_rightpackage.ProjectMember_RefID Inner Join
  tms_pro_acc_rightspackages
    On tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID =
    tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID
Where
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_projectmembers.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.IsDeleted = 0 And
  tms_pro_projectmembers1.IsDeleted = 0 And
  tms_pro_members_2_rightpackage.IsDeleted = 0
Group By
  tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID,
  tms_pro_projectmembers.IsDeleted, tms_pro_projectmembers1.IsDeleted,
  tms_pro_members_2_rightpackage.IsDeleted
  