UPDATE 
	cmn_ctr_contract_defaultparameters
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Contract_RefID=@Contract_RefID,
	ParameterName=@ParameterName,
	IsStringValue=@IsStringValue,
	IfStringValue_DefaultValue=@IfStringValue_DefaultValue,
	IsNumericValue=@IsNumericValue,
	IfNumericValue_DefaultValue=@IfNumericValue_DefaultValue,
	IsBooleanValue=@IsBooleanValue,
	IfBooleanValue_DefaultValue=@IfBooleanValue_DefaultValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CTR_Contract_DefaultParameterID = @CMN_CTR_Contract_DefaultParameterID