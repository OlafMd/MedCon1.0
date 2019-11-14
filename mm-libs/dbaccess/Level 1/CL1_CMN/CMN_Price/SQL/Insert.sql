INSERT INTO 
	cmn_prices
	(
		CMN_PriceID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_PriceID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)