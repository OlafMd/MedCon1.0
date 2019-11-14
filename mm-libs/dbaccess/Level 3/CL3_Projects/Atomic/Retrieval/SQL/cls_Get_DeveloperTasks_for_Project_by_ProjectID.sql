
  
  Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertasks.Name As DeveloperTask,
  tms_pro_developertasks.PercentageComplete
From
  tms_pro_projects Inner Join
  tms_pro_businesstasks On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_businesstasks.Project_RefID Inner Join
  tms_pro_businesstask_2_feature On tms_pro_businesstasks.TMS_PRO_BusinessTaskID
    = tms_pro_businesstask_2_feature.BusinessTask_RefID Inner Join
  tms_pro_feature On tms_pro_businesstask_2_feature.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID Inner Join
  tms_pro_feature_2_developertask On tms_pro_feature.TMS_PRO_FeatureID =
    tms_pro_feature_2_developertask.Feature_RefID Inner Join
  tms_pro_developertasks On tms_pro_feature_2_developertask.DeveloperTask_RefID
    = tms_pro_developertasks.TMS_PRO_DeveloperTaskID
Where
 tms_pro_projects.TMS_PRO_ProjectID = @ProjectID And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_developertasks.IsComplete = 0
  
  
  
  