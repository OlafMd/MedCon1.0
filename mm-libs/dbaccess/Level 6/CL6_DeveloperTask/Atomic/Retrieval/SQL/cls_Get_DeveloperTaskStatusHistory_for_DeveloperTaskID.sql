
    Select
  tms_pro_developertask_statushistory.DeveloperTask_Status_RefID,
  tms_pro_developertask_statushistory.Comment,
  tms_pro_developertask_statushistory.Creation_Timestamp,
  tms_pro_developertask_statushistory.TriggeredBy_ProjectMember_RefID,
  tms_pro_developertask_statuses.Label_DictID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  tms_pro_developertask_statuses.GlobalPropertyMatchingID
From
  tms_pro_developertask_statushistory Join
  tms_pro_developertask_statuses
    On tms_pro_developertask_statushistory.DeveloperTask_Status_RefID =
    tms_pro_developertask_statuses.TMS_PRO_DeveloperTask_StatusID Inner Join
  tms_pro_projectmembers
    On tms_pro_developertask_statushistory.TriggeredBy_ProjectMember_RefID =
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID Inner Join
  cmn_per_personinfo_2_account On tms_pro_projectmembers.USR_Account_RefID =
    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  tms_pro_developertask_statushistory.DeveloperTask_RefID = @DeveloperTaskID And
  tms_pro_developertask_statuses.IsDeleted = 0 And
  tms_pro_developertask_statushistory.IsDeleted = 0 And
  tms_pro_projectmembers.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  tms_pro_developertask_statushistory.Tenant_RefID = @TenantID
Order By
  tms_pro_developertask_statushistory.Creation_Timestamp Desc
  