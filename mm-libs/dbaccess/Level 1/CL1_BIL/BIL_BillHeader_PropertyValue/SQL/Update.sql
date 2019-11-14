UPDATE 
	bil_billheader_propertyvalues
SET 
	BIL_BillHeader_RefID=@BIL_BillHeader_RefID,
	PropertyKey=@PropertyKey,
	PropertyValue=@PropertyValue,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	BIL_BillHeader_PropertyValueID = @BIL_BillHeader_PropertyValueID