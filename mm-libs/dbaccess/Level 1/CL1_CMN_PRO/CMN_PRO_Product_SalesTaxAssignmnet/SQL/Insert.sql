INSERT INTO 
	cmn_pro_product_salestaxassignmnets
	(
		CMN_PRO_Product_SalesTaxAssignmnetID,
		SourceEconomicRegion_RefID,
		TargetEconomicRegion_RefID,
		Product_RefID,
		ApplicableSalesTax_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_PRO_Product_SalesTaxAssignmnetID,
		@SourceEconomicRegion_RefID,
		@TargetEconomicRegion_RefID,
		@Product_RefID,
		@ApplicableSalesTax_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)