UPDATE 
	res_str_hvacr_propertyassessments
SET 
	STR_HVACR_RefID=@STR_HVACR_RefID,
	Rating_RefID=@Rating_RefID,
	HVACRProperty_RefID=@HVACRProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_HVACR_PropertyAssessmentID = @RES_STR_HVACR_PropertyAssessmentID