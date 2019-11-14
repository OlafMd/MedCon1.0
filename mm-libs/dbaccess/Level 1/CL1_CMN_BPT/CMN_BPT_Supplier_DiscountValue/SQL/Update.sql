UPDATE 
	cmn_bpt_supplier_discountvalues
SET 
	Supplier_RefID=@Supplier_RefID,
	ORD_PRC_DiscountType_RefID=@ORD_PRC_DiscountType_RefID,
	DiscountValue_in_percent=@DiscountValue_in_percent,
	IsDefaultSupplierDiscountValue=@IsDefaultSupplierDiscountValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_Supplier_DiscountValueID = @CMN_BPT_Supplier_DiscountValueID