INSERT INTO 
	hec_dia_recommendedproduct_dosages
	(
		HEC_DIA_RecommendedProduct_DosageID,
		RecommendedProduct_RefID,
		Dosage_RefID,
		IsDefault,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_DIA_RecommendedProduct_DosageID,
		@RecommendedProduct_RefID,
		@Dosage_RefID,
		@IsDefault,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)