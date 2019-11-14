UPDATE 
	ord_prc_discounttypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	IsDefaultAbsoluteDiscountValue=@IsDefaultAbsoluteDiscountValue,
	IsDefaultRelativeDiscountValue=@IsDefaultRelativeDiscountValue,
	DisplayName=@DisplayName,
	DiscountType_Name_DictID=@DiscountType_Name,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_DiscountTypeID = @ORD_PRC_DiscountTypeID