INSERT INTO 
	cmn_bpt_memo_relatedparticipants
	(
		CMN_BPT_Memo_RelatedParticipantID,
		CMN_BPT_BusinessParticipant_RefID,
		CMN_BPT_Memo_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_Memo_RelatedParticipantID,
		@CMN_BPT_BusinessParticipant_RefID,
		@CMN_BPT_Memo_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)