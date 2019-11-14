UPDATE 
	cmn_pro_variant_dimensionvalues
SET 
	ProductVariant_RefID=@ProductVariant_RefID,
	DimensionValue_RefID=@DimensionValue_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_Variant_DimensionValueID = @CMN_PRO_Variant_DimensionValueID