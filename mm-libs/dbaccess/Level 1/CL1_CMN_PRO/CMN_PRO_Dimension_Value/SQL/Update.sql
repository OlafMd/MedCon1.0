UPDATE 
	cmn_pro_dimension_values
SET 
	Dimensions_RefID=@Dimensions_RefID,
	DimensionValue_Text_DictID=@DimensionValue_Text,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_Dimension_ValueID = @CMN_PRO_Dimension_ValueID