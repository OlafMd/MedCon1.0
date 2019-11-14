UPDATE 
	ord_cuo_rfp_issuedproposalresponseheader_2_cuo_header
SET 
	ORD_CUO_RFP_IssuedProposalResponse_Header_RefID=@ORD_CUO_RFP_IssuedProposalResponse_Header_RefID,
	ORD_CUO_CustomerOrder_Header_RefID=@ORD_CUO_CustomerOrder_Header_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID