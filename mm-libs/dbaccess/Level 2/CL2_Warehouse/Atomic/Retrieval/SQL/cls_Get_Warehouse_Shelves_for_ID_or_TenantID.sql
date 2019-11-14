
	SELECT log_wrh_shelves.LOG_WRH_ShelfID,
	       log_wrh_shelves.Rack_RefID,
	       log_wrh_shelves.R_Warehouse_RefID,
	       log_wrh_shelves.R_Area_RefID,
	       log_wrh_shelves.CoordinateCode,
	       log_wrh_shelves.CoordinateX,
	       log_wrh_shelves.CoordinateY,
	       log_wrh_shelves.CoordinateZ,
	       log_wrh_shelves.ShelfCapacity_Unit_RefID,
	       log_wrh_shelves.ShelfCapacity_Maximum,
	       log_wrh_shelves.R_ShelfCapacity_Free,
	       log_wrh_shelves.R_ShelfCapacity_Used,
	       log_wrh_shelves.LimitShelfContent_ToOneProduct,
	       log_wrh_shelves.LimitShelfContent_ToOneProductVariant,
	       log_wrh_shelves.LimitShelfContent_ToOneProductRelease,
	       log_wrh_shelves.IsShelfLocked,
	       log_wrh_shelves.IsDeleted,
         log_wrh_shelves.Shelf_Name,
         log_wrh_racks.Shelf_NamePrefix
	  FROM log_wrh_shelves
         INNER JOIN log_wrh_racks on log_wrh_shelves.Rack_RefID = log_wrh_racks.LOG_WRH_RackID
	 WHERE log_wrh_shelves.LOG_WRH_ShelfID = IFNULL(@ShelfID, log_wrh_shelves.LOG_WRH_ShelfID)
	       AND log_wrh_shelves.Tenant_RefID = @TenantID
         AND log_wrh_shelves.IsDeleted = 0
  