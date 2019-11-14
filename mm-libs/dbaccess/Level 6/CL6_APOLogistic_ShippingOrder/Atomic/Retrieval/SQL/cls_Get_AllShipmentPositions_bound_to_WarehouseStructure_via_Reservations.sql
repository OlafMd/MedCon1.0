
Select
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID,
  log_shp_shipment_positions.CMN_PRO_Product_RefID,
  log_shp_shipment_positions.CMN_PRO_ProductVariant_RefID,
  log_shp_shipment_positions.CMN_PRO_ProductRelease_RefID,
  log_shp_shipment_positions.TrackingInstance_ToShip_RefID,
  log_shp_shipment_positions.QuantityToShip,
  log_rsv_reservations.LOG_RSV_ReservationID,
  log_rsv_reservations.ReservedQuantity,
  log_rsv_reservations.IsReservationExpirable,
  log_rsv_reservations.ReservationExpiryDate,
  log_rsv_reservations.IsReservationExecuted,
  log_wrh_shelf_contents.Quantity_Current As ShelfContent_Quantity_Current,
  log_wrh_shelf_contents.Quantity_Initial As ShelfContent_Quantity_Initial,
  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
  log_wrh_shelves.LOG_WRH_ShelfID,
  log_wrh_shelves.CoordinateCode As Shelf_CoordinateCode,
  log_wrh_shelves.CoordinateX As Shelf_CoordinateX,
  log_wrh_shelves.CoordinateY As Shelf_CoordinateY,
  log_wrh_shelves.CoordinateZ As Shelf_CoordinateZ,
  log_wrh_shelves.Shelf_Name,
  log_wrh_racks.LOG_WRH_RackID,
  log_wrh_racks.CoordinateCode As Rack_CoordinateCode,
  log_wrh_racks.Shelves_XLabel As Rack_Shelves_XLabel,
  log_wrh_racks.Shelves_YLabel As Rack_Shelves_YLabel,
  log_wrh_racks.Shelves_ZLabel As Rack_Shelves_ZLabel,
  log_wrh_racks.Rack_Name,
  log_wrh_racks.Shelf_NamePrefix As Rack_Shelf_NamePrefix,
  log_wrh_areas.LOG_WRH_AreaID,
  log_wrh_areas.CoordinateCode As Area_CoordinateCode,
  log_wrh_areas.Area_Name,
  log_wrh_areas.Rack_NamePrefix As Area_Rack_NamePrefix,
  log_wrh_warehouses.LOG_WRH_WarehouseID,
  log_wrh_warehouses.CoordinateCode As Warehouse_CoordinateCode,
  log_wrh_warehouses.Warehouse_Name,
  log_producttrackinginstances.LOG_ProductTrackingInstanceID,
  log_producttrackinginstances.SerialNumber,
  log_producttrackinginstances.BatchNumber,
  log_producttrackinginstances.ExpirationDate,
  log_rsv_reservation_trackinginstances.ReservedQuantityFromTrackingInstance
From
  log_shp_shipment_positions Inner Join
  log_rsv_reservations On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
    = log_rsv_reservations.LOG_SHP_Shipment_Position_RefID And
    log_rsv_reservations.IsDeleted = 0 And log_rsv_reservations.Tenant_RefID =
    @TenantID Left Join
  log_wrh_shelf_contents On log_rsv_reservations.LOG_WRH_Shelf_Content_RefID =
    log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID And
    log_wrh_shelf_contents.IsDeleted = 0 And log_wrh_shelf_contents.Tenant_RefID
    = @TenantID Left Join
  log_wrh_shelves On log_wrh_shelf_contents.Shelf_RefID =
    log_wrh_shelves.LOG_WRH_ShelfID And log_wrh_shelves.IsDeleted = 0 And
    log_wrh_shelves.Tenant_RefID = @TenantID Left Join
  log_wrh_racks On log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID And
    log_wrh_racks.IsDeleted = 0 And log_wrh_racks.Tenant_RefID = @TenantID
  Left Join
  log_wrh_areas On log_wrh_shelves.R_Area_RefID = log_wrh_areas.LOG_WRH_AreaID
    And log_wrh_areas.IsDeleted = 0 And log_wrh_areas.Tenant_RefID = @TenantID
  Left Join
  log_wrh_warehouses On log_wrh_shelves.R_Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID And log_wrh_warehouses.IsDeleted = 0
    And log_wrh_warehouses.Tenant_RefID = @TenantID Left Join
  log_rsv_reservation_trackinginstances
    On log_rsv_reservations.LOG_RSV_ReservationID =
    log_rsv_reservation_trackinginstances.LOG_RSV_Reservation_RefID And
    log_rsv_reservation_trackinginstances.IsDeleted = 0 And
    log_rsv_reservation_trackinginstances.Tenant_RefID = @TenantID Left Join
  log_producttrackinginstances
    On log_rsv_reservation_trackinginstances.LOG_ProductTrackingInstance_RefID =
    log_producttrackinginstances.LOG_ProductTrackingInstanceID And
    log_producttrackinginstances.IsDeleted = 0 And
    log_producttrackinginstances.Tenant_RefID = @TenantID
Where
  log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderID
  And
  log_shp_shipment_positions.Tenant_RefID = @TenantID And
  log_shp_shipment_positions.IsDeleted = 0
	