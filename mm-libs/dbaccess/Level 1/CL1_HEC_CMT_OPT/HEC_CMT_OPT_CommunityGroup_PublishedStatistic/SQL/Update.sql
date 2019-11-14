UPDATE 
	hec_cmt_opt_communitygroup_publishedstatistics
SET 
	CommunityGroup_RefID=@CommunityGroup_RefID,
	Version_Internal=@Version_Internal,
	Version_Display=@Version_Display,
	PublishDate=@PublishDate,
	PublicDownloadURL=@PublicDownloadURL,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CMT_OPT_CommunityGroup_PublishedStatisticID = @HEC_CMT_OPT_CommunityGroup_PublishedStatisticID