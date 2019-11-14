INSERT INTO 
	cmn_ctr_contract_parameters
	(
		CMN_CTR_Contract_ParameterID,
		Contract_DefaultParameter_RefID,
		Contract_RefID,
		ParameterName,
		IsStringValue,
		IfStringValue_Value,
		IsNumericValue,
		IfNumericValue_Value,
		IsBooleanValue,
		IfBooleanValue_Value,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_CTR_Contract_ParameterID,
		@Contract_DefaultParameter_RefID,
		@Contract_RefID,
		@ParameterName,
		@IsStringValue,
		@IfStringValue_Value,
		@IsNumericValue,
		@IfNumericValue_Value,
		@IsBooleanValue,
		@IfBooleanValue_Value,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)