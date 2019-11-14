
	SELECT log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID,
	       log_wrh_warehouse_groups.Parent_RefID,
	       log_wrh_warehouse_groups.WarehouseGroup_Name,
	       log_wrh_warehouse_groups.WarehouseGroup_Description_DictID,
	       log_wrh_warehouse_groups.IsDeleted,
         log_wrh_warehouse_group_defaultsuppliers.CMN_BPT_Supplier_RefID
	  FROM log_wrh_warehouse_groups
         LEFT JOIN log_wrh_warehouse_group_defaultsuppliers on log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID = log_wrh_warehouse_group_defaultsuppliers.Warehouse_Group_RefID AND log_wrh_warehouse_group_defaultsuppliers.IsDeleted = 0
	  WHERE log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID = IFNULL(@Warehouse_GroupID, log_wrh_warehouse_groups.LOG_WRH_Warehouse_GroupID) 
          AND log_wrh_warehouse_groups.Tenant_RefID = @TenantID
          AND log_wrh_warehouse_groups.IsDeleted = 0
  