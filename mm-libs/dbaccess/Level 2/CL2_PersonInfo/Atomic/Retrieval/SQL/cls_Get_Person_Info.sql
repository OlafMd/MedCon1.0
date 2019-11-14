
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_per_personinfo.PrimaryEmail,
	  cmn_per_personinfo.Title,
	  cmn_per_personinfo.Salutation_General,
	  cmn_per_personinfo.Salutation_Letter,
	  cmn_per_personinfo.Gender
	From
	  cmn_per_personinfo Inner Join
	  cmn_per_personinfo_2_account On cmn_per_personinfo.CMN_PER_PersonInfoID =
	    cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID
	Where
	  cmn_per_personinfo_2_account.USR_Account_RefID = @Account_ID And
	  cmn_per_personinfo_2_account.Tenant_RefID = @Tenant_ID And
	  cmn_per_personinfo.IsDeleted = 0
  