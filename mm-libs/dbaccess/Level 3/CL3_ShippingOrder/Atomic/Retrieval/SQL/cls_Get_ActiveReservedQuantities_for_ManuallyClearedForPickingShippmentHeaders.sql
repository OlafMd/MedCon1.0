
Select
  Sum(log_rsv_reservation_trackinginstances.ReservedQuantityFromTrackingInstance) As ReservedQuantityFromTrackingInstance,
  log_rsv_reservation_trackinginstances.LOG_ProductTrackingInstance_RefID
From
  log_rsv_reservations Inner Join
  log_shp_shipment_positions
    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
    log_rsv_reservations.LOG_SHP_Shipment_Position_RefID Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Inner Join
  log_rsv_reservation_trackinginstances
    On log_rsv_reservation_trackinginstances.LOG_RSV_Reservation_RefID =
    log_rsv_reservations.LOG_RSV_ReservationID
Where
  log_rsv_reservations.IsDeleted = 0 And
  log_shp_shipment_positions.IsDeleted = 0 And
  log_shp_shipment_headers.IsDeleted = 0 And
  log_rsv_reservations.IsReservationExecuted = 0 And
  log_shp_shipment_positions.IsCancelled = 0 And
  log_shp_shipment_headers.IsManuallyCleared_ForPicking = 1 And
  log_rsv_reservation_trackinginstances.IsDeleted = 0 And
  log_rsv_reservation_trackinginstances.LOG_ProductTrackingInstance_RefID = @ProductTrackingInstanceList
Group By
  log_rsv_reservation_trackinginstances.LOG_ProductTrackingInstance_RefID
  