UPDATE 
	cmn_pro_dimensions
SET 
	Product_RefID=@Product_RefID,
	Abbreviation=@Abbreviation,
	DimensionName_DictID=@DimensionName,
	OrderSequence=@OrderSequence,
	IsDimensionTemplate=@IsDimensionTemplate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_DimensionID = @CMN_PRO_DimensionID