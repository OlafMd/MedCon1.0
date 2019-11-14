UPDATE 
	res_loc_meansoftransportations
SET 
	Transportation_Name_DictID=@Transportation_Name,
	Transportation_Description_DictID=@Transportation_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_LOC_MeansOfTransportationID = @RES_LOC_MeansOfTransportationID