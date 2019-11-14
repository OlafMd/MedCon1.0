UPDATE 
	ord_prc_extrademandproducts
SET 
	Supplier_RefID=@Supplier_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	RequestedQuantity=@RequestedQuantity,
	IsProcurementRunning=@IsProcurementRunning,
	ProcurementOrderPosition_RefID=@ProcurementOrderPosition_RefID,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	CreatedFor_Office_RefID=@CreatedFor_Office_RefID,
	DeliveryTo_Warehouse_RefID=@DeliveryTo_Warehouse_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ExtraDemandProductID = @ORD_PRC_ExtraDemandProductID