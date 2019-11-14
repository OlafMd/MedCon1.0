UPDATE 
	log_rcp_rqf_position_memberitems_2_shipmentposition
SET 
	LOG_RCP_RQF_Position_MemberItem_RefID=@LOG_RCP_RQF_Position_MemberItem_RefID,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID