UPDATE 
	hec_dia_frequentpotentialdiagnoses
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	MedicalPractice_RefID=@MedicalPractice_RefID,
	NumberOfOccurences=@NumberOfOccurences,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DIA_FrequentPotentialDiagnosisID = @HEC_DIA_FrequentPotentialDiagnosisID