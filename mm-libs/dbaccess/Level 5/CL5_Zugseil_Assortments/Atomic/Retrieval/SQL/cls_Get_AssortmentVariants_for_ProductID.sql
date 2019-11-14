
	SELECT cmn_pro_product_variants.CMN_PRO_Product_VariantID
		,cmn_pro_product_variants.VariantName_DictID
    ,CMN_PRO_ASS_AssortmentVariants.CMN_PRO_ASS_AssortmentVariantID 
	FROM CMN_PRO_ASS_AssortmentVariants
	INNER JOIN cmn_pro_product_variants ON cmn_pro_product_variants.CMN_PRO_Product_VariantID = cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID
		AND cmn_pro_product_variants.CMN_PRO_Product_RefID = @ProductID
		AND cmn_pro_product_variants.IsDeleted = 0
		AND cmn_pro_product_variants.Tenant_RefID = @TenantID
    AND CMN_PRO_Product_Variants.IsStandardProductVariant = 0
	WHERE cmn_pro_product_variants.IsDeleted = 0
		AND cmn_pro_product_variants.Tenant_RefID = @TenantID
  