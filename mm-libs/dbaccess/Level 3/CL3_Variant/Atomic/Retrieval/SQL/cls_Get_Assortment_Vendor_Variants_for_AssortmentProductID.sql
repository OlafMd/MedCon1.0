
	SELECT cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_ASS_AssortmentVariant_VendorVariantID,
	       cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID,
	       cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_Product_Variant_RefID
	FROM cmn_pro_ass_assortmentvariants
	INNER JOIN cmn_pro_product_variants ON cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID
	AND cmn_pro_product_variants.Tenant_RefID = @TenantID
	AND cmn_pro_product_variants.IsDeleted = 0
	INNER JOIN cmn_pro_ass_assortmentvariant_vendorvariants ON cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID = cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_ASS_AssortmentVariant_RefID
	AND cmn_pro_ass_assortmentvariant_vendorvariants.Tenant_RefID = @TenantID
	AND cmn_pro_ass_assortmentvariant_vendorvariants.IsDeleted = 0
	WHERE cmn_pro_product_variants.CMN_PRO_Product_RefID = @ProductID
	  AND cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID
	  AND cmn_pro_ass_assortmentvariants.IsDeleted = 0
  