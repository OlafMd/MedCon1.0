UPDATE 
	ord_cuo_customerorderreturn_positions
SET 
	CustomerOrderReturnHeader_RefID=@CustomerOrderReturnHeader_RefID,
	CorrespondingReceiptPosition_RefID=@CorrespondingReceiptPosition_RefID,
	Position_Quantity=@Position_Quantity,
	Position_ValuePerUnit=@Position_ValuePerUnit,
	Position_ValueTotal=@Position_ValueTotal,
	Position_Comment=@Position_Comment,
	Position_Description=@Position_Description,
	Position_Unit_RefID=@Position_Unit_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	Price_From_PricelistRelease_RefID=@Price_From_PricelistRelease_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_CustomerOrderReturn_PositionID = @ORD_CUO_CustomerOrderReturn_PositionID