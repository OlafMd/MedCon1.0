
	Select
	  ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
	From
	  ord_cuo_customerorder_positions Left Join
	  ord_cuo_customerorder_position_2_shipmentposition
	    On
	    ord_cuo_customerorder_position_2_shipmentposition.ORD_CUO_CustomerOrder_Position_RefID = ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID Left Join
	  log_shp_shipment_positions
	    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
	    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID
	Where
	  ord_cuo_customerorder_positions.Tenant_RefID = @TenantID And
	  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID = @ShipmentPositionID
	  And
	  ord_cuo_customerorder_positions.IsDeleted = 0
  