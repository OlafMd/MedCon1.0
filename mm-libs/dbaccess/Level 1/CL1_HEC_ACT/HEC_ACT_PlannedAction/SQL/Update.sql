UPDATE 
	hec_act_plannedactions
SET 
	HealthcarePlannedActionITL=@HealthcarePlannedActionITL,
	Patient_RefID=@Patient_RefID,
	Appointment_RefID=@Appointment_RefID,
	PlannedFor_Date=@PlannedFor_Date,
	IsPerformed=@IsPerformed,
	IfPerformed_PerformedAction_RefID=@IfPerformed_PerformedAction_RefID,
	IsToBePerformedExternally=@IsToBePerformedExternally,
	MedicalPractice_RefID=@MedicalPractice_RefID,
	MedicalPracticeType_RefID=@MedicalPracticeType_RefID,
	ToBePerformedBy_BusinessParticipant_RefID=@ToBePerformedBy_BusinessParticipant_RefID,
	IsPlannedFollowup=@IsPlannedFollowup,
	IfPlannedFollowup_PreviousAction_RefID=@IfPlannedFollowup_PreviousAction_RefID,
	IsCancelled=@IsCancelled,
	IfCancelled_Reason=@IfCancelled_Reason,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_ACT_PlannedActionID = @HEC_ACT_PlannedActionID