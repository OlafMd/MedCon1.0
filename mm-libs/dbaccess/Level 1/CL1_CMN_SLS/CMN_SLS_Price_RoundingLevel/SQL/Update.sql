UPDATE 
	cmn_sls_price_roundinglevels
SET 
	Rounding_RefID=@Rounding_RefID,
	RoundingAmount=@RoundingAmount,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_Price_RoundingLevelID = @CMN_SLS_Price_RoundingLevelID