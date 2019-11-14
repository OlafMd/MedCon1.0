INSERT INTO 
	acc_dun_dunningprocess_memberbills
	(
		ACC_DUN_DunningProcess_MemberBillID,
		ACC_DUN_DunningProcess_RefID,
		BIL_BillHeader_RefID,
		CurrentUnpaidBillFraction,
		ApplicableProcessDunningFees,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_DUN_DunningProcess_MemberBillID,
		@ACC_DUN_DunningProcess_RefID,
		@BIL_BillHeader_RefID,
		@CurrentUnpaidBillFraction,
		@ApplicableProcessDunningFees,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)