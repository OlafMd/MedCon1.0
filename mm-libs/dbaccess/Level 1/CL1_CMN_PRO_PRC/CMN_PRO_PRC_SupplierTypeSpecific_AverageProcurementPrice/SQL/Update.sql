UPDATE 
	cmn_pro_prc_suppliertypespecific_averageprocurementprices
SET 
	CMN_BPT_Supplier_Type_RefID=@CMN_BPT_Supplier_Type_RefID,
	CurrentAverageProcurement_Price_RefID=@CurrentAverageProcurement_Price_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	IsCurrentAveragePrice=@IsCurrentAveragePrice,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_PRC_SupplierTypeSpecific_AverageProcurementPriceID = @CMN_PRO_PRC_SupplierTypeSpecific_AverageProcurementPriceID