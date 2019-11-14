
	Select
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
	  log_rsv_reservations.IsReservationExecuted,
	  log_rsv_reservations.LOG_RSV_ReservationID,
    log_shp_shipment_positions.CMN_PRO_Product_RefID
	From
	  log_shp_shipment_positions Left Join
	  log_rsv_reservations On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
	    = log_rsv_reservations.LOG_SHP_Shipment_Position_RefID And
	    log_shp_shipment_positions.Tenant_RefID = log_rsv_reservations.Tenant_RefID
	Where
	  log_rsv_reservations.IsReservationExecuted = 0 And
	  log_shp_shipment_positions.Tenant_RefID = @TenantID And
	  log_shp_shipment_positions.CMN_PRO_Product_RefID = @ProductID
  