UPDATE 
	tms_pro_peers_businesstask
SET 
	BusinessTask_RefID=@BusinessTask_RefID,
	ProjectMember_RefID=@ProjectMember_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID