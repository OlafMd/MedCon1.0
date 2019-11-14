UPDATE 
	cmn_prices
SET 
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PriceID = @CMN_PriceID