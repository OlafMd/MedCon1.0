
	Select
	  tms_pro_feature_statuses.TMS_PRO_Feature_StatusID AS FeatureStatus_ID,
	  tms_pro_feature_statuses.Label_DictID,
    tms_pro_feature_statuses.GlobalPropertyMatchingID AS FeatureStatus_GlobalPropertyMatchingID
	From
	  tms_pro_feature_statuses
	Where
	  tms_pro_feature_statuses.Tenant_RefID = @TenantID And
	  tms_pro_feature_statuses.IsDeleted = 0
  