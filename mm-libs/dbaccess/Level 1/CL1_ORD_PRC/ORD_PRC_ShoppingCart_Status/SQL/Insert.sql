INSERT INTO 
	ord_prc_shoppingcart_statuses
	(
		ORD_PRC_ShoppingCart_StatusID,
		GlobalPropertyMatchingID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ORD_PRC_ShoppingCart_StatusID,
		@GlobalPropertyMatchingID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)