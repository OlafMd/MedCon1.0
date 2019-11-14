UPDATE 
	log_rcp_rqf_requestquantityforwarding_positions
SET 
	ReceivedQuantityForwarding_Header_RefID=@ReceivedQuantityForwarding_Header_RefID,
	TotalReceivedQuantity=@TotalReceivedQuantity,
	ExpectedQuantity=@ExpectedQuantity,
	CreatedFrom_PositionForwardingInstruction_RefID=@CreatedFrom_PositionForwardingInstruction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_RQF_RequestQuantityForwarding_PositionID = @LOG_RCP_RQF_RequestQuantityForwarding_PositionID