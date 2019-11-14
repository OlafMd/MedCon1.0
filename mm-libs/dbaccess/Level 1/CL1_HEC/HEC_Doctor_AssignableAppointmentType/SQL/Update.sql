UPDATE 
	hec_doctor_assignableappointmenttypes
SET 
	Doctor_RefID=@Doctor_RefID,
	TaskTemplate_RefID=@TaskTemplate_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_Doctor_AssignableAppointmentTypeID = @HEC_Doctor_AssignableAppointmentTypeID