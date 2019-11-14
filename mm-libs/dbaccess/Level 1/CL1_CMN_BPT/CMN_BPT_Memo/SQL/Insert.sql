INSERT INTO 
	cmn_bpt_memos
	(
		CMN_BPT_MemoID,
		DocumentStructureHeader_RefID,
		CreatedBy_Account_RefID,
		UpdatedBy_Account_RefID,
		Memo_Title,
		Memo_Abbreviation,
		Memo_Date,
		Memo_Text,
		UpdatedOn,
		IsImportant,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_BPT_MemoID,
		@DocumentStructureHeader_RefID,
		@CreatedBy_Account_RefID,
		@UpdatedBy_Account_RefID,
		@Memo_Title,
		@Memo_Abbreviation,
		@Memo_Date,
		@Memo_Text,
		@UpdatedOn,
		@IsImportant,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)