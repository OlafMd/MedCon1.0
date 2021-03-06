
      Select
        hec_bil_potentialcodes.BillingCode As gpos_code,
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_Number As injection_from,
        hec_bil_potentialcodes.HEC_BIL_PotentialCodeID As gpos_id,
        cmn_price_values.PriceValue_Amount As gpos_price,
        hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As gpos_type
      From
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
          On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID =
          hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_RefID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Tenant_RefID =
          @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
          On hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_UniversalProperty_RefID =
          hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And
          hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsDeleted = 0 And
          hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.PropertyName = 'From injection no.'
        Inner Join hec_bil_potentialcodes On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And
          hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0
        Inner Join hec_bil_potentialcode_catalogs On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
          hec_bil_potentialcode_catalogs.IsDeleted = 0 And hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID
        Inner Join hec_bil_potentialcode_2_potentialdiagnosis On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID = hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID
          And hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID = @TenantID And hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0 And
          hec_bil_potentialcode_2_potentialdiagnosis.HEC_DIA_PotentialDiagnosis_RefID = @DiagnoseID
        Inner Join hec_bil_potentialcode_2_healthcareproduct On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID = hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID And
          hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID = @TenantID And hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0 And
          hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID = @DrugID
        Inner Join cmn_price_values On hec_bil_potentialcodes.Price_RefID = cmn_price_values.Price_RefID And cmn_price_values.Tenant_RefID = @TenantID And cmn_price_values.IsDeleted = 0
        Inner Join hec_crt_insurancetobrokercontracts On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID =
          hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID And
          hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID And
          hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
          hec_crt_insurancetobrokercontracts.IsDeleted = 0
      Where
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 
	