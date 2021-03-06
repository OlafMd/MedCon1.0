UPDATE 
	log_rcp_receipt_headers
SET 
	ReceiptHeaderITL=@ReceiptHeaderITL,
	IsCustomerReturnReceipt=@IsCustomerReturnReceipt,
	ExpectedDeliveryHeader_RefID=@ExpectedDeliveryHeader_RefID,
	ReceiptHeaderCurrency_RefID=@ReceiptHeaderCurrency_RefID,
	ReceiptNumber=@ReceiptNumber,
	ProvidingSupplier_RefID=@ProvidingSupplier_RefID,
	DeliveringBusinessParticipant_RefID=@DeliveringBusinessParticipant_RefID,
	WRH_Warehouse_RefID=@WRH_Warehouse_RefID,
	DeliverySlip_Number=@DeliverySlip_Number,
	DeliverySlip_Date=@DeliverySlip_Date,
	DeliverySlip_Document_RefID=@DeliverySlip_Document_RefID,
	IsQualityControlPerformed=@IsQualityControlPerformed,
	QualityControlPerformed_ByAccount_RefID=@QualityControlPerformed_ByAccount_RefID,
	QualityControlPerformed_AtDate=@QualityControlPerformed_AtDate,
	IsPriceConditionsManuallyCleared=@IsPriceConditionsManuallyCleared,
	PriceConditionsManuallyCleared_ByAccount_RefID=@PriceConditionsManuallyCleared_ByAccount_RefID,
	PriceConditionsManuallyCleared_AtDate=@PriceConditionsManuallyCleared_AtDate,
	IsTakenIntoStock=@IsTakenIntoStock,
	TakenIntoStock_ByAccount_RefID=@TakenIntoStock_ByAccount_RefID,
	TakenIntoStock_AtDate=@TakenIntoStock_AtDate,
	IsReceiptForwardedToBookkeeping=@IsReceiptForwardedToBookkeeping,
	ReceiptForwardedToBookkeeping_ByAccount_RefID=@ReceiptForwardedToBookkeeping_ByAccount_RefID,
	ReceiptForwardedToBookkeeping_AtDate=@ReceiptForwardedToBookkeeping_AtDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_Receipt_HeaderID = @LOG_RCP_Receipt_HeaderID