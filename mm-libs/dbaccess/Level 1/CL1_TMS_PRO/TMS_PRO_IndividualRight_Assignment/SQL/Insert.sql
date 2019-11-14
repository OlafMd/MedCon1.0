INSERT INTO 
	tms_pro_individualright_assignments
	(
		TMS_PRO_IndividualRight_AssignmentID,
		ACC_Right_RefID,
		ProjectMember_RefID,
		IsRevocation,
		IsAssignment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_IndividualRight_AssignmentID,
		@ACC_Right_RefID,
		@ProjectMember_RefID,
		@IsRevocation,
		@IsAssignment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)