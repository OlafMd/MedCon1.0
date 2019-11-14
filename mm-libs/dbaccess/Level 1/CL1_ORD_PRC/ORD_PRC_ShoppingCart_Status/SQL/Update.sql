UPDATE 
	ord_prc_shoppingcart_statuses
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ShoppingCart_StatusID = @ORD_PRC_ShoppingCart_StatusID