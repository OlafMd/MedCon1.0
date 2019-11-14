
Select
  tms_pro_members_2_rightpackage.Tenant_RefID,
  tms_pro_members_2_rightpackage.IsDeleted,
  tms_pro_members_2_rightpackage.Creation_Timestamp,
  tms_pro_members_2_rightpackage.ProjectMember_RefID,
  tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID,
  tms_pro_members_2_rightpackage.AssignmentID
From
  tms_pro_projectmembers Left Join
  tms_pro_projectmembers tms_pro_projectmembers1
    On tms_pro_projectmembers.Project_RefID =
    tms_pro_projectmembers1.Project_RefID Inner Join
  tms_pro_members_2_rightpackage
    On tms_pro_projectmembers1.TMS_PRO_ProjectMemberID =
    tms_pro_members_2_rightpackage.ProjectMember_RefID
Where
  tms_pro_members_2_rightpackage.IsDeleted = 0 And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_projectmembers.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.IsDeleted = 0 And
  tms_pro_projectmembers1.IsDeleted = 0
  