
Select
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  OrderIn.Position_RequestedDateOfDelivery,
  OrderIn.Status_Name_DictID,
  OrderIn.Status_Code,
  hec_patient_treatment_requiredproducts.Quantity,
  hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
  OrderIn.ORD_CUO_CustomerOrder_PositionID,
  OrderIn.ORD_CUO_CustomerOrder_StatusID,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
  cmn_bpt_businessparticipants.DisplayName As PharmacyName,
  hec_pharmacies.HEC_PharmacyID,
  hec_patient_treatment_requiredproducts.HEC_Product_RefID,
  hec_products.HEC_ProductID,
  hec_products.Recepie,
  OrderIn.GlobalPropertyMatchingID,
  OrderIn.OrderNumber,
  OrderIn.Creation_Timestamp,
  OrderIn.Current_CustomerOrderStatus_RefID
From
  cmn_pro_products Inner Join
  hec_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_patient_treatment_requiredproducts
    On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
    hec_products.HEC_ProductID Left Join
  (Select
    ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
    ord_cuo_customerorder_positions.Position_RequestedDateOfDelivery,
    ord_cuo_customerorder_statuses.Status_Code,
    ord_cuo_customerorder_statuses.Status_Name_DictID,
    ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID,
    ord_cuo_customerorder_statuses.GlobalPropertyMatchingID,
    ord_cuo_customerorder_headers.CustomerOrder_Number As OrderNumber,
    ord_cuo_customerorder_statushistory.Creation_Timestamp,
    ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID
  From
    ord_cuo_customerorder_positions Inner Join
    ord_cuo_customerorder_headers
      On ord_cuo_customerorder_positions.CustomerOrder_Header_RefID =
      ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID Inner Join
    ord_cuo_customerorder_statushistory
      On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
      ord_cuo_customerorder_statushistory.CustomerOrder_Header_RefID Inner Join
    ord_cuo_customerorder_statuses
      On ord_cuo_customerorder_statushistory.CustomerOrder_Status_RefID =
      ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID
  Where
    ord_cuo_customerorder_positions.Tenant_RefID = @TenantID And
    ord_cuo_customerorder_positions.IsDeleted = 0 And
    ord_cuo_customerorder_headers.IsDeleted = 0 And
    ord_cuo_customerorder_statuses.IsDeleted = 0 And
    ord_cuo_customerorder_statushistory.IsDeleted = 0) OrderIn
    On
    hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID =
    OrderIn.ORD_CUO_CustomerOrder_PositionID Inner Join
  hec_pharmacies
    On hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID =
    hec_pharmacies.HEC_PharmacyID Inner Join
  cmn_com_companyinfo On hec_pharmacies.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID
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
  