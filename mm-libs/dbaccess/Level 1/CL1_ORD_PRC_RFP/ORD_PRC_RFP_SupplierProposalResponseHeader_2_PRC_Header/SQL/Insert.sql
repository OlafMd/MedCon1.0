INSERT INTO 
	ord_prc_rfp_supplierproposalresponseheader_2_prc_header
	(
		AssignmentID,
		ORD_PRC_RFP_SupplierProposalResponse_Header_RefID,
		ORD_PRC_ProcurementOrder_HeaderID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ORD_PRC_RFP_SupplierProposalResponse_Header_RefID,
		@ORD_PRC_ProcurementOrder_HeaderID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)