INSERT INTO 
	ord_prc_spb_supplierbill_positions
	(
		ORD_PRC_SPB_SupplierBill_PositionID,
		SupplierBill_Header_RefID,
		PositionNumber,
		BillPosition_Comment,
		PositionIndex,
		PositionValue_BeforeTax,
		PositionValue_IncludingTax,
		BillPosition_ProductNumber,
		Quantity,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_SPB_SupplierBill_PositionID,
		@SupplierBill_Header_RefID,
		@PositionNumber,
		@BillPosition_Comment,
		@PositionIndex,
		@PositionValue_BeforeTax,
		@PositionValue_IncludingTax,
		@BillPosition_ProductNumber,
		@Quantity,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)