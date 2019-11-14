UPDATE 
	res_str_staircase_propertyassessments
SET 
	STR_Staircase_RefID=@STR_Staircase_RefID,
	Rating_RefID=@Rating_RefID,
	StaircaseProperty_RefID=@StaircaseProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_Staircase_PropertyAssessmentID = @RES_STR_Staircase_PropertyAssessmentID