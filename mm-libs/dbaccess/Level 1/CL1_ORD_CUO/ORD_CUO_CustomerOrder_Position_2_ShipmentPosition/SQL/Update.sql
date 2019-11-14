UPDATE 
	ord_cuo_customerorder_position_2_shipmentposition
SET 
	ORD_CUO_CustomerOrder_Position_RefID=@ORD_CUO_CustomerOrder_Position_RefID,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	CMN_BPT_CTM_OrganizationalUnit_RefID=@CMN_BPT_CTM_OrganizationalUnit_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID