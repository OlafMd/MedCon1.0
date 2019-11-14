
Select
  tms_quicktasks.TMS_QuickTaskID,
  tms_quicktasks.R_QuickTask_InvestedTime_min,
  tms_quicktasks.QuickTask_StartTime,
  tms_quicktasks.QuickTask_Title_DictID
From
  tms_quicktasks
Where
  Date(tms_quicktasks.QuickTask_StartTime) = @Date And
  tms_quicktasks.QuickTask_CreatedByAccount_RefID = @AccountID And
  tms_quicktasks.IsDeleted = 0
  