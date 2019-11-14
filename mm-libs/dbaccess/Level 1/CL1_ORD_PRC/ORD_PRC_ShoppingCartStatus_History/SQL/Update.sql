UPDATE 
	ord_prc_shoppingcartstatus_history
SET 
	ORD_PRC_ShoppingCart_RefID=@ORD_PRC_ShoppingCart_RefID,
	ORD_PRC_ShoppingCart_Status_RefID=@ORD_PRC_ShoppingCart_Status_RefID,
	PerformedBy_Account_RefID=@PerformedBy_Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ShoppingCartStatus_HistoryID = @ORD_PRC_ShoppingCartStatus_HistoryID