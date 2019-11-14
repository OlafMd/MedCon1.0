UPDATE 
	cmn_pro_distributioncenters
SET 
	LOG_REG_DistributionArea_RefID=@LOG_REG_DistributionArea_RefID,
	Warehouse_RefID=@Warehouse_RefID,
	Product_RefID=@Product_RefID,
	ProductVariant_RefID=@ProductVariant_RefID,
	ProductRelease_RefID=@ProductRelease_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_DistributionCenterID = @CMN_PRO_DistributionCenterID