INSERT INTO 
	cmn_str_office_types
	(
		CMN_STR_Office_TypeID,
		OfficeType_Name_DictID,
		OfficeType_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_Office_TypeID,
		@OfficeType_Name,
		@OfficeType_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)