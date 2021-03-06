INSERT INTO 
	log_wrh_areas
	(
		LOG_WRH_AreaID,
		GlobalPropertyMatchingID,
		CoordinateCode,
		Area_Name,
		Warehouse_RefID,
		IsStructureHidden,
		IsConsignmentArea,
		IfConsignmentArea_DefaultOwningSupplier_RefID,
		Rack_NamePrefix,
		IsPointOfSalesArea,
		IsLongTermStorageArea,
		IsCrossDockArea,
		IsDefaultIntakeArea,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_AreaID,
		@GlobalPropertyMatchingID,
		@CoordinateCode,
		@Area_Name,
		@Warehouse_RefID,
		@IsStructureHidden,
		@IsConsignmentArea,
		@IfConsignmentArea_DefaultOwningSupplier_RefID,
		@Rack_NamePrefix,
		@IsPointOfSalesArea,
		@IsLongTermStorageArea,
		@IsCrossDockArea,
		@IsDefaultIntakeArea,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)