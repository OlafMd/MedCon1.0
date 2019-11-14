UPDATE 
	ord_prc_supplierbill_2_procurementorderheader
SET 
	ORD_PRC_SPB_SupplierBill_Header_RefID=@ORD_PRC_SPB_SupplierBill_Header_RefID,
	ORD_PRC_ProcurementOrder_Header_RefID=@ORD_PRC_ProcurementOrder_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID