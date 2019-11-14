INSERT INTO 
	cmn_per_personinfo_correspondences
	(
		CMN_PER_PersonInfo_CorrespondenceID,
		CMN_PER_PersonInfo_RefID,
		CorrespondenceType_RefID,
		CorrespondenceText,
		IsDefaultCorrespondence,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PER_PersonInfo_CorrespondenceID,
		@CMN_PER_PersonInfo_RefID,
		@CorrespondenceType_RefID,
		@CorrespondenceText,
		@IsDefaultCorrespondence,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)