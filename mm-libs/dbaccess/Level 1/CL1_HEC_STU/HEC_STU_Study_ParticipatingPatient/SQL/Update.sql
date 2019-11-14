UPDATE 
	hec_stu_study_participatingpatients
SET 
	Study_RefID=@Study_RefID,
	Patient_RefID=@Patient_RefID,
	Participation_DateOfSigning=@Participation_DateOfSigning,
	Participation_Comment=@Participation_Comment,
	ParticipationPolicyInternalNumber=@ParticipationPolicyInternalNumber,
	HasFulfilledParticipationPolicyRequirements=@HasFulfilledParticipationPolicyRequirements,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_STU_Study_ParticipatingPatientID = @HEC_STU_Study_ParticipatingPatientID