UPDATE 
	hec_cmt_membership_credentials
SET 
	Membership_RefID=@Membership_RefID,
	Membership_Username=@Membership_Username,
	Membership_Password=@Membership_Password,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_Membership_CredentialID = @HEC_CMT_Membership_CredentialID