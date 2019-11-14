
Select
  tms_pro_developertasks.PercentageComplete As DeveloperTask_PercentageComplete,
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID As DeveloperTask_ID,
  tms_pro_developertask_statushistory.DeveloperTask_Status_RefID As
  DeveloperTask_StatusID,
  tms_pro_developertask_statushistory.Creation_Timestamp As
  DeveloperTask_StatusCreationTimeStamp,
  tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID As
  DeveloperTask_InvolvementID
From
  tms_pro_developertasks Inner Join
  tms_pro_projectmembers On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
    tms_pro_developertasks.GrabbedByMember_RefID Inner Join
  tms_pro_developertask_involvements
    On tms_pro_developertask_involvements.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Right Join
  tms_pro_developertask_statushistory
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_developertask_statushistory.DeveloperTask_RefID
Where
  tms_pro_projectmembers.USR_Account_RefID = @AccountID And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_developertasks.IsComplete = 0 And
  (tms_pro_developertasks.IsBeingPrepared = @IsBeingPrepared_Only Or
    tms_pro_developertasks.IsBeingPrepared = 1 Or
    tms_pro_developertasks.IsBeingPrepared Is Null) And
  (tms_pro_developertask_involvements.IsDeleted = 0 Or
    tms_pro_developertask_involvements.IsDeleted Is Null) And
  (tms_pro_developertask_involvements.IsArchived = 0 Or
    tms_pro_developertask_involvements.IsArchived Is Null) And
  tms_pro_developertask_involvements.IsActive = 1 And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_projectmembers.IsDeleted = 0
  