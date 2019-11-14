
	Select
	  tms_pro_developertasks.PercentageComplete,
	  tms_pro_feature.TMS_PRO_FeatureID
	From
	  tms_pro_feature Inner Join
	  tms_pro_feature_2_developertask On tms_pro_feature.TMS_PRO_FeatureID =
	    tms_pro_feature_2_developertask.Feature_RefID Inner Join
	  tms_pro_developertasks On tms_pro_feature_2_developertask.DeveloperTask_RefID
	    = tms_pro_developertasks.TMS_PRO_DeveloperTaskID
	Where
	  tms_pro_feature.IsArchived = 0 And
	  tms_pro_feature.IsDeleted = 0 And
	  tms_pro_feature.Tenant_RefID = @TenantID And
	  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID
  