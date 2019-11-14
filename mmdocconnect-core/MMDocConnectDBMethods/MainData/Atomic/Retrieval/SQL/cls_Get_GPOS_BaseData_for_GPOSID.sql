
  Select        
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID As GposID,
    Convert(hec_bil_potentialcodes_de.Content Using utf8) As GposName,
    hec_bil_potentialcodes.BillingCode As GposNumber,
    hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType,
    hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_Number As
    FromInjection,
    hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.Value_String As
    ManagementFeeValue,
    hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.Value_Boolean As
    WaiveWithOrder,
    cmn_price_values.PriceValue_Amount As FeeValue
  From
    hec_bil_potentialcodes
    Inner Join hec_bil_potentialcodes_de On hec_bil_potentialcodes.CodeName_DictID
      = hec_bil_potentialcodes_de.DictID And hec_bil_potentialcodes_de.IsDeleted =
      0
    Inner Join hec_bil_potentialcode_catalogs
      On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
      hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
      hec_bil_potentialcode_catalogs.Tenant_RefID =
      @TenantID And
      hec_bil_potentialcode_catalogs.IsDeleted = 0
    Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
      On
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
      On
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_RefID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.IsDeleted = 0
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
      On
      hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.PropertyName = 'From injection no.' And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsDeleted = 0
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
    hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1
      On
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.CoveredPotentialBillCode_RefID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.IsDeleted = 0
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
    hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1
      On
      hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.PropertyName = 'Service Fee in EUR' And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.IsDeleted = 0
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
    hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2
      On
      hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.CoveredPotentialBillCode_RefID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.IsDeleted = 0
    Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
    hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2
      On
      hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.PropertyName = 'Waive with order' And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.Tenant_RefID = @TenantID And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.IsDeleted = 0
    Inner Join cmn_price_values On hec_bil_potentialcodes.Price_RefID =
      cmn_price_values.Price_RefID And cmn_price_values.Tenant_RefID =
      @TenantID And cmn_price_values.IsDeleted = 0
  Where
    hec_bil_potentialcodes.Tenant_RefID = @TenantID And
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID =
    @GposID And
    hec_bil_potentialcodes.IsDeleted = 0
  Group By
    hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
  