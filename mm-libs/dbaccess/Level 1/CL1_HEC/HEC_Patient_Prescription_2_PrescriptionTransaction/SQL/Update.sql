UPDATE 
	hec_patient_prescription_2_prescriptiontransaction
SET 
	HEC_Patient_Prescription_Header_RefID=@HEC_Patient_Prescription_Header_RefID,
	HEC_Patient_Prescription_Transaction_RefID=@HEC_Patient_Prescription_Transaction_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID