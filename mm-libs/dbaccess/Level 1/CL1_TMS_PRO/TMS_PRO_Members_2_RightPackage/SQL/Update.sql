UPDATE 
	tms_pro_members_2_rightpackage
SET 
	ACC_RightsPackage_RefID=@ACC_RightsPackage_RefID,
	ProjectMember_RefID=@ProjectMember_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID