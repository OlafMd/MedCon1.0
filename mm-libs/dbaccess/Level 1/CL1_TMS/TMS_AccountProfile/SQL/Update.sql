UPDATE 
	tms_accountprofiles
SET 
	Account_RefID=@Account_RefID,
	Description=@Description,
	AutomaticTaskPrioritization=@AutomaticTaskPrioritization,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_AccountProfileID = @TMS_AccountProfileID