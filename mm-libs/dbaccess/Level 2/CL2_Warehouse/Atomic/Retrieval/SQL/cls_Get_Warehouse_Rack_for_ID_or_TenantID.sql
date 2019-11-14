
	SELECT LOG_WRH_RackID,
	       log_wrh_racks.Area_RefID,
	       log_wrh_racks.CoordinateCode,
	       log_wrh_racks.Shelves_Use_XCoordinate,
	       log_wrh_racks.Shelves_Use_YCoordinate,
	       log_wrh_racks.Shelves_Use_ZCoordinate,
	       log_wrh_racks.IsStructureHidden,
	       log_wrh_racks.Shelves_XLabel,
	       log_wrh_racks.Shelves_YLabel,
	       log_wrh_racks.Shelves_ZLabel,
	       log_wrh_racks.IsDeleted,
         log_wrh_racks.Shelf_NamePrefix,
         log_wrh_racks.Rack_Name,
         log_wrh_rack_defaultsuppliers.CMN_BPT_Supplier_RefID
	  FROM log_wrh_racks
         LEFT JOIN log_wrh_rack_defaultsuppliers ON log_wrh_racks.LOG_WRH_RackID = log_wrh_rack_defaultsuppliers.Rack_RefID AND log_wrh_rack_defaultsuppliers.IsDeleted = 0
	 WHERE log_wrh_racks.LOG_WRH_RackID = IFNULL(@RackID, log_wrh_racks.LOG_WRH_RackID)
	       AND log_wrh_racks.Tenant_RefID = @TenantID
         AND log_wrh_racks.IsDeleted = 0
  