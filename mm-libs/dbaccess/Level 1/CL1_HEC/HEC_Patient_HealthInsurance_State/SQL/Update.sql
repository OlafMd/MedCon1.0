UPDATE 
	hec_patient_healthinsurance_states
SET 
	HealthInsuranceState_Abbreviation=@HealthInsuranceState_Abbreviation,
	HealthInsuranceState_Name_DictID=@HealthInsuranceState_Name,
	HealthInsuranceState_Description_DictID=@HealthInsuranceState_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_HealthInsurance_StateID = @HEC_Patient_HealthInsurance_StateID