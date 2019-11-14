UPDATE 
	tms_pro_individualright_assignments
SET 
	ACC_Right_RefID=@ACC_Right_RefID,
	ProjectMember_RefID=@ProjectMember_RefID,
	IsRevocation=@IsRevocation,
	IsAssignment=@IsAssignment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_IndividualRight_AssignmentID = @TMS_PRO_IndividualRight_AssignmentID