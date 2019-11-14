INSERT INTO 
	cmn_price_values
	(
		CMN_Price_ValueID,
		Price_RefID,
		PriceValue_Currency_RefID,
		PriceValue_Amount,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_Price_ValueID,
		@Price_RefID,
		@PriceValue_Currency_RefID,
		@PriceValue_Amount,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)