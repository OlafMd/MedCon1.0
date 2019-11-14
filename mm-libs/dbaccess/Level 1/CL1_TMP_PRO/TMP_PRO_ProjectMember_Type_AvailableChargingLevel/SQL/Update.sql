UPDATE 
	tmp_pro_projectmember_type_availablecharginglevels
SET 
	ProjectMember_Type_RefID=@ProjectMember_Type_RefID,
	ChargingLevel_RefID=@ChargingLevel_RefID,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID = @TMP_PRO_ProjectMember_Type_AvailableChargingLevelsID