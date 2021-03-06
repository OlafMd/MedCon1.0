INSERT INTO 
	hec_dia_potentialdiagnosis_prioritysequence
	(
		HEC_DIA_PotentialDiagnosis_PrioritySequenceID,
		PotentialDiagnosis_RefID,
		PotentialDiagnosis_Catalog_RefID,
		PriorityNumber_Manual,
		PriorityNumber_Automatic,
		Tenant_RefID,
		Creation_Timestamp,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_DIA_PotentialDiagnosis_PrioritySequenceID,
		@PotentialDiagnosis_RefID,
		@PotentialDiagnosis_Catalog_RefID,
		@PriorityNumber_Manual,
		@PriorityNumber_Automatic,
		@Tenant_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Modification_Timestamp
	)