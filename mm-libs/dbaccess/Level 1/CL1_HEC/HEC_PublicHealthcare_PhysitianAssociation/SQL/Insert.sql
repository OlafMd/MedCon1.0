INSERT INTO 
	hec_publichealthcare_physitianassociations
	(
		HEC_PublicHealthcare_PhysitianAssociationID,
		HealthAssociation_Name,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_PublicHealthcare_PhysitianAssociationID,
		@HealthAssociation_Name,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)