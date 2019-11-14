
	SELECT COUNT(cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID) as NumberOfNotBoundedVariants
	FROM cmn_pro_ass_assortmentvariants
	INNER JOIN cmn_pro_product_variants ON cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID
	AND cmn_pro_product_variants.Tenant_RefID = @TenantID
	AND cmn_pro_product_variants.IsDeleted = 0
	AND cmn_pro_product_variants.CMN_PRO_Product_RefID=@ProductID
	WHERE NOT EXISTS
	    ( SELECT cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_ASS_AssortmentVariant_VendorVariantID
	     FROM cmn_pro_ass_assortmentvariant_vendorvariants
	     WHERE cmn_pro_ass_assortmentvariant_vendorvariants.CMN_PRO_ASS_AssortmentVariant_RefID=cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID
	       AND cmn_pro_ass_assortmentvariant_vendorvariants.Tenant_RefID = @TenantID
	       AND cmn_pro_ass_assortmentvariant_vendorvariants.IsDeleted = 0)
	  AND cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID
	  AND cmn_pro_ass_assortmentvariants.IsDeleted = 0
  