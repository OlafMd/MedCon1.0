
	SELECT
		bil_billheader_assignedpayments.BIL_BillHeader_AssignedPaymentID,
		bil_billheaders.TotalValue_IncludingTax AS Bill_TotalValue,
		date_add(bil_billheaders.DateOnBill, INTERVAL acc_pay_conditions.MaximumPaymentTreshold_InDays DAY) AS PaymentDeadline,
		bil_billheader_assignedpayments.AssignedValue AS PayedAmount,
		acc_bok_accounting_bookinglines.DateOfTransaction AS PayedOnDate
	FROM
		bil_billheaders
	INNER JOIN bil_billheader_assignedpayments
		ON bil_billheader_assignedpayments.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
		AND bil_billheader_assignedpayments.IsDeleted = 0
		AND bil_billheader_assignedpayments.Tenant_RefID = @TenantID
	INNER JOIN acc_pay_conditions
		ON acc_pay_conditions.ACC_PAY_ConditionID = bil_billheaders.BillHeader_PaymentCondition_RefID
		AND acc_pay_conditions.IsDeleted = 0
		AND acc_pay_conditions.Tenant_RefID = @TenantID
	INNER JOIN acc_bok_accounting_transactions
		ON acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID = bil_billheader_assignedpayments.ACC_BOK_AccountingTransaction_RefID
		AND acc_bok_accounting_transactions.IsDeleted = 0
		AND acc_bok_accounting_transactions.Tenant_RefID = @TenantID
	INNER JOIN acc_bok_accounting_bookinglines
		ON acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID = acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID
		AND acc_bok_accounting_bookinglines.IsDeleted = 0
		AND acc_bok_accounting_bookinglines.Tenant_RefID = @TenantID
	WHERE
		bil_billheaders.BIL_BillHeaderID = @BillHeaderID
		AND bil_billheaders.IsDeleted = 0
		AND bil_billheaders.Tenant_RefID = @TenantID
	GROUP BY acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID
  