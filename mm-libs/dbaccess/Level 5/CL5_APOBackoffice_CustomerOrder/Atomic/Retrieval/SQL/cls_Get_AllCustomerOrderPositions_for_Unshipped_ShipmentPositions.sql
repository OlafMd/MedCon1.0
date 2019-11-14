
Select
  ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
  ord_cuo_customerorder_positions.CustomerOrder_Header_RefID,
  ord_cuo_customerorder_positions.CMN_PRO_Product_RefID,
  ord_cuo_customerorder_positions.Position_Quantity,
  ord_cuo_customerorder_positions.Position_ValuePerUnit,
  ord_cuo_customerorder_positions.Position_ValueTotal
From
  ord_cuo_customerorder_positions Right Join
  ord_cuo_customerorder_headers
    On ord_cuo_customerorder_positions.CustomerOrder_Header_RefID =
    ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID And
    ord_cuo_customerorder_headers.IsDeleted = 0 And
    ord_cuo_customerorder_headers.Tenant_RefID = @TenantID Right Join
  log_shp_shipmentheader_2_customerorderheader
    On
    log_shp_shipmentheader_2_customerorderheader.ORD_CUO_CustomerOrder_Header_RefID = ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID And ord_cuo_customerorder_headers.IsDeleted = 0 And ord_cuo_customerorder_headers.Tenant_RefID = @TenantID Left Join
  ord_cuo_customerorder_position_2_shipmentposition
    On ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID =
    ord_cuo_customerorder_position_2_shipmentposition.ORD_CUO_CustomerOrder_Position_RefID And ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 And ord_cuo_customerorder_position_2_shipmentposition.Tenant_RefID = @TenantID Left Join
  log_shp_shipment_positions
    On
    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID And log_shp_shipment_positions.IsDeleted = 0 And log_shp_shipment_positions.Tenant_RefID = @TenantID Left Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID And
    log_shp_shipment_headers.IsDeleted = 0 And
    log_shp_shipment_headers.Tenant_RefID = @TenantID Left Join
  ord_cuo_position_customerorganizationalunitdistribution
    On ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID =
    ord_cuo_position_customerorganizationalunitdistribution.ORD_CUO_CustomerOrder_Position_RefID And ord_cuo_position_customerorganizationalunitdistribution.IsDeleted = 0 And ord_cuo_position_customerorganizationalunitdistribution.Tenant_RefID = @TenantID
Where
  log_shp_shipmentheader_2_customerorderheader.IsDeleted = 0 And
  log_shp_shipmentheader_2_customerorderheader.Tenant_RefID = @TenantID And
  log_shp_shipmentheader_2_customerorderheader.LOG_SHP_Shipment_Header_RefID = @ShipmentHeaderID And
  log_shp_shipment_headers.IsShipped = 0 And
  ord_cuo_position_customerorganizationalunitdistribution.CMN_BPT_CTM_OrganizationalUnit_RefID = @OrganizationalUnitID
	