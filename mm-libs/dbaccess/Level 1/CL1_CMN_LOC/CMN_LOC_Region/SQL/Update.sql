UPDATE 
	cmn_loc_regions
SET 
	Country_RefID=@Country_RefID,
	Parent_RefID=@Parent_RefID,
	Region_Name_DictID=@Region_Name,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Creation_Timestamp=@Creation_Timestamp
WHERE 
	CMN_LOC_RegionID = @CMN_LOC_RegionID