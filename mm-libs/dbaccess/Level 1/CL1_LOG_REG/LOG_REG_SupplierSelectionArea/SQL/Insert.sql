INSERT INTO 
	log_reg_supplierselectionareas
	(
		LOG_REG_SupplierSelectionAreaID,
		SupplierSelectionArea_Name_DictID,
		SupplierSelectionArea_Description_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@LOG_REG_SupplierSelectionAreaID,
		@SupplierSelectionArea_Name,
		@SupplierSelectionArea_Description,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)