
	Select
	  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
	  tms_pro_developertasks.IdentificationNumber,
	  tms_pro_developertasks.Completion_Deadline,
	  tms_pro_developertasks.Completion_Timestamp,
	  tms_pro_developertasks.PercentageComplete,
	  tms_pro_developertasks.Name,
	  tms_pro_developertasks.Description
	From
	  tms_pro_developertasks Inner Join
	  tms_pro_feature_2_developertask
	    On tms_pro_feature_2_developertask.DeveloperTask_RefID =
	    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
	  tms_pro_feature On tms_pro_feature.TMS_PRO_FeatureID =
	    tms_pro_feature_2_developertask.Feature_RefID
	Where
	  tms_pro_feature.IsDeleted = 0 And
	  tms_pro_feature.IsArchived = 0 And
	  tms_pro_feature.Tenant_RefID = @TenantID And
	  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID
  