
Select
  log_rcp_receipt_position_qualitycontrolitems.LOG_RCP_Receipt_Position_QualityControlItem,
  log_rcp_receipt_position_qualitycontrolitems.Quantity,
  log_rcp_receipt_position_qualitycontrolitems.BatchNumber,
  log_rcp_receipt_position_qualitycontrolitems.ExpiryDate,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  cmn_pro_products.CMN_PRO_ProductID As ProductID,
  log_wrh_areas.CoordinateCode As CoordinateCodeArea,
  log_wrh_warehouses.CoordinateCode As CoordinateCodeWarehouse,
  log_wrh_racks.CoordinateCode As CoordinateCodeRack,
  log_wrh_shelves.CoordinateCode As CoordinateCodeShelf,
  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID,
  log_rcp_receipt_headers.ReceiptNumber,
  log_wrh_shelves.LOG_WRH_ShelfID
From
  log_rcp_receipt_headers Inner Join
  log_rcp_receipt_positions On log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID
    = log_rcp_receipt_positions.Receipt_Header_RefID And
    log_rcp_receipt_positions.Tenant_RefID = @TenantID And
    log_rcp_receipt_positions.IsDeleted = 0 Inner Join
  log_rcp_receiptposition_2_procurementorderposition
    On log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID =
    log_rcp_receiptposition_2_procurementorderposition.LOG_RCP_Receipt_Position_RefID And log_rcp_receiptposition_2_procurementorderposition.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_positions
    On
    log_rcp_receiptposition_2_procurementorderposition.ORD_PRO_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID Inner Join
  cmn_pro_products On ord_prc_procurementorder_positions.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And
    ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_positions.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID And cmn_pro_products.IsDeleted = 0
  Inner Join
  log_rcp_receipt_position_qualitycontrolitems
    On log_rcp_receipt_position_qualitycontrolitems.Receipt_Position_RefID =
    log_rcp_receipt_positions.LOG_RCP_Receipt_PositionID And
    log_rcp_receipt_position_qualitycontrolitems.Tenant_RefID = @TenantID And
    log_rcp_receipt_position_qualitycontrolitems.IsDeleted = 0 Left Join
  log_wrh_shelves
    On log_rcp_receipt_position_qualitycontrolitems.Target_WRH_Shelf_RefID =
    log_wrh_shelves.LOG_WRH_ShelfID And log_wrh_shelves.Tenant_RefID = @TenantID
    And log_wrh_shelves.IsDeleted = 0 Left Join
  log_wrh_warehouses On log_wrh_shelves.R_Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID And log_wrh_warehouses.Tenant_RefID =
    @TenantID And log_wrh_warehouses.IsDeleted = 0 Left Join
  log_wrh_areas On log_wrh_shelves.R_Area_RefID = log_wrh_areas.LOG_WRH_AreaID
    And log_wrh_areas.Tenant_RefID = @TenantID And log_wrh_areas.IsDeleted = 0
  Left Join
  log_wrh_racks On log_wrh_racks.LOG_WRH_RackID = log_wrh_shelves.Rack_RefID And
    log_wrh_racks.Tenant_RefID = @TenantID And log_wrh_racks.IsDeleted = 0
Where
  log_rcp_receipt_headers.LOG_RCP_Receipt_HeaderID = @HeaderID And
  log_rcp_receipt_headers.Tenant_RefID = @TenantID And
  log_rcp_receipt_headers.IsDeleted = 0
  