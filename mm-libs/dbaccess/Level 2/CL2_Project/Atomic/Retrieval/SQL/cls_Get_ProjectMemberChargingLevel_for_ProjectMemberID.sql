
	Select
  tms_pro_projectmembers.ChargingLevel_RefID
From
  tms_pro_projectmembers
Where
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID = @ProjectMemberID And
  tms_pro_projectmembers.IsDeleted = 0 And
  tms_pro_projectmembers.Tenant_RefID = @TenantID
  
  