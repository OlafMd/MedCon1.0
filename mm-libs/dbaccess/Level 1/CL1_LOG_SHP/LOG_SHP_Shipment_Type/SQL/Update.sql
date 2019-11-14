UPDATE 
	log_shp_shipment_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ShipmentType_Name_DictID=@ShipmentType_Name,
	ShipmentType_Description_DictID=@ShipmentType_Description,
	IsCustomerPickup=@IsCustomerPickup,
	IsPartialPickingPermitted=@IsPartialPickingPermitted,
	IsFixedPricePerShipment=@IsFixedPricePerShipment,
	IfFixedPricePerShipment_Price_RefID=@IfFixedPricePerShipment_Price_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_SHP_Shipment_TypeID = @LOG_SHP_Shipment_TypeID