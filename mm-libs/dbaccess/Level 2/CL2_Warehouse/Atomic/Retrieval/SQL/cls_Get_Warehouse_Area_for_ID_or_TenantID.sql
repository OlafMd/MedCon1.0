
	SELECT log_wrh_areas.LOG_WRH_AreaID,
	       log_wrh_areas.CoordinateCode,
	       log_wrh_areas.Area_Name, 
	       log_wrh_areas.Warehouse_RefID,
	       log_wrh_areas.IsStructureHidden,
	       log_wrh_areas.IsConsignmentArea,
	       log_wrh_areas.IfConsignmentArea_DefaultOwningSupplier_RefID,
         log_wrh_areas.Rack_NamePrefix,
	       log_wrh_areas.IsDeleted,
         log_wrh_area_defaultsuppliers.CMN_BPT_Supplier_RefID,
         log_wrh_areas.IsDefaultIntakeArea,
         log_wrh_areas.IsLongTermStorageArea,
         log_wrh_areas.IsPointOfSalesArea
	  FROM log_wrh_areas
         LEFT JOIN log_wrh_area_defaultsuppliers ON log_wrh_areas.LOG_WRH_AreaID = log_wrh_area_defaultsuppliers.Area_RefID AND log_wrh_area_defaultsuppliers.IsDeleted = 0
	 WHERE log_wrh_areas.LOG_WRH_AreaID = IFNULL(@AreaID, log_wrh_areas.LOG_WRH_AreaID)
	       AND log_wrh_areas.Tenant_RefID = @TenantID
         AND log_wrh_areas.IsDeleted = 0
  