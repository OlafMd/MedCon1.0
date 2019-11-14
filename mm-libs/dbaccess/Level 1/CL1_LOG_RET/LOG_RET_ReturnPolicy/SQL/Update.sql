UPDATE 
	log_ret_returnpolicies
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ReturnPolicy_Abbreviation=@ReturnPolicy_Abbreviation,
	ReturnPolicy_Reason_DictID=@ReturnPolicy_Reason,
	ReturnPolicy_Cost_RefID=@ReturnPolicy_Cost_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	LOG_RET_ReturnPolicyID = @LOG_RET_ReturnPolicyID