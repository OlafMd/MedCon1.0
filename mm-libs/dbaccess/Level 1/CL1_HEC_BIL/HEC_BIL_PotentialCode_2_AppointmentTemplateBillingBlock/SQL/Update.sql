UPDATE 
	hec_bil_potentialcode_2_appointmenttemplatebillingblock
SET 
	HEC_BIL_PotentialCode_RefID=@HEC_BIL_PotentialCode_RefID,
	HEC_APP_Appointment_Template_BillingBlock_RefID=@HEC_APP_Appointment_Template_BillingBlock_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID