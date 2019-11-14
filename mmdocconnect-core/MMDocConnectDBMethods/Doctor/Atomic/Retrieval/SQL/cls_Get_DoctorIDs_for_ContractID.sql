
Select
  hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID As DoctorID
From
  hec_crt_insurancetobrokercontract_participatingdoctors Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontracts.IsDeleted = 0
Where
  hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID =
  @TenantID And
  hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID
	