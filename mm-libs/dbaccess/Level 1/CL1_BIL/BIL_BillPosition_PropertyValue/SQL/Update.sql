UPDATE 
	bil_billposition_propertyvalue
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	PropertyKey=@PropertyKey,
	PropertyValue=@PropertyValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillPosition_PropertyValueID = @BIL_BillPosition_PropertyValueID