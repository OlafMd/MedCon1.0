
	
Select
  tms_pro_feature_2_developertask.DeveloperTask_RefID,
  tms_pro_feature.Name_DictID,
  tms_pro_feature.TMS_PRO_FeatureID,
  tms_pro_feature.IdentificationNumber,
  tms_pro_feature.DOC_Structure_Header_RefID,
  tms_pro_feature.Description_DictID,
  tms_pro_feature.Feature_Deadline,
  tms_pro_feature.Creation_Timestamp,
  tms_pro_feature_type.Label_DictID As Feature_Type_DictID,
  tms_pro_feature_statuses.Label_DictID As Feature_Status_DictID,
  tms_pro_feature_type.TMS_PRO_Feature_TypeID,
  tms_pro_feature_statuses.TMS_PRO_Feature_StatusID As Feature_StatusID,
  tms_pro_feature.Project_RefID,
  tms_pro_feature.Parent_RefID,
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
  Subscription.AssignmentID
From
  tms_pro_feature Left Join
  tms_pro_feature_2_developertask
    On (tms_pro_feature_2_developertask.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID And
    (tms_pro_feature_2_developertask.IsDeleted = 0 Or
    tms_pro_feature_2_developertask.IsDeleted Is Null)) Left Join
  tms_pro_feature_statuses On tms_pro_feature.Status_RefID =
    tms_pro_feature_statuses.TMS_PRO_Feature_StatusID Left Join
  tms_pro_feature_type On tms_pro_feature.Type_RefID =
    tms_pro_feature_type.TMS_PRO_Feature_TypeID Left Join
  (Select
    tms_pro_peers_features.AssignmentID,
    tms_pro_peers_features.Feature_RefID
  From
    tms_pro_peers_features Inner Join
    tms_pro_projectmembers On tms_pro_peers_features.ProjectMember_RefID =
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  Where
    tms_pro_projectmembers.USR_Account_RefID = @AccountID And
    tms_pro_peers_features.Feature_RefID = @FeatureID And
    tms_pro_peers_features.IsDeleted = 0 And
    tms_pro_projectmembers.IsDeleted = 0) Subscription
    On tms_pro_feature.TMS_PRO_FeatureID = Subscription.Feature_RefID Inner Join
  tms_pro_projectmembers On tms_pro_feature.Project_RefID =
    tms_pro_projectmembers.Project_RefID
Where
  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID And
  (tms_pro_feature.IsArchived = 0 OR tms_pro_feature.IsArchived = @IncludeArchived) And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_feature.Tenant_RefID = @TenantID
  
  