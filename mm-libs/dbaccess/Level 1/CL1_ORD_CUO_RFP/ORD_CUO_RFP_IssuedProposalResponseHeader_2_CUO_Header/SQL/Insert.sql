INSERT INTO 
	ord_cuo_rfp_issuedproposalresponseheader_2_cuo_header
	(
		AssignmentID,
		ORD_CUO_RFP_IssuedProposalResponse_Header_RefID,
		ORD_CUO_CustomerOrder_Header_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@ORD_CUO_RFP_IssuedProposalResponse_Header_RefID,
		@ORD_CUO_CustomerOrder_Header_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)