INSERT INTO 
	cmn_sls_dpf_type_procurementpricedependencies
	(
		CMN_SLS_DPF_Type_ProcurementPriceDependencyID,
		DynamicPricingFormula_Type_RefID,
		ApplicableFrom_ProcurementPrice,
		ApplicableThrough_ProcurementPrice,
		DynamicPricingFormula,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_SLS_DPF_Type_ProcurementPriceDependencyID,
		@DynamicPricingFormula_Type_RefID,
		@ApplicableFrom_ProcurementPrice,
		@ApplicableThrough_ProcurementPrice,
		@DynamicPricingFormula,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)