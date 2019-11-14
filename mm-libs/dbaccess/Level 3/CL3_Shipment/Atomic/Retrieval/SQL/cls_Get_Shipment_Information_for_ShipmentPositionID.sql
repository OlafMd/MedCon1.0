
   
Select
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_types_de.Content As ShipmentType,
  log_wrh_warehouses.Warehouse_Name,
  Concat_Ws(' ', cmn_addresses.Street_Name, cmn_addresses.Street_Number,
  cmn_addresses.City_Region, cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode, cmn_addresses.Country_Name,
  cmn_addresses.Province_Name) As Shipping_Address
From
  log_shp_shipment_positions Left Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_headers.IsDeleted = 0 Left Join
  log_shp_shipment_types On log_shp_shipment_headers.ShipmentType_RefID =
    log_shp_shipment_types.LOG_SHP_Shipment_TypeID Left Join
  log_wrh_warehouses On log_shp_shipment_headers.Source_Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID Left Join
  cmn_addresses On log_shp_shipment_headers.Shippipng_AddressUCD_RefID =
    cmn_addresses.CMN_AddressID Left Join
  log_shp_shipment_types_de On log_shp_shipment_types.ShipmentType_Name_DictID =
    log_shp_shipment_types_de.DictID And
    log_shp_shipment_types_de.Language_RefID = @LanguageID
Where
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = @ShipmentPositionID
  And
  log_shp_shipment_positions.IsDeleted = 0 And
  log_shp_shipment_positions.Tenant_RefID = @TenantID
    
    
