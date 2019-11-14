
	Select
	  log_shp_shipment_positions.CMN_PRO_Product_RefID,
	  Sum(log_shp_shipment_positions.QuantityToShip) as  QuantityToShip
	From
	  log_shp_shipment_positions Inner Join
	  log_shp_shipment_headers On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID
	    = log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
	Where
	  log_shp_shipment_positions.IsDeleted = 0 And
	  log_shp_shipment_headers.IsShipped = 0 And
	  log_shp_shipment_headers.IsDeleted = 0 And
	  log_shp_shipment_headers.HasPickingFinished = 0 And
  log_shp_shipment_headers.IsCustomerReturnShipment = 0 And
	  log_shp_shipment_headers.Tenant_RefID = @TenantID
	Group By
	  log_shp_shipment_positions.CMN_PRO_Product_RefID
  