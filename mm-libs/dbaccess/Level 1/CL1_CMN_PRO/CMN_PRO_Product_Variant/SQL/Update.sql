UPDATE 
	cmn_pro_product_variants
SET 
	ProductVariantITL=@ProductVariantITL,
	VariantName_DictID=@VariantName,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	ProductVariant_DocumentationStructure_RefID=@ProductVariant_DocumentationStructure_RefID,
	IsStandardProductVariant=@IsStandardProductVariant,
	IsImportedFromExternalCatalog=@IsImportedFromExternalCatalog,
	IsProductAvailableForOrdering=@IsProductAvailableForOrdering,
	IsObsolete=@IsObsolete,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_Product_VariantID = @CMN_PRO_Product_VariantID