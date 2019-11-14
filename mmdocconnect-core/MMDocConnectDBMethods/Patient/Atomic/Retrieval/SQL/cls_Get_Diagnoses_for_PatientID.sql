
Select
  hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName as catalog_display_name,
  hec_dia_potentialdiagnosis_catalogcodes.Code as diagnose_icd_10,
  hec_dia_potentialdiagnoses_de.Content as diagnose_name,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID As diagnose_id
From
  hec_patient_healthinsurances
  Inner Join hec_his_healthinsurance_companies
    On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID And
      hec_his_healthinsurance_companies.Tenant_RefID = @TenantID And 
      hec_his_healthinsurance_companies.IsDeleted = 0
  Inner Join cmn_ctr_contract_parties
    On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID = cmn_ctr_contract_parties.Undersigning_BusinessParticipant_RefID And
      cmn_ctr_contract_parties.Tenant_RefID = @TenantID And 
      cmn_ctr_contract_parties.IsDeleted = 0
  Inner Join hec_crt_insurancetobrokercontracts
    On cmn_ctr_contract_parties.Contract_RefID = hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
    hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And 
    hec_crt_insurancetobrokercontracts.IsDeleted = 0
  Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses
    On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID = hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID
  And hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0 
 Inner Join hec_dia_potentialdiagnoses
    On hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
      hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
      hec_dia_potentialdiagnoses.IsDeleted = 0
  Inner Join hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
      hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
      hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 
  Inner Join hec_dia_potentialdiagnosis_catalogs
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID = hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID And
      hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
      hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0
  Inner Join hec_dia_potentialdiagnoses_de
    On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID = hec_dia_potentialdiagnoses_de.DictID And
      hec_dia_potentialdiagnoses_de.IsDeleted = 0   
Where
  hec_patient_healthinsurances.Tenant_RefID = @TenantID And
  hec_patient_healthinsurances.IsDeleted = 0 And
  hec_patient_healthinsurances.Patient_RefID = @PatientID
Group By
  diagnose_id
Order by 
  lower(diagnose_name)
  