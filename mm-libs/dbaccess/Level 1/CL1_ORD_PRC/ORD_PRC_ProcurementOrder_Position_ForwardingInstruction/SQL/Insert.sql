INSERT INTO 
	ord_prc_procurementorder_position_forwardinginstructions
	(
		ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID,
		ProcurementOrder_Position_RefID,
		QuantityToForward,
		ForwardTo_BusinessParticipant_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID,
		@ProcurementOrder_Position_RefID,
		@QuantityToForward,
		@ForwardTo_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)