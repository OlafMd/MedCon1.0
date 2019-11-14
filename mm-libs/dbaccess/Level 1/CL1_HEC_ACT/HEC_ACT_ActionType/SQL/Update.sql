UPDATE 
	hec_act_actiontype
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ActionType_Name_DictID=@ActionType_Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_ActionTypeID = @HEC_ACT_ActionTypeID