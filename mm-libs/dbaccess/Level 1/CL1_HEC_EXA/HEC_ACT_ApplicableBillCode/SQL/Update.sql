UPDATE 
	hec_act_applicablebillcodes
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	HEC_BIL_PotentialCode_RefID=@HEC_BIL_PotentialCode_RefID,
	Proposed_ValueMultiplicator=@Proposed_ValueMultiplicator,
	Proposed_ValueMultiplicator_Comment=@Proposed_ValueMultiplicator_Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_ApplicableBillCodeID = @HEC_ACT_ApplicableBillCodeID