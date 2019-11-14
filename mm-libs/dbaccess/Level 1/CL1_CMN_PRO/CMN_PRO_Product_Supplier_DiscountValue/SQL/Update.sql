UPDATE 
	cmn_pro_product_supplier_discountvalues
SET 
	Product_Supplier_RefID=@Product_Supplier_RefID,
	ORD_PRC_DiscountType_RefID=@ORD_PRC_DiscountType_RefID,
	IsAbsoluteDiscountValue=@IsAbsoluteDiscountValue,
	IsRelativeDiscountValue=@IsRelativeDiscountValue,
	DiscountValue=@DiscountValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Product_Supplier_DiscountValueID = @CMN_PRO_Product_Supplier_DiscountValueID