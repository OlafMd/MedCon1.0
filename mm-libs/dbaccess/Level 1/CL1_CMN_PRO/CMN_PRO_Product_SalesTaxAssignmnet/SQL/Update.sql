UPDATE 
	cmn_pro_product_salestaxassignmnets
SET 
	SourceEconomicRegion_RefID=@SourceEconomicRegion_RefID,
	TargetEconomicRegion_RefID=@TargetEconomicRegion_RefID,
	Product_RefID=@Product_RefID,
	ApplicableSalesTax_RefID=@ApplicableSalesTax_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PRO_Product_SalesTaxAssignmnetID = @CMN_PRO_Product_SalesTaxAssignmnetID