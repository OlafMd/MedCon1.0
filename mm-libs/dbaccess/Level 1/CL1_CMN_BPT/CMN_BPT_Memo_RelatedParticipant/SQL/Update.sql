UPDATE 
	cmn_bpt_memo_relatedparticipants
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	CMN_BPT_Memo_RefID=@CMN_BPT_Memo_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_Memo_RelatedParticipantID = @CMN_BPT_Memo_RelatedParticipantID