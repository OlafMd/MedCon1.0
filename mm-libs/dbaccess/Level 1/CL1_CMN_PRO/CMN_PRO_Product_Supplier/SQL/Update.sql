UPDATE 
	cmn_pro_product_suppliers
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	CMN_BPT_Supplier_RefID=@CMN_BPT_Supplier_RefID,
	SupplierPriority=@SupplierPriority,
	MinimalPackageOrderingAmount=@MinimalPackageOrderingAmount,
	BatchOrderSize=@BatchOrderSize,
	ProcurementPrice_RefID=@ProcurementPrice_RefID,
	RecommendedRetailPrice_RefID=@RecommendedRetailPrice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Product_SupplierID = @CMN_PRO_Product_SupplierID