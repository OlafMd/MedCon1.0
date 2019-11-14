
	Select
  tms_pro_businesstask_2_feature.Tenant_RefID,
  tms_pro_businesstask_2_feature.IsDeleted,
  tms_pro_businesstask_2_feature.Creation_Timestamp,
  tms_pro_businesstask_2_feature.Feature_RefID,
  tms_pro_businesstask_2_feature.BusinessTask_RefID,
  tms_pro_businesstask_2_feature.AssignmentID
From
  tms_pro_businesstask_2_feature
Where
  tms_pro_businesstask_2_feature.Tenant_RefID = @TenantID And
  tms_pro_businesstask_2_feature.IsDeleted = 0
  