UPDATE 
	log_wrh_warehouse_group_defaultsuppliers
SET 
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	Warehouse_Group_RefID=@Warehouse_Group_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Warehouse_Group_SupplierID = @LOG_WRH_Warehouse_Group_SupplierID