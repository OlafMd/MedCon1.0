
	Select
  tms_pro_feature.TMS_PRO_FeatureID,
  tms_pro_feature.Name_DictID As Name,
  tms_pro_feature.IdentificationNumber,
  tms_pro_feature.Description_DictID As Description,
  tms_pro_feature.Feature_Deadline,
  tms_pro_feature.Parent_RefID,
  tms_pro_feature.Project_RefID
From
  tms_pro_feature
Where
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_feature.Tenant_RefID = @TenantID
  