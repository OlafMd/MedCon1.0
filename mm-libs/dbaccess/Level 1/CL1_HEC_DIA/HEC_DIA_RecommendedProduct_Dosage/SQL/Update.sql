UPDATE 
	hec_dia_recommendedproduct_dosages
SET 
	RecommendedProduct_RefID=@RecommendedProduct_RefID,
	Dosage_RefID=@Dosage_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_RecommendedProduct_DosageID = @HEC_DIA_RecommendedProduct_DosageID