UPDATE 
	log_reg_supplierselectionarea_2_country
SET 
	LOG_REG_SupplierSelectionArea_RefID=@LOG_REG_SupplierSelectionArea_RefID,
	CMN_Country_RefID=@CMN_Country_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID