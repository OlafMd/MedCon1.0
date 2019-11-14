INSERT INTO 
	hec_product_dosageforms
	(
		HEC_Product_DosageFormID,
		GlobalPropertyMatchingID,
		DosageForm_Name_DictID,
		DosageForm_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Product_DosageFormID,
		@GlobalPropertyMatchingID,
		@DosageForm_Name,
		@DosageForm_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID,
		@Modification_Timestamp
	)