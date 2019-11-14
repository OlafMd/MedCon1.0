UPDATE 
	ord_prc_spb_supplierbill_headers
SET 
	Supplier_RefID=@Supplier_RefID,
	Currency_RefID=@Currency_RefID,
	SupplierBillNumber=@SupplierBillNumber,
	DateOnBill=@DateOnBill,
	TotalValue_BeforeTax=@TotalValue_BeforeTax,
	TotalValue_IncludingTax=@TotalValue_IncludingTax,
	BillComment=@BillComment,
	PaymentTargetDate=@PaymentTargetDate,
	CashDiscountInPercent=@CashDiscountInPercent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_SPB_SupplierBill_HeaderID = @ORD_PRC_SPB_SupplierBill_HeaderID