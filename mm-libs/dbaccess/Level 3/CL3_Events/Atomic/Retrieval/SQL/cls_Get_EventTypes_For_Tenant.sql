
Select
  cmn_str_sce_structurecalendarevent_types.CMN_STR_SCE_StructureCalendarEvent_TypeID,
  cmn_str_sce_structurecalendarevent_types.CalendaEventName_DictID,
  cmn_str_sce_structurecalendarevent_types.EventIcon_RefID,
  cmn_str_sce_structurecalendarevent_types.PriorityOrdinal,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Foreground,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Background,
  cmn_str_sce_structurecalendarevent_types.ColorCode_Alpha,
  cmn_str_sce_structurecalendarevent_types.IsShowingNotification,
  cmn_str_sce_structurecalendarevent_types.IsWorkingDay,
  cmn_str_sce_structurecalendarevent_types.IsHalfWorkingDay,
  cmn_str_sce_structurecalendarevent_types.IsNonWorkingDay,
  cmn_str_sce_structurecalendarevent_types.IsDeleted,
  cmn_str_sce_structurecalendarevent_types.Tenant_RefID,
  cmn_str_sce_structurecalendarevent_types.InternalEventTypeID,
  cmn_str_sce_structurecalendarevent_types.IsEventType_Imported
From
  cmn_str_sce_structurecalendarevent_types
Where
  cmn_str_sce_structurecalendarevent_types.IsDeleted = 0 And
  cmn_str_sce_structurecalendarevent_types.Tenant_RefID = @TenantID
  