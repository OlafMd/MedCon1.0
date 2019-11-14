UPDATE 
	tms_pro_feature_2_projectmember
SET 
	Feature_RefID=@Feature_RefID,
	ProjectMember_RefID=@ProjectMember_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID