INSERT INTO 
	log_rcp_receiptposition_2_procurementorderposition
	(
		AssignmentID,
		LOG_RCP_Receipt_Position_RefID,
		ORD_PRO_ProcurementOrder_Position_RefID,
		ReceivedQuantityFromProcurementOrderPosition,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@LOG_RCP_Receipt_Position_RefID,
		@ORD_PRO_ProcurementOrder_Position_RefID,
		@ReceivedQuantityFromProcurementOrderPosition,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)