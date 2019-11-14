UPDATE 
	hec_crt_insurancetobrokercontract_participatingdoctors
SET 
	InsuranceToBrokerContract_RefID=@InsuranceToBrokerContract_RefID,
	Doctor_RefID=@Doctor_RefID,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID = @HEC_CRT_InsuranceToBrokerContract_ParticipatingDoctorID