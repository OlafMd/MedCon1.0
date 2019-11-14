UPDATE 
	hec_patient_prescription_transactions
SET 
	PerscriptionTransaction_DeliveryAddress_RefID=@PerscriptionTransaction_DeliveryAddress_RefID,
	PrescriptionTransaction_Patient_RefID=@PrescriptionTransaction_Patient_RefID,
	PrescriptionTransaction_InternalNubmer=@PrescriptionTransaction_InternalNubmer,
	PrescriptionTransaction_IsComplete=@PrescriptionTransaction_IsComplete,
	PrescriptionTransaction_RequestedDateOfDeliveryFrom=@PrescriptionTransaction_RequestedDateOfDeliveryFrom,
	PrescriptionTransaction_RequestedDateOfDeliveryTo=@PrescriptionTransaction_RequestedDateOfDeliveryTo,
	PrescriptionTransaction_CreatedByBusinessParticpant_RefID=@PrescriptionTransaction_CreatedByBusinessParticpant_RefID,
	PrescriptionTransaction_Comment=@PrescriptionTransaction_Comment,
	PrescriptionTransaction_UsePatientAddress=@PrescriptionTransaction_UsePatientAddress,
	PrescriptionTransaction_UseReceiptAddress=@PrescriptionTransaction_UseReceiptAddress,
	PrescriptionTransaction_UseParticipationPolicyAddress=@PrescriptionTransaction_UseParticipationPolicyAddress,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Prescription_TransactionID = @HEC_Patient_Prescription_TransactionID