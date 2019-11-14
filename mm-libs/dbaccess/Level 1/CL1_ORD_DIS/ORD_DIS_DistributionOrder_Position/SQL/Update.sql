UPDATE 
	ord_dis_distributionorder_positions
SET 
	DistributionOrder_Header_RefID=@DistributionOrder_Header_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	Quantity=@Quantity,
	InternallyCharged_TotalNetPriceValue=@InternallyCharged_TotalNetPriceValue,
	InternallyCharged_TotalPointValue=@InternallyCharged_TotalPointValue,
	Position_OrdinalNumber=@Position_OrdinalNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_DIS_DistributionOrder_PositionID = @ORD_DIS_DistributionOrder_PositionID