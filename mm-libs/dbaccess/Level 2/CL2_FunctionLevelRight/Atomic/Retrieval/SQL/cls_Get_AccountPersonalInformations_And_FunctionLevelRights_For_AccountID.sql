
	Select
	  USR_Account_FunctionLevelRights.AssignmentID As
	  FunctionLevelRight_AssignmentID,
	  USR_Account_FunctionLevelRights.USR_Account_FunctionLevelRightID,
	  USR_Account_FunctionLevelRights.FunctionLevelRight_RefID,
	  USR_Account_FunctionLevelRights.RightName,
	  USR_Account_FunctionLevelRights.FunctionLevelRights_Group_RefID,
	  usr_accounts.DefaultLanguage_RefID,
	  usr_accounts.Username,
	  usr_accounts.BusinessParticipant_RefID,
	  usr_accounts.AccountType,
	  CMN_PER_PersonInfo_2_Account.AssignmentID As PersonalInfo_AssignmentID,
	  CMN_PER_PersonInfo_2_Account.CMN_PER_PersonInfoID,
	  CMN_PER_PersonInfo_2_Account.Salutation_Letter,
	  CMN_PER_PersonInfo_2_Account.Salutation_General,
	  CMN_PER_PersonInfo_2_Account.Address_RefID,
	  CMN_PER_PersonInfo_2_Account.BirthDate,
	  CMN_PER_PersonInfo_2_Account.ProfileImage_Document_RefID,
	  CMN_PER_PersonInfo_2_Account.Title,
	  CMN_PER_PersonInfo_2_Account.PrimaryEmail,
	  CMN_PER_PersonInfo_2_Account.LastName,
	  CMN_PER_PersonInfo_2_Account.FirstName,
	  usr_accounts.USR_AccountID,
	  usr_accounts.Tenant_RefID
	From
	  usr_accounts Left Join
	  (Select
	    usr_account_2_functionlevelright.AssignmentID,
	    usr_account_2_functionlevelright.FunctionLevelRight_RefID,
	    usr_account_2_functionlevelright.Account_RefID,
	    usr_account_functionlevelrights.Tenant_RefID As Tenant_RefID1,
	    usr_account_functionlevelrights.RightName,
	    usr_account_functionlevelrights.FunctionLevelRights_Group_RefID,
	    usr_account_functionlevelrights.USR_Account_FunctionLevelRightID
	  From
	    usr_account_functionlevelrights Inner Join
	    usr_account_2_functionlevelright
	      On usr_account_2_functionlevelright.FunctionLevelRight_RefID =
	      usr_account_functionlevelrights.USR_Account_FunctionLevelRightID
	  Where
	    usr_account_functionlevelrights.IsDeleted = 0 And
	    usr_account_2_functionlevelright.IsDeleted =
	    0) USR_Account_FunctionLevelRights On usr_accounts.USR_AccountID =
	    USR_Account_FunctionLevelRights.Account_RefID Inner Join
	  (Select
	    cmn_per_personinfo_2_account.Tenant_RefID,
	    cmn_per_personinfo_2_account.USR_Account_RefID,
	    cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID,
	    cmn_per_personinfo_2_account.AssignmentID,
	    cmn_per_personinfo.Salutation_Letter,
	    cmn_per_personinfo.Salutation_General,
	    cmn_per_personinfo.Tenant_RefID As Tenant_RefID1,
	    cmn_per_personinfo.Address_RefID,
	    cmn_per_personinfo.BirthDate,
	    cmn_per_personinfo.ProfileImage_Document_RefID,
	    cmn_per_personinfo.Title,
	    cmn_per_personinfo.PrimaryEmail,
	    cmn_per_personinfo.LastName,
	    cmn_per_personinfo.FirstName,
	    cmn_per_personinfo.CMN_PER_PersonInfoID
	  From
	    cmn_per_personinfo_2_account Inner Join
	    cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID
	      = cmn_per_personinfo.CMN_PER_PersonInfoID
	  Where
	    cmn_per_personinfo_2_account.IsDeleted = 0 And
	    cmn_per_personinfo.IsDeleted = 0) CMN_PER_PersonInfo_2_Account
	    On CMN_PER_PersonInfo_2_Account.USR_Account_RefID =
	    usr_accounts.USR_AccountID
	Where
	  usr_accounts.USR_AccountID = @AccountID And
	  usr_accounts.Tenant_RefID = @TenantID And
	  usr_accounts.IsDeleted = 0
  