UPDATE 
	cmn_per_personinfo_correspondences
SET 
	CMN_PER_PersonInfo_RefID=@CMN_PER_PersonInfo_RefID,
	CorrespondenceType_RefID=@CorrespondenceType_RefID,
	CorrespondenceText=@CorrespondenceText,
	IsDefaultCorrespondence=@IsDefaultCorrespondence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PER_PersonInfo_CorrespondenceID = @CMN_PER_PersonInfo_CorrespondenceID