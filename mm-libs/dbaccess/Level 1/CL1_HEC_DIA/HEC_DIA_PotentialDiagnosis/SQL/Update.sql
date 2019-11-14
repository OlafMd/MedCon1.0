UPDATE 
	hec_dia_potentialdiagnoses
SET 
	PotentialDiagnosisITL=@PotentialDiagnosisITL,
	PotentialDiagnosis_Name_DictID=@PotentialDiagnosis_Name,
	PotentialDiagnosis_Description_DictID=@PotentialDiagnosis_Description,
	ICD10_Code=@ICD10_Code,
	IsHospitalTransmissionIndicated=@IsHospitalTransmissionIndicated,
	IsRefferalIndicated=@IsRefferalIndicated,
	IsAllergy=@IsAllergy,
	IsRefferalIndicated_PracticeType_RefID=@IsRefferalIndicated_PracticeType_RefID,
	DefaultTimeUntillDeactivation_InDays=@DefaultTimeUntillDeactivation_InDays,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_PotentialDiagnosisID = @HEC_DIA_PotentialDiagnosisID