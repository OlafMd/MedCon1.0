
    Select
      hec_bil_potentialcode_2_healthcareproduct.AssignmentID
    From
      hec_crt_insurancetobrokercontract_participatingpatients Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On
        hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID = hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And 
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And 
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
        Inner Join
      hec_bil_potentialcode_2_healthcareproduct
        On
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID And 
        hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID And 
        hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0 And
        hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID = @DrugID
    Where
      hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID = @PatientID And
      (hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0 Or 
      hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = @IsResubmit)
	