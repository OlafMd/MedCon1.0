INSERT INTO 
	log_shp_receivablecreditnoteheader_2_procurementorderheader
	(
		AssignmentID,
		ReceivableCreditNote_Header_RefID,
		ProcurementOrder_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ReceivableCreditNote_Header_RefID,
		@ProcurementOrder_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)