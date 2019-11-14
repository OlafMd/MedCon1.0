
Select
tms_pro_projects.TMS_PRO_ProjectID,
tms_pro_projects.Name_DictID,
tms_pro_projectmembers.TMS_PRO_ProjectMemberID
From
tms_pro_projects Inner Join
tms_pro_projectmembers On tms_pro_projectmembers.Project_RefID =
tms_pro_projects.TMS_PRO_ProjectID
Where
tms_pro_projects.IsDeleted = 0 And
tms_pro_projectmembers.IsDeleted = 0 And
tms_pro_projectmembers.USR_Account_RefID =@UserAccountID And
tms_pro_projectmembers.Tenant_RefID =@TenantID
  