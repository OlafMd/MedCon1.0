UPDATE 
	log_wrh_shelf_predefinedproductlocations
SET 
	Shelf_RefID=@Shelf_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	LocationPriority=@LocationPriority,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	LOG_WRH_Shelf_PredefinedProductLocationID = @LOG_WRH_Shelf_PredefinedProductLocationID