INSERT INTO 
	log_wrh_shelves
	(
		LOG_WRH_ShelfID,
		GlobalPropertyMatchingID,
		Rack_RefID,
		R_Warehouse_RefID,
		R_Area_RefID,
		Shelf_Name,
		CoordinateCode,
		CoordinateX,
		CoordinateY,
		CoordinateZ,
		ShelfCapacity_Unit_RefID,
		ShelfCapacity_Maximum,
		R_ShelfCapacity_Free,
		R_ShelfCapacity_Used,
		LimitShelfContent_ToOneProduct,
		LimitShelfContent_ToOneProductVariant,
		LimitShelfContent_ToOneProductRelease,
		IsShelfLocked,
		Predefined_Product_RefID,
		Predefined_Product_Variant_RefID,
		Predefined_Product_Release_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_ShelfID,
		@GlobalPropertyMatchingID,
		@Rack_RefID,
		@R_Warehouse_RefID,
		@R_Area_RefID,
		@Shelf_Name,
		@CoordinateCode,
		@CoordinateX,
		@CoordinateY,
		@CoordinateZ,
		@ShelfCapacity_Unit_RefID,
		@ShelfCapacity_Maximum,
		@R_ShelfCapacity_Free,
		@R_ShelfCapacity_Used,
		@LimitShelfContent_ToOneProduct,
		@LimitShelfContent_ToOneProductVariant,
		@LimitShelfContent_ToOneProductRelease,
		@IsShelfLocked,
		@Predefined_Product_RefID,
		@Predefined_Product_Variant_RefID,
		@Predefined_Product_Release_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)