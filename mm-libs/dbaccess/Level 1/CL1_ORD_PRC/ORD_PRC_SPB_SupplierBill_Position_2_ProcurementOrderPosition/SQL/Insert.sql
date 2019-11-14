INSERT INTO 
	ord_prc_spb_supplierbill_position_2_procurementorderposition
	(
		AssignmentID,
		ORD_PRC_SPB_SupplierBill_Position_RefID,
		ORD_PRC_ProcurementOrder_Position_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ORD_PRC_SPB_SupplierBill_Position_RefID,
		@ORD_PRC_ProcurementOrder_Position_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)