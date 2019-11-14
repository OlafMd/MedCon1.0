UPDATE 
	hec_product_dosageforms
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DosageForm_Name_DictID=@DosageForm_Name,
	DosageForm_Description_DictID=@DosageForm_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Product_DosageFormID = @HEC_Product_DosageFormID