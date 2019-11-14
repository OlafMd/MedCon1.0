
Select
  acc_pay_conditions.ACC_PAY_ConditionID,
  acc_pay_conditions.PaymentCondition_Name_DictID,
  acc_pay_conditions.MaximumPaymentTreshold_InDays,
  details.SequenceNumber,
  details.DiscountPercentage,
  details.DateInterval_To,
  details.DateInterval_From,
  details.ACC_PAY_Condition_DetailID
From
  acc_pay_conditions Left Join
  (Select
    acc_pay_condition_details.ACC_PAY_Condition_DetailID,
    acc_pay_condition_details.DateInterval_From,
    acc_pay_condition_details.DateInterval_To,
    acc_pay_condition_details.DiscountPercentage,
    acc_pay_condition_details.SequenceNumber,
    acc_pay_condition_details.Conditions_RefID
  From
    acc_pay_condition_details
  Where
    acc_pay_condition_details.IsDeleted = 0 And
    acc_pay_condition_details.Tenant_RefID = @TenantID) details
    On acc_pay_conditions.ACC_PAY_ConditionID = details.Conditions_RefID
Where
  acc_pay_conditions.IsDeleted = 0 And
  acc_pay_conditions.Tenant_RefID = @TenantID
  