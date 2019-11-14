UPDATE 
	ord_dis_distributionorder_position_customizations
SET 
	DistributionOrder_Position_RefID=@DistributionOrder_Position_RefID,
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
	ORD_DIS_DistributionOrder_Position_CustomizationID = @ORD_DIS_DistributionOrder_Position_CustomizationID