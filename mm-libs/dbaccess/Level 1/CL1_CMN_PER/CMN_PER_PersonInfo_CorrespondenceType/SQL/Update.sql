UPDATE 
	cmn_per_personinfo_correspondencetypes
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	DisplayName=@DisplayName,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PER_PersonInfo_CorrespondenceTypeID = @CMN_PER_PersonInfo_CorrespondenceTypeID