INSERT INTO 
	hec_act_performedactions
	(
		HEC_ACT_PerformedActionID,
		HealthcarePerformedActionITL,
		Patient_RefID,
		IsPerformed_Internally,
		IfPerformedInternaly_ResponsibleBusinessParticipant_RefID,
		IsPerformed_Externally,
		IsPerformed_MedicalPractice_RefID,
		IfPerformed_MedicalPracticeType_RefID,
		IfPerformed_DateOfAction_Year,
		IfPerformed_DateOfAction_Month,
		IfPerformed_DateOfAction_Day,
		IfPerfomed_DateOfAction,
		IsFollowupPerformedAction,
		IsFollowupPerformed_PreviousPerformedAction_RefID,
		IsFinalized,
		IM_IfPerformed_MedicalPractice_Name,
		IM_IfPerformed_MedicalPracticeType_Name,
		IM_IfPerformed_ResponsibleBP_FullName,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_ACT_PerformedActionID,
		@HealthcarePerformedActionITL,
		@Patient_RefID,
		@IsPerformed_Internally,
		@IfPerformedInternaly_ResponsibleBusinessParticipant_RefID,
		@IsPerformed_Externally,
		@IsPerformed_MedicalPractice_RefID,
		@IfPerformed_MedicalPracticeType_RefID,
		@IfPerformed_DateOfAction_Year,
		@IfPerformed_DateOfAction_Month,
		@IfPerformed_DateOfAction_Day,
		@IfPerfomed_DateOfAction,
		@IsFollowupPerformedAction,
		@IsFollowupPerformed_PreviousPerformedAction_RefID,
		@IsFinalized,
		@IM_IfPerformed_MedicalPractice_Name,
		@IM_IfPerformed_MedicalPracticeType_Name,
		@IM_IfPerformed_ResponsibleBP_FullName,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)