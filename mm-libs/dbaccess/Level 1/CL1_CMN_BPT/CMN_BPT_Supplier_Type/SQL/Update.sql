UPDATE 
	cmn_bpt_supplier_types
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	SupplierType_Name_DictID=@SupplierType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_Supplier_TypeID = @CMN_BPT_Supplier_TypeID