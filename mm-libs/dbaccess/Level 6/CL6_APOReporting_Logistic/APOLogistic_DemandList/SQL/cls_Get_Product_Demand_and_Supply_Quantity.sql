
Select Distinct
  cmn_pro_products.Product_Number,
  Sum(log_shp_shipment_positions.QuantityToShip) As DemandQuantity,
  stock.SupplyQuantity,
  cmn_pro_products.CMN_PRO_ProductID As ProductID
From
  log_shp_shipment_headers Left Join
  log_shp_shipment_positions
    On log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID =
    log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID Left Join
  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
    log_shp_shipment_positions.CMN_PRO_Product_RefID Left Join
  (Select
    log_wrh_shelf_contents.Product_RefID,
    Sum(log_wrh_shelf_contents.Quantity_Current) As SupplyQuantity,
    cmn_pro_products.Product_Number
  From
    log_wrh_shelf_contents Inner Join
    cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
      log_wrh_shelf_contents.Product_RefID
  Where
    log_wrh_shelf_contents.IsDeleted = 0 And
    log_wrh_shelf_contents.Tenant_RefID = @TenantID And
    cmn_pro_products.IsDeleted = 0 And
    cmn_pro_products.Tenant_RefID = @TenantID
  Group By
    log_wrh_shelf_contents.Product_RefID, cmn_pro_products.Product_Number,
    cmn_pro_products.IsDeleted, cmn_pro_products.Tenant_RefID) stock
    On cmn_pro_products.CMN_PRO_ProductID = stock.Product_RefID
Where
  log_shp_shipment_headers.Tenant_RefID = @TenantID And
  log_shp_shipment_positions.IsDeleted = 0 And
  log_shp_shipment_positions.Tenant_RefID = @TenantID
  And
  log_shp_shipment_headers.IsShipped = 0 And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID
Group By
  cmn_pro_products.Product_Number
  