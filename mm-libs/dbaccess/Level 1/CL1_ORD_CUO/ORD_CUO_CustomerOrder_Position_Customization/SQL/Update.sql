UPDATE 
	ord_cuo_customerorder_position_customizations
SET 
	CustomerOrder_Position_RefID=@CustomerOrder_Position_RefID,
	Customization_Name=@Customization_Name,
	CustomizationVariant_Name=@CustomizationVariant_Name,
	ValuePerUnit=@ValuePerUnit,
	ValueTotal=@ValueTotal,
	Customization_Variant_RefID=@Customization_Variant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_CUO_CustomerOrder_Position_CustomizationID = @ORD_CUO_CustomerOrder_Position_CustomizationID