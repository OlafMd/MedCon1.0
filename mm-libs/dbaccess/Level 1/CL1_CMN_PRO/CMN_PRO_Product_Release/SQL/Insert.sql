INSERT INTO 
	cmn_pro_product_releases
	(
		CMN_PRO_Product_ReleaseID,
		ProductReleaseITL,
		Product_RefID,
		Product_Variant_RefID,
		IsRelease_Released,
		IsRelease_UnderDevelopment,
		IfReleased_ReleasedDate,
		IfUnderDevelopment_EstimatedReleaseDate,
		ProductRelease_DocumentationStructure_RefID,
		Product_ReleaseName,
		OrderSequence,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID,
		IsStandardProductRelease
	)
VALUES 
	(
		@CMN_PRO_Product_ReleaseID,
		@ProductReleaseITL,
		@Product_RefID,
		@Product_Variant_RefID,
		@IsRelease_Released,
		@IsRelease_UnderDevelopment,
		@IfReleased_ReleasedDate,
		@IfUnderDevelopment_EstimatedReleaseDate,
		@ProductRelease_DocumentationStructure_RefID,
		@Product_ReleaseName,
		@OrderSequence,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID,
		@IsStandardProductRelease
	)