UPDATE 
	hec_his_healthinsurance_companies
SET 
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	HealthInsurance_IKNumber=@HealthInsurance_IKNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_HealthInsurance_CompanyID = @HEC_HealthInsurance_CompanyID