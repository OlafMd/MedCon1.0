UPDATE 
	cmn_str_pps_workarea_types
SET 
	Name_DictID=@Name,
	Description_DictID=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_PPS_WorkArea_TypeID = @CMN_STR_PPS_WorkArea_TypeID