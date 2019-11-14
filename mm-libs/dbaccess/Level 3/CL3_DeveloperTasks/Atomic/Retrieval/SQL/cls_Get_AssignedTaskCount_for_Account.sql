
    Select
      count(*) As taskCount
    From
      tms_pro_projectmembers Inner Join
      tms_pro_developertask_involvements
        On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
        tms_pro_developertask_involvements.ProjectMember_RefID Inner Join
      tms_pro_developertasks
        On tms_pro_developertask_involvements.DeveloperTask_RefID =
        tms_pro_developertasks.TMS_PRO_DeveloperTaskID
    Where
      tms_pro_projectmembers.IsDeleted = 0 And
      tms_pro_developertasks.IsArchived = 0 And
      tms_pro_developertasks.IsComplete = 0 And
      tms_pro_projectmembers.USR_Account_RefID = @AccountID And
      tms_pro_developertask_involvements.IsDeleted = 0 And
      tms_pro_developertask_involvements.IsArchived = 0
    Group By
      tms_pro_projectmembers.IsDeleted, tms_pro_projectmembers.USR_Account_RefID,
      tms_pro_developertasks.IsDeleted
  