UPDATE 
	hec_dia_typicalpotentialobservations
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	PotentialObservation_RefID=@PotentialObservation_RefID,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DIA_TypicalPotentialObservationID = @HEC_DIA_TypicalPotentialObservationID