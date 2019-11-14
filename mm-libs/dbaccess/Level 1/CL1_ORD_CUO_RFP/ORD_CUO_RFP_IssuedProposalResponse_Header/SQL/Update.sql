UPDATE 
	ord_cuo_rfp_issuedproposalresponse_headers
SET 
	ProposalResponseHeaderITPL=@ProposalResponseHeaderITPL,
	CreatedFor_RequestForProposal_Header_RefID=@CreatedFor_RequestForProposal_Header_RefID,
	DefaultCurrency_RefID=@DefaultCurrency_RefID,
	ValidThrough=@ValidThrough,
	TotalPrice_WithoutTax=@TotalPrice_WithoutTax,
	TotalPrice_IncludingTax=@TotalPrice_IncludingTax,
	ProposalResponseDocument_RefID=@ProposalResponseDocument_RefID,
	IsActive=@IsActive,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_CUO_RFP_IssuedProposalResponse_HeaderID = @ORD_CUO_RFP_IssuedProposalResponse_HeaderID