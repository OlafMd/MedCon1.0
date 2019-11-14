
Select
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID
From
  hec_bil_potentialcode_2_healthcareproduct Inner Join
  hec_bil_potentialcode_2_potentialdiagnosis
    On hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID =
    hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID And
    hec_bil_potentialcode_2_potentialdiagnosis.HEC_DIA_PotentialDiagnosis_RefID
    = @DiagnosisID And hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID =
    @TenantID And hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0
  Inner Join
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
    On hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID =
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 And 
    hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID
Where
  hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID And
  hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0 And
  hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID = @DrugID
	