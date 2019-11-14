UPDATE 
	cmn_pro_product_customerinquiries
SET 
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	InquiredQuantity=@InquiredQuantity,
	DateOfInquiry=@DateOfInquiry,
	InquiringCustomer_RefID=@InquiringCustomer_RefID,
	IsFulfillable=@IsFulfillable,
	IsFulfilled=@IsFulfilled,
	IsFulfilled_CustomerOrderHeader_RefID=@IsFulfilled_CustomerOrderHeader_RefID,
	NotFulfilled_Reason=@NotFulfilled_Reason,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_Product_CustomerInquiryID = @CMN_PRO_Product_CustomerInquiryID