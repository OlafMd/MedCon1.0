UPDATE 
	hec_patient_prescription_documents
SET 
	PrescriptionHeader_RefID=@PrescriptionHeader_RefID,
	Document_RefID=@Document_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Prescription_DocumentID = @HEC_Patient_Prescription_DocumentID