
  Select
    ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
    ord_cuo_customerorder_positions.Position_Quantity As CustomerOrderQuantity,
    ord_cuo_position_customerorganizationalunitdistribution.Quantity As
    OranizationalUnitQuantity,
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
    log_shp_shipment_positions.QuantityToShip As ShipmentQuantity,
    log_shp_shipment_headers.IsShipped,
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID
  From
    log_shp_shipment_positions Inner Join
    ord_cuo_customerorder_position_2_shipmentposition
      On
      ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID And log_shp_shipment_positions.IsDeleted = 0 And log_shp_shipment_positions.Tenant_RefID = @TenantID And ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 And ord_cuo_customerorder_position_2_shipmentposition.Tenant_RefID = @TenantID Inner Join
    ord_cuo_customerorder_positions
      On
      ord_cuo_customerorder_position_2_shipmentposition.ORD_CUO_CustomerOrder_Position_RefID = ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID And ord_cuo_customerorder_positions.CustomerOrder_Header_RefID = @CustomerOrderID And ord_cuo_customerorder_positions.IsDeleted = 0 Inner Join
    ord_cuo_position_customerorganizationalunitdistribution
      On ord_cuo_customerorder_position_2_shipmentposition.IsDeleted =
      ord_cuo_position_customerorganizationalunitdistribution.CMN_BPT_CTM_OrganizationalUnit_RefID And ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID = ord_cuo_position_customerorganizationalunitdistribution.ORD_CUO_CustomerOrder_Position_RefID And ord_cuo_position_customerorganizationalunitdistribution.CMN_BPT_CTM_OrganizationalUnit_RefID = @OrganizationalUnitID And ord_cuo_position_customerorganizationalunitdistribution.IsDeleted = 0 Inner Join
    log_shp_shipment_headers
      On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
      log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
      log_shp_shipment_headers.Tenant_RefID = @TenantID
  