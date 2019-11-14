INSERT INTO 
	hec_tre_potentialprocedure_localization_catalogcodes
	(
		HEC_TRE_PotentialProcedure_Localization_CatalogCodeID,
		HEC_TRE_PotentialProcedure_Localization_RefID,
		HEC_TRE_PotentialProcedure_Catalogs,
		Code,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_TRE_PotentialProcedure_Localization_CatalogCodeID,
		@HEC_TRE_PotentialProcedure_Localization_RefID,
		@HEC_TRE_PotentialProcedure_Catalogs,
		@Code,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)