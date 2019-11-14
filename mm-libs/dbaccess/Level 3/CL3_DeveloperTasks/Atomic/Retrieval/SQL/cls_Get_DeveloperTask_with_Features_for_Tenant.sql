
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_feature_2_developertask.AssignmentID,
  tms_pro_feature.TMS_PRO_FeatureID,
  tms_pro_developertasks.Project_RefID,
  tms_pro_developertasks.GrabbedByMember_RefID,
  tms_pro_developertasks.Completion_Deadline,
  tms_pro_developertasks.Name,
  tms_pro_developertasks.Description,
  tms_pro_developertasks.Developer_Points,
  tms_pro_developertasks.IsComplete,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_developertasks.IsBeingPrepared,
  tms_pro_developertasks.DeveloperTime_RequiredEstimation_min,
  tms_pro_developertasks.DeveloperTime_CurrentInvestment_min,
  tms_pro_developertasks.PercentageComplete,
  tms_pro_feature.Parent_RefID,
  tms_pro_feature.Name_DictID,
  tms_pro_developertasks.IdentificationNumber,
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID
From
  tms_pro_feature Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_feature_2_developertask.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID Inner Join
  tms_pro_developertasks On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_feature_2_developertask.DeveloperTask_RefID Inner Join
  tms_pro_projectmembers On tms_pro_projectmembers.Project_RefID =
    tms_pro_developertasks.Project_RefID
Where
  tms_pro_feature.IsArchived = 0 And
  tms_pro_feature.IsDeleted = 0 And
  tms_pro_feature_2_developertask.IsDeleted = 0 And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.USR_Account_RefID = @AccountID

  