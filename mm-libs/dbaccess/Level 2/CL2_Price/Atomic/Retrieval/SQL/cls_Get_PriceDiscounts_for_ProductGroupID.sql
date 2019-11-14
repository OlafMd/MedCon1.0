
	SELECT
	  cmn_sls_pricelist_discounts.CMN_SLS_Pricelist_DiscountID,
	  cmn_pro_productgroups.CMN_PRO_ProductGroupID,
    cmn_pro_productgroups.ProductGroup_Name_DictID,
	  cmn_sls_pricelist_discounts.Product_RefID,
	  cmn_sls_pricelist_discounts.Product_Variant_RefID,
	  cmn_sls_pricelist_discounts.Product_Release_RefID,
	  cmn_sls_pricelist_discounts.DiscountPercentAmount,
	  cmn_sls_pricelist_discounts.DiscountValid_From,
	  cmn_sls_pricelist_discounts.DiscountValid_To,
    cmn_sls_pricelist_discounts.IsDeleted
	FROM
	  cmn_sls_pricelist_discounts
	  INNER JOIN cmn_pro_productgroups 
	    ON cmn_sls_pricelist_discounts.ProductGroup_RefID = cmn_pro_productgroups.CMN_PRO_ProductGroupID
	    AND cmn_pro_productgroups.IsDeleted = 0
	 WHERE
	  cmn_sls_pricelist_discounts.IsDeleted = 0
	  AND cmn_sls_pricelist_discounts.Tenant_RefID = @TenantID
	  AND cmn_sls_pricelist_discounts.ProductGroup_RefID = IFNULL(@ProductGroupID, cmn_sls_pricelist_discounts.ProductGroup_RefID)
  