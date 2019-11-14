UPDATE 
	cmn_pro_prc_general_averageprocurementprices
SET 
	CurrentAverageProcurement_Price_RefID=@CurrentAverageProcurement_Price_RefID,
	Product_RefID=@Product_RefID,
	Product_Variant_RefID=@Product_Variant_RefID,
	IsCurrentAveragePrice=@IsCurrentAveragePrice,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_PRC_General_AverageProcurementPricesID = @CMN_PRO_PRC_General_AverageProcurementPricesID