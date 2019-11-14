UPDATE 
	log_rcp_rqf_header_2_shipmentheader
SET 
	LOG_RCP_RQF_RequestQuantityForwarding_Header_RefID=@LOG_RCP_RQF_RequestQuantityForwarding_Header_RefID,
	LOG_SHP_Shipment_Header_RefID=@LOG_SHP_Shipment_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID