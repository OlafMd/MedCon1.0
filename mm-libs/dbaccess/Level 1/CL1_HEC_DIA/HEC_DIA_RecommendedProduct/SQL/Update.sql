UPDATE 
	hec_dia_recommendedproducts
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	HealthcareProduct_RefID=@HealthcareProduct_RefID,
	IsDefault=@IsDefault,
	Modification_Timestamp=@Modification_Timestamp,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DIA_RecommendedProductID = @HEC_DIA_RecommendedProductID