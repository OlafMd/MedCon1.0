UPDATE 
	bil_billposition_2_shipmentposition
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID