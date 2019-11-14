
    Select
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID As ContractID,
      hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID As InsuranceToBrokerContractID
    From
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
      Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses On hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID = @DiagnoseID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0
      Inner Join hec_crt_insurancetobrokercontracts On hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
    Where
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID = @DrugID And
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 And
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID = @TenantID 
    Group By
      hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID
	