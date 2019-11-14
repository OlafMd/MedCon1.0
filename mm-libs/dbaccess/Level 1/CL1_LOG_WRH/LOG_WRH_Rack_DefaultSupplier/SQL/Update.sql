UPDATE 
	log_wrh_rack_defaultsuppliers
SET 
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	Rack_RefID=@Rack_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Rack_DefaultSupplierID = @LOG_WRH_Rack_DefaultSupplierID