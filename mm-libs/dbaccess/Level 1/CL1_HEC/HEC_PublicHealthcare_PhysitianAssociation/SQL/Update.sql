UPDATE 
	hec_publichealthcare_physitianassociations
SET 
	HealthAssociation_Name=@HealthAssociation_Name,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_PublicHealthcare_PhysitianAssociationID = @HEC_PublicHealthcare_PhysitianAssociationID