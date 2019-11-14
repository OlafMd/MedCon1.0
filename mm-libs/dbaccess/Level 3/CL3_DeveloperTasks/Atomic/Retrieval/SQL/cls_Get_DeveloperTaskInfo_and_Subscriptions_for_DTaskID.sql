
Select
  tms_pro_developertasks.Name,
  tms_pro_developertasks.IdentificationNumber,
  tms_pro_developertasks.DeveloperTime_CurrentInvestment_min,
  tms_pro_developertasks.DeveloperTime_RequiredEstimation_min,
  tms_pro_developertasks.PercentageComplete,
  tms_pro_developertasks.Description,
  tms_pro_developertasks.Completion_Deadline,
  tms_pro_developertask_priorities.Label_DictID As Priority_Label_DictID,
  tms_pro_developertask_priorities.IconLocationURL As Priority_IconLocationURL,
  tms_pro_developertask_types.Label_DictID As Type_Label_DictID,
  tms_pro_developertask_types.IconLocationURL As Type_IconLocationURL,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_developertasks.Creation_Timestamp,
  tms_pro_developertask_priorities.PriorityLevel,
  RecommendedTo.USR_AccountID As RecommendedTo_AccountID,
  RecommendedTo.Username As RecommendedTo_Username,
  RecommendedTo.TMS_PRO_ProjectMemberID As RecommendedTo_ProjectMemberID,
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertasks.IsArchived,
  tms_pro_developertasks.IsComplete,
  tms_pro_developertasks.DOC_Structure_Header_RefID,
  tms_pro_developertasks.Completion_Timestamp,
  tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID,
  tms_pro_developertask_types.TMS_PRO_DeveloperTask_TypeID,
  tms_pro_developertasks.IsBeingPrepared,
  tms_pro_feature_2_developertask.Feature_RefID As Parent_RefID,
  tms_pro_developertasks.Project_RefID,
  Assignment.Assignment_To,
  usr_accounts.Username As CreatedBy_Username,
  Subscriptions.AssignmentID As PeersDevelopmentAssignmentID,
  tms_pro_projectmembers_subscription.TMS_PRO_ProjectMemberID,
  Assignment.TMS_PRO_ProjectMemberID As AssignedTo_ProjectMemberID,
  Assignment.TMS_PRO_DeveloperTask_InvolvementID,
  Assignment.OrderSequence,
  Assignment.R_InvestedWorkingTime_min,
  Assignment.Developer_CompletionTimeEstimation_min,
  Assignment.Assignment_Timestamp,
  Assignment.IsDeleted,
  Assignment.IsActive,
  AssignedRevision.CMN_PRO_Product_Release_RefID,
  tms_pro_developertasks.IsTaskEstimable
From
  tms_pro_developertasks Left Join
  tms_pro_developertask_priorities On tms_pro_developertasks.Priority_RefID =
    tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID Left Join
  tms_pro_developertask_types On tms_pro_developertasks.DeveloperTask_Type_RefID
    = tms_pro_developertask_types.TMS_PRO_DeveloperTask_TypeID Left Join
  (Select
    tms_pro_developertask_recommendations.DeveloperTask_RefID,
    usr_accounts_RecommendedTo.Username,
    usr_accounts_RecommendedTo.USR_AccountID,
    tms_pro_projectmembers_RecommendedTo.TMS_PRO_ProjectMemberID
  From
    tms_pro_developertask_recommendations Inner Join
    tms_pro_projectmembers tms_pro_projectmembers_RecommendedTo
      On tms_pro_projectmembers_RecommendedTo.TMS_PRO_ProjectMemberID =
      tms_pro_developertask_recommendations.RecommendedTo_ProjectMember_RefID
    Inner Join
    usr_accounts usr_accounts_RecommendedTo
      On tms_pro_projectmembers_RecommendedTo.USR_Account_RefID =
      usr_accounts_RecommendedTo.USR_AccountID
  Where
    tms_pro_developertask_recommendations.DeveloperTask_RefID = @DTaskID And
    tms_pro_developertask_recommendations.IsDeleted = 0 And
    tms_pro_projectmembers_RecommendedTo.IsDeleted = 0 And
    usr_accounts_RecommendedTo.IsDeleted = 0 And
    tms_pro_developertask_recommendations.Tenant_RefID = @TenantID)
  RecommendedTo On RecommendedTo.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Left Join
  (Select
    usr_accounts.Username As Assignment_To,
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
    tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID,
    tms_pro_developertask_involvements.DeveloperTask_RefID,
    tms_pro_developertask_involvements.OrderSequence,
    tms_pro_developertask_involvements.R_InvestedWorkingTime_min,
    tms_pro_developertask_involvements.Developer_CompletionTimeEstimation_min,
    tms_pro_developertask_involvements.Creation_Timestamp As
    Assignment_Timestamp,
    tms_pro_developertask_involvements.IsDeleted,
    tms_pro_developertask_involvements.IsActive
  From
    tms_pro_projectmembers Inner Join
    usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
      usr_accounts.USR_AccountID Inner Join
    tms_pro_developertask_involvements
      On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
      tms_pro_developertask_involvements.ProjectMember_RefID
  Where
    tms_pro_developertask_involvements.IsDeleted = 0 And
    tms_pro_projectmembers.IsDeleted = 0) Assignment
    On Assignment.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_feature_2_developertask.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
  tms_pro_projectmembers On tms_pro_developertasks.CreatedBy_ProjectMember_RefID
    = tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
  usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
    usr_accounts.USR_AccountID Left Join
  (Select
    tms_pro_peers_development.DeveloperTask_RefID,
    tms_pro_peers_development.AssignmentID
  From
    tms_pro_peers_development Inner Join
    tms_pro_projectmembers On tms_pro_peers_development.ProjectMember_RefID =
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  Where
    tms_pro_peers_development.DeveloperTask_RefID = @DTaskID And
    tms_pro_projectmembers.USR_Account_RefID = @AccountID And
    tms_pro_projectmembers.IsDeleted = 0 And
    tms_pro_peers_development.IsDeleted = 0) Subscriptions
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    Subscriptions.DeveloperTask_RefID Left Join
  tms_pro_projectmembers tms_pro_projectmembers_subscription
    On (tms_pro_developertasks.Project_RefID =
    tms_pro_projectmembers_subscription.Project_RefID 
	And tms_pro_projectmembers_subscription.USR_Account_RefID = @AccountID )
	Left Join
  (Select
    cmn_pro_product_release_2_developertask.TMS_PRO_DeveloperTask_RefID,
    cmn_pro_product_release_2_developertask.CMN_PRO_Product_Release_RefID
  From
    cmn_pro_product_release_2_developertask
  Where
    cmn_pro_product_release_2_developertask.IsDeleted = 0 And
    cmn_pro_product_release_2_developertask.Tenant_RefID = @TenantID)
  AssignedRevision On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    AssignedRevision.TMS_PRO_DeveloperTask_RefID
Where
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @DTaskID And
  (tms_pro_developertasks.IsBeingPrepared = 1 Or
    tms_pro_developertasks.IsBeingPrepared = @IsBeingPrepared_Only) And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_feature_2_developertask.IsDeleted = 0
  