UPDATE 
	hec_act_performedaction_procedures
SET 
	ActionProcedureITL=@ActionProcedureITL,
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	PotentialProcedure_RefID=@PotentialProcedure_RefID,
	PotentialProcedure_Name=@PotentialProcedure_Name,
	PotentialProcedure_Code=@PotentialProcedure_Code,
	PotentialProcedure_Localization_RefID=@PotentialProcedure_Localization_RefID,
	PotentialProcedure_Localization_Name=@PotentialProcedure_Localization_Name,
	PotentialProcedure_Localization_Code=@PotentialProcedure_Localization_Code,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_ProcedureID = @HEC_ACT_PerformedAction_ProcedureID