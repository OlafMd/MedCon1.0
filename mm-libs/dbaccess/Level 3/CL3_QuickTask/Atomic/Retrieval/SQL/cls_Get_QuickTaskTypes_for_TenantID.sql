
	Select
	  tms_quicktask_type.TMS_QuickTask_TypeID,
	  tms_quicktask_type.QuickTaskType_Name_DictID,
	  tms_quicktask_type.QuickTaskType_ExternalID,
	  tms_quicktask_type.QuickTaskType_Description_DictID,
	  tms_quicktask_type.IsPersistent,
	  tms_quicktask_type.Tenant_RefID
	From
	  tms_quicktask_type
	Where
	  (tms_quicktask_type.Tenant_RefID = Cast(0x00000000000000000000000000000000 As Binary) Or
	    (tms_quicktask_type.Tenant_RefID = @TenantID)) And
	  tms_quicktask_type.IsDeleted = 0
  