INSERT INTO 
	ord_prc_spb_supplierbill_headers
	(
		ORD_PRC_SPB_SupplierBill_HeaderID,
		Supplier_RefID,
		Currency_RefID,
		SupplierBillNumber,
		DateOnBill,
		TotalValue_BeforeTax,
		TotalValue_IncludingTax,
		BillComment,
		PaymentTargetDate,
		CashDiscountInPercent,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_SPB_SupplierBill_HeaderID,
		@Supplier_RefID,
		@Currency_RefID,
		@SupplierBillNumber,
		@DateOnBill,
		@TotalValue_BeforeTax,
		@TotalValue_IncludingTax,
		@BillComment,
		@PaymentTargetDate,
		@CashDiscountInPercent,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)