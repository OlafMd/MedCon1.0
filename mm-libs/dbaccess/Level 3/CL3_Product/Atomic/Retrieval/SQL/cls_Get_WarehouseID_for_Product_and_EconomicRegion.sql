
	SELECT cmn_pro_distributioncenters.Warehouse_RefID
	FROM cmn_pro_distributioncenters
	WHERE cmn_pro_distributioncenters.IsDeleted = 0
		AND cmn_pro_distributioncenters.Product_RefID = @ProductID
		AND cmn_pro_distributioncenters.EconomicRegion_RefID = @EconomicRegionID
		AND cmn_pro_distributioncenters.Tenant_RefID = @TenantID
  