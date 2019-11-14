UPDATE 
	log_rcp_receiptheader_2_procurementorderheader
SET 
	LOG_RCP_Receipt_Header_RefID=@LOG_RCP_Receipt_Header_RefID,
	ORD_PRO_ProcurementOrder_Header_RefID=@ORD_PRO_ProcurementOrder_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID