INSERT INTO 
	cmn_str_professionkeys
	(
		CMN_STR_ProfessionKeyID,
		SocialSecurityProfessionKey,
		CMN_STR_Profession_RefID,
		CMN_EconomicRegion_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_ProfessionKeyID,
		@SocialSecurityProfessionKey,
		@CMN_STR_Profession_RefID,
		@CMN_EconomicRegion_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)