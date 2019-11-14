UPDATE 
	res_bld_apartment_2_apartmenttype
SET 
	RES_BLD_Apartment_RefID=@RES_BLD_Apartment_RefID,
	RES_BLD_Apartment_Type_RefID=@RES_BLD_Apartment_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID