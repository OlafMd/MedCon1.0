
	Select
	  tms_pro_tags.TagValue,
	  tms_pro_feature.TMS_PRO_FeatureID
	From
	  tms_pro_feature_2_tag Inner Join
	  tms_pro_feature On tms_pro_feature_2_tag.Feature_RefID =
	    tms_pro_feature.TMS_PRO_FeatureID Inner Join
	  tms_pro_tags On tms_pro_feature_2_tag.Tag_RefID = tms_pro_tags.TMS_PRO_TagID
	Where
	  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID And
	  tms_pro_feature.IsArchived = 0 And
	  tms_pro_feature.IsDeleted = 0 And
	  tms_pro_feature.Tenant_RefID = @TenantID
  