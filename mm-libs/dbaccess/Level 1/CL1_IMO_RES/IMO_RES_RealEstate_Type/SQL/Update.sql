UPDATE 
	imo_res_realestate_types
SET 
	Label_DictID=@Label,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_RES_RealEstate_TypeID = @IMO_RES_RealEstate_TypeID