UPDATE 
	hec_patient_referrals
SET 
	Patient_RefID=@Patient_RefID,
	ReferredBy_Doctor_RefID=@ReferredBy_Doctor_RefID,
	DateOfReferral=@DateOfReferral,
	ReferralTo_MedicalPracticeType_RefID=@ReferralTo_MedicalPracticeType_RefID,
	PatientEffectivelyWentTo_MedicalPractice_RefID=@PatientEffectivelyWentTo_MedicalPractice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_Patient_ReferralID = @HEC_Patient_ReferralID