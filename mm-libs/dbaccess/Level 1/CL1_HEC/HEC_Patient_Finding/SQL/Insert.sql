INSERT INTO 
	hec_patient_findings
	(
		HEC_Patient_FindingID,
		Patient_RefID,
		DateOfFindings,
		MedicalPractice_RefID,
		MedicalPracticeType_RefID,
		UndersigningDoctor_RefID,
		IsFindingFromReferral,
		IfFindingFromReferral_Referral_RefID,
		IsFindingFromProcedure,
		IfFindingFromProcedure_ActionProcedure_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_Patient_FindingID,
		@Patient_RefID,
		@DateOfFindings,
		@MedicalPractice_RefID,
		@MedicalPracticeType_RefID,
		@UndersigningDoctor_RefID,
		@IsFindingFromReferral,
		@IfFindingFromReferral_Referral_RefID,
		@IsFindingFromProcedure,
		@IfFindingFromProcedure_ActionProcedure_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)