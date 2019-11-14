
	(Select
  log_wrh_quantitylevels.Product_RefID as Product_RefID,
  log_wrh_warehouse_group_defaultsuppliers.CMN_BPT_Supplier_RefID as CMN_BPT_Supplier_RefID
From
  log_wrh_quantitylevels Left Join
  log_wrh_warehouse_group_2_quantitylevels
    On log_wrh_quantitylevels.Quantity_Minimum =
    log_wrh_warehouse_group_2_quantitylevels.LOG_WRH_QuantityLevel_RefID And
    log_wrh_warehouse_group_2_quantitylevels.IsDeleted = 0 And
    log_wrh_warehouse_group_2_quantitylevels.Tenant_RefID = @TenantID Left Join
  log_wrh_warehouse_group_defaultsuppliers
    On log_wrh_warehouse_group_2_quantitylevels.LOG_WRH_Warehouse_Group_RefID =
    log_wrh_warehouse_group_defaultsuppliers.LOG_WRH_Warehouse_Group_SupplierID
    And log_wrh_warehouse_group_defaultsuppliers.IsDeleted = 0 And
    log_wrh_warehouse_group_defaultsuppliers.Tenant_RefID = @TenantID
Where
  log_wrh_quantitylevels.Product_RefID = @ProductIDList And
  log_wrh_quantitylevels.IsDeleted = 0)  
Union     
(Select
  log_wrh_quantitylevels.Product_RefID as Product_RefID,
  log_wrh_warehouse_defaultsuppliers.CMN_BPT_Supplier_RefID as CMN_BPT_Supplier_RefID
From
  log_wrh_quantitylevels Left Join
  log_wrh_warehouse_2_quantitylevels On log_wrh_quantitylevels.Quantity_Minimum
    = log_wrh_warehouse_2_quantitylevels.LOG_WRH_QuantityLevel_RefID And
    log_wrh_warehouse_2_quantitylevels.IsDeleted = 0 And
    log_wrh_warehouse_2_quantitylevels.Tenant_RefID = @TenantID Left Join
  log_wrh_warehouse_defaultsuppliers
    On log_wrh_warehouse_2_quantitylevels.LOG_WRH_Warehouse_RefID =
    log_wrh_warehouse_defaultsuppliers.LOG_WRH_Warehouse_DefaultSupplierID And
    log_wrh_warehouse_defaultsuppliers.IsDeleted = 0 And
    log_wrh_warehouse_defaultsuppliers.Tenant_RefID = @TenantID
Where
  log_wrh_quantitylevels.Product_RefID = @ProductIDList And
  log_wrh_quantitylevels.IsDeleted = 0 )
Union(
Select
  log_wrh_quantitylevels.Product_RefID As Product_RefID,
  log_wrh_area_defaultsuppliers.CMN_BPT_Supplier_RefID As CMN_BPT_Supplier_RefID
From
  log_wrh_quantitylevels Left Join
  log_wrh_area_2_quantitylevels
    On log_wrh_quantitylevels.LOG_WRH_QuantityLevelID =
    log_wrh_area_2_quantitylevels.LOG_WRH_QuantityLevel_RefID And
    log_wrh_area_2_quantitylevels.IsDeleted = 0 And
    log_wrh_area_2_quantitylevels.Tenant_RefID = @TenantID Left Join
  log_wrh_area_defaultsuppliers
    On log_wrh_area_2_quantitylevels.LOG_WRH_Area_RefID =
    log_wrh_area_defaultsuppliers.Area_RefID And
    log_wrh_area_defaultsuppliers.IsDeleted = 0 And
    log_wrh_area_defaultsuppliers.Tenant_RefID = @TenantID
Where
  log_wrh_quantitylevels.Product_RefID = @ProductIDList And
  log_wrh_quantitylevels.IsDeleted = 0
)
Union(
  Select
  log_wrh_quantitylevels.Product_RefID As Product_RefID,
  log_wrh_rack_defaultsuppliers.CMN_BPT_Supplier_RefID As CMN_BPT_Supplier_RefID
From
  log_wrh_quantitylevels Left Join
  log_wrh_rack_2_quantitylevels
    On log_wrh_quantitylevels.LOG_WRH_QuantityLevelID =
    log_wrh_rack_2_quantitylevels.LOG_WRH_QuantityLevel_RefID And
    log_wrh_rack_2_quantitylevels.IsDeleted = 0 And
    log_wrh_rack_2_quantitylevels.Tenant_RefID = @TenantID Left Join
  log_wrh_rack_defaultsuppliers
    On log_wrh_rack_2_quantitylevels.LOG_WRH_Rack_RefID =
    log_wrh_rack_defaultsuppliers.Rack_RefID And
    log_wrh_rack_defaultsuppliers.IsDeleted = 0 And
    log_wrh_rack_defaultsuppliers.Tenant_RefID = @TenantID
Where
  log_wrh_quantitylevels.Product_RefID = @ProductIDList And
  log_wrh_quantitylevels.IsDeleted = 0
)

  