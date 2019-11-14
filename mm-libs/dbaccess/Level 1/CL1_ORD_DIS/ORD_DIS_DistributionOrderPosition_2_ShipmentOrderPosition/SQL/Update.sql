UPDATE 
	ord_dis_distributionorderposition_2_shipmentorderposition
SET 
	ORD_DIS_DistributionOrder_Position_RefID=@ORD_DIS_DistributionOrder_Position_RefID,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	IsDistributionShipment=@IsDistributionShipment,
	IsReplenishmentShipment=@IsReplenishmentShipment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID