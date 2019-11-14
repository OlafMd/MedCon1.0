UPDATE 
	cmn_bpt_memo_additionalfields
SET 
	Memo_RefID=@Memo_RefID,
	Field_Key=@Field_Key,
	Field_Value=@Field_Value,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_Memo_AdditionalFieldID = @CMN_BPT_Memo_AdditionalFieldID