UPDATE 
	res_str_apartments
SET 
	RES_BLD_Apartment_RefID=@RES_BLD_Apartment_RefID,
	DUD_Revision_RefID=@DUD_Revision_RefID,
	AverageRating_RefID=@AverageRating_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_ApartmentID = @RES_STR_ApartmentID