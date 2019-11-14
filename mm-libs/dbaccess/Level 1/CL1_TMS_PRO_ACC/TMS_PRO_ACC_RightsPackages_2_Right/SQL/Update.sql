UPDATE 
	tms_pro_acc_rightspackages_2_rights
SET 
	RightsPackage_RefID=@RightsPackage_RefID,
	Right_RefID=@Right_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID