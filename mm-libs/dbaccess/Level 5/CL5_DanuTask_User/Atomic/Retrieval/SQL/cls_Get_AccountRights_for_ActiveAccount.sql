
	Select
	  usr_account_2_functionlevelright.FunctionLevelRight_RefID
	From
	  usr_account_2_functionlevelright
	Where
	  usr_account_2_functionlevelright.Account_RefID = @AccountID And
	  usr_account_2_functionlevelright.IsDeleted = 0
  