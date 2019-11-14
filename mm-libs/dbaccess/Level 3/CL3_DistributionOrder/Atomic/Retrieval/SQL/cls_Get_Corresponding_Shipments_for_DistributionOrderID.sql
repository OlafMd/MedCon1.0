
   
Select Distinct
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID As ShipmentHeaderID,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.ShipmentHeader_Number,
  log_shp_shipment_headers.IsShipped,
  log_shp_shipment_headers.IsPartiallyReadyForPicking,
  log_shp_shipment_headers.IsReadyForPicking,
  log_shp_shipment_headers.HasPickingStarted,
  log_shp_shipment_headers.HasPickingFinished,
  log_wrh_warehouses.Warehouse_Name,
  (Select
    log_shp_shipment_statuses.GlobalPropertyMatchingID
  From
    log_shp_shipment_headers Left Join
    log_shp_shipment_statushistory
      On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
      log_shp_shipment_statushistory.LOG_SHP_Shipment_Header_RefID Left Join
    log_shp_shipment_statuses
      On log_shp_shipment_statushistory.LOG_SHP_Shipment_Status_RefID =
      log_shp_shipment_statuses.LOG_SHP_Shipment_StatusID
  Where
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    ShipmentHeaderID And
    log_shp_shipment_statuses.IsDeleted = 0
  Order By
    log_shp_shipment_statuses.Creation_Timestamp Desc
  Limit 1) As ShipmentStatus
From
  log_shp_shipment_positions Left Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Left Join
  log_wrh_warehouses On log_shp_shipment_headers.Source_Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID Left Join
  ord_dis_distributionorderposition_2_shipmentorderposition
    On
    ord_dis_distributionorderposition_2_shipmentorderposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Left Join
  ord_dis_distributionorder_positions
    On ord_dis_distributionorder_positions.ORD_DIS_DistributionOrder_PositionID
    =
    ord_dis_distributionorderposition_2_shipmentorderposition.ORD_DIS_DistributionOrder_Position_RefID
Where
  ord_dis_distributionorder_positions.Tenant_RefID = @TenantID And
  ord_dis_distributionorder_positions.DistributionOrder_Header_RefID =
  @DistributionOrderID
Group By
  ShipmentHeaderID
    
    
