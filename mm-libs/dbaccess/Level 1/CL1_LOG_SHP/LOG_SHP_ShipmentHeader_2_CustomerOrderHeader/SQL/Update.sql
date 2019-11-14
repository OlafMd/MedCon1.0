UPDATE 
	log_shp_shipmentheader_2_customerorderheader
SET 
	LOG_SHP_Shipment_Header_RefID=@LOG_SHP_Shipment_Header_RefID,
	ORD_CUO_CustomerOrder_Header_RefID=@ORD_CUO_CustomerOrder_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID