UPDATE 
	ord_prc_expecteddelivery_headers
SET 
	ExpectedDeliveryHeaderITL=@ExpectedDeliveryHeaderITL,
	ExpectedDeliveryDate=@ExpectedDeliveryDate,
	ExpectedDeliveryNumber=@ExpectedDeliveryNumber,
	LOG_WRH_Warehouse_RefID=@LOG_WRH_Warehouse_RefID,
	IsDeliveryOpen=@IsDeliveryOpen,
	IsDeliveryClosed=@IsDeliveryClosed,
	IsDeliveryManuallyCreated=@IsDeliveryManuallyCreated,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ExpectedDelivery_HeaderID = @ORD_PRC_ExpectedDelivery_HeaderID