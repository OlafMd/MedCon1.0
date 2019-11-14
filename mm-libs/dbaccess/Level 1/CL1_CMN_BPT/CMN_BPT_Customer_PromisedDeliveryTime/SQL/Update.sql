UPDATE 
	cmn_bpt_customer_promiseddeliverytimes
SET 
	Customer_RefID=@Customer_RefID,
	CRONExpression=@CRONExpression,
	Specified_Product_Group_RefID=@Specified_Product_Group_RefID,
	Specified_Product_RefID=@Specified_Product_RefID,
	Specified_Product_Variant_RefID=@Specified_Product_Variant_RefID,
	Specified_Product_Release_RefID=@Specified_Product_Release_RefID,
	TimeToDelivery_in_min=@TimeToDelivery_in_min,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_Customer_PromisedDeliveryTimeID = @CMN_BPT_Customer_PromisedDeliveryTimeID