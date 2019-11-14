UPDATE 
	cmn_pro_ass_distributionprice_values
SET 
	DistributionPrice_RefID=@DistributionPrice_RefID,
	CMN_Price_RefID=@CMN_Price_RefID,
	DefaultPointValue=@DefaultPointValue,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_ASS_DistributionPrice_ValueID = @CMN_PRO_ASS_DistributionPrice_ValueID