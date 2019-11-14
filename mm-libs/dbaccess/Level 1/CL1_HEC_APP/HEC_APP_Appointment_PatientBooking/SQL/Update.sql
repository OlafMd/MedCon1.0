UPDATE 
	hec_app_appointment_patientbookings
SET 
	Appointment_RefID=@Appointment_RefID,
	Patient_RefID=@Patient_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_APP_Appointment_PatientBookingID = @HEC_APP_Appointment_PatientBookingID