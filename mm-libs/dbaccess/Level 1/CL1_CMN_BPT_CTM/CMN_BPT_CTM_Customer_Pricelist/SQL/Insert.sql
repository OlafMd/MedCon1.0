INSERT INTO 
	cmn_bpt_ctm_customer_pricelists
	(
		CMN_BPT_CTM_Customer_PricelistID,
		CMN_BPT_CTM_Customer_RefID,
		CMN_SLS_Pricelist_RefID,
		IsDefault,
		IsActive,
		AdditionalPricelistDiscount_InPercent,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_BPT_CTM_Customer_PricelistID,
		@CMN_BPT_CTM_Customer_RefID,
		@CMN_SLS_Pricelist_RefID,
		@IsDefault,
		@IsActive,
		@AdditionalPricelistDiscount_InPercent,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)