INSERT INTO 
	cmn_str_pps_workplaces
	(
		CMN_STR_PPS_WorkplaceID,
		WorkArea_RefID,
		Name_DictID,
		Description_DictID,
		CMN_CAL_CalendarInstance_RefID,
		ShortName,
		IsMockObject,
		DisplayColor,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_STR_PPS_WorkplaceID,
		@WorkArea_RefID,
		@Name,
		@Description,
		@CMN_CAL_CalendarInstance_RefID,
		@ShortName,
		@IsMockObject,
		@DisplayColor,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)