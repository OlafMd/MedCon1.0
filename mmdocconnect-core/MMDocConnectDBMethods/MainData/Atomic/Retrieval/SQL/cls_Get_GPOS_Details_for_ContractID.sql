
      Select
        hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID As GposID,
        hec_bil_potentialcodes.BillingCode As GposNumber,
        hec_bil_potentialcodes_de.Content As GposName,
        Group_Concat(Distinct cmn_pro_products_de.Content Order By
        cmn_pro_products_de.Content Separator ', ') As DrugNames,
        Group_Concat(Distinct hec_dia_potentialdiagnoses_de.Content Order By
        hec_dia_potentialdiagnoses_de.Content Separator ', ') As DiagnoseNames,
        hec_bil_potentialcode_catalogs.GlobalPropertyMatchingID As GposType,
        cmn_price_values.PriceValue_Amount As FeeValue,
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Value_Number As FromInjection,
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.Value_String As ManagementFeeValue,
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.Value_Boolean As WaiveWithOrder
      From
        hec_crt_insurancetobrokercontracts
        Inner Join hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes
          On hec_crt_insurancetobrokercontracts.HEC_CRT_InsuranceToBrokerContractID =
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.InsuranceToBrokerContract_RefID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.Tenant_RefID = @TenantID And hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.IsDeleted = 0
        Inner Join hec_bil_potentialcodes
          On
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.PotentialBillCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.Tenant_RefID = @TenantID And hec_bil_potentialcodes.IsDeleted = 0
        Inner Join hec_bil_potentialcodes_de On hec_bil_potentialcodes.CodeName_DictID
          = hec_bil_potentialcodes_de.DictID And hec_bil_potentialcodes_de.IsDeleted =
          0
        left Join hec_bil_potentialcode_2_healthcareproduct
          On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID =
          hec_bil_potentialcode_2_healthcareproduct.HEC_BIL_PotentialCode_RefID And
          hec_bil_potentialcode_2_healthcareproduct.Tenant_RefID =
          @TenantID And
          hec_bil_potentialcode_2_healthcareproduct.IsDeleted = 0
        left Join hec_products
          On hec_bil_potentialcode_2_healthcareproduct.HEC_Product_RefID =
          hec_products.HEC_ProductID And hec_products.Tenant_RefID =
          @TenantID And hec_products.IsDeleted = 0
        left Join cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
          cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.Tenant_RefID =
          @TenantID And cmn_pro_products.IsDeleted = 0
        left Join cmn_pro_products_de On cmn_pro_products.Product_Name_DictID =
          cmn_pro_products_de.DictID And cmn_pro_products_de.IsDeleted = 0
        left Join hec_bil_potentialcode_2_potentialdiagnosis
          On hec_bil_potentialcodes.HEC_BIL_PotentialCodeID =
          hec_bil_potentialcode_2_potentialdiagnosis.HEC_BIL_PotentialCode_RefID And
          hec_bil_potentialcode_2_potentialdiagnosis.Tenant_RefID =
          @TenantID And
          hec_bil_potentialcode_2_potentialdiagnosis.IsDeleted = 0
        left Join hec_dia_potentialdiagnoses
          On
          hec_bil_potentialcode_2_potentialdiagnosis.HEC_DIA_PotentialDiagnosis_RefID
          = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
          hec_dia_potentialdiagnoses.Tenant_RefID =
          @TenantID And hec_dia_potentialdiagnoses.IsDeleted
          = 0
        left Join hec_dia_potentialdiagnoses_de
          On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
          hec_dia_potentialdiagnoses_de.DictID And
          hec_dia_potentialdiagnoses_de.IsDeleted = 0
        Inner Join hec_bil_potentialcode_catalogs
          On hec_bil_potentialcodes.PotentialCode_Catalog_RefID =
          hec_bil_potentialcode_catalogs.HEC_BIL_PotentialCode_CatalogID And
          hec_bil_potentialcode_catalogs.IsDeleted = 0 And
          hec_bil_potentialcode_catalogs.Tenant_RefID =
          @TenantID
        Inner Join cmn_price_values On hec_bil_potentialcodes.Price_RefID =
          cmn_price_values.Price_RefID And cmn_price_values.Tenant_RefID =
          @TenantID And cmn_price_values.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
          On
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_RefID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.Tenant_RefID = @TenantID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
          On
          hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.PropertyName = 'From injection no.'
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.Tenant_RefID = @TenantID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1
          On
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.CoveredPotentialBillCode_RefID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.Tenant_RefID = @TenantID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1
          On
          hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty1.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.PropertyName = 'Service Fee in EUR' 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.Tenant_RefID = @TenantID
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties1.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
        hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2
          On
          hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes.HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID = hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.CoveredPotentialBillCode_RefID
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.Tenant_RefID = @TenantID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.IsDeleted = 0
        Inner Join hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
        hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2
          On
          hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty2.CoveredPotentialBillCode_UniversalProperty_RefID = hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.PropertyName = 'Waive with order' 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.Tenant_RefID = @TenantID 
          And hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties2.IsDeleted = 0
      Where
        hec_crt_insurancetobrokercontracts.Tenant_RefID = @TenantID And
        hec_crt_insurancetobrokercontracts.IsDeleted = 0 And
        hec_crt_insurancetobrokercontracts.Ext_CMN_CTR_Contract_RefID = @ContractID

      Group By
        hec_bil_potentialcodes.HEC_BIL_PotentialCodeID
  