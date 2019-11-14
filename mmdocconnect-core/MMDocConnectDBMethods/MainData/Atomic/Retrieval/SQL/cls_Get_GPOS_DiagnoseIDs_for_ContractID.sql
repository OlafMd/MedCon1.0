
Select
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID As GposID,
  hec_bil_potentialcode_2_potentialdiagnosis.HEC_DIA_PotentialDiagnosis_RefID As DiagnoseID,
  Concat(hec_dia_potentialdiagnoses_de.Content, ' (', hec_dia_potentialdiagnosis_catalogcodes.Code, ')') As DiagnoseName,
  hec_dia_potentialdiagnosis_catalogcodes.Code as DiagnoseICD10,
  hec_dia_potentialdiagnoses_de.Content as DiagnoseShortName
From
  hec_crt_insurancetobrokercontracts
  Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID =
    @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
  Inner Join hec_bil_potentialcode_2_potentialdiagnosis On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID =
    hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID And hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID = @TenantID And
    hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0
  Inner Join hec_dia_potentialdiagnoses On hec_bil_potentialcode_2_potentialdiagnosis.HEC_DIA_PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And hec_dia_potentialdiagnoses.IsDeleted = 0
  Inner Join hec_dia_potentialdiagnoses_de On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID = hec_dia_potentialdiagnoses_de.DictID And
    hec_dia_potentialdiagnoses_de.IsDeleted = 0
  Inner Join hec_dia_potentialdiagnosis_catalogcodes On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
    And hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0
Where
  hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
  hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
  hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID
Group By
  hec_bil_potentialcode_2_potentialdiagnosis.AssignmentID, hec_dia_potentialdiagnosis_catalogcodes.Code
  