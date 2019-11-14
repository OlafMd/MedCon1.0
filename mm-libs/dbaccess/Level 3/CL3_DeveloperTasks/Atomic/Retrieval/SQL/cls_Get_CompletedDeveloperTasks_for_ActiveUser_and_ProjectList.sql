
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID AS DeveloperTask_ID
From
  tms_pro_developertasks Inner Join
  tms_pro_projects On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_developertasks.Project_RefID Inner Join
  tms_pro_projectmembers On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_projectmembers.Project_RefID
Where
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.IsComplete = 1 And
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_projects.Tenant_RefID = @TenantID And
  tms_pro_projects.TMS_PRO_ProjectID = @ProjectID_List And
  tms_pro_projects.IsArchived = 0 And
  tms_pro_developertasks.IsArchived = 0
   
  