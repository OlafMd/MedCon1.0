UPDATE 
	cmn_str_pps_workplace_activities
SET 
	WorkplaceActivity_Name_DictID=@WorkplaceActivity_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_PPS_Workplace_ActivityID = @CMN_STR_PPS_Workplace_ActivityID