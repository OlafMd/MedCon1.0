UPDATE 
	hec_act_performedaction_referral_2_procedure
SET 
	HEC_ACT_PerformedAction_Referral_RefID=@HEC_ACT_PerformedAction_Referral_RefID,
	HEC_ACT_PerformedAction_Procedure_RefID=@HEC_ACT_PerformedAction_Procedure_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID