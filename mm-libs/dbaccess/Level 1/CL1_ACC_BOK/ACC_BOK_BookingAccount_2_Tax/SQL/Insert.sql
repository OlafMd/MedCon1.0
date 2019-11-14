INSERT INTO 
	acc_bok_bookingaccount_2_tax
	(
		AssignmentID,
		ACC_BOK_BookingAccount_RefID,
		ACC_TAX_Tax_RefID,
		IsDefaultAccountForRevenueBookings,
		IsDefaultAccountForTaxBookings,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ACC_BOK_BookingAccount_RefID,
		@ACC_TAX_Tax_RefID,
		@IsDefaultAccountForRevenueBookings,
		@IsDefaultAccountForTaxBookings,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)