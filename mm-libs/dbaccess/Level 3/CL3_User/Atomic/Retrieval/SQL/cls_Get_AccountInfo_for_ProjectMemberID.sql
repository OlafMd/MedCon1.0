
	Select
		  usr_accounts.Username,
		  usr_accounts.BusinessParticipant_RefID,
		  usr_accounts.USR_AccountID,
		  usr_accounts.AccountType,
		  usr_accounts.DefaultLanguage_RefID
		From
		  tms_pro_projectmembers Inner Join
		  usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
		    usr_accounts.USR_AccountID
		Where
		  usr_accounts.IsDeleted = 0 And
		  tms_pro_projectmembers.TMS_PRO_ProjectMemberID=@ProjectMember

  