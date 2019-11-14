UPDATE 
	ord_dis_distributionorder_header_documents
SET 
	DistributionOrder_Header_RefID=@DistributionOrder_Header_RefID,
	Document_RefID=@Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	ORD_DIS_DistributionOrder_Header_DocumentID = @ORD_DIS_DistributionOrder_Header_DocumentID