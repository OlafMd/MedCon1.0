INSERT INTO 
	hec_crt_insurancetobrokercontract_participatingpatients
	(
		HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,
		InsuranceToBrokerContract_RefID,
		Patient_RefID,
		ValidFrom,
		ValidThrough,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID,
		@InsuranceToBrokerContract_RefID,
		@Patient_RefID,
		@ValidFrom,
		@ValidThrough,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)