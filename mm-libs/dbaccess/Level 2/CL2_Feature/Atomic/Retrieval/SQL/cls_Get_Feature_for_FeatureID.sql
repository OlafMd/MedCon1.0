
	Select
	  tms_pro_feature.TMS_PRO_FeatureID,
	  tms_pro_feature.IdentificationNumber,
	  tms_pro_feature.Project_RefID,
	  tms_pro_feature.Name_DictID,
	  tms_pro_feature.Description_DictID,
	  tms_pro_feature.Feature_Deadline,
	  tms_pro_feature.Creation_Timestamp
	From
	  tms_pro_feature
	Where
	  tms_pro_feature.IsDeleted = 0 And
	  tms_pro_feature.IsArchived = 0 And
	  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID And
	  tms_pro_feature.Tenant_RefID = @TenantID
  