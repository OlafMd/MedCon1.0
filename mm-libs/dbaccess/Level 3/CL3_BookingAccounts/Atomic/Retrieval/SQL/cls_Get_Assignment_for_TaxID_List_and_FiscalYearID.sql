
	SELECT
		acc_bok_bookingaccount_2_tax.AssignmentID,
		acc_bok_bookingaccount_2_tax.ACC_BOK_BookingAccount_RefID,
		acc_bok_bookingaccount_2_tax.ACC_TAX_Tax_RefID
	FROM
		acc_bok_bookingaccount_2_tax
	INNER JOIN acc_bok_bookingaccounts
		 ON acc_bok_bookingaccounts.ACC_BOK_BookingAccountID = acc_bok_bookingaccount_2_tax.ACC_BOK_BookingAccount_RefID
		AND acc_bok_bookingaccounts.FiscalYear_RefID = @FiscalYearID
		AND acc_bok_bookingaccounts.Tenant_RefID = @TenantID
		AND acc_bok_bookingaccounts.IsDeleted = 0
	WHERE
		acc_bok_bookingaccount_2_tax.Tenant_RefID = @TenantID
		AND acc_bok_bookingaccount_2_tax.IsDefaultAccountForTaxBookings = @IsTaxAccount
		AND acc_bok_bookingaccount_2_tax.IsDefaultAccountForRevenueBookings = @IsRevenueAccount
		AND acc_bok_bookingaccount_2_tax.IsDeleted = 0
		AND acc_bok_bookingaccount_2_tax.ACC_TAX_Tax_RefID = @TaxID
  