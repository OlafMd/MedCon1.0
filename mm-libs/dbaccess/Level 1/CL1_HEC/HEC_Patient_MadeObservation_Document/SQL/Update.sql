UPDATE 
	hec_patient_madeobservation_documents
SET 
	HEC_Patient_MadeObservation_RefID=@HEC_Patient_MadeObservation_RefID,
	Document_RefID=@Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_Patient_MadeObservation_DocumentID = @HEC_Patient_MadeObservation_DocumentID