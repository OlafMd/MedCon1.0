UPDATE 
	acc_dun_dunningprocess_memberbills
SET 
	ACC_DUN_DunningProcess_RefID=@ACC_DUN_DunningProcess_RefID,
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	CurrentUnpaidBillFraction=@CurrentUnpaidBillFraction,
	ApplicableProcessDunningFees=@ApplicableProcessDunningFees,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_DunningProcess_MemberBillID = @ACC_DUN_DunningProcess_MemberBillID