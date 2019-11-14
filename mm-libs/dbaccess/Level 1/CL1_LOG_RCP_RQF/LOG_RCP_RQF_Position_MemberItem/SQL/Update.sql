UPDATE 
	log_rcp_rqf_position_memberitems
SET 
	RequestQuantityForwarding_Position_RefID=@RequestQuantityForwarding_Position_RefID,
	Quantity=@Quantity,
	BatchNumber=@BatchNumber,
	SerialKey=@SerialKey,
	ExpiryDate=@ExpiryDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RCP_RQF_Position_MemberItemID = @LOG_RCP_RQF_Position_MemberItemID