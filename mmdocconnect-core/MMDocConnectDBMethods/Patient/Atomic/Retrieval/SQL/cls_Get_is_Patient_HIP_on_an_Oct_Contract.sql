
    Select
      hec_patient_healthinsurances.HEC_Patient_HealthInsurancesID as PatientHealthInsuranceID,
      cmn_ctr_contract_parties.Contract_RefID as ContractID
    From
      hec_patient_healthinsurances Inner Join
      hec_his_healthinsurance_companies
        On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
        hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And hec_his_healthinsurance_companies.IsDeleted = 0 Inner Join
      cmn_ctr_contract_parties
        On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
        cmn_ctr_contract_parties.Tenant_RefID = @TenantID And cmn_ctr_contract_parties.IsDeleted = 0 Inner Join
      hec_crt_insurancetobrokercontracts
        On cmn_ctr_contract_parties.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And hec_crt_insurancetobrokercontracts.IsDeleted = 0 Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 Inner Join
      hec_bil_potentialcodes
        On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0 Inner Join
      hec_bil_potentialcode_catalogs
        On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And        
        hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = 'mm.docconnect.gpos.catalog.voruntersuchung' And
        hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And hec_bil_potentialcode_catalogs.IsDeleted = 0
    Where
      hec_patient_healthinsurances.Patient_RefID = @PatientID And
      hec_patient_healthinsurances.Tenant_RefID = @TenantID
	