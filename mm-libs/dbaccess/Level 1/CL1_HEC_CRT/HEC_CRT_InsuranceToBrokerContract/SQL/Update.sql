UPDATE 
	hec_crt_insurancetobrokercontracts
SET 
	Ext_CMN_CTR_Contract_RefID=@Ext_CMN_CTR_Contract_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CRT_InsuranceToBrokerContractID = @HEC_CRT_InsuranceToBrokerContractID