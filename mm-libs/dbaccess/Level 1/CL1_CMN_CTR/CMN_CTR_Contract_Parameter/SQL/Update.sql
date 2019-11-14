UPDATE 
	cmn_ctr_contract_parameters
SET 
	Contract_DefaultParameter_RefID=@Contract_DefaultParameter_RefID,
	Contract_RefID=@Contract_RefID,
	ParameterName=@ParameterName,
	IsStringValue=@IsStringValue,
	IfStringValue_Value=@IfStringValue_Value,
	IsNumericValue=@IsNumericValue,
	IfNumericValue_Value=@IfNumericValue_Value,
	IsBooleanValue=@IsBooleanValue,
	IfBooleanValue_Value=@IfBooleanValue_Value,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_CTR_Contract_ParameterID = @CMN_CTR_Contract_ParameterID