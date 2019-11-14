
	Select
	  cmn_str_sce_structurecalendarevent_types.CMN_STR_SCE_StructureCalendarEvent_TypeID
	From
	  cmn_str_sce_structurecalendarevent_types Inner Join
	  cmn_str_sce_structurecalendarevents
	    On cmn_str_sce_structurecalendarevents.StructureCalendarEvent_Type_RefID =
	    cmn_str_sce_structurecalendarevent_types.CMN_STR_SCE_StructureCalendarEvent_TypeID
	Where
	  cmn_str_sce_structurecalendarevent_types.IsDeleted = 0 And
	  cmn_str_sce_structurecalendarevents.IsDeleted = 0 And
	  cmn_str_sce_structurecalendarevents.Tenant_RefID = @TenantID
  