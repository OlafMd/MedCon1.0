
Select
  cmn_bpt_customer_promiseddeliverytimes.CMN_BPT_Customer_PromisedDeliveryTimeID,
  cmn_bpt_customer_promiseddeliverytimes.CRONExpression,
  cmn_bpt_customer_promiseddeliverytimes.TimeToDelivery_in_min
From
  cmn_bpt_customer_promiseddeliverytimes
Where
  cmn_bpt_customer_promiseddeliverytimes.Tenant_RefID = @TenantID And
  cmn_bpt_customer_promiseddeliverytimes.IsDeleted = 0 And
  cmn_bpt_customer_promiseddeliverytimes.Customer_RefID = @CustomerID
  