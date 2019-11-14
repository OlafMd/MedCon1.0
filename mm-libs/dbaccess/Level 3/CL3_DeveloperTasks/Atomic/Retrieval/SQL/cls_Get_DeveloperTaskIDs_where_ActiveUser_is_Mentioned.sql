
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID As DeveloperTask_ID,
  Comments.R_CommentMention_Text as CommentMention
From
  tms_pro_developertasks Inner Join
  tms_pro_projects On tms_pro_developertasks.Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_feature_2_developertask.DeveloperTask_RefID Inner Join
  tms_pro_feature On tms_pro_feature_2_developertask.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID Inner Join
  (Select Distinct
    tms_pro_comments.Comment_BoundTo_DeveloperTask_RefID,
    tms_pro_comment_mentions.R_CommentMention_Text
  From
    tms_pro_comment_mentions Inner Join
    tms_pro_comments On tms_pro_comment_mentions.Comment_RefID =
      tms_pro_comments.TMS_PRO_CommentID
  Where
    tms_pro_comment_mentions.Mention_Account_RefID = @AccountID And
    tms_pro_comments.IsDeleted = 0 And
    tms_pro_comment_mentions.IsDeleted = 0 And
    tms_pro_comments.Tenant_RefID = @TenantID) Comments
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    Comments.Comment_BoundTo_DeveloperTask_RefID Inner Join
  tms_pro_businesstask_2_feature On tms_pro_feature.TMS_PRO_FeatureID =
    tms_pro_businesstask_2_feature.Feature_RefID Inner Join
  tms_pro_businesstasks On tms_pro_businesstask_2_feature.BusinessTask_RefID =
    tms_pro_businesstasks.TMS_PRO_BusinessTaskID
Where
  tms_pro_developertasks.IsComplete = 0 And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.Status_RefID != @FeatureStatusExcluded And
  tms_pro_businesstasks.Task_Status_RefID != @BusinessTaskStatusExcluded And
  tms_pro_businesstasks.IsArchived = 0 And
  tms_pro_businesstasks.IsDeleted = 0 And
  tms_pro_projects.IsArchived = 0 And
  tms_pro_projects.Status_RefID != @ProjectStatusExcluded
  