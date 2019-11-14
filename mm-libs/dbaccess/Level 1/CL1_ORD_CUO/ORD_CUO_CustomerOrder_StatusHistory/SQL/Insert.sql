INSERT INTO 
	ord_cuo_customerorder_statushistory
	(
		ORD_CUO_CustomerOrder_StatusHistoryID,
		CustomerOrder_Header_RefID,
		CustomerOrder_Status_RefID,
		StatusHistoryComment,
		PerformedBy_BusinessParticipant_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_CUO_CustomerOrder_StatusHistoryID,
		@CustomerOrder_Header_RefID,
		@CustomerOrder_Status_RefID,
		@StatusHistoryComment,
		@PerformedBy_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)