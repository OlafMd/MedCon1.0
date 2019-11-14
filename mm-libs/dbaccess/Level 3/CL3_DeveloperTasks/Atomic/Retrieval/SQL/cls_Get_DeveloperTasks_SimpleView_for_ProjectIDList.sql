
Select
  tms_pro_developertasks.Name,
  tms_pro_developertasks.IdentificationNumber,
  tms_pro_developertasks.Priority_RefID,
  tms_pro_developertasks.Project_RefID,
  tms_pro_developertasks.DeveloperTime_CurrentInvestment_min,
  tms_pro_developertasks.DeveloperTime_RequiredEstimation_min,
  tms_pro_developertasks.PercentageComplete,
  tms_pro_developertasks.Description,
  tms_pro_developertasks.Developer_Points,
  tms_pro_developertasks.Completion_Deadline,
  tms_pro_developertasks.DOC_Structure_Header_RefID,
  tms_pro_developertasks.CreatedBy_ProjectMember_RefID,
  tms_pro_developertasks.Completion_Timestamp,
  tms_pro_developertasks.Creation_Timestamp,
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertasks.IsArchived,
  tms_pro_developertasks.IsComplete,
  tms_pro_developertasks.DeveloperTask_Type_RefID,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_feature_2_developertask.Feature_RefID,
  tms_pro_developertasks.IsBeingPrepared,
  tms_pro_developertasks.GrabbedByMember_RefID,
  tms_pro_projectmembers.USR_Account_RefID
From
  tms_pro_developertasks Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_feature_2_developertask.DeveloperTask_RefID Left Join
  tms_pro_projectmembers On tms_pro_developertasks.GrabbedByMember_RefID =
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID
Where
  tms_pro_developertasks.Project_RefID = @ProjectIDList And
  (tms_pro_developertasks.IsArchived = 0 Or
    tms_pro_developertasks.IsArchived = @Is_ArchivedTasks_Included) And
  (tms_pro_developertasks.IsComplete = 1 Or
    tms_pro_developertasks.IsComplete = @ShowOnly_CompletedTasks) And
  (tms_pro_developertasks.IsIncompleteInformation = 1 Or
    tms_pro_developertasks.IsIncompleteInformation = @ShowOnly_IncompleteInfo)
  And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_feature_2_developertask.IsDeleted = 0
Order By
  tms_pro_developertasks.IdentificationNumber
  