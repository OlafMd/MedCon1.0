UPDATE 
	ord_prc_expecteddelivery_positions
SET 
	ExpectedDeliveryPositionITL=@ExpectedDeliveryPositionITL,
	ORD_PRC_ExpectedDelivery_RefID=@ORD_PRC_ExpectedDelivery_RefID,
	TotalExpectedQuantity=@TotalExpectedQuantity,
	AlreadyReceivedQuantityOfDelivery=@AlreadyReceivedQuantityOfDelivery,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ExpectedDelivery_PositionID = @ORD_PRC_ExpectedDelivery_PositionID