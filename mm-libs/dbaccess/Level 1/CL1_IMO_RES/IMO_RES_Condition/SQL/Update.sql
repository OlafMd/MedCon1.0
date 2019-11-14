UPDATE 
	imo_res_conditions
SET 
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_RES_ConditionID = @IMO_RES_ConditionID