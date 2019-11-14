UPDATE 
	cmn_pro_product_supplierareabindings
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	LOG_REG_SupplierSelectionArea_RefID=@LOG_REG_SupplierSelectionArea_RefID,
	IsDefault_ProductSupplier=@IsDefault_ProductSupplier,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_Product_SupplierAreaBindingID = @CMN_PRO_Product_SupplierAreaBindingID