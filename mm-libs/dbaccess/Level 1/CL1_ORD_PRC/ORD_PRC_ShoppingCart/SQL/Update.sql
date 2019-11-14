UPDATE 
	ord_prc_shoppingcart
SET 
	ShoppingCart_CurrentStatus_RefID=@ShoppingCart_CurrentStatus_RefID,
	InternalIdentifier=@InternalIdentifier,
	CreatedBy_Account_RefID=@CreatedBy_Account_RefID,
	IsProcurementOrderCreated=@IsProcurementOrderCreated,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ShoppingCartID = @ORD_PRC_ShoppingCartID