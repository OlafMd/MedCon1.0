
	Select
	  tms_pro_feature_2_developertask.AssignmentID,
	  tms_pro_feature_2_developertask.Feature_RefID,
	  tms_pro_feature_2_developertask.DeveloperTask_RefID,
	  tms_pro_feature_2_developertask.Creation_Timestamp,
	  tms_pro_feature_2_developertask.IsDeleted,
	  tms_pro_feature_2_developertask.Tenant_RefID
	From
	  tms_pro_feature_2_developertask
	Where
	  tms_pro_feature_2_developertask.Tenant_RefID = @TenantID
    And tms_pro_feature_2_developertask.IsDeleted = 0
  