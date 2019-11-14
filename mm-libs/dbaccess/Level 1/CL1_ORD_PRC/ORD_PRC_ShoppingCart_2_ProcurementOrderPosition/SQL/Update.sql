UPDATE 
	ord_prc_shoppingcart_2_procurementorderposition
SET 
	ORD_PRC_ProcurementOrder_Position_RefID=@ORD_PRC_ProcurementOrder_Position_RefID,
	ORD_PRC_ShoppingCart_Product_RefID=@ORD_PRC_ShoppingCart_Product_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID