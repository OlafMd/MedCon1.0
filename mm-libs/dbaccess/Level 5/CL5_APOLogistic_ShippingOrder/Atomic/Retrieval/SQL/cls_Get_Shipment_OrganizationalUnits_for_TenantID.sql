
	Select Distinct
	  cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID,
	  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitNumber,
	  cmn_bpt_ctm_organizationalunits.InternalOrganizationalUnitSimpleName,
	  log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID,
	  log_shp_shipment_positions.IsDeleted
	From
	  cmn_bpt_ctm_organizationalunits 
	  Inner Join
	  ord_cuo_customerorder_position_2_shipmentposition
	    On
	    ord_cuo_customerorder_position_2_shipmentposition.CMN_BPT_CTM_OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And ord_cuo_customerorder_position_2_shipmentposition.IsDeleted = 0 Right Join
	  log_shp_shipment_positions
	    On
	    ord_cuo_customerorder_position_2_shipmentposition.LOG_SHP_Shipment_Position_RefID = log_shp_shipment_positions.LOG_SHP_Shipment_PositionID And log_shp_shipment_positions.IsDeleted = 0
	
	Where
		cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID
		AND cmn_bpt_ctm_organizationalunits.IsDeleted = 0
  		AND log_shp_shipment_positions.Tenant_RefID = @TenantID
  