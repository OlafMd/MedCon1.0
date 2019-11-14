UPDATE 
	ord_prc_shoppingcart_products
SET 
	ORD_PRC_ShoppingCart_RefID=@ORD_PRC_ShoppingCart_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	SequenceNumber=@SequenceNumber,
	Quantity=@Quantity,
	IsCanceled=@IsCanceled,
	Comment=@Comment,
	IsProductReplacementAllowed=@IsProductReplacementAllowed,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ShoppingCart_ProductID = @ORD_PRC_ShoppingCart_ProductID