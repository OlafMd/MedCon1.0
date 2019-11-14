
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID As Task_ID,
  tms_pro_developertasks.IdentificationNumber As Task_Identification,
  tms_pro_developertasks.Name As Task_Name,
  tms_pro_developertasks.Completion_Deadline As Task_Deadline,
  tms_pro_developertasks.PercentageComplete As Task_PercentageComplete,
  tms_pro_developertasks.Completion_Timestamp As Task_CompletionStamp,
  tms_pro_developertasks.Creation_Timestamp As Task_CreationStamp,
  tms_pro_developertasks.DeveloperTime_CurrentInvestment_min As Task_CurrentInvestment,
  tms_pro_developertasks.DeveloperTime_RequiredEstimation_min As Task_RequiredEstimation,
  Member.CreatedByFirstName,
  Member.CreatedByLastName,
  tms_pro_developertasks.Description As Task_Description,
  Assignment.TMS_PRO_DeveloperTask_InvolvementID As Task_Involvement,
  Assignment.IsActive,
  Assignment.DeveloperInvested,
  Assignment.Developer_CompletionEstimation,
  Assignment.Assignment_Timestamp,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_developertasks.IsComplete,
  tms_pro_developertask_priorities.Label_DictID
From
  tms_pro_developertasks Left Join
  tms_pro_developertask_priorities On tms_pro_developertasks.Priority_RefID =
    tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID Left Join
  (Select
    tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID,
    tms_pro_developertask_involvements.DeveloperTask_RefID,
    tms_pro_developertask_involvements.IsActive,
    tms_pro_developertask_involvements.R_InvestedWorkingTime_min As
    DeveloperInvested,
    tms_pro_developertask_involvements.Developer_CompletionTimeEstimation_min As
    Developer_CompletionEstimation,
    tms_pro_developertask_involvements.Creation_Timestamp As
    Assignment_Timestamp
  From
    tms_pro_developertask_involvements
  Where
    tms_pro_developertask_involvements.IsDeleted = 0) Assignment
    On Assignment.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Left Join
  (Select
    cmn_per_personinfo.FirstName As CreatedByFirstName,
    cmn_per_personinfo.LastName As CreatedByLastName,
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  From
    tms_pro_projectmembers Inner Join
    cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
      cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
    cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID
      = cmn_per_personinfo.CMN_PER_PersonInfoID) Member
    On tms_pro_developertasks.CreatedBy_ProjectMember_RefID =
    Member.TMS_PRO_ProjectMemberID
Where
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @TaskID And
  (tms_pro_developertasks.IsBeingPrepared = 1 Or
    tms_pro_developertasks.IsBeingPrepared = @IsBeingPrepared_Only) And
  tms_pro_developertasks.IsDeleted = 0 
