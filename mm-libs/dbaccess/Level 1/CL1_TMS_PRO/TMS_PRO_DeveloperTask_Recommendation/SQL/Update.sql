UPDATE 
	tms_pro_developertask_recommendations
SET 
	DeveloperTask_RefID=@DeveloperTask_RefID,
	RecommendedBy_ProjectMember_RefID=@RecommendedBy_ProjectMember_RefID,
	RecommendedTo_ProjectMember_RefID=@RecommendedTo_ProjectMember_RefID,
	Description=@Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTask_RecommendationID = @TMS_PRO_DeveloperTask_RecommendationID