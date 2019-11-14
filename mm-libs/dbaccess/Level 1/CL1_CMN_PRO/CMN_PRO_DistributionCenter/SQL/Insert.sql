INSERT INTO 
	cmn_pro_distributioncenters
	(
		CMN_PRO_DistributionCenterID,
		LOG_REG_DistributionArea_RefID,
		Warehouse_RefID,
		Product_RefID,
		ProductVariant_RefID,
		ProductRelease_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_DistributionCenterID,
		@LOG_REG_DistributionArea_RefID,
		@Warehouse_RefID,
		@Product_RefID,
		@ProductVariant_RefID,
		@ProductRelease_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)