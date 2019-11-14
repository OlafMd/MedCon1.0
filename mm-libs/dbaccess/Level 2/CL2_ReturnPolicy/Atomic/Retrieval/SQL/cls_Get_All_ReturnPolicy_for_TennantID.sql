
	Select distinct
  log_ret_returnpolicies.LOG_RET_ReturnPolicyID,
  log_ret_returnpolicies.Creation_Timestamp,
  log_ret_returnpolicies.GlobalPropertyMatchingID,
  log_ret_returnpolicies.ReturnPolicy_Abbreviation,
  log_ret_returnpolicies.ReturnPolicy_Reason_DictID,
  log_ret_returnpolicies.Tenant_RefID,
  cmn_price_values.PriceValue_Amount,
  cmn_price_values.PriceValue_Currency_RefID
From
  log_ret_returnpolicies Inner Join
  cmn_price_values On log_ret_returnpolicies.ReturnPolicy_Cost_RefID =
    cmn_price_values.Price_RefID
Where
  log_ret_returnpolicies.Tenant_RefID = @TenantID And
  log_ret_returnpolicies.IsDeleted = 0
  