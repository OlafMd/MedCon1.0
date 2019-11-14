INSERT INTO 
	cmn_languages
	(
		CMN_LanguageID,
		ISO_639_1,
		ISO_639_2,
		Label,
		Name_DictID,
		Icon_Document_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_LanguageID,
		@ISO_639_1,
		@ISO_639_2,
		@Label,
		@Name,
		@Icon_Document_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)