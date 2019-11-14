
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_per_personinfo.PrimaryEmail,
	  cmn_per_personinfo.CMN_PER_PersonInfoID,
	  usr_accounts.Username
	From
	  cmn_bpt_businessparticipants Inner Join
	  usr_accounts On usr_accounts.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
	  cmn_account_applicationsubscriptions
	    On cmn_account_applicationsubscriptions.Account_RefID =
	    usr_accounts.USR_AccountID Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID
	Where
	  usr_accounts.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  usr_accounts.Tenant_RefID = @TenantID And
	  cmn_account_applicationsubscriptions.Application_RefID = @ApplicationID And
	  cmn_account_applicationsubscriptions.IsDeleted = 0 And
	  cmn_account_applicationsubscriptions.IsDisabled = 0
  