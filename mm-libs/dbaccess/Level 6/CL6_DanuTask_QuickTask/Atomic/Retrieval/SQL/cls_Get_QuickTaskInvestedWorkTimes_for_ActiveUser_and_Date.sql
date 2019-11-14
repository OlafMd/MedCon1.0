
Select
  tms_quicktasks.TMS_QuickTaskID,
  tms_quicktasks.IdentificationNumber,
  tms_quicktasks.QuickTask_Title_DictID,
  tms_quicktasks.QuickTask_StartTime,
  tms_quicktasks.QuickTask_Description_DictID,
  tms_quicktasks.QuickTask_Type_RefID,
  tms_pro_projects.TMS_PRO_ProjectID,
  tms_pro_projects.Name_DictID,
  tms_quicktasks.R_QuickTask_InvestedTime_min
From
  cmn_bpt_investedworktimes Left Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_investedworktimes.BusinessParticipant_RefID Inner Join
  tms_quicktask_investedworktimes
    On cmn_bpt_investedworktimes.CMN_BPT_InvestedWorkTimeID =
    tms_quicktask_investedworktimes.CMN_BPT_InvestedWorkTime_RefID Inner Join
  tms_quicktasks On tms_quicktask_investedworktimes.TMS_QuickTasks_RefID =
    tms_quicktasks.TMS_QuickTaskID Inner Join
  tms_pro_projects On tms_quicktasks.AssignedTo_Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID
Where
  cmn_bpt_investedworktimes.IsDeleted = 0 And
  tms_quicktasks.IsDeleted = 0 And
  tms_quicktask_investedworktimes.IsDeleted = 0 And
  usr_accounts.USR_AccountID = @AccountID And
  DATE(tms_quicktasks.QuickTask_StartTime) = DATE(@StartDate) And
  tms_pro_projects.Tenant_RefID = @TenantID
  