
	Select
	  usr_accounts.Username,
	  usr_accounts.DefaultLanguage_RefID,
	  cmn_per_personinfo.CMN_PER_PersonInfoID,
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_per_personinfo.PrimaryEmail,
	  cmn_per_personinfo.Title,
	  cmn_per_personinfo.ProfileImage_Document_RefID,
	  cmn_per_personinfo_2_account.USR_Account_RefID,
	  doc_documentrevisions.File_ServerLocation,
	  doc_documentrevisions.File_SourceLocation
	From
	  usr_accounts Left Join
	  cmn_per_personinfo_2_account On usr_accounts.USR_AccountID =
	    cmn_per_personinfo_2_account.USR_Account_RefID Inner Join
	  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID Left Outer Join
	  doc_documentrevisions On cmn_per_personinfo.ProfileImage_Document_RefID =
	    doc_documentrevisions.Document_RefID And
	    doc_documentrevisions.IsLastRevision = 1
	Where
	  usr_accounts.USR_AccountID = @UserAccountID And
	  usr_accounts.IsDeleted = 0
	Group By
	  usr_accounts.Username, doc_documentrevisions.File_ServerLocation,
	  doc_documentrevisions.File_SourceLocation,
	  doc_documentrevisions.IsLastRevision

  