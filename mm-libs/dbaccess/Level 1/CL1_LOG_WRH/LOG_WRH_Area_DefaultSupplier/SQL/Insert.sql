INSERT INTO 
	log_wrh_area_defaultsuppliers
	(
		LOG_WRH_Area_DefaultSupplierID,
		CMN_BPT_Supplier_RefID,
		Area_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@LOG_WRH_Area_DefaultSupplierID,
		@CMN_BPT_Supplier_RefID,
		@Area_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)