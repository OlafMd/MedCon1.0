
  Select
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID,
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
    log_shp_shipment_positions.CMN_PRO_Product_RefID,
    log_shp_shipment_positions.TrackingInstance_ToShip_RefID,
    log_shp_shipment_positions.QuantityToShip,
    log_shp_shipment_positions.ShipmentPositionITL,
    log_shp_shipment_positions.ShipmentPosition_ValueWithoutTax,
    log_shp_shipment_positions.ShipmentPosition_PricePerUnitValueWithoutTax
  From
    log_shp_shipment_positions
  Where
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    IfNull(@ShipmentHeaderID,
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID) And
    log_shp_shipment_positions.Tenant_RefID = @TenantID And
    log_shp_shipment_positions.IsDeleted = 0
  