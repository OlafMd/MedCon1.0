UPDATE 
	cmn_price_values
SET 
	Price_RefID=@Price_RefID,
	PriceValue_Currency_RefID=@PriceValue_Currency_RefID,
	PriceValue_Amount=@PriceValue_Amount,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_Price_ValueID = @CMN_Price_ValueID