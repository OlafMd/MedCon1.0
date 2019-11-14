UPDATE 
	cmn_sls_pricelist
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Pricelist_Name_DictID=@Pricelist_Name,
	Pricelist_Description_DictID=@Pricelist_Description,
	IsDiscountCalculated_Accumulative=@IsDiscountCalculated_Accumulative,
	IsDiscountCalculated_Maximum=@IsDiscountCalculated_Maximum,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_PricelistID = @CMN_SLS_PricelistID