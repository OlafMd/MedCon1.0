UPDATE 
	hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
SET 
	InsuranceToBrokerContract_RefID=@InsuranceToBrokerContract_RefID,
	HealthcareProduct_RefID=@HealthcareProduct_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID = @HEC_CTR_InsuranceToBrokerContracts_CoveredHealthcareProductID