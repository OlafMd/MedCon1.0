UPDATE 
	ord_prc_procurementorder_position_discounts
SET 
	ORD_PRC_ProcurementOrder_Position_RefID=@ORD_PRC_ProcurementOrder_Position_RefID,
	ORD_PRC_DiscountType_RefID=@ORD_PRC_DiscountType_RefID,
	IsDiscountRelative=@IsDiscountRelative,
	IsDiscountAbsolute=@IsDiscountAbsolute,
	DiscountValue=@DiscountValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_ProcurementOrder_Position_DiscountID = @ORD_PRC_ProcurementOrder_Position_DiscountID