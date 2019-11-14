
Select
  Sum(log_rsv_reservations.ReservedQuantity) Reserved_Quantity,
  log_wrh_shelf_contents.Quantity_Current,
  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.IsCustomerReturnShipment
From
  log_producttrackinginstances Inner Join
  log_wrh_shelfcontent_2_trackinginstance
    On log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
    = log_producttrackinginstances.LOG_ProductTrackingInstanceID And
    log_wrh_shelfcontent_2_trackinginstance.IsDeleted = 0 And
    log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID Inner Join
  log_wrh_shelf_contents On log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID =
    log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID And
    log_wrh_shelf_contents.IsDeleted = 0 And log_wrh_shelf_contents.Tenant_RefID
    = @TenantID Left Join
  log_rsv_reservations On log_rsv_reservations.LOG_WRH_Shelf_Content_RefID =
    log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID And
    log_rsv_reservations.IsDeleted = 0 And log_rsv_reservations.Tenant_RefID =
    @TenantID And log_rsv_reservations.IsReservationExecuted = 0 Inner Join
  log_shp_shipment_positions
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    log_rsv_reservations.LOG_SHP_Shipment_Position_RefID Inner Join
  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
Where
  log_producttrackinginstances.IsDeleted = 0 And
  log_producttrackinginstances.Tenant_RefID = @TenantID And
  log_producttrackinginstances.CMN_PRO_Product_RefID = @ProductID And
  log_shp_shipment_headers.HasPickingStarted = 1 And
  log_shp_shipment_headers.IsCustomerReturnShipment = 0
Group By
  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.IsCustomerReturnShipment
  