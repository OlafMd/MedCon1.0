
	Select
	  Sum(cmn_sls_sta_dailysales_overall.OverallSoldQuantity) as OverallSoldQuantity,
	  cmn_sls_sta_dailysales_overall.Product_RefID
	From
	  cmn_sls_sta_dailysales_overall
	Where
	  cmn_sls_sta_dailysales_overall.Product_RefID = @ProductIDList And
	  cmn_sls_sta_dailysales_overall.OverallSalesForDay >= @DateFrom And 
	  cmn_sls_sta_dailysales_overall.OverallSalesForDay <= @DateTo And
	  cmn_sls_sta_dailysales_overall.Tenant_RefID = @TenantID And
	  cmn_sls_sta_dailysales_overall.IsDeleted = 0
	Group By
	  cmn_sls_sta_dailysales_overall.Product_RefID
  