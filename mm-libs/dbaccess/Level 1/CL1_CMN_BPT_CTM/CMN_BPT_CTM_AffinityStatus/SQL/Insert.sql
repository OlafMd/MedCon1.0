INSERT INTO 
	cmn_bpt_ctm_affinitystatuses
	(
		CMN_BPT_CTM_AffinityStatusID,
		AffinityStatus_Name_DictID,
		AffinityStatus_Description_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_CTM_AffinityStatusID,
		@AffinityStatus_Name,
		@AffinityStatus_Description,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)