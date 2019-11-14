UPDATE 
	hec_patient_findings
SET 
	Patient_RefID=@Patient_RefID,
	DateOfFindings=@DateOfFindings,
	MedicalPractice_RefID=@MedicalPractice_RefID,
	MedicalPracticeType_RefID=@MedicalPracticeType_RefID,
	UndersigningDoctor_RefID=@UndersigningDoctor_RefID,
	IsFindingFromReferral=@IsFindingFromReferral,
	IfFindingFromReferral_Referral_RefID=@IfFindingFromReferral_Referral_RefID,
	IsFindingFromProcedure=@IsFindingFromProcedure,
	IfFindingFromProcedure_ActionProcedure_RefID=@IfFindingFromProcedure_ActionProcedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_FindingID = @HEC_Patient_FindingID