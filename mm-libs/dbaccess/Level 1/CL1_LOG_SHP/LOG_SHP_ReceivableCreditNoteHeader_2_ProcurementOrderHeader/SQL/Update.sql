UPDATE 
	log_shp_receivablecreditnoteheader_2_procurementorderheader
SET 
	ReceivableCreditNote_Header_RefID=@ReceivableCreditNote_Header_RefID,
	ProcurementOrder_Header_RefID=@ProcurementOrder_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID