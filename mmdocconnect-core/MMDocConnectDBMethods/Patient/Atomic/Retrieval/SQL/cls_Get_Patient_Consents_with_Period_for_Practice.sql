
    Select
      hec_patient_medicalpractices.HEC_Patient_RefID,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidFrom,
      hec_crt_insurancetobrokercontract_participatingpatients.ValidThrough,
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.HealthcareProduct_RefID,
      hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID
    From
      hec_patient_medicalpractices Inner Join
      hec_crt_insurancetobrokercontract_participatingpatients
        On hec_patient_medicalpractices.HEC_Patient_RefID = hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID And
        hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
      Inner Join
      hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts
        On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.IsDeleted = 0 And hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts.Tenant_RefID =
        @TenantID Inner Join
      hec_crt_insurancetobrokercontracts
        On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0
    Where
      hec_patient_medicalpractices.HEC_MedicalPractices_RefID = @PracticeID And
      hec_patient_medicalpractices.Tenant_RefID = @TenantID And
      hec_patient_medicalpractices.IsDeleted = 0
  