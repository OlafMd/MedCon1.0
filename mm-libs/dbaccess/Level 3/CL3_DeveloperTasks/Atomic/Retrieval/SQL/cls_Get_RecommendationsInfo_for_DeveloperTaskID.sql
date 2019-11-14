
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID
From
  tms_pro_developertask_recommendations Inner Join
  tms_pro_projectmembers
    On tms_pro_developertask_recommendations.RecommendedTo_ProjectMember_RefID =
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
  cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  tms_pro_developertask_recommendations.DeveloperTask_RefID = @DTaskID And
  tms_pro_developertask_recommendations.IsDeleted = 0
  