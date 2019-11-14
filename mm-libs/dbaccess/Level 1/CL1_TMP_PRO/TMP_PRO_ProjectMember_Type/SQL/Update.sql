UPDATE 
	tmp_pro_projectmember_types
SET 
	ProjectMemberType_Name_DictID=@ProjectMemberType_Name,
	Color=@Color,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMP_PRO_ProjectMember_TypeID = @TMP_PRO_ProjectMember_TypeID