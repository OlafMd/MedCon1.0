UPDATE 
	tms_pro_feature_2_tag
SET 
	Tag_RefID=@Tag_RefID,
	Feature_RefID=@Feature_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID