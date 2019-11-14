INSERT INTO 
	cmn_str_pps_workareas
	(
		CMN_STR_PPS_WorkAreaID,
		Office_RefID,
		CMN_BPT_STA_SettingProfile_RefID,
		Parent_RefID,
		WorkArea_Type_RefID,
		Name_DictID,
		Description_DictID,
		CMN_CAL_CalendarInstance_RefID,
		Default_StartWorkingHour,
		ShortName,
		IsMockObject,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_PPS_WorkAreaID,
		@Office_RefID,
		@CMN_BPT_STA_SettingProfile_RefID,
		@Parent_RefID,
		@WorkArea_Type_RefID,
		@Name,
		@Description,
		@CMN_CAL_CalendarInstance_RefID,
		@Default_StartWorkingHour,
		@ShortName,
		@IsMockObject,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)