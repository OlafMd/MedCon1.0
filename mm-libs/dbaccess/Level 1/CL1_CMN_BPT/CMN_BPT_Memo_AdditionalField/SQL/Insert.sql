INSERT INTO 
	cmn_bpt_memo_additionalfields
	(
		CMN_BPT_Memo_AdditionalFieldID,
		Memo_RefID,
		Field_Key,
		Field_Value,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_Memo_AdditionalFieldID,
		@Memo_RefID,
		@Field_Key,
		@Field_Value,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)