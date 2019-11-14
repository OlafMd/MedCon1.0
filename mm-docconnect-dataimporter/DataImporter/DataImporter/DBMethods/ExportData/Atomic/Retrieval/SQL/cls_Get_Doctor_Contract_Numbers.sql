
    
Select
  cmn_ctr_contracts.CMN_CTR_ContractID,
  hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID As ContractAssignment,
  hec_crt_insurancetobrokercontract_participatingdoctors.ValidFrom As
  ValidFrom,
  hec_crt_insurancetobrokercontract_participatingdoctors.ValidThrough As
  ValidThrough,
  hec_crt_insurancetobrokercontracts.Tenant_RefID As Tenant_RefID1,
  hec_crt_insurancetobrokercontracts.IsDeleted As IsDeleted1,
  hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID As
  Tenant_RefID2,
  hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted As
  IsDeleted2,
  hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID,
  cmn_ctr_contracts.ContractName,
  cmn_ctr_contracts.IsDeleted,
  cmn_ctr_contracts.Tenant_RefID
From
  hec_crt_insurancetobrokercontract_participatingdoctors Inner Join
  hec_crt_insurancetobrokercontracts
    On
    hec_crt_insurancetobrokercontract_participatingdoctors.InsuranceToBrokerContract_RefID = hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID Inner Join
  cmn_ctr_contracts On cmn_ctr_contracts.CMN_CTR_ContractID =
    hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID
Where
  hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
  hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
  hec_crt_insurancetobrokercontract_participatingdoctors.Tenant_RefID =
  @TenantID And
  hec_crt_insurancetobrokercontract_participatingdoctors.IsDeleted = 0 And
  hec_crt_insurancetobrokercontract_participatingdoctors.Doctor_RefID =
  @DoctorID And
  cmn_ctr_contracts.IsDeleted = 0 And
  cmn_ctr_contracts.Tenant_RefID = @TenantID
	
  