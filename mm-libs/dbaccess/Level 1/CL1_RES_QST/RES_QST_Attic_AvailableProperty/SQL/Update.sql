UPDATE 
	res_qst_attic_availableproperties
SET 
	RES_QST_Questionnaire_Version_RefID=@RES_QST_Questionnaire_Version_RefID,
	RES_STR_Attic_Property_RefID=@RES_STR_Attic_Property_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	RES_QST_Attic_AvailablePropertyID = @RES_QST_Attic_AvailablePropertyID