INSERT INTO 
	cmn_sls_pointofsales
	(
		CMN_SLS_PointOfSaleID,
		PointOfSaleITL,
		PointOfSale_DisplayName,
		CMN_STR_Office_RefID,
		IsPickUpStationForDistributionOrder,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_SLS_PointOfSaleID,
		@PointOfSaleITL,
		@PointOfSale_DisplayName,
		@CMN_STR_Office_RefID,
		@IsPickUpStationForDistributionOrder,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)