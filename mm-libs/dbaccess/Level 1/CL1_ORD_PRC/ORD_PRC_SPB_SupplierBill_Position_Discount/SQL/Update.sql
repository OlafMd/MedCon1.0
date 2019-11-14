UPDATE 
	ord_prc_spb_supplierbill_position_discounts
SET 
	SupplierBill_Position_RefID=@SupplierBill_Position_RefID,
	OrderSequence=@OrderSequence,
	DiscountDisplayName=@DiscountDisplayName,
	Discount_Name_DictID=@Discount_Name,
	Discount_in_percentage=@Discount_in_percentage,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_SPB_SupplierBill_Position_DiscountID = @ORD_PRC_SPB_SupplierBill_Position_DiscountID