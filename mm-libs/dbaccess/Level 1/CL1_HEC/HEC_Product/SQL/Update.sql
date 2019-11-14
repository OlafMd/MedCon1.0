UPDATE 
	hec_products
SET 
	Ext_PRO_Product_RefID=@Ext_PRO_Product_RefID,
	Recepie=@Recepie,
	ProductDosageForm_RefID=@ProductDosageForm_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ProductID = @HEC_ProductID