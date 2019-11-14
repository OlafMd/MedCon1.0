UPDATE 
	hec_doctors
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	Account_RefID=@Account_RefID,
	DoctorIDNumber=@DoctorIDNumber,
	IsDoctorForFollowupTreatmentsOnly=@IsDoctorForFollowupTreatmentsOnly,
	IsTreatingChildren=@IsTreatingChildren,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_DoctorID = @HEC_DoctorID