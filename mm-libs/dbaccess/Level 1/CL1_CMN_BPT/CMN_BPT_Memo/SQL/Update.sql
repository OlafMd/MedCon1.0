UPDATE 
	cmn_bpt_memos
SET 
	DocumentStructureHeader_RefID=@DocumentStructureHeader_RefID,
	CreatedBy_Account_RefID=@CreatedBy_Account_RefID,
	UpdatedBy_Account_RefID=@UpdatedBy_Account_RefID,
	Memo_Title=@Memo_Title,
	Memo_Abbreviation=@Memo_Abbreviation,
	Memo_Date=@Memo_Date,
	Memo_Text=@Memo_Text,
	UpdatedOn=@UpdatedOn,
	IsImportant=@IsImportant,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_MemoID = @CMN_BPT_MemoID