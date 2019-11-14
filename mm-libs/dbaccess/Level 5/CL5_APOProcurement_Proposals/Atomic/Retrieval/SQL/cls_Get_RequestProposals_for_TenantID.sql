
	Select  
  ord_prc_rfp_requestforproposal_positions.CMN_PRO_Product_RefID,
  cmn_bpt_businessparticipants1.DisplayName As Deliverer,
  ord_prc_rfp_requestforproposal_positions.DeliveryUntillDate,
  ord_prc_rfp_requestforproposal_positions.Quantity,
  ord_prc_rfp_requestforproposal_headers.ORD_PRC_RFO_RequestForProposal_HeaderID,
  ord_prc_rfp_requestforproposal_positions.ORD_PRC_RFP_RequestForProposal_PositionID,
  ord_prc_rfp_requestforproposal_headers.CompleteDeliveryUntillDate,
  ord_prc_rfp_requestforproposal_headers.ProposalDeadline,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalRequest_Sent,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalResponse_Received,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalResponse_Accepted,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalResponse_ReceptionAcknowledged,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalResponse_Declined,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalRequest_Revoked,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalResponse_ModificationRequired,
  ord_prc_rfp_potentialsupplier_history.Comment,
  ord_prc_rfp_potentialsuppliers.ORD_PRC_RFP_PotentialSupplierID,
  ord_prc_rfp_supplierproposalresponse_headers.OfferReceivedFrom_RegisteredBusinessParticipant_RefID,
  ord_prc_rfp_supplierproposalresponse_headers.CreatedFor_RequestForProposal_Header_RefID,
  ord_prc_rfp_potentialsupplier_history.ORD_PRC_RFP_PotentialSupplier_HistoryID
From
  ord_prc_rfp_requestforproposal_headers Inner Join
  ord_prc_rfp_requestforproposal_positions
    On ord_prc_rfp_requestforproposal_positions.RequestForProposal_Header_RefID
    =
    ord_prc_rfp_requestforproposal_headers.ORD_PRC_RFO_RequestForProposal_HeaderID And ord_prc_rfp_requestforproposal_positions.Tenant_RefID = @TenantID Left Join
  hec_prc_rfp_requestforproposal_positions
    On
    hec_prc_rfp_requestforproposal_positions.Ext_ORD_PRC_RFP_RequestForProposal_Position_RefID = ord_prc_rfp_requestforproposal_positions.ORD_PRC_RFP_RequestForProposal_PositionID And hec_prc_rfp_requestforproposal_positions.Tenant_RefID = @TenantID Inner Join
  ord_prc_rfp_potentialsuppliers
    On
    ord_prc_rfp_requestforproposal_headers.ORD_PRC_RFO_RequestForProposal_HeaderID = ord_prc_rfp_potentialsuppliers.RequestForProposal_Header_RefID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On ord_prc_rfp_potentialsuppliers.CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Inner Join
  ord_prc_rfp_potentialsupplier_history
    On ord_prc_rfp_potentialsupplier_history.ORD_PRC_RFP_PotentialSupplier_RefID
    = ord_prc_rfp_potentialsuppliers.ORD_PRC_RFP_PotentialSupplierID And
    ord_prc_rfp_potentialsupplier_history.Tenant_RefID = @TenantID Left Join
  ord_prc_rfp_supplierproposalresponse_headers
    On
    ord_prc_rfp_supplierproposalresponse_headers.CreatedFor_RequestForProposal_Header_RefID = ord_prc_rfp_requestforproposal_headers.ORD_PRC_RFO_RequestForProposal_HeaderID 
Where
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalRequest_Sent =
  IfNull(@IsEvent_ProposalRequest_Sent,
  ord_prc_rfp_potentialsupplier_history.IsEvent_ProposalRequest_Sent) And
  ord_prc_rfp_requestforproposal_headers.Tenant_RefID = @TenantID And
  ord_prc_rfp_requestforproposal_headers.IsDeleted = 0 
  