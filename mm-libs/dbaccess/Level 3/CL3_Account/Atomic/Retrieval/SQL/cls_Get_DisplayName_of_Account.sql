
	Select
	  usr_accounts.USR_AccountID,
	  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
	  cmn_bpt_businessparticipants.DisplayName
	From
	  usr_accounts Inner Join
	  cmn_bpt_businessparticipants On usr_accounts.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
	Where
	  usr_accounts.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  usr_accounts.Tenant_RefID = @TenantID And
    usr_accounts.USR_AccountID = @AccountID
  