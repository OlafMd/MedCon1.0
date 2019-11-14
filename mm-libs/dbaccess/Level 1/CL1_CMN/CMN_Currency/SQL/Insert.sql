INSERT INTO 
	cmn_currencies
	(
		CMN_CurrencyID,
		Name_DictID,
		ISO4127,
		Symbol,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CurrencyID,
		@Name,
		@ISO4127,
		@Symbol,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)