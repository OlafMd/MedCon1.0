UPDATE 
	hec_cmt_membership_potentialprocedurecatalogsubscriptions
SET 
	Membership_RefID=@Membership_RefID,
	PotentialProcedureCatalogITL=@PotentialProcedureCatalogITL,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_Membership_PotentialProcedureCatalogSubscriptionID = @HEC_CMT_Membership_PotentialProcedureCatalogSubscriptionID