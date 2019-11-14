
	Select
	  cmn_bpt_ctm_customer_pricelists.CMN_BPT_CTM_Customer_PricelistID,
	  cmn_bpt_ctm_customer_pricelists.CMN_BPT_CTM_Customer_RefID,
	  cmn_bpt_ctm_customer_pricelists.CMN_SLS_Pricelist_RefID,
	  cmn_bpt_ctm_customer_pricelists.IsDefault,
	  cmn_bpt_ctm_customer_pricelists.IsActive,
	  cmn_bpt_ctm_customer_pricelists.AdditionalPricelistDiscount_InPercent
	From
	  cmn_bpt_ctm_customer_pricelists
	Where
	  cmn_bpt_ctm_customer_pricelists.Tenant_RefID = @TenantID And
	  cmn_bpt_ctm_customer_pricelists.IsDeleted = 0
  