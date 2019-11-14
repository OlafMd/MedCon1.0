UPDATE 
	cmn_bpt_ctm_customer_pricelists
SET 
	CMN_BPT_CTM_Customer_RefID=@CMN_BPT_CTM_Customer_RefID,
	CMN_SLS_Pricelist_RefID=@CMN_SLS_Pricelist_RefID,
	IsDefault=@IsDefault,
	IsActive=@IsActive,
	AdditionalPricelistDiscount_InPercent=@AdditionalPricelistDiscount_InPercent,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_CTM_Customer_PricelistID = @CMN_BPT_CTM_Customer_PricelistID