INSERT INTO 
	hec_dosages
	(
		HEC_DosageID,
		DosageText,
		Creation_Timestamp,
		Modification_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@HEC_DosageID,
		@DosageText,
		@Creation_Timestamp,
		@Modification_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)