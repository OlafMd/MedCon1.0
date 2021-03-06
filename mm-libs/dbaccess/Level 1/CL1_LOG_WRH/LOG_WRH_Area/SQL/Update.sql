UPDATE 
	log_wrh_areas
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	CoordinateCode=@CoordinateCode,
	Area_Name=@Area_Name,
	Warehouse_RefID=@Warehouse_RefID,
	IsStructureHidden=@IsStructureHidden,
	IsConsignmentArea=@IsConsignmentArea,
	IfConsignmentArea_DefaultOwningSupplier_RefID=@IfConsignmentArea_DefaultOwningSupplier_RefID,
	Rack_NamePrefix=@Rack_NamePrefix,
	IsPointOfSalesArea=@IsPointOfSalesArea,
	IsLongTermStorageArea=@IsLongTermStorageArea,
	IsCrossDockArea=@IsCrossDockArea,
	IsDefaultIntakeArea=@IsDefaultIntakeArea,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_AreaID = @LOG_WRH_AreaID