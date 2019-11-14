
Select
  tms_pro_projects.TMS_PRO_ProjectID AS Project_ID
From
  tms_pro_projects Left Join
  tms_pro_projectmembers On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_projectmembers.Project_RefID Inner Join
  tms_pro_members_2_rightpackage
    On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
    tms_pro_members_2_rightpackage.ProjectMember_RefID
Where
  tms_pro_members_2_rightpackage.IsDeleted = 0 And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_members_2_rightpackage.ACC_RightsPackage_RefID = @RightPackIDList And
  tms_pro_projects.IsArchived = @IsArchived And
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_projects.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.IsDeleted = 0
  