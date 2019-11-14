
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID As Task_ID,
  tms_pro_developertasks.IdentificationNumber As Task_Identification,
  tms_pro_developertasks.Name As Task_Name,
  tms_pro_projects.Name_DictID,
  tms_pro_developertasks.Completion_Deadline As Task_Deadline,
  tms_pro_developertasks.PercentageComplete As Task_PercentageComplete,
  tms_pro_developertask_priorities.Priority_Colour As Task_PriorityColor,
  tms_pro_developertasks.Completion_Timestamp As Task_CompletionStamp,
  tms_pro_developertasks.Creation_Timestamp As Task_CreationStamp,
  Member.FirstName,
  Member.LastName,
  tms_pro_developertasks.Description As Task_Description,
  Assignment.TMS_PRO_DeveloperTask_InvolvementID As Task_Involvement,
  Assignment.IsActive,
  tms_pro_developertasks.IsArchived,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_developertasks.IsComplete
From
  tms_pro_developertasks Left Join
  tms_pro_developertask_priorities On tms_pro_developertasks.Priority_RefID =
    tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID Left Join
  (Select
    tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID,
    tms_pro_developertask_involvements.DeveloperTask_RefID,
    tms_pro_developertask_involvements.IsActive
  From
    tms_pro_developertask_involvements
  Where
    tms_pro_developertask_involvements.IsDeleted = 0) Assignment
    On Assignment.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
  tms_pro_projects On tms_pro_developertasks.Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID Left Join
  (Select
    cmn_per_personinfo.FirstName,
    cmn_per_personinfo.LastName,
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID
  From
    tms_pro_projectmembers Inner Join
    cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
      cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
    cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID
      = cmn_per_personinfo.CMN_PER_PersonInfoID) Member
    On tms_pro_developertasks.GrabbedByMember_RefID =
    Member.TMS_PRO_ProjectMemberID
Where
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @TaskIDList And
  tms_pro_developertasks.IsArchived = 0 And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_projects.IsArchived = 0 And
  tms_pro_projects.IsDeleted = 0

   
  