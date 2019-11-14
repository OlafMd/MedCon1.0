
		  SELECT cmn_bpt_memos.CMN_BPT_MemoID,
		       usr_accounts.USR_AccountID,
		       usr_accounts.Username,
		       cmn_bpt_memos.Memo_Text,
		       cmn_bpt_memos.Creation_Timestamp,
		       cmn_bpt_memos.IsImportant,
		       cmn_bpt_memo_relatedparticipants.CMN_BPT_Memo_RelatedParticipantID,
		       cmn_bpt_memo_relatedparticipants.CMN_BPT_BusinessParticipant_RefID,
		       cmn_bpt_memos.Tenant_RefID
		  FROM cmn_bpt_memos 
		        INNER JOIN
		        cmn_bpt_memo_relatedparticipants
		           ON cmn_bpt_memos.CMN_BPT_MemoID = cmn_bpt_memo_relatedparticipants.CMN_BPT_Memo_RefID 
		           AND cmn_bpt_memo_relatedparticipants.IsDeleted = 0
		           AND cmn_bpt_memo_relatedparticipants.Tenant_RefID = @TenantID
		        INNER JOIN
		        usr_accounts
		        ON usr_accounts.USR_AccountID = cmn_bpt_memos.CreatedBy_Account_RefID
		  WHERE cmn_bpt_memo_relatedparticipants.CMN_BPT_BusinessParticipant_RefID = @RelatedParticipantID
		       AND cmn_bpt_memos.Tenant_RefID = @TenantID
		       AND cmn_bpt_memos.IsDeleted = 0
	         AND (@IsImportant is null OR cmn_bpt_memos.IsImportant = @IsImportant)

  