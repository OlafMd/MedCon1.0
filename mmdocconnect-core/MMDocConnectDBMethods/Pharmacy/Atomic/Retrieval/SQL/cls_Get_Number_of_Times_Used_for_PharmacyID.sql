
Select
  Count(ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID) As
  NumberOfUsages
From
  hec_pharmacies Inner Join
  cmn_bpt_businessparticipants
    On hec_pharmacies.Ext_CompanyInfo_RefID =
    cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_headers
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID And
    ord_prc_procurementorder_headers.IsDeleted = 0 And
    ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
Where
  hec_pharmacies.HEC_PharmacyID = @PharmacyID And
  hec_pharmacies.IsDeleted = 0 And
  hec_pharmacies.Tenant_RefID = @TenantID
  