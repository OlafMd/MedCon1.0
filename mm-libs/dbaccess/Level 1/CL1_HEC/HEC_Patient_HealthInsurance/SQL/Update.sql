UPDATE 
	hec_patient_healthinsurances
SET 
	HealthInsurance_Number=@HealthInsurance_Number,
	HealthInsurance_State_RefID=@HealthInsurance_State_RefID,
	Patient_RefID=@Patient_RefID,
	HIS_HealthInsurance_Company_RefID=@HIS_HealthInsurance_Company_RefID,
	IsPrimary=@IsPrimary,
	SequenceNumber=@SequenceNumber,
	InsuranceStateCode=@InsuranceStateCode,
	InsuranceValidFrom=@InsuranceValidFrom,
	InsuranceValidThrough=@InsuranceValidThrough,
	IsNotSelfInsured=@IsNotSelfInsured,
	IsNotSelfInsured_InsuredPersonName=@IsNotSelfInsured_InsuredPersonName,
	IsNotSelfInsured_InsuredPersonBirthday=@IsNotSelfInsured_InsuredPersonBirthday,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_HealthInsurancesID = @HEC_Patient_HealthInsurancesID