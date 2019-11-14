
Select
  log_shp_shipment_types.GlobalPropertyMatchingID,
  log_shp_shipment_types.LOG_SHP_Shipment_TypeID,
  log_shp_shipment_types.ShipmentType_Name_DictID,
  log_shp_shipment_types.ShipmentType_Description_DictID,
  log_shp_shipment_types.IsCustomerPickup,
  log_shp_shipment_types.IsPartialPickingPermitted,
  log_shp_shipment_types.IsFixedPricePerShipment,
  log_shp_shipment_types.IfFixedPricePerShipment_Price_RefID
From
  log_shp_shipment_types
Where
  log_shp_shipment_types.Tenant_RefID = @TenantID And
  log_shp_shipment_types.IsDeleted = 0
  