
		Select
	  cmn_pro_ass_distributionprices.CMN_PRO_ASS_DistributionPriceID,
	  cmn_pro_product_variants.IsStandardProductVariant,
	  cmn_pro_ass_assortmentvariants.CMN_PRO_ASS_AssortmentVariantID,
	  cmn_pro_products.CMN_PRO_ProductID,
     cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID,
	  cmn_pro_product_variants.VariantName_DictID
	From
	  cmn_pro_ass_assortmentproducts Join
	  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
	    cmn_pro_ass_assortmentproducts.Ext_CMN_PRO_Product_RefID And
	    cmn_pro_products.IsDeleted = 0 Join
	  cmn_pro_product_variants On cmn_pro_product_variants.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_product_variants.IsDeleted =
	    0 Join
	  cmn_pro_ass_assortmentvariants
	    On cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID =
	    cmn_pro_product_variants.CMN_PRO_Product_VariantID And
	    cmn_pro_ass_assortmentvariants.IsDeleted = 0 Join
	  cmn_pro_ass_distributionprices
	    On cmn_pro_ass_distributionprices.CMN_PRO_ASS_DistributionPriceID =
	    cmn_pro_ass_assortmentvariants.DistributionPrice_RefID And
	    cmn_pro_ass_distributionprices.IsDeleted = 0 
		           
		      WHERE
		      cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID =@ProductID
		       AND cmn_pro_ass_assortmentproducts.Tenant_RefID = @TenantID
		       AND cmn_pro_ass_assortmentproducts.IsDeleted = 0

  