UPDATE 
	hec_potentialobservations
SET 
	HealthcareObservationITL=@HealthcareObservationITL,
	Observation_Text_DictID=@Observation_Text,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_PotentialObservationID = @HEC_PotentialObservationID