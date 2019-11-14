INSERT INTO 
	cmn_per_personinfo_socialsecuritynumbers
	(
		CMN_PER_PersonInfo_SocialSecurityNumberID,
		PersonInfo_RefID,
		SocialSecurityNumber,
		SocialSecurityNumber_Type_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PER_PersonInfo_SocialSecurityNumberID,
		@PersonInfo_RefID,
		@SocialSecurityNumber,
		@SocialSecurityNumber_Type_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)