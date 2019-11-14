UPDATE 
	log_wrh_warehouse_defaultsuppliers
SET 
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	Warehouse_RefID=@Warehouse_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Warehouse_DefaultSupplierID = @LOG_WRH_Warehouse_DefaultSupplierID