UPDATE 
	hec_medicalpractice_offeredservices
SET 
	MedicalService_RefID=@MedicalService_RefID,
	MedicalPractice_RefID=@MedicalPractice_RefID,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_MedicalPractice_OfferedServiceID = @HEC_MedicalPractice_OfferedServiceID