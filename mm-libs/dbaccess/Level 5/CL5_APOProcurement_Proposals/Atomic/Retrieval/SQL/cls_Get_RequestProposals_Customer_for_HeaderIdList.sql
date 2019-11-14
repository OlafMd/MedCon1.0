
		Select
	  ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID,
	  ord_cuo_rfp_requestforproposal_headers.RequestingBusinessParticipant_RefID,
	  ord_cuo_rfp_requestforproposal_headers.RequestForProposal_Number,
	  ord_cuo_rfp_requestforproposal_headers.DateOfPublish,
	  ord_cuo_rfp_requestforproposal_headers.ProposalDeadline,
	  ord_cuo_rfp_requestforproposal_headers.CompleteDeliveryUntillDate,
	  ord_cuo_rfp_requestforproposal_headers.RequestForProposalHeaderITPL,
	  ord_cuo_rfp_requestforproposal_positions.ORD_CUO_RFP_RequestForProposal_PositionID,
	  ord_cuo_rfp_requestforproposal_positions.CMN_PRO_Product_RefID,
	  ord_cuo_rfp_requestforproposal_positions.Quantity,
	  ord_cuo_rfp_requestforproposal_positions.IsReplacementPermitted,
	  ord_cuo_rfp_requestforproposal_positions.OrderSequence,
	  ord_cuo_rfp_requestforproposal_positions.DeliveryUntillDate,
	  ord_cuo_rfp_requestforproposal_positions.RequestForProposalPositionITPL
	From
	  ord_cuo_rfp_requestforproposal_headers Inner Join
	  ord_cuo_rfp_requestforproposal_positions
	    On ord_cuo_rfp_requestforproposal_positions.RequestForProposal_Header_RefID
	    =
	    ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID
	Where
	  ord_cuo_rfp_requestforproposal_headers.ORD_CUO_RFO_RequestForProposal_HeaderID
	  = @HeaderID_List And   
	  ord_cuo_rfp_requestforproposal_headers.Tenant_RefID = @TenantID And
	  ord_cuo_rfp_requestforproposal_headers.IsDeleted = 0

  