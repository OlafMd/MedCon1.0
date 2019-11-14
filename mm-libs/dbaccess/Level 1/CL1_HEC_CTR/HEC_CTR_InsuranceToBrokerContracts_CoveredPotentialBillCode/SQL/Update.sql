UPDATE 
	hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
SET 
	InsuranceToBrokerContract_RefID=@InsuranceToBrokerContract_RefID,
	PotentialBillCode_RefID=@PotentialBillCode_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = @HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID