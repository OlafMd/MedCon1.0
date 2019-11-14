INSERT INTO 
	ord_prc_expecteddelivery_positions
	(
		ORD_PRC_ExpectedDelivery_PositionID,
		ExpectedDeliveryPositionITL,
		ORD_PRC_ExpectedDelivery_RefID,
		TotalExpectedQuantity,
		AlreadyReceivedQuantityOfDelivery,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_ExpectedDelivery_PositionID,
		@ExpectedDeliveryPositionITL,
		@ORD_PRC_ExpectedDelivery_RefID,
		@TotalExpectedQuantity,
		@AlreadyReceivedQuantityOfDelivery,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)