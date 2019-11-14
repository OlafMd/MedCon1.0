UPDATE 
	ord_prc_spb_supplierbill_positions
SET 
	SupplierBill_Header_RefID=@SupplierBill_Header_RefID,
	PositionNumber=@PositionNumber,
	BillPosition_Comment=@BillPosition_Comment,
	PositionIndex=@PositionIndex,
	PositionValue_BeforeTax=@PositionValue_BeforeTax,
	PositionValue_IncludingTax=@PositionValue_IncludingTax,
	BillPosition_ProductNumber=@BillPosition_ProductNumber,
	Quantity=@Quantity,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_SPB_SupplierBill_PositionID = @ORD_PRC_SPB_SupplierBill_PositionID