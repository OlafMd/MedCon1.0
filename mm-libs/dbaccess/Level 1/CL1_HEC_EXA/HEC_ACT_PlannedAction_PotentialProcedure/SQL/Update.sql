UPDATE 
	hec_act_plannedaction_potentialprocedures
SET 
	PlannedAction_RefID=@PlannedAction_RefID,
	PotentialProcedure_RefID=@PotentialProcedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PlannedAction_PotentialProcedureID = @HEC_ACT_PlannedAction_PotentialProcedureID