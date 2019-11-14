INSERT INTO 
	log_shp_shipmentheader_2_customerorderheader
	(
		AssignmentID,
		LOG_SHP_Shipment_Header_RefID,
		ORD_CUO_CustomerOrder_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@LOG_SHP_Shipment_Header_RefID,
		@ORD_CUO_CustomerOrder_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)