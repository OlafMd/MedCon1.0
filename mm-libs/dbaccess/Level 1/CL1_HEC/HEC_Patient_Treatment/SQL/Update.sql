UPDATE 
	hec_patient_treatment
SET 
	PotentialTreatment_RefID=@PotentialTreatment_RefID,
	TreatmentITL=@TreatmentITL,
	IsTreatmentFollowup=@IsTreatmentFollowup,
	IfTreatmentFollowup_FromTreatment_RefID=@IfTreatmentFollowup_FromTreatment_RefID,
	TreatmentPractice_RefID=@TreatmentPractice_RefID,
	IsTreatmentPerformed=@IsTreatmentPerformed,
	IfTreatmentPerformed_ByDoctor_RefID=@IfTreatmentPerformed_ByDoctor_RefID,
	IfTreatmentPerformed_Date=@IfTreatmentPerformed_Date,
	IsScheduled=@IsScheduled,
	IfSheduled_Date=@IfSheduled_Date,
	IfSheduled_ForDoctor_RefID=@IfSheduled_ForDoctor_RefID,
	IsTreatmentBilled=@IsTreatmentBilled,
	IfTreatmentBilled_Date=@IfTreatmentBilled_Date,
	Treatment_Comment=@Treatment_Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_TreatmentID = @HEC_Patient_TreatmentID