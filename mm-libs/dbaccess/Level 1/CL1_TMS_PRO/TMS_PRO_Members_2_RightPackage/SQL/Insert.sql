INSERT INTO 
	tms_pro_members_2_rightpackage
	(
		AssignmentID,
		ACC_RightsPackage_RefID,
		ProjectMember_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@ACC_RightsPackage_RefID,
		@ProjectMember_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)