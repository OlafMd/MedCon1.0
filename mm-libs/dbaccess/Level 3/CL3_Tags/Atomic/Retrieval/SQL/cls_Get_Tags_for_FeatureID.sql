
	Select
  tms_pro_tags.TMS_PRO_TagID,
  tms_pro_tags.TagValue
From
  tms_pro_tags Inner Join
  tms_pro_feature_2_tag On tms_pro_feature_2_tag.Tag_RefID =
    tms_pro_tags.TMS_PRO_TagID Inner Join
  tms_pro_feature On tms_pro_feature.TMS_PRO_FeatureID =
    tms_pro_feature_2_tag.Feature_RefID
Where
  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.Tenant_RefID = @TenantID And
  tms_pro_tags.IsDeleted = 0 And
  tms_pro_feature_2_tag.Tenant_RefID = @TenantID And
  tms_pro_feature_2_tag.IsDeleted = 0 And
  tms_pro_tags.Tenant_RefID = @TenantID And
  tms_pro_tags.IsDeleted = 0
  