
    
Select
  tms_pro_feature.TMS_PRO_FeatureID,
  tms_pro_feature.Name_DictID
From
  tms_pro_projects Inner Join
  tms_pro_feature On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_feature.Project_RefID
Where
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_projects.TMS_PRO_ProjectID = @ProjectID
  
  