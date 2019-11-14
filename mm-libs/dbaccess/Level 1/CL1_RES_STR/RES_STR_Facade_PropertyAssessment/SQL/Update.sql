UPDATE 
	res_str_facade_propertyassessments
SET 
	STR_Facade_RefID=@STR_Facade_RefID,
	Rating_RefID=@Rating_RefID,
	FacadeProperty_RefID=@FacadeProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Facade_PropertyAssessmentID = @RES_STR_Facade_PropertyAssessmentID