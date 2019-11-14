
   
Select
  log_shp_shipment_types.LOG_SHP_Shipment_TypeID,
  log_shp_shipment_types.ShipmentType_Name_DictID,
  log_shp_shipment_types.ShipmentType_Description_DictID
From
  log_shp_shipment_types
Where
  log_shp_shipment_types.IsDeleted = 0 And
  log_shp_shipment_types.Tenant_RefID = @TenantID
     
 