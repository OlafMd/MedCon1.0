INSERT INTO 
	ord_prc_shoppingcart_2_procurementorderposition
	(
		AssignmentID,
		ORD_PRC_ProcurementOrder_Position_RefID,
		ORD_PRC_ShoppingCart_Product_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ORD_PRC_ProcurementOrder_Position_RefID,
		@ORD_PRC_ShoppingCart_Product_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)