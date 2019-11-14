UPDATE 
	res_str_apartment_propertyassessments
SET 
	STR_Apartment_RefID=@STR_Apartment_RefID,
	Rating_RefID=@Rating_RefID,
	ApartmentProperty_RefID=@ApartmentProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Apartment_PropertyAssessmentID = @RES_STR_Apartment_PropertyAssessmentID