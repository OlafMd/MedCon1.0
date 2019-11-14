
	SELECT cmn_pro_products.Product_Name_DictID
		,cmn_pro_products.Product_Number
	  ,cmn_pro_products.CMN_PRO_ProductID
	  ,cmn_price_values.PriceValue_Amount
    ,cmn_pro_products_de.Content
	FROM CMN_PRO_ASS_Assortment_2_AssortmentProduct
	INNER JOIN CMN_PRO_ASS_AssortmentProducts ON cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_Product_RefID = cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID
		AND CMN_PRO_ASS_AssortmentProducts.IsDeleted = 0
		AND CMN_PRO_ASS_AssortmentProducts.Tenant_RefID = @TenantID
	INNER JOIN cmn_pro_products ON cmn_pro_products.CMN_PRO_ProductID = cmn_pro_ass_assortmentproducts.Ext_CMN_PRO_Product_RefID
		AND cmn_pro_products.IsDeleted = 0
		AND cmn_pro_products.Tenant_RefID = @TenantID
	INNER JOIN cmn_pro_product_variants ON cmn_pro_product_variants.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
		AND cmn_pro_product_variants.IsDeleted = 0
		AND cmn_pro_product_variants.Tenant_RefID = @TenantID
		AND cmn_pro_product_variants.IsStandardProductVariant = 1
	INNER JOIN cmn_pro_ass_assortmentvariants ON cmn_pro_ass_assortmentvariants.Ext_CMN_PRO_Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID
		AND cmn_pro_ass_assortmentvariants.IsDeleted = 0
		AND cmn_pro_ass_assortmentvariants.Tenant_RefID = @TenantID
  LEFT JOIN cmn_pro_products_de ON cmn_pro_products.Product_Name_DictID = cmn_pro_products_de.DictID
	  AND cmn_pro_products_de.Language_RefID = @LanguageID
	  AND cmn_pro_products_de.IsDeleted = 0
	LEFT JOIN cmn_pro_ass_distributionprices ON cmn_pro_ass_distributionprices.CMN_PRO_ASS_DistributionPriceID = cmn_pro_ass_assortmentvariants.DistributionPrice_RefID
		AND cmn_pro_ass_distributionprices.IsDeleted = 0
		AND cmn_pro_ass_distributionprices.Tenant_RefID = @TenantID
	LEFT JOIN cmn_pro_ass_distributionprice_values ON cmn_pro_ass_distributionprice_values.DistributionPrice_RefID = cmn_pro_ass_distributionprices.CMN_PRO_ASS_DistributionPriceID
		AND cmn_pro_ass_distributionprice_values.IsDeleted = 0
		AND cmn_pro_ass_distributionprice_values.Tenant_RefID = @TenantID
	  AND (NOW() BETWEEN cmn_pro_ass_distributionprice_values.ValidFrom AND cmn_pro_ass_distributionprice_values.ValidThrough)
	LEFT JOIN cmn_prices ON cmn_prices.CMN_PriceID = cmn_pro_ass_distributionprice_values.CMN_Price_RefID
		AND cmn_prices.IsDeleted = 0
		AND cmn_prices.Tenant_RefID = @TenantID
	LEFT JOIN cmn_price_values ON cmn_price_values.Price_RefID = cmn_prices.CMN_PriceID
		AND cmn_price_values.IsDeleted = 0
    and cmn_price_values.PriceValue_Currency_RefID = @CurrencyID
		AND cmn_price_values.Tenant_RefID = @TenantID
	WHERE CMN_PRO_ASS_Assortment_2_AssortmentProduct.CMN_PRO_ASS_Assortment_RefID = @AssortmentID
		AND CMN_PRO_ASS_Assortment_2_AssortmentProduct.IsDeleted = 0
		AND CMN_PRO_ASS_Assortment_2_AssortmentProduct.Tenant_RefID = @TenantID
    AND (
		@SearchCriteria IS NULL
		OR UPPER(cmn_pro_products_de.Content) LIKE CONCAT('%', UPPER(@SearchCriteria), '%')
		OR UPPER(cmn_pro_products.Product_Number) LIKE CONCAT('%', UPPER(@SearchCriteria), '%')
		)
		 GROUP BY cmn_pro_products.CMN_PRO_ProductID
ORDER BY cmn_pro_products_de.Content LIMIT @PageSize OFFSET @ActivePage



  