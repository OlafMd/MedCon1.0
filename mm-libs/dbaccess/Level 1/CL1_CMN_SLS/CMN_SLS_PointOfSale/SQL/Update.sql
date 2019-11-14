UPDATE 
	cmn_sls_pointofsales
SET 
	PointOfSaleITL=@PointOfSaleITL,
	PointOfSale_DisplayName=@PointOfSale_DisplayName,
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	IsPickUpStationForDistributionOrder=@IsPickUpStationForDistributionOrder,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_SLS_PointOfSaleID = @CMN_SLS_PointOfSaleID