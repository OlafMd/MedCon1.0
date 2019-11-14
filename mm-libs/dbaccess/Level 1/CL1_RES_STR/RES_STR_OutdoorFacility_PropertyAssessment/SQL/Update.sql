UPDATE 
	res_str_outdoorfacility_propertyassessments
SET 
	STR_OutdoorFacility_RefID=@STR_OutdoorFacility_RefID,
	Rating_RefID=@Rating_RefID,
	OutdoorFacilityProperty_RefID=@OutdoorFacilityProperty_RefID,
	DocumentHeader_RefID=@DocumentHeader_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_STR_OutdoorFacility_PropertyAssessmentID = @RES_STR_OutdoorFacility_PropertyAssessmentID