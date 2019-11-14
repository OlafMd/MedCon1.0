
Select
  tms_quicktask_type.TMS_QuickTask_TypeID,
  tms_quicktask_type.QuickTaskType_Name_DictID ,
  tms_quicktask_type.QuickTaskType_Description_DictID,
  tms_quicktask_type.Creation_Timestamp
From
  tms_quicktask_type
Where
  tms_quicktask_type.IsDeleted = 0 And
  tms_quicktask_type.Tenant_RefID = @TenantID
  