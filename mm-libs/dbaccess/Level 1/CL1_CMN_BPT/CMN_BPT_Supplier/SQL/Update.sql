UPDATE 
	cmn_bpt_suppliers
SET 
	Ext_BusinessParticipant_RefID=@Ext_BusinessParticipant_RefID,
	SupplierType_RefID=@SupplierType_RefID,
	ExternalSupplierProvidedIdentifier=@ExternalSupplierProvidedIdentifier,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_SupplierID = @CMN_BPT_SupplierID