UPDATE 
	res_str_basement_propertyassessments
SET 
	STR_Basement_RefID=@STR_Basement_RefID,
	Rating_RefID=@Rating_RefID,
	BasementProperty_RefID=@BasementProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Basement_PropertyAssessmentID = @RES_STR_Basement_PropertyAssessmentID