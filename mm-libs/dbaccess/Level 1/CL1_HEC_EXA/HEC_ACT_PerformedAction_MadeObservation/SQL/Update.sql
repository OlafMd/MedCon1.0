UPDATE 
	hec_act_performedaction_madeobservations
SET 
	HEC_ACT_PerformedAction_RefID=@HEC_ACT_PerformedAction_RefID,
	PotentialObservation_RefID=@PotentialObservation_RefID,
	Relevant_PatientDiagnosis_RefID=@Relevant_PatientDiagnosis_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PerformedAction_ObservationID = @HEC_ACT_PerformedAction_ObservationID