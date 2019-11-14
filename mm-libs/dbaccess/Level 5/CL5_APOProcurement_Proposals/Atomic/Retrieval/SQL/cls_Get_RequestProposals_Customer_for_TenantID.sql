
	Select
	  ord_cuo_rfp_requestforproposal_positions.CMN_PRO_Product_RefID,
	  ord_cuo_rfp_requestforproposal_positions.IsReplacementPermitted,
	  ord_cuo_rfp_requestforproposal_positions.Quantity,
	  ord_cuo_rfp_requestforproposal_positions.DeliveryUntillDate,
	  ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID,
	  ord_cuo_rfp_requestforproposal_headers.CompleteDeliveryUntillDate,
	  ord_cuo_rfp_requestforproposal_headers.ProposalDeadline,
    ord_cuo_rfp_requestforproposal_headers.RequestingBusinessParticipant_RefID,
	  ord_cuo_rfp_requestforproposal_history.Comment,
	  ord_cuo_rfp_requestforproposal_history.IsEvent_ProposalResponse_Sent,
	  ord_cuo_rfp_requestforproposal_history.IsEvent_ProposalRequest_Received,
	  ord_cuo_rfp_requestforproposal_history.IsEvent_ProposalRequest_ReceptionAcknowledged,
	  ord_cuo_rfp_requestforproposal_history.IsEvent_ByCustomer_ProposalResponse_Declined,
	  ord_cuo_rfp_requestforproposal_history.IsEvent_ByCustomer_ProposalResponse_Accepted,
    ord_cuo_rfp_requestforproposal_positions.ORD_CUO_RFP_RequestForProposal_PositionID
	From
	  ord_cuo_rfp_requestforproposal_headers Inner Join
	  ord_cuo_rfp_requestforproposal_positions
	    On
	    ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID = ord_cuo_rfp_requestforproposal_positions.RequestForProposal_Header_RefID
	    And ord_cuo_rfp_requestforproposal_positions.Tenant_RefID = @TenantID
	    Inner Join
	  ord_cuo_rfp_requestforproposal_history
	    On ord_cuo_rfp_requestforproposal_history.RequestForProposal_Header_RefID =
	    ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID 
	    And ord_cuo_rfp_requestforproposal_history.Tenant_RefID = @TenantID 
	    Inner Join
	  hec_cuo_rfp_requestforproposal_headers
	    On
	    ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID = hec_cuo_rfp_requestforproposal_headers.Ext_ORD_CUO_RFP_RequestForProposal_Header_RefID
	    And hec_cuo_rfp_requestforproposal_headers.Tenant_RefID = @TenantID
	     Inner Join
	  hec_cuo_rfp_requestforproposal_positions
	    On
	    hec_cuo_rfp_requestforproposal_positions.Ext_ORD_CUO_RFP_RequestForProposal_Position_RefID = ord_cuo_rfp_requestforproposal_positions.ORD_CUO_RFP_RequestForProposal_PositionID
	    And hec_cuo_rfp_requestforproposal_positions.Tenant_RefID = @TenantID
	     Left Join
	  ord_cuo_rfp_issuedproposalresponse_headers
	    On
	    ord_cuo_rfp_issuedproposalresponse_headers.CreatedFor_RequestForProposal_Header_RefID = ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID
	    And ord_cuo_rfp_issuedproposalresponse_headers.Tenant_RefID = @TenantID 
	Where
	  ord_cuo_rfp_requestforproposal_headers.Tenant_RefID = @TenantID And
	  ord_cuo_rfp_requestforproposal_headers.IsDeleted = 0
  