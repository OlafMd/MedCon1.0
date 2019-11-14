
Select
  hec_bil_potentialcodes.BillingCode As GposCode,
  hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_Number As InjectionFrom,
  hec_bil_potentialcodes.HEC_BIL_PotentialCodeID As GposID,
  cmn_price_values.PriceValue_Amount As GposPrice,
  hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType
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
  Inner Join hec_bil_potentialcodes
    On hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID
    = @TenantID And hec_bil_potentialcodes.IsDeleted = 0
  Inner Join hec_bil_potentialcode_catalogs
    On hec_bil_potentialcodes.PotentialCode_Catalog_RefID = hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And hec_bil_potentialcode_catalogs.IsDeleted = 0 And
    hec_bil_potentialcode_catalogs.Tenant_RefID = @TenantID
  Inner Join cmn_price_values
    On hec_bil_potentialcodes.Price_RefID = cmn_price_values.Price_RefID And cmn_price_values.Tenant_RefID = @TenantID And cmn_price_values.IsDeleted = 0
Where
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0 And
  hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID = @InsuranceToBrokerContractID
	