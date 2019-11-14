UPDATE 
	cmn_currencies
SET 
	Name_DictID=@Name,
	ISO4127=@ISO4127,
	Symbol=@Symbol,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_CurrencyID = @CMN_CurrencyID