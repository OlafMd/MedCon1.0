
	Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  hec_patient_treatment_requiredproducts.Quantity,
  hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
  cmn_bpt_businessparticipants.DisplayName As PharmacyName,
  hec_pharmacies.HEC_PharmacyID,
  hec_patient_treatment_requiredproducts.HEC_Product_RefID,
  hec_products.HEC_ProductID,
  hec_products.Recepie,
  OrderIn.ORD_PRC_ProcurementOrder_StatusID,
  OrderIn.Creation_Timestamp1,
  OrderIn.Status_Name_DictID,
  OrderIn.Status_Code,
  OrderIn.GlobalPropertyMatchingID,
  OrderIn.ProcurementOrder_Number,
  OrderIn.Position_RequestedDateOfDelivery,
  OrderIn.ProcurementOrder_Date,
  OrderIn.ORD_PRC_ProcurementOrder_PositionID,
  hec_patient_treatment_requiredproducts.BoundTo_ProcurementOrderPosition_RefID
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_patient_treatment_requiredproducts
    On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
    hec_products.HEC_ProductID Inner Join
  hec_pharmacies
    On hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID =
    hec_pharmacies.HEC_PharmacyID Inner Join
  cmn_com_companyinfo On hec_pharmacies.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  (Select
    ord_prc_procurementorder_statushistory.Creation_Timestamp As
    Creation_Timestamp1,
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID,
    ord_prc_procurementorder_statuses.Status_Name_DictID,
    ord_prc_procurementorder_statuses.Status_Code,
    ord_prc_procurementorder_statuses.GlobalPropertyMatchingID,
    ord_prc_procurementorder_headers.ProcurementOrder_Number,
    ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery,
    ord_prc_procurementorder_headers.ProcurementOrder_Date,
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID,
    ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID
  From
    ord_prc_procurementorder_headers Inner Join
    ord_prc_procurementorder_positions
      On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
      ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    Inner Join
    ord_prc_procurementorder_statushistory
      On ord_prc_procurementorder_statushistory.ProcurementOrder_Header_RefID =
      ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    Inner Join
    ord_prc_procurementorder_statuses
      On ord_prc_procurementorder_statushistory.ProcurementOrder_Status_RefID =
      ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID
  Where
    ord_prc_procurementorder_positions.IsDeleted = 0 And
    ord_prc_procurementorder_headers.IsDeleted = 0 And
    ord_prc_procurementorder_statushistory.IsDeleted = 0 And
    ord_prc_procurementorder_statuses.IsDeleted = 0) OrderIn
    On OrderIn.ORD_PRC_ProcurementOrder_PositionID =
    cmn_pro_products.CMN_PRO_ProductID
Where
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID =
  @TreatmentID And
  cmn_pro_products.IsDeleted = 0 And
  cmn_pro_products.Tenant_RefID = @TenantID And
  hec_patient_treatment_requiredproducts.IsDeleted = 0 And
  hec_pharmacies.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  hec_products.IsDeleted = 0
  