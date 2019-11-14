UPDATE 
	hec_patient_finding_documents
SET 
	Patient_Finding_RefID=@Patient_Finding_RefID,
	Document_RefID=@Document_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_Patient_Finding_DocumentID = @HEC_Patient_Finding_DocumentID