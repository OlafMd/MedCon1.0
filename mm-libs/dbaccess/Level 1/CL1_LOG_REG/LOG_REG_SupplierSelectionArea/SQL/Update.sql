UPDATE 
	log_reg_supplierselectionareas
SET 
	SupplierSelectionArea_Name_DictID=@SupplierSelectionArea_Name,
	SupplierSelectionArea_Description_DictID=@SupplierSelectionArea_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	LOG_REG_SupplierSelectionAreaID = @LOG_REG_SupplierSelectionAreaID