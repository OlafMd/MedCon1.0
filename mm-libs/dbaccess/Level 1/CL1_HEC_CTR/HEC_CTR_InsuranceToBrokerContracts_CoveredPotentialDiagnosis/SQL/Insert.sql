INSERT INTO 
	hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses
	(
		HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosisID,
		InsuranceToBrokerContract_RefID,
		PotentialDiagnosis_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialDiagnosisID,
		@InsuranceToBrokerContract_RefID,
		@PotentialDiagnosis_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)