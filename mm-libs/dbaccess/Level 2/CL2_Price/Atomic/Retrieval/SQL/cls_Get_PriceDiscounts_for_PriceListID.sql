
	SELECT
	  cmn_sls_pricelist_discounts.CMN_SLS_Pricelist_DiscountID,
	  cmn_sls_pricelist.CMN_SLS_PricelistID,
    cmn_sls_pricelist.Pricelist_Name_DictID,
    cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID,
    cmn_sls_pricelist_releases.Release_Version,
	  cmn_sls_pricelist_discounts.Product_RefID,
	  cmn_sls_pricelist_discounts.Product_Variant_RefID,
	  cmn_sls_pricelist_discounts.Product_Release_RefID,
	  cmn_sls_pricelist_discounts.DiscountPercentAmount,
	  cmn_sls_pricelist_discounts.DiscountValid_From,
	  cmn_sls_pricelist_discounts.DiscountValid_To,
    cmn_sls_pricelist_discounts.IsDeleted
	FROM
	  cmn_sls_pricelist_discounts
	  INNER JOIN cmn_sls_pricelist_releases
	    ON cmn_sls_pricelist_discounts.PricelistVersion_RefID = cmn_sls_pricelist_releases.CMN_SLS_Pricelist_ReleaseID
	       AND cmn_sls_pricelist_releases.IsDeleted = 0
	  INNER JOIN cmn_sls_pricelist
	    ON cmn_sls_pricelist_releases.Pricelist_RefID = cmn_sls_pricelist.CMN_SLS_PricelistID
	       AND cmn_sls_pricelist.IsDeleted = 0
	 WHERE
	  cmn_sls_pricelist_discounts.IsDeleted = 0
	  AND cmn_sls_pricelist_discounts.Tenant_RefID = @TenantID
	  AND cmn_sls_pricelist.CMN_SLS_PricelistID = IFNULL(@PriceListID, cmn_sls_pricelist.CMN_SLS_PricelistID)
  