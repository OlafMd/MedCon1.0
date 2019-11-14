
    SELECT
        acc_ipl_installments.ACC_IPL_InstallmentID,
        acc_ipl_installment_2_assignedpayments.ACC_IPL_Installment_2_AssignedPaymentID,
        acc_ipl_installments.Amount AS ExpectedAmount,
        acc_bok_accounting_bookinglines.DateOfTransaction AS Payment_PayedOnDate,
        acc_ipl_installment_2_assignedpayments.AssignedValue AS PayedAmount,
        acc_ipl_installments.PaymentDeadline AS PaymentDeadline,
        acc_ipl_installments.PayedOnDate AS PayedOnDate,
        acc_ipl_installments.IsFullyPaid AS Installment_IsFullyPaid
    FROM
        bil_billheader_2_installmentplans
    INNER JOIN acc_ipl_installmentplans
        ON acc_ipl_installmentplans.ACC_IPL_InstallmentPlanID = bil_billheader_2_installmentplans.BIL_InstallmentPlan_RefID
        AND acc_ipl_installmentplans.IsDeleted = 0
        AND acc_ipl_installmentplans.Tenant_RefID = @TenantID
    INNER JOIN acc_ipl_installments
        ON acc_ipl_installments.InstallmentPlan_RefID = acc_ipl_installmentplans.ACC_IPL_InstallmentPlanID
        AND acc_ipl_installments.IsDeleted = 0
        AND acc_ipl_installments.Tenant_RefID = @TenantID
    LEFT OUTER JOIN acc_ipl_installment_2_assignedpayments
        ON acc_ipl_installment_2_assignedpayments.ACC_IPL_Installment_RefID = acc_ipl_installments.ACC_IPL_InstallmentID
        AND acc_ipl_installment_2_assignedpayments.IsDeleted = 0
        AND acc_ipl_installment_2_assignedpayments.Tenant_RefID = @TenantID
    LEFT OUTER JOIN acc_bok_accounting_transactions
        ON acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID = acc_ipl_installment_2_assignedpayments.ACC_BOK_Accounting_Transaction_RefID
        AND acc_bok_accounting_transactions.IsDeleted = 0
        AND acc_bok_accounting_transactions.Tenant_RefID = @TenantID
    LEFT OUTER JOIN acc_bok_accounting_bookinglines
        ON acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID = acc_bok_accounting_transactions.ACC_BOK_Accounting_TransactionID
        AND acc_bok_accounting_bookinglines.IsDeleted = 0
        AND acc_bok_accounting_bookinglines.Tenant_RefID = @TenantID

    WHERE
        bil_billheader_2_installmentplans.BIL_BillHeader_RefID = @BillHeaderID
        AND bil_billheader_2_installmentplans.IsDeleted = 0
        AND bil_billheader_2_installmentplans.Tenant_RefID = @TenantID	
    GROUP BY acc_ipl_installments.ACC_IPL_InstallmentID
    ORDER BY acc_ipl_installments.PaymentDeadline ASC

  