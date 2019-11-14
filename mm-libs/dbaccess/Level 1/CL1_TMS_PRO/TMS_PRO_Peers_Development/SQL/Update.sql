UPDATE 
	tms_pro_peers_development
SET 
	DeveloperTask_RefID=@DeveloperTask_RefID,
	ProjectMember_RefID=@ProjectMember_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID