UPDATE 
	tms_pro_projectmembers
SET 
	Project_RefID=@Project_RefID,
	USR_Account_RefID=@USR_Account_RefID,
	ProjectMember_Type_RefID=@ProjectMember_Type_RefID,
	IsOwner=@IsOwner,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID,
	ChargingLevel_RefID=@ChargingLevel_RefID
WHERE 
	TMS_PRO_ProjectMemberID = @TMS_PRO_ProjectMemberID