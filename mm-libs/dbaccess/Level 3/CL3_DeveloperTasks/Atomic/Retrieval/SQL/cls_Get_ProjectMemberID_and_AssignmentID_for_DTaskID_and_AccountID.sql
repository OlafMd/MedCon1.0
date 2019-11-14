
    Select
      tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
      Assignments.TMS_PRO_DeveloperTask_InvolvementID
    From
      tms_pro_projectmembers Inner Join
      tms_pro_developertasks On tms_pro_developertasks.Project_RefID =
        tms_pro_projectmembers.Project_RefID Left Join
      (Select
        tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID,
        tms_pro_developertask_involvements.ProjectMember_RefID
      From
        tms_pro_developertask_involvements
      Where
        tms_pro_developertask_involvements.DeveloperTask_RefID = @DTaskID)
      Assignments On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
        Assignments.ProjectMember_RefID
    Where
      tms_pro_projectmembers.USR_Account_RefID = @AccountID And
      tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @DTaskID
  