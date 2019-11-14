UPDATE 
	cmn_str_professionkeys
SET 
	SocialSecurityProfessionKey=@SocialSecurityProfessionKey,
	CMN_STR_Profession_RefID=@CMN_STR_Profession_RefID,
	CMN_EconomicRegion_RefID=@CMN_EconomicRegion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_ProfessionKeyID = @CMN_STR_ProfessionKeyID