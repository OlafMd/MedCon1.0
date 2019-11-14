UPDATE 
	ord_prc_rfp_issuedproposalresponse_positions
SET 
	ProposalResponsePositionITPL=@ProposalResponsePositionITPL,
	IssuedProposalResponseHeader_RefID=@IssuedProposalResponseHeader_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	CreatedFrom_RequestForProposal_Position_RefID=@CreatedFrom_RequestForProposal_Position_RefID,
	Quantity=@Quantity,
	TotalPrice_WithoutTax=@TotalPrice_WithoutTax,
	TotalPrice_IncludingTax=@TotalPrice_IncludingTax,
	PricePerUnit_WithoutTax=@PricePerUnit_WithoutTax,
	PricePerUnit_IncludingTax=@PricePerUnit_IncludingTax,
	IsReplacementProduct=@IsReplacementProduct,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ORD_PRC_RFP_IssuedProposalResponse_PositionID = @ORD_PRC_RFP_IssuedProposalResponse_PositionID