UPDATE 
	hec_medicalpractise_availablepharmaciesforordering
SET 
	HEC_MedicalPractise_RefID=@HEC_MedicalPractise_RefID,
	HEC_Pharmacy_RefID=@HEC_Pharmacy_RefID,
	SequenceNumber=@SequenceNumber,
	IsDefault=@IsDefault,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_MedicalPractise_AvailablePharmaciesForOrderingID = @HEC_MedicalPractise_AvailablePharmaciesForOrderingID