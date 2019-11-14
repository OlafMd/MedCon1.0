
	SELECT cmn_pro_product_variants.CMN_PRO_Product_VariantID AS BoundToVariantID
		,cmn_pro_product_variants.CMN_PRO_Product_RefID AS BoundToProductID
	FROM cmn_pro_ass_assortmentvariant_vendorvariants
	LEFT JOIN cmn_pro_product_variants ON cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID
		AND cmn_pro_product_variants.IsDeleted = 0
		AND cmn_pro_product_variants.Tenant_RefID = @TenantID
	WHERE cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_ASS_AssortmentVariant_RefID = @AssortmentVariantID
		AND cmn_pro_ass_assortmentvariant_vendorvariants.IsDeleted = 0
		AND cmn_pro_ass_assortmentvariant_vendorvariants.Tenant_RefID = @TenantID
  