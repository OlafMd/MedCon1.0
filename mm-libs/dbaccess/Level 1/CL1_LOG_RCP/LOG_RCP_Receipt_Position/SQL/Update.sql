UPDATE 
	log_rcp_receipt_positions
SET 
	ReceiptPositionITL=@ReceiptPositionITL,
	Receipt_Header_RefID=@Receipt_Header_RefID,
	TotalQuantityTakenIntoStock=@TotalQuantityTakenIntoStock,
	TotalQuantityFreeOfCharge=@TotalQuantityFreeOfCharge,
	ExpectedPositionPrice=@ExpectedPositionPrice,
	PriceOnSupplierBill=@PriceOnSupplierBill,
	ReceiptPosition_Product_RefID=@ReceiptPosition_Product_RefID,
	ReceiptPosition_ProductVariant_RefID=@ReceiptPosition_ProductVariant_RefID,
	ReceiptPosition_ProductRelease_RefID=@ReceiptPosition_ProductRelease_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_Receipt_PositionID = @LOG_RCP_Receipt_PositionID