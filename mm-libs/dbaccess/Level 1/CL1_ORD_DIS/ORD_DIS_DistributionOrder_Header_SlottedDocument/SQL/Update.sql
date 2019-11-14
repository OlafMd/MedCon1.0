UPDATE 
	ord_dis_distributionorder_header_slotteddocuments
SET 
	DistributionOrder_Header_RefID=@DistributionOrder_Header_RefID,
	DocumentSlots_RefID=@DocumentSlots_RefID,
	Document_RefID=@Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_DIS_DistributionOrder_Header_SlottedDocumentID = @ORD_DIS_DistributionOrder_Header_SlottedDocumentID