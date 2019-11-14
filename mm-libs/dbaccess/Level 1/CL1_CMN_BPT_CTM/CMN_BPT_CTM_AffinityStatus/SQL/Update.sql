UPDATE 
	cmn_bpt_ctm_affinitystatuses
SET 
	AffinityStatus_Name_DictID=@AffinityStatus_Name,
	AffinityStatus_Description_DictID=@AffinityStatus_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_CTM_AffinityStatusID = @CMN_BPT_CTM_AffinityStatusID