
Select
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID As diagnose_id,
  hec_dia_potentialdiagnoses_de.Content As diagnose_name,
  hec_dia_potentialdiagnosis_catalogcodes.Code As diagnose_icd_10,
  hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName As
  catalog_display_name
From
  cmn_ctr_contracts Inner Join
  hec_crt_insurancetobrokercontracts On cmn_ctr_contracts.CMN_CTR_ContractID =
    hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID And
    cmn_ctr_contracts.Tenant_RefID = @TenantID And cmn_ctr_contracts.IsDeleted =
    0 Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses
    On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.Tenant_RefID = @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnoses
    On
    hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And hec_dia_potentialdiagnoses.IsDeleted = 0 And hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID Inner Join
  hec_dia_potentialdiagnoses_de
    On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
    hec_dia_potentialdiagnoses_de.DictID And
    hec_dia_potentialdiagnoses_de.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 Inner Join
  hec_dia_potentialdiagnosis_catalogs
    On hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    = hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID
    And hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0
Where
  cmn_ctr_contracts.Tenant_RefID = @TenantID And
  cmn_ctr_contracts.IsDeleted = 0 And
  cmn_ctr_contracts.CMN_CTR_ContractID = @ContractID
Group By
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
Order By
  LOWER(hec_dia_potentialdiagnoses_de.Content)
	