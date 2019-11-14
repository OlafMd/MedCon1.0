UPDATE 
	res_str_attic_propertyassessments
SET 
	STR_Attic_RefID=@STR_Attic_RefID,
	Rating_RefID=@Rating_RefID,
	AtticProperty_RefID=@AtticProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Attic_PropertyAssessmentID = @RES_STR_Attic_PropertyAssessmentID