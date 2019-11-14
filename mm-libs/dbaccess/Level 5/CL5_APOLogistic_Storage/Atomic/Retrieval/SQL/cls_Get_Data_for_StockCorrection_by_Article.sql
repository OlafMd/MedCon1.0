
   Select
  cmn_pro_products.Product_Number,
  hec_product_dosageforms.GlobalPropertyMatchingID As
  DosageFormGlobalPropertyName,
  hec_product_dosageforms.DosageForm_Name_DictID,
  cmn_pro_pac_packageinfo.PackageContent_Amount,
  cmn_units.ISOCode,
  log_wrh_shelf_contents.Quantity_Current,
  log_producttrackinginstances.BatchNumber,
  log_producttrackinginstances.ExpirationDate,
  log_wrh_racks.Rack_Name,
  log_wrh_shelves.Shelf_Name,
  log_wrh_areas.Area_Name,
  log_wrh_warehouses.Warehouse_Name,
  cmn_pro_products.CMN_PRO_ProductID,
  log_producttrackinginstances.LOG_ProductTrackingInstanceID,
  log_producttrackinginstances.CurrentQuantityOnTrackingInstance,
  log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID,
  cmn_pro_products.Product_Name_DictID
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And hec_products.Tenant_RefID = @TenantID
    And hec_products.IsDeleted = 0 Inner Join
  hec_product_dosageforms On hec_products.ProductDosageForm_RefID =
    hec_product_dosageforms.HEC_Product_DosageFormID And
    hec_product_dosageforms.Tenant_RefID = @TenantID And
    hec_product_dosageforms.IsDeleted = 0 Inner Join
  cmn_pro_pac_packageinfo On cmn_pro_products.PackageInfo_RefID =
    cmn_pro_pac_packageinfo.CMN_PRO_PAC_PackageInfoID And
    cmn_pro_pac_packageinfo.Tenant_RefID = @TenantID And
    cmn_pro_pac_packageinfo.IsDeleted = 0 Inner Join
  cmn_units On cmn_pro_pac_packageinfo.PackageContent_MeasuredInUnit_RefID =
    cmn_units.CMN_UnitID And cmn_units.Tenant_RefID = @TenantID And
    cmn_units.IsDeleted = 0 Inner Join
  log_wrh_shelf_contents On log_wrh_shelf_contents.Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID And log_wrh_shelf_contents.Tenant_RefID =
    @TenantID And log_wrh_shelf_contents.IsDeleted = 0 Inner Join
  log_wrh_shelves On log_wrh_shelf_contents.Shelf_RefID =
    log_wrh_shelves.LOG_WRH_ShelfID And log_wrh_shelves.Tenant_RefID = @TenantID
  Inner Join
  log_wrh_warehouses On log_wrh_shelves.R_Warehouse_RefID =
    log_wrh_warehouses.LOG_WRH_WarehouseID And log_wrh_warehouses.Tenant_RefID =
    @TenantID And log_wrh_warehouses.IsDeleted = 0 Inner Join
  log_wrh_racks On log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID And
    log_wrh_racks.Tenant_RefID = @TenantID And log_wrh_racks.IsDeleted = 0
  Inner Join
  log_wrh_areas On log_wrh_shelves.R_Area_RefID = log_wrh_areas.LOG_WRH_AreaID
    And log_wrh_areas.Tenant_RefID = @TenantID And log_wrh_areas.IsDeleted = 0
  Left Join
  log_wrh_shelfcontent_2_trackinginstance
    On log_wrh_shelf_contents.LOG_WRH_Shelf_ContentID =
    log_wrh_shelfcontent_2_trackinginstance.LOG_WRH_Shelf_Content_RefID
  Left Join
  log_producttrackinginstances
    On log_wrh_shelfcontent_2_trackinginstance.LOG_ProductTrackingInstance_RefID
    = log_producttrackinginstances.LOG_ProductTrackingInstanceID And
    log_wrh_shelfcontent_2_trackinginstance.Tenant_RefID = @TenantID
Where
  cmn_pro_products.CMN_PRO_ProductID = @ProductID_List And
  (@BatchNumber Is Null Or
    log_producttrackinginstances.BatchNumber = @BatchNumber) And
  (@ExpirationDate Is Null Or
    log_producttrackinginstances.ExpirationDate = @ExpirationDate) And
  cmn_pro_products.Tenant_RefID = @TenantID And
  cmn_pro_products.IsDeleted = 0
  