
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID AS DeveloperTask_ID
From
  tms_pro_developertasks Inner Join
  tms_pro_projectmembers On tms_pro_developertasks.GrabbedByMember_RefID =
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
  tms_pro_projects On tms_pro_projects.TMS_PRO_ProjectID =
    tms_pro_projectmembers.Project_RefID Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_feature_2_developertask.DeveloperTask_RefID Inner Join
  tms_pro_feature On tms_pro_feature_2_developertask.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID Inner Join
  tms_pro_businesstask_2_feature On tms_pro_feature.TMS_PRO_FeatureID =
    tms_pro_businesstask_2_feature.Feature_RefID Inner Join
  tms_pro_businesstasks On tms_pro_businesstask_2_feature.BusinessTask_RefID =
    tms_pro_businesstasks.TMS_PRO_BusinessTaskID
Where
  tms_pro_projects.Status_RefID != @ProjectStatusExcluded And
  tms_pro_businesstasks.IsDeleted = 0 And
  tms_pro_businesstasks.IsArchived = 0 And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_developertasks.IsComplete = 0 And
  (tms_pro_developertasks.IsBeingPrepared = 1 Or
    tms_pro_developertasks.IsBeingPrepared = @IsBeingPrepared_Only Or
    tms_pro_developertasks.IsBeingPrepared Is Null) And
  tms_pro_projects.IsArchived = 0 And
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_developertasks.Project_RefID = @ProjectID_List And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_businesstasks.Task_Status_RefID != @BusinessTaskStatusExcluded And
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_feature.Status_RefID != @FeatureStatusExcluded
  