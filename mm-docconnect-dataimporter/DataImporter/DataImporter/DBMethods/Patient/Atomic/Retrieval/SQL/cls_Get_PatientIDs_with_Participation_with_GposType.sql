
    Select
      hec_crt_insurancetobrokercontract_participatingpatients.Patient_RefID as patient_id
    From
      hec_crt_insurancetobrokercontract_participatingpatients Inner Join
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        On hec_crt_insurancetobrokercontract_participatingpatients.InsuranceToBrokerContract_RefID =
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And
        hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0 Inner Join
      hec_bil_potentialcodes
        On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
        hec_bil_potentialcodes.Tenant_RefID = @TenantID And
        hec_bil_potentialcodes.IsDeleted = 0 Inner Join
      hec_bil_potentialcode_catalogs
        On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
  	    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID = @GposType And
  	    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID And
  	    hec_bil_potentialcode_catalogs.IsDeleted = 0
    Where
	    hec_crt_insurancetobrokercontract_participatingpatients.Tenant_RefID = @TenantID And
	    hec_crt_insurancetobrokercontract_participatingpatients.IsDeleted = 0
    Group by
      patient_id
    Order by 
	    null
  