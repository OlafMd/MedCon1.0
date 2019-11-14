UPDATE 
	cmn_str_pps_workareas
SET 
	Office_RefID=@Office_RefID,
	CMN_BPT_STA_SettingProfile_RefID=@CMN_BPT_STA_SettingProfile_RefID,
	Parent_RefID=@Parent_RefID,
	WorkArea_Type_RefID=@WorkArea_Type_RefID,
	Name_DictID=@Name,
	Description_DictID=@Description,
	CMN_CAL_CalendarInstance_RefID=@CMN_CAL_CalendarInstance_RefID,
	Default_StartWorkingHour=@Default_StartWorkingHour,
	ShortName=@ShortName,
	IsMockObject=@IsMockObject,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_PPS_WorkAreaID = @CMN_STR_PPS_WorkAreaID