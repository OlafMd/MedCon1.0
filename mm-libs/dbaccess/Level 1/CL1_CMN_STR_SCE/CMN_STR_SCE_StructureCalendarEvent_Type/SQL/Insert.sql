INSERT INTO 
	cmn_str_sce_structurecalendarevent_types
	(
		CMN_STR_SCE_StructureCalendarEvent_TypeID,
		CalendaEventName_DictID,
		EventIcon_RefID,
		PriorityOrdinal,
		ColorCode_Foreground,
		ColorCode_Background,
		ColorCode_Alpha,
		IsShowingNotification,
		IsWorkingDay,
		IsHalfWorkingDay,
		IsNonWorkingDay,
		InternalEventTypeID,
		IsEventType_Imported,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_SCE_StructureCalendarEvent_TypeID,
		@CalendaEventName,
		@EventIcon_RefID,
		@PriorityOrdinal,
		@ColorCode_Foreground,
		@ColorCode_Background,
		@ColorCode_Alpha,
		@IsShowingNotification,
		@IsWorkingDay,
		@IsHalfWorkingDay,
		@IsNonWorkingDay,
		@InternalEventTypeID,
		@IsEventType_Imported,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)