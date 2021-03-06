INSERT INTO 
	cmn_pro_ass_assortments
	(
		CMN_PRO_ASS_AssortmentID,
		AssortmentName_DictID,
		AvailableForSalesFrom,
		AvailableForSalesThrough,
		AvailableForOrderingFrom,
		AvailableForOrderingThrough,
		IsForInternalDistribution,
		IsDefaultAssortment_ForCostcenterOrder,
		IsDefaultAssortment_ForOfficeOrder,
		IsDefaultAssortment_ForPersonalOrder,
		IsDefaultAssortment_ForWarehouseOrder,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_ASS_AssortmentID,
		@AssortmentName,
		@AvailableForSalesFrom,
		@AvailableForSalesThrough,
		@AvailableForOrderingFrom,
		@AvailableForOrderingThrough,
		@IsForInternalDistribution,
		@IsDefaultAssortment_ForCostcenterOrder,
		@IsDefaultAssortment_ForOfficeOrder,
		@IsDefaultAssortment_ForPersonalOrder,
		@IsDefaultAssortment_ForWarehouseOrder,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)