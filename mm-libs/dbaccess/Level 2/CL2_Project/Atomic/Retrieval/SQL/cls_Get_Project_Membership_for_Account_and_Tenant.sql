
Select
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
  tms_pro_projectmembers.USR_Account_RefID,
  tms_pro_projectmembers.Project_RefID,
  tms_pro_projectmembers.IsOwner,
  tms_pro_projectmembers.Creation_Timestamp,
  tms_pro_projectmembers.IsDeleted,
  tms_pro_projectmembers.Tenant_RefID,
  tms_pro_projectmembers.ProjectMember_Type_RefID,
  tms_pro_projectmembers.ChargingLevel_RefID
From
  tms_pro_projectmembers
Where
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_projectmembers.IsDeleted = 0 And
  tms_pro_projectmembers.Tenant_RefID = @TenantID
  