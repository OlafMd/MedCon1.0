UPDATE 
	ord_cuo_customerorder_positions
SET 
	CustomerProcurementOrderPositionITL=@CustomerProcurementOrderPositionITL,
	CustomerOrder_Header_RefID=@CustomerOrder_Header_RefID,
	Position_OrdinalNumber=@Position_OrdinalNumber,
	Position_Quantity=@Position_Quantity,
	Position_ValuePerUnit=@Position_ValuePerUnit,
	Position_ValueTotal=@Position_ValueTotal,
	Position_Comment=@Position_Comment,
	Position_Description=@Position_Description,
	Position_Unit_RefID=@Position_Unit_RefID,
	Position_RequestedDateOfDelivery=@Position_RequestedDateOfDelivery,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	IsProductReplacementAllowed=@IsProductReplacementAllowed,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrder_PositionID = @ORD_CUO_CustomerOrder_PositionID