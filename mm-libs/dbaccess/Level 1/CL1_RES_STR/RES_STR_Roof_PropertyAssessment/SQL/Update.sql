UPDATE 
	res_str_roof_propertyassessments
SET 
	STR_Roof_RefID=@STR_Roof_RefID,
	Rating_RefID=@Rating_RefID,
	RoofProperty_RefID=@RoofProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Roof_PropertyAssessmentID = @RES_STR_Roof_PropertyAssessmentID