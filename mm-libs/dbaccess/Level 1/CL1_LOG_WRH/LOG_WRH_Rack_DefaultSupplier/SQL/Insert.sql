INSERT INTO 
	log_wrh_rack_defaultsuppliers
	(
		LOG_WRH_Rack_DefaultSupplierID,
		CMN_BPT_Supplier_RefID,
		Rack_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_Rack_DefaultSupplierID,
		@CMN_BPT_Supplier_RefID,
		@Rack_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)