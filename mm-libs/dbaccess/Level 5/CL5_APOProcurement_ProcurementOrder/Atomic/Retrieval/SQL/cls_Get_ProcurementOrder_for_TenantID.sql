
SELECT 
  ord_prc_procurementorder_headers.ProcurementOrder_Number
  ,COUNT(DISTINCT ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID) AS PositionsCount
  ,SUM(DISTINCT ord_prc_procurementorder_positions.Position_ValueTotal) AS Position_ValueTotal
  ,cmn_bpt_businessparticipants.DisplayName
  ,cmn_bpt_suppliers.CMN_BPT_SupplierID
  ,ord_prc_procurementorder_headers.Creation_Timestamp
  ,ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
  ,cmn_bpt_supplier_types.GlobalPropertyMatchingID
  ,COUNT(DISTINCT ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_NoteID) notesNumber
  ,cmn_currencies.ISO4127
  ,cmn_currencies.Symbol
FROM ord_prc_procurementorder_headers
LEFT JOIN ord_prc_procurementorder_positions 
  ON ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID = ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
  AND ord_prc_procurementorder_positions.IsDeleted = 0
  AND ord_prc_procurementorder_positions.Tenant_RefID = @TenantID
INNER JOIN cmn_bpt_suppliers 
  ON ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID = cmn_bpt_suppliers.CMN_BPT_SupplierID
  AND cmn_bpt_suppliers.IsDeleted = 0
  AND cmn_bpt_suppliers.Tenant_RefID = @TenantID
INNER JOIN cmn_bpt_businessparticipants 
  ON cmn_bpt_suppliers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  AND cmn_bpt_businessparticipants.IsDeleted = 0
  AND cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
INNER JOIN cmn_bpt_supplier_types 
  ON cmn_bpt_suppliers.SupplierType_RefID = cmn_bpt_supplier_types.CMN_BPT_Supplier_TypeID
  AND cmn_bpt_supplier_types.IsDeleted = 0
  AND cmn_bpt_supplier_types.Tenant_RefID = @TenantID
LEFT JOIN ord_prc_procurementorder_notes 
  ON ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID = ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Header_RefID
  AND ord_prc_procurementorder_notes.Tenant_RefID = @TenantID
  AND ord_prc_procurementorder_notes.IsDeleted = 0
INNER JOIN cmn_currencies 
  ON cmn_currencies.CMN_CurrencyID = cmn_bpt_businessparticipants.DefaultCurrency_RefID
  AND cmn_currencies.Tenant_RefID = @TenantID
  AND cmn_currencies.IsDeleted = 0
WHERE 
  ord_prc_procurementorder_headers.Tenant_RefID = @TenantID
  AND ord_prc_procurementorder_headers.IsDeleted = 0
  AND NOT EXISTS (
    SELECT 
      1
    FROM ord_prc_expecteddelivery_2_procurementorderposition
    WHERE
      ord_prc_expecteddelivery_2_procurementorderposition.Tenant_RefID = @TenantID
      AND ord_prc_expecteddelivery_2_procurementorderposition.IsDeleted = 0
      AND ord_prc_expecteddelivery_2_procurementorderposition.ORD_PRC_ProcurementOrder_Position_RefID 
        = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID)
GROUP BY 
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID;
  