UPDATE 
	log_shp_shipment_statuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Status_Code=@Status_Code,
	Status_Name_DictID=@Status_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_Shipment_StatusID = @LOG_SHP_Shipment_StatusID