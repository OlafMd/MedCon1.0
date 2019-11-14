UPDATE 
	cmn_per_personinfo_socialsecuritynumbers
SET 
	PersonInfo_RefID=@PersonInfo_RefID,
	SocialSecurityNumber=@SocialSecurityNumber,
	SocialSecurityNumber_Type_RefID=@SocialSecurityNumber_Type_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PER_PersonInfo_SocialSecurityNumberID = @CMN_PER_PersonInfo_SocialSecurityNumberID