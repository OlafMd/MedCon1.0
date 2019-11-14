
Select
  cmn_bpt_supplier_defaultdeliverytimes.CRONExpression,
  cmn_bpt_supplier_defaultdeliverytimes.Tenant_RefID As TenantID,
  cmn_bpt_supplier_defaultdeliverytimes.TimeToDelivery_in_min,
  cmn_bpt_supplier_defaultdeliverytimes.Supplier_RefID,
  cmn_bpt_supplier_defaultdeliverytimes.CMN_BPT_Supplier_DefaultDeliveryTimeID
From
  cmn_bpt_supplier_defaultdeliverytimes
Where
  cmn_bpt_supplier_defaultdeliverytimes.Tenant_RefID = IfNull(@CustomTenantID,
  cmn_bpt_supplier_defaultdeliverytimes.Tenant_RefID) And
  cmn_bpt_supplier_defaultdeliverytimes.IsDeleted = 0
  