INSERT INTO 
	cmn_pro_prc_suppliertypespecific_averageprocurementprices
	(
		CMN_PRO_PRC_SupplierTypeSpecific_AverageProcurementPriceID,
		CMN_BPT_Supplier_Type_RefID,
		CurrentAverageProcurement_Price_RefID,
		Product_RefID,
		Product_Variant_RefID,
		IsCurrentAveragePrice,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_PRC_SupplierTypeSpecific_AverageProcurementPriceID,
		@CMN_BPT_Supplier_Type_RefID,
		@CurrentAverageProcurement_Price_RefID,
		@Product_RefID,
		@Product_Variant_RefID,
		@IsCurrentAveragePrice,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)