INSERT INTO 
	ord_dis_distributionorder_header_slotteddocuments
	(
		ORD_DIS_DistributionOrder_Header_SlottedDocumentID,
		DistributionOrder_Header_RefID,
		DocumentSlots_RefID,
		Document_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@ORD_DIS_DistributionOrder_Header_SlottedDocumentID,
		@DistributionOrder_Header_RefID,
		@DocumentSlots_RefID,
		@Document_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)