UPDATE 
	cmn_str_pps_workplaces
SET 
	WorkArea_RefID=@WorkArea_RefID,
	Name_DictID=@Name,
	Description_DictID=@Description,
	CMN_CAL_CalendarInstance_RefID=@CMN_CAL_CalendarInstance_RefID,
	ShortName=@ShortName,
	IsMockObject=@IsMockObject,
	DisplayColor=@DisplayColor,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_WorkplaceID = @CMN_STR_PPS_WorkplaceID