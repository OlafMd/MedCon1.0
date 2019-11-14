
Select
  hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID As DoctorID,
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As ContractID
From
  hec_crt_insurancetobrokercontract_participatingpatients Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And 
    hec_crt_insurancetobrokercontracts.IsDeleted = 0 And 
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID Inner Join
  hec_crt_insurancetobrokercontract_participatingdoctors
    On
    hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID And 
    hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID = @TenantID And 
    hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0
Where
  hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientID And
  hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
  hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
	