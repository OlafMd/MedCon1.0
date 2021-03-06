UPDATE 
	ord_prc_procurementorder_positions
SET 
	SupplierCustomerOrderPositionITL=@SupplierCustomerOrderPositionITL,
	ProcurementOrder_Header_RefID=@ProcurementOrder_Header_RefID,
	Position_OrdinalNumber=@Position_OrdinalNumber,
	Position_Quantity=@Position_Quantity,
	Position_ValuePerUnit=@Position_ValuePerUnit,
	Position_ValueTotal=@Position_ValueTotal,
	Position_Comment=@Position_Comment,
	Position_Unit_RefID=@Position_Unit_RefID,
	Position_RequestedDateOfDelivery=@Position_RequestedDateOfDelivery,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	IsProductReplacementAllowed=@IsProductReplacementAllowed,
	IsBonusDelivery_WasNotOrdered=@IsBonusDelivery_WasNotOrdered,
	RequestedDateOfDelivery_TimeFrame_From=@RequestedDateOfDelivery_TimeFrame_From,
	RequestedDateOfDelivery_TimeFrame_To=@RequestedDateOfDelivery_TimeFrame_To,
	BillTo_BusinessParticipant_RefID=@BillTo_BusinessParticipant_RefID,
	IsProFormaOrderPosition=@IsProFormaOrderPosition,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_PRC_ProcurementOrder_PositionID = @ORD_PRC_ProcurementOrder_PositionID