INSERT INTO 
	acc_ipl_installment_2_assignedpayments
	(
		ACC_IPL_Installment_2_AssignedPaymentID,
		ACC_BOK_Accounting_Transaction_RefID,
		ACC_IPL_Installment_RefID,
		AssignedBy_BusinessParticipant_RefID,
		AssignedValue,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_IPL_Installment_2_AssignedPaymentID,
		@ACC_BOK_Accounting_Transaction_RefID,
		@ACC_IPL_Installment_RefID,
		@AssignedBy_BusinessParticipant_RefID,
		@AssignedValue,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)