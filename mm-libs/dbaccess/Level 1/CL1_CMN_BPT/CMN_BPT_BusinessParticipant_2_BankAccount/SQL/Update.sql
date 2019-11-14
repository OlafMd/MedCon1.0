UPDATE 
	cmn_bpt_businessparticipant_2_bankaccount
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	ACC_BNK_BankAccount_RefID=@ACC_BNK_BankAccount_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID