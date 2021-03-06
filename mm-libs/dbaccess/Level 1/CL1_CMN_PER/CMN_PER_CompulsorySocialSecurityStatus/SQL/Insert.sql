INSERT INTO 
	cmn_per_compulsorysocialsecuritystatuses
	(
		CMN_PER_CompulsorySocialSecurityStatusID,
		GlobalPropertyMatchingID,
		SocialSecurityStatus_DisplayName,
		SocialSecurityStatus_Name_DictID,
		SocialSecurityStatus_Description_DictID,
		CMN_EconomicRegion_RefID,
		SocialSecurityStatus_Code,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PER_CompulsorySocialSecurityStatusID,
		@GlobalPropertyMatchingID,
		@SocialSecurityStatus_DisplayName,
		@SocialSecurityStatus_Name,
		@SocialSecurityStatus_Description,
		@CMN_EconomicRegion_RefID,
		@SocialSecurityStatus_Code,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)