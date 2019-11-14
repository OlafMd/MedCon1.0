UPDATE 
	cmn_pro_product_releases
SET 
	ProductReleaseITL=@ProductReleaseITL,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	IsRelease_Released=@IsRelease_Released,
	IsRelease_UnderDevelopment=@IsRelease_UnderDevelopment,
	IfReleased_ReleasedDate=@IfReleased_ReleasedDate,
	IfUnderDevelopment_EstimatedReleaseDate=@IfUnderDevelopment_EstimatedReleaseDate,
	ProductRelease_DocumentationStructure_RefID=@ProductRelease_DocumentationStructure_RefID,
	Product_ReleaseName=@Product_ReleaseName,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID,
	IsStandardProductRelease=@IsStandardProductRelease
WHERE 
	CMN_PRO_Product_ReleaseID = @CMN_PRO_Product_ReleaseID