
Select
  acc_pay_types.PaymentType_Name_DictID,
  acc_pay_types.GlobalPropertyMatchingID,
  acc_pay_types.ACC_PAY_TypeID,
  acc_pay_types.IsCashPaymentType
From
  acc_pay_types
Where
  acc_pay_types.Tenant_RefID = @TenantID And
  acc_pay_types.IsDeleted = 0
  