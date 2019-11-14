
	Select
	  cmn_pro_products.CMN_PRO_ProductID,
	  cmn_pro_products.Product_Name_DictID,
	  cmn_pro_products.Product_Description_DictID,
	  cmn_pro_products.Product_Number,
	  cmn_pro_products.Product_DocumentationStructure_RefID,
	  cmn_pro_product_variants.CMN_PRO_Product_VariantID,
	  cmn_pro_product_variants.IsStandardProductVariant,
	  cmn_pro_product_variants.ProductVariantITL,
	  cmn_pro_product_variants.IsImportedFromExternalCatalog,
	  cmn_pro_product_variants.IsProductAvailableForOrdering,
	  cmn_pro_product_variants.IsObsolete,
	  cmn_pro_product_variants.VariantName_DictID
	From
	  cmn_pro_products Join
	  cmn_pro_product_variants On cmn_pro_product_variants.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And
	     cmn_pro_products.IsProductForInternalDistributionOnly = 0 And
	       cmn_pro_product_variants.Tenant_RefID = @TenantID
	Where
	  cmn_pro_products.CMN_PRO_ProductID = @ProductIDs And
	  cmn_pro_product_variants.IsImportedFromExternalCatalog = 0 And
	  cmn_pro_products.IsDeleted = 0 And
	  cmn_pro_products.Tenant_RefID = @TenantID And
	  cmn_pro_products.IsImportedFromExternalCatalog = 0 
	 
  