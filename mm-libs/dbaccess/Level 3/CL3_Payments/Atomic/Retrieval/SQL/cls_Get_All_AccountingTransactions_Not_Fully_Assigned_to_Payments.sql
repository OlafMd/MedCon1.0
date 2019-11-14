
    SELECT
        SUM(COALESCE(acc_bok_accounting_bookinglines.TransactionValue, 0)) AS TotalTransactionValue,
        SUM(COALESCE(bil_billheader_assignedpayments.AssignedValue, 0)) AS AssignedTransactionValue,
        acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID AS AccountingTransactionID
		SUM(COALESCE(acc_bok_accounting_bookinglines.TransactionValue, 0)) - SUM(COALESCE(bil_billheader_assignedpayments.AssignedValue, 0)) AS UnassignedTransactionValue
    FROM
        acc_bok_accounting_bookinglines
    INNER JOIN acc_bok_bookingaccounts_purpose_bp_assignments
        ON acc_bok_bookingaccounts_purpose_bp_assignments.BookingAccount_RefID = acc_bok_accounting_bookinglines.BookingAccount_RefID
        AND acc_bok_bookingaccounts_purpose_bp_assignments.IsDeleted = 0
        AND acc_bok_bookingaccounts_purpose_bp_assignments.Tenant_RefID = @TenantID
        AND acc_bok_bookingaccounts_purpose_bp_assignments.BusinessParticipant_RefID = @BusinessParticipantID
        AND acc_bok_bookingaccounts_purpose_bp_assignments.Is_L3_CustomerAccount = 1
    INNER JOIN acc_bok_bookingaccounts
        ON acc_bok_bookingaccounts.ACC_BOK_BookingAccountID = acc_bok_bookingaccounts_purpose_bp_assignments.BookingAccount_RefID
        AND acc_bok_bookingaccounts.IsDeleted = 0
        AND acc_bok_bookingaccounts.Tenant_RefID = @TenantID
        AND acc_bok_bookingaccounts.FiscalYear_RefID = @FiscalYearID
    LEFT OUTER JOIN bil_billheader_assignedpayments
        ON bil_billheader_assignedpayments.ACC_BOK_AccountingTransaction_RefID = acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID
        AND bil_billheader_assignedpayments.IsDeleted = 0
        AND bil_billheader_assignedpayments.Tenant_RefID = @TenantID
    WHERE
        acc_bok_accounting_bookinglines.IsDeleted = 0
        AND acc_bok_accounting_bookinglines.Tenant_RefID = @TenantID
    GROUP BY acc_bok_accounting_bookinglines.PartOfAccountingTransaction_RefID
  