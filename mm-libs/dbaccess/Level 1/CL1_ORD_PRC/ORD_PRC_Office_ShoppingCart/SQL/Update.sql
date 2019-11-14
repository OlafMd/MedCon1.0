UPDATE 
	ord_prc_office_shoppingcarts
SET 
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	ORD_PRC_ShoppingCart_RefID=@ORD_PRC_ShoppingCart_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_Office_ShoppingCartID = @ORD_PRC_Office_ShoppingCartID