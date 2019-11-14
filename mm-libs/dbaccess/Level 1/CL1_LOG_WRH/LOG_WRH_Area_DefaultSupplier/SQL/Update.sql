UPDATE 
	log_wrh_area_defaultsuppliers
SET 
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	Area_RefID=@Area_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_WRH_Area_DefaultSupplierID = @LOG_WRH_Area_DefaultSupplierID