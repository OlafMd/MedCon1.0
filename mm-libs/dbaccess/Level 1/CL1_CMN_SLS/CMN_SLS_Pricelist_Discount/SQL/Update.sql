UPDATE 
	cmn_sls_pricelist_discounts
SET 
	PricelistVersion_RefID=@PricelistVersion_RefID,
	ProductGroup_RefID=@ProductGroup_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	Product_Release_RefID=@Product_Release_RefID,
	DiscountPercentAmount=@DiscountPercentAmount,
	DiscountValid_From=@DiscountValid_From,
	DiscountValid_To=@DiscountValid_To,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_SLS_Pricelist_DiscountID = @CMN_SLS_Pricelist_DiscountID